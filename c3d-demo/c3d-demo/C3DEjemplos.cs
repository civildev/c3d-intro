using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

using Autodesk.Civil.ApplicationServices;
using Autodesk.Civil.DatabaseServices;

[assembly: CommandClass(typeof(c3d_demo.C3DEjemplos))]

namespace c3d_demo
{
    public class C3DEjemplos
    {
        [CommandMethod("MostrarAlineaciones")]
        public void MostrarAlineaciones()
        {
            ObjectIdCollection alineaciones = CivilApplication.ActiveDocument.GetAlignmentIds();
            Database db = HostApplicationServices.WorkingDatabase;
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                foreach(ObjectId alineacionId in alineaciones)
                {
                    Alignment alineacion = alineacionId.GetObject(OpenMode.ForRead) as Alignment;
                    escribir("Alineacion: " + alineacion.Name);
                }
            }
        }


        private void escribir(string msg)
        {
            _editor.WriteMessage("\n" + msg);
        }

        private Editor _editor
        {
            get
            {
                if (m_Editor == null)
                {
                    m_Editor = Application.DocumentManager.MdiActiveDocument.Editor;
                    
                }

                return m_Editor;
            }
        }

        private Editor m_Editor = null;
    }
}
