using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.WinForms.ApCars.Extensions;
using UTN.WinForms.ApCars.Layers.UI.Mantenimientos;
using UTN.WinForms.ApCars.Layers.UI.Seguridad;

namespace apCars
{
    public partial class frmPrincipal : Form
    {
        private static readonly ILog _myLogControlEventos =
           log4net.LogManager.GetLogger("MyControlEventos");


        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItemUsuarios_Click(object sender, EventArgs e)
        {
            frmSeguridad oForm;
            try
            {
                oForm = new frmSeguridad();
                oForm.MdiParent = this;
                oForm.Show();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bodegasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarca oForm;
            try
            {
                oForm = new frmMarca();
                oForm.MdiParent = this;
                oForm.Show();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImpuesto oForm;
            try
            {
                oForm = new frmImpuesto();
                oForm.MdiParent = this;
                oForm.Show();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
