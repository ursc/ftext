using System;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;

namespace ftext
{
    public class Addin : Autodesk.AutoCAD.Runtime.IExtensionApplication
    {
        public void Terminate()
        {
        }
        public void Initialize()
        {
        }

        [CommandMethod("ft")]
        public void ft()
        {
            var acDoc = Application.DocumentManager.MdiActiveDocument;
            if (acDoc != null) {
                var form = new Form1(acDoc);
                form.ShowDialog();
            }
        }
    }
}
