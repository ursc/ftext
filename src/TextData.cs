using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;

namespace ftext
{
    public class TextData
    {
        public DBObject DBObject;
        public Layout Layout;
        public int RowIndex;
        public int ColumnIndex;
        public string Text;
    }
}
