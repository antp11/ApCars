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
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.BLL;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Layers.UI.Mantenimientos
{
    public partial class frmMantenimientoProvincia : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        public frmMantenimientoProvincia()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                IBLLProvincia bllProvincia = new BLLProvincia();
                Provincia provincia = bllProvincia.GetProvinciaFromInternet(Convert.ToInt16(this.mskIdProvincia.Text));

                if (provincia == null)
                {
                    MessageBox.Show($"Error el código {mskIdProvincia.Text} NO existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.mskIdProvincia.Text = provincia.IdProvincia.ToString();
                this.txtDescripcion.Text = provincia.Descripcion;

            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmMantenimientoProvincia_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LoadData()
        {
            IBLLProvincia bllProvincia = new BLLProvincia();

            try
            {

                // Cambiar el estado
                this.ChangeState(EstadoMantenimiento.Ninguno);

                // Configuracion del DataGridView para que se vea bien la imagen.
                dgvDatos.AutoGenerateColumns = false;
                // dgvDatos.RowTemplate.Height = 100;
                dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


                // Cargar el DataGridView
                this.dgvDatos.DataSource = bllProvincia.GetAll();


            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ChangeState(EstadoMantenimiento estado)
        {
            erp.Clear();
            this.mskIdProvincia.Clear();
            this.txtDescripcion.Clear();

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnBuscar.Enabled = false;

            this.mskIdProvincia.Enabled = false;
            this.txtDescripcion.Enabled = false;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.mskIdProvincia.Enabled = true;
                    this.txtDescripcion.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    mskIdProvincia.Focus();
                    break;
                case EstadoMantenimiento.Editar:
                    this.mskIdProvincia.Enabled = false;
                    this.txtDescripcion.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    txtDescripcion.Focus();
                    break;
                case EstadoMantenimiento.Borrar:
                    break;
                case EstadoMantenimiento.Ninguno:
                    break;
            }
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            this.ChangeState(EstadoMantenimiento.Nuevo);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            IBLLProvincia bllProvincia = new BLLProvincia();
            erp = new ErrorProvider();
            try
            {
                erp.Clear();
                Provincia oProvincia = new Provincia();

                if (string.IsNullOrEmpty(mskIdProvincia.Text))
                {
                    erp.SetError(mskIdProvincia, "Dato Requerido");
                    mskIdProvincia.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    erp.SetError(txtDescripcion, "Dato Requerido");
                    txtDescripcion.Focus();
                    return;
                }


                oProvincia.IdProvincia = Convert.ToInt32(this.mskIdProvincia.Text);
                oProvincia.Descripcion = txtDescripcion.Text.Trim();


                oProvincia = bllProvincia.Save(oProvincia);

                if (oProvincia != null)
                    this.LoadData();


            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            Provincia oProvincia = null;
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.ChangeState(EstadoMantenimiento.Editar);
                    oProvincia = this.dgvDatos.SelectedRows[0].DataBoundItem as Provincia;
                    this.mskIdProvincia.Text = oProvincia.IdProvincia.ToString();
                    this.txtDescripcion.Text = oProvincia.Descripcion;

                }
                else
                {
                    MessageBox.Show("Seleccione el registro !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripBtnBorrar_Click(object sender, EventArgs e)
        {
            BLLProvincia bllProvincia = new BLLProvincia();

            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    this.ChangeState(EstadoMantenimiento.Borrar);

                    Provincia oProvincia = this.dgvDatos.SelectedRows[0].DataBoundItem as Provincia;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oProvincia.IdProvincia} {oProvincia.Descripcion}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bllProvincia.Delete(oProvincia.IdProvincia);
                        this.LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el registro !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
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
