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
    public partial class frmImpuesto : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmImpuesto()
        {
            InitializeComponent();
        }
        private void ChangeState(EstadoMantenimiento estado)
        {
            epError.Clear();
            this.mskPorcentaje.Clear();
            this.dtpFecha.CustomFormat = " ";


            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.mskPorcentaje.Enabled = false;
            this.dtpFecha.Enabled = false;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.mskPorcentaje.Enabled = true;
                    this.dtpFecha.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    dtpFecha.Focus();
                    break;
                case EstadoMantenimiento.Editar:
                    this.mskPorcentaje.Enabled = true;
                    this.dtpFecha.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    mskPorcentaje.Focus();
                    break;
                case EstadoMantenimiento.Borrar:
                    break;
                case EstadoMantenimiento.Ninguno:
                    break;
            }
        }
        private void LoadData()
        {
            IBLLImpuesto bllImpuesto = new BLLImpuesto();

            try
            {

                // Cambiar el estado
                this.ChangeState(EstadoMantenimiento.Ninguno);

                // Configuracion del DataGridView para que se vea bien la imagen.
                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.RowTemplate.Height = 100;
                dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


                // Cargar el DataGridView
                this.dgvDatos.DataSource = bllImpuesto.GetAll();




            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            this.ChangeState(EstadoMantenimiento.Nuevo);
        }

        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {

            Impuesto oImpuesto = null;
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.ChangeState(EstadoMantenimiento.Editar);
                    oImpuesto = this.dgvDatos.SelectedRows[0].DataBoundItem as Impuesto;
                    this.mskPorcentaje.Text = oImpuesto.Porcentaje.ToString();
                    this.dtpFecha.Text = oImpuesto.IdFecha.ToString();



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
            BLLImpuesto bLLImpuesto = new BLLImpuesto();

            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    this.ChangeState(EstadoMantenimiento.Borrar);

                    Impuesto oImpuesto = this.dgvDatos.SelectedRows[0].DataBoundItem as Impuesto;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oImpuesto.IdFecha} {oImpuesto.Porcentaje}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bLLImpuesto.Delete(oImpuesto.IdFecha);
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

        private void frmImpuesto_Load(object sender, EventArgs e)
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            IBLLImpuesto BLLiMPUESTO = new BLLImpuesto();
            epError = new ErrorProvider();
            try
            {
                epError.Clear();
                Impuesto oImpuesto = new Impuesto();

                if (string.IsNullOrEmpty(mskPorcentaje.Text))
                {
                    epError.SetError(mskPorcentaje, "Dato Requerido");
                    mskPorcentaje.Focus();
                    return;
                }

                if (dtpFecha == null)
                {
                    epError.SetError(dtpFecha, "Dato Requerido");
                    dtpFecha.Focus();
                    return;
                }




                oImpuesto.IdFecha = Convert.ToDateTime(this.dtpFecha.Text);
                oImpuesto.Porcentaje = Convert.ToDouble(this.mskPorcentaje.Text);



                oImpuesto = BLLiMPUESTO.Save(oImpuesto);

                if (oImpuesto != null)
                    this.LoadData();


            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
