using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using Forms = System.Windows.Forms;

using DB = Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.PlottingServices;
using Autodesk.AutoCAD.ApplicationServices;

namespace ftext
{
    public class TextFinder
    {
        protected readonly Document doc;

        public string Find;
        public List<TextData> Found;
        
        private bool IsRegex;
        private bool IgnoreCase;

        private Regex rxFind;
        private StringComparison comp;

        public TextFinder(Document doc)
        {
            this.doc = doc;
            Found = new List<TextData>();
        }

        public bool isMatch(string s)
        {
            if (IsRegex) {
                return rxFind.IsMatch(s);
            }
            return s.IndexOf(Find, comp) >= 0;
        }

        public void Search(string find, bool isRegex, bool ignoreCase)
        {
            Find = find;
            IsRegex = isRegex;
            IgnoreCase = ignoreCase;
            Found.Clear();

            RegexOptions option;
            if (IgnoreCase) {
                comp = StringComparison.OrdinalIgnoreCase;
                option = RegexOptions.Compiled | RegexOptions.IgnoreCase;
            } else {
                comp = StringComparison.Ordinal;
                option = RegexOptions.Compiled;
            }
            rxFind = new Regex(Find, option);

            Search();
        }

        private void Search()
        {
            var acDoc = Application.DocumentManager.MdiActiveDocument;
            if (acDoc != null) {
                using (DocumentLock dlock = acDoc.LockDocument()) {

                    var acCurDb = acDoc.Database;
                    using (var tr = acCurDb.TransactionManager.StartTransaction()) {
                        var bt = (DB.BlockTable)tr.GetObject(acCurDb.BlockTableId, DB.OpenMode.ForRead, false);
                        foreach (DB.ObjectId objId in bt) {
                            DB.BlockTableRecord btr = tr.GetObject(objId, DB.OpenMode.ForRead, false) as DB.BlockTableRecord;
                            if (btr != null) {
                                if (btr.IsLayout) {
                                    var layout = (DB.Layout)tr.GetObject(btr.LayoutId, DB.OpenMode.ForRead);
                                    foreach (DB.ObjectId objId2 in btr) {
                                        processObjectId(tr, layout, objId2);
                                    }
                                }
                            }
                        }
                        tr.Abort();
                    }
                }
            }
        }

        public void processObjectId(DB.Transaction tr, DB.Layout layout, DB.ObjectId objId)
        {
            var ent = tr.GetObject(objId, DB.OpenMode.ForWrite, false);

            if (ent is DB.Table) {
                var tbl = ent as DB.Table;

                if (tbl.NumRows > 0 && tbl.NumColumns > 0) {
                    for (var r = 0; r < tbl.NumRows; r++) {
                        for (var c = 0; c < tbl.NumColumns; c++) {
                            var s = tbl.GetTextString(r, c, 0, DB.FormatOption.IgnoreMtextFormat);
                            if (isMatch(s)) {
                                var t = new TextData {
                                    Layout = layout,
                                    DBObject = ent,
                                    RowIndex = r,
                                    ColumnIndex = c,
                                    Text = s
                                };
                                Found.Add(t);
                            }
                        }
                    }
                }
            } else if (ent is DB.MText) {
                var text = ent as DB.MText;
                if (isMatch(text.Contents)) {
                    var t = new TextData {
                        Layout = layout,
                        DBObject = ent,
                        Text = text.Contents
                    };
                    Found.Add(t);
                }
            } else if (ent is DB.DBText) {
                var text = ent as DB.DBText;
                if (isMatch(text.TextString)) {
                    var t = new TextData {
                        Layout = layout,
                        DBObject = ent,
                        Text = text.TextString
                    };
                    Found.Add(t);
                }
            } else if (ent is DB.BlockReference) {
                var br = ent as DB.BlockReference;
                var brId = br.IsDynamicBlock ? br.DynamicBlockTableRecord : br.BlockTableRecord;
                var btr = (DB.BlockTableRecord)tr.GetObject(brId, DB.OpenMode.ForRead, false);
                foreach (DB.ObjectId objId2 in btr) {
                    processObjectId(tr, layout, objId2);
                }
            }
        }

        public bool ZoomTo(int row, int scale)
        {
            var layout = Found[row].Layout;
            var entity = Found[row].DBObject as DB.Entity;

            using (var tr = doc.Database.TransactionManager.StartTransaction()) {
                if (DB.LayoutManager.Current.CurrentLayout != layout.LayoutName) {
                    DB.LayoutManager.Current.CurrentLayout = layout.LayoutName;
                }

                var vp = tr.GetObject(doc.Editor.CurrentViewportObjectId, DB.OpenMode.ForRead, false) as DB.Viewport;
                if (vp == null || vp.Number != 1) {
                    tr.Commit();
                    return true;
                }

                var width = entity.GeometricExtents.MaxPoint.X - entity.GeometricExtents.MinPoint.X;
                var height = entity.GeometricExtents.MaxPoint.Y - entity.GeometricExtents.MinPoint.Y;

                Point3d pos;
                if (entity is DB.Table) {
                    var tbl = entity as DB.Table;

                    double minX, minY, maxX, maxY;

                    var pts = new Point3dCollection();
                    tbl.GetCellExtents(Found[row].RowIndex, Found[row].ColumnIndex, true, pts);
                    if (pts.Count == 4) {
                        minX = maxX = pts[0].X;
                        minY = maxY = pts[0].Y;

                        for (int p = 1; p < pts.Count; p++) {
                            if (pts[p].X < minX) minX = pts[p].X;
                            if (pts[p].Y < minY) minY = pts[p].Y;
                            if (pts[p].X > maxX) maxX = pts[p].X;
                            if (pts[p].Y > maxY) maxY = pts[p].Y;
                        }

                        width = maxX - minX;
                        height = maxY - minY;
                    } else {
                        minX = entity.GeometricExtents.MinPoint.X;
                        minY = entity.GeometricExtents.MinPoint.Y;
                    }

                    pos = new Point3d(minX + width / 2, minY + height / 2, 0);
                } else if (entity is DB.MText) {
                    var text = entity as DB.MText;

                    width = text.ActualWidth;
                    height = text.ActualHeight;

                    var p1 = new Point3d(text.ActualWidth, -text.ActualHeight, 0);
                    var v1 = p1.GetAsVector().RotateBy(text.Rotation, Vector3d.ZAxis);
                    pos = text.Location.Add(v1.DivideBy(2.0));
                } else if (entity is DB.DBText) {
                    var text = entity as DB.DBText;

                    var v1 = new Vector3d(width, height, 0);
                    pos = text.Position.Add(v1.DivideBy(2.0));
                }

                using (var acView = doc.Editor.GetCurrentView()) {
                    acView.Width = width * 10 / scale;
                    acView.Height = height * 10 / scale;
                    acView.CenterPoint = new Point2d(pos.X, pos.Y);
                    doc.Editor.SetCurrentView(acView);
                }
                tr.Commit();
            }
            doc.Editor.SetImpliedSelection(new DB.ObjectId[0]);
            doc.Editor.UpdateScreen();

            return false;
        }
    }
}
