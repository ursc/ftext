using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

using DB = Autodesk.AutoCAD.DatabaseServices;
using ACAD = Autodesk.AutoCAD.ApplicationServices;

namespace ftext
{
    public partial class Form1 : Form
    {
        private TextFinder textFinder;
        private MyData myData;

        public Form1(ACAD.Document doc)
        {
            InitializeComponent();

            textFinder = new TextFinder(doc);

            myData = MyData.LoadMyData("ftext.bin");
            scaleTrackBar.Value = myData.scale;
            foreach (var find in myData.finds) {
                historyDataGridView.Rows.Add(find);
            }
        }

        private void insertHistory(string find)
        {
            var index = myData.finds.IndexOf(find);
            if (index == -1) {
                myData.finds.Insert(0, find);
                historyDataGridView.Rows.Insert(0, find);
            } else if (index > 0) {
                myData.finds.RemoveAt(index);
                myData.finds.Insert(0, find);
                historyDataGridView.Rows.RemoveAt(index);
                historyDataGridView.Rows.Insert(0, find);
            }
            historyDataGridView.Rows[0].Selected = true;
        }

        private void zoomTo()
        {
            var rows = foundDataGridView.SelectedRows;
            if (rows != null && rows.Count == 1) {
                errorLabel.Visible = textFinder.ZoomTo(rows[0].Index, scaleTrackBar.Value);
            }
        }

        private void find()
        {
            foundDataGridView.Rows.Clear();

            var find = findTextBox.Text;

            insertHistory(find);

            textFinder.Search(find, rxCheckBox.Checked, caseCheckBox.Checked);

            string t;
            foreach (var data in textFinder.Found) {
                if (data.DBObject is DB.Table) {
                    t = "Table[" + data.RowIndex.ToString() + "," + data.ColumnIndex.ToString() + "]";
                } else if (data.DBObject is DB.MText) {
                    t = "MText";
                } else if (data.DBObject is DB.DBText) {
                    t = "DBText";
                } else {
                    t = "";
                }
                foundDataGridView.Rows.Add(data.Layout.LayoutName, t, data.Text);
            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            find();
        }

        private void foundDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            zoomTo();
        }

        private void scaleTrackBar_ValueChanged(object sender, EventArgs e)
        {
            zoomTo();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myData.scale = scaleTrackBar.Value;
            myData.Save();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                Close();
            }
        }

        private void findTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                find();
            }
        }

        private void historyDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            myData.finds.RemoveAt(e.Row.Index);
        }

        private void historyDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (historyDataGridView.SelectedRows.Count == 1) {
                var index = historyDataGridView.SelectedRows[0].Index;
                findTextBox.RemoveWatermak();
                findTextBox.Text = myData.finds[index];
            }
        }
    }
}
