using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.WinForms.ApCars.Extensions;
using UTN.WinForms.ApCars.Layers.UI;
using UTN.WinForms.ApCars.Layers.UI.Mantenimientos;
using UTN.WinForms.ApCars.Layers.UI.Procesos;
using UTN.WinForms.ApCars.Layers.UI.Seguridad;
using UTN.WinForms.ApCars.Properties;

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

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void impuestoToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {

                Utils.CultureInfo();
                this.Text = ConfigurationManager.AppSettings["NombreEmpresa"] + " " + Application.ProductName + " Versión:  " + Application.ProductVersion;

                toolStripStatusLblMensaje.Text = "Usuario Conectado: " + Settings.Default.Login + "/" + Settings.Default.Nombre;

                if (!Directory.Exists(@"C:\temp"))
                    Directory.CreateDirectory(@"C:\temp");

                _myLogControlEventos.InfoFormat("Conectado a Form Principal");



                // Activar Seguridad
                Seguridad();

            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Metodo que habilita y deshabilita opciones del MENU
        /// </summary>
        private void Seguridad()
        {
            List<string> menus = new List<string>();

            // Se deshabilita TODO primero
            foreach (ToolStripItem opcionMenu in this.mspMenuPrincipal.Items) //para cada opción de la barra de menú
            {
                // deshabita todos !
                ((ToolStripItem)(opcionMenu)).Enabled = false;
            }

            // Tabla Rol
            // IdRol DescripcionRol
            // 1   Administrador
            // 2   Vendedor
            // 3   Reportes
            // Siempre permitir el MENU Acercade  
            menus.Add("toolStripMenuItemAcercaDe");

            // Admin
            if (Settings.Default.RolId.Equals("1"))
            {
                menus.Add("toolStripMenuItemMantenimientos");
                menus.Add("toolStripMenuItemProcesos");
                menus.Add("reportesToolStripMenuItemReportes");
                menus.Add("administracionToolStripMenuItem");
            }

            // Vendedor
            if (Settings.Default.RolId.Equals("2"))
            {
                menus.Add("toolStripMenuItemMantenimientos");
                menus.Add("toolStripMenuItemProcesos");
            }

            // Reportes
            if (Settings.Default.RolId.Equals("3"))
            {
                menus.Add("reportesToolStripMenuItemReportes");
            }


            foreach (ToolStripItem opcionMenu in this.mspMenuPrincipal.Items) //para cada opción de la barra de menú
            {
                if (opcionMenu is ToolStripDropDownButton)
                {
                    foreach (ToolStripMenuItem oToolStripMenuItem in ((ToolStripDropDownButton)opcionMenu).DropDownItems)
                    {
                        oToolStripMenuItem.Enabled = menus.Exists(p => p.Equals(oToolStripMenuItem.Name, StringComparison.InvariantCultureIgnoreCase));
                    }
                }
                // Habilita solo las opciones que se encuentrna en la lista "menu"
                opcionMenu.Enabled = menus.Exists(p => p.Equals(opcionMenu.Name, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        private void vehiculosToolStripMenuItemProductos_Click(object sender, EventArgs e)
        {
            frmMantenimientoVehiculos oForm;
            try
            {
                oForm = new frmMantenimientoVehiculos();
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

        private void provinciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoProvincia oForm;
            try
            {
                oForm = new frmMantenimientoProvincia();
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

        private void clientesToolStripMenuItemCliente_Click(object sender, EventArgs e)
        {
            frmMantenimientoCliente oForm;
            try
            {
                oForm = new frmMantenimientoCliente();
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

        private void facturarToolStripMenuItemFacturar_Click(object sender, EventArgs e)
        {
            frmFacturacion oForm;
            try
            {
                oForm = new frmFacturacion();
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
