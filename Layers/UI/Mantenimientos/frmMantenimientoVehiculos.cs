using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.Electronics.Interfaces;
using UTN.WinForms.ApCars.Enums;
using UTN.WinForms.ApCars.Extensions;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.BLL;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Layers.UI
{
    public partial class frmMantenimientoVehiculos : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        public frmMantenimientoVehiculos()
        {
            InitializeComponent();
        }

        private void frmMantenimientoVehiculos_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                llenarCombos();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            llenarCombos();

        }

        private void llenarCombos()
        {

            IBLLEstilo bllEstilo;
            IBLLMarca bllMarca;

            ;
            try
            {


                bllEstilo = new BLLEstilo();
                bllMarca = new BLLMarca();

                cmbEstilo.DataSource = bllEstilo.GetAll();
                cmbEstilo.SelectedIndex = 0;
                cmbEstilo.DisplayMember = "Descripcion";
                cmbEstilo.ValueMember = "IdEstilo";

                cmbMarca.DataSource = bllMarca.GetAll();
                cmbMarca.SelectedIndex = 0;
                cmbMarca.DisplayMember = "DescripcionMarca";
                cmbMarca.ValueMember = "IdMarca";

                cmbCombustible.DataSource = Enum.GetValues(typeof(TipoCombustible));
                cmbCombustible.SelectedIndex = 0;

                cmbTransmision.DataSource = Enum.GetValues(typeof(TipoTransmision));



            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pbImagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opt = new OpenFileDialog();
                opt.Title = "Seleccione la Imagen ";
                opt.SupportMultiDottedExtensions = true;
                opt.DefaultExt = "*.All files";
                opt.Filter = "Archivos de Imagenes (*.jpg)|*.jpg| All files (*.*)|*.*";
                opt.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                opt.FileName = "";

                if (opt.ShowDialog(this) == DialogResult.OK)
                {

                    //ruta = opt.FileName.Trim();
                    this.pbImagen.ImageLocation = opt.FileName;
                    pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

                    byte[] cadenaBytes = File.ReadAllBytes(opt.FileName);

                    // Guarla la imagenen Bytes en el Tag de la imagen.
                    pbImagen.Tag = (byte[])cadenaBytes;

                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pbDocumentacion_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opt = new OpenFileDialog();
                opt.Title = "Seleccione el Documento ";
                opt.SupportMultiDottedExtensions = true;
                opt.DefaultExt = "*.docx";
                opt.Filter = "Archivos de Documentos (*.docx)|*.docx| All files (*.*)|*.*";
                opt.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                opt.FileName = "";

                if (opt.ShowDialog(this) == DialogResult.OK)
                {

                    // Leer todo el archivo de bytes
                    byte[] cadenaBytes = File.ReadAllBytes(opt.FileName);
                    this.pbDocumentacion.Tag = cadenaBytes;
                    this.pbDocumentacion.Image = Properties.Resources.MSWordAcepted;

                }

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
            IBLLVehiculo bllVehiculo = new BLLVehiculo();
            epError = new ErrorProvider();
            try
            {
                epError.Clear();
                Vehiculo oVehiculo = new Vehiculo();
                //Validación de VIN
                if (string.IsNullOrEmpty(mskVIN.Text))
                {
                    epError.SetError(mskVIN, "Dato Requerido");
                    mskVIN.Focus();
                    return;
                }

                //Validación de descripción
                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    epError.SetError(txtDescripcion, "Dato Requerido");
                    txtDescripcion.Focus();
                    return;
                }
                // VALIDACION DE AÑO
                if (string.IsNullOrEmpty(mskAnno.Text))
                {
                    epError.SetError(txtDescripcion, "Dato Requerido");
                    mskAnno.Focus();
                    return;
                }
                //VALIDACION DE COLOR
                if (string.IsNullOrEmpty(txtColor.Text))
                {
                    epError.SetError(txtColor, "Dato Requerido");
                    txtColor.Focus();
                    return;
                }
                //Validación de Imagen
                if (this.pbImagen.Tag == null)
                {
                    MessageBox.Show("La Imagen  es un dato requerido !", "Atención");
                    return;
                }

                //Validación de Documetación
                if (this.pbDocumentacion.Tag == null)
                {
                    MessageBox.Show("La Imagen  es un dato requerido !", "Atención");
                    return;
                }
                //Validación de cantidad de pasajeros
                if (nudCantidadPasajeros.Value == 0)
                {
                    MessageBox.Show("Dato Requerido!", "Atención");
                    return;
                }

                //Validación de precio
                if (string.IsNullOrEmpty(mskPrecio.Text))
                {
                    epError.SetError(mskPrecio, "Dato Requerido");
                    mskPrecio.Focus();
                    return;
                }
                //Validación de extras
                if (string.IsNullOrEmpty(txtExtras.Text))
                {
                    epError.SetError(txtExtras, "Dato Requerido");
                    mskPrecio.Focus();
                    return;
                }

                oVehiculo.IdVIN = mskVIN.Text;
                oVehiculo.IdMarca = Convert.ToInt32(cmbMarca.SelectedValue);
                oVehiculo.IdEstilo = Convert.ToInt32(cmbEstilo.SelectedValue);
                oVehiculo.DescripcionVehiculo = txtDescripcion.Text;
                oVehiculo.Anno = Convert.ToInt32(mskAnno.Text);
                oVehiculo.CantidadPaasajero = Convert.ToInt32(nudCantidadPasajeros.Value);
                oVehiculo.TipoCombustible = (TipoCombustible)cmbCombustible.SelectedItem;
                oVehiculo.Color = txtColor.Text;
                oVehiculo.TipoTransmision = (TipoTransmision)cmbTransmision.SelectedItem;
                oVehiculo.Precio = Convert.ToDouble(mskPrecio.Text);
                oVehiculo.Foto = (byte[])this.pbImagen.Tag;
                oVehiculo.Documento = (byte[])pbDocumentacion.Tag;
                oVehiculo.Extras = txtExtras.Text;





                oVehiculo = bllVehiculo.Save(oVehiculo);

                if (oVehiculo != null)
                    this.LoadData();


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
            IBLLVehiculo bllVehiculo = new BLLVehiculo();

            try
            {

                // Cambiar el estado
                this.ChangeState(EstadoMantenimiento.Ninguno);

                // Configuracion del DataGridView para que se vea bien la imagen.
                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.RowTemplate.Height = 100;
                dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


                // Cargar el DataGridView
                this.dgvDatos.DataSource = bllVehiculo.GetAll();

                this.pbImagen.Image = Properties.Resources.insert_image;
                this.pbImagen.SizeMode = PictureBoxSizeMode.CenterImage;


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
            epError.Clear();
            this.mskVIN.Clear();
            this.mskPrecio.Clear();
            this.mskAnno.Clear();
            this.txtDescripcion.Clear();
            this.txtColor.Clear();
            this.txtExtras.Clear();
            this.pbImagen.Tag = null;
            this.pbDocumentacion.Tag = null;
            //this.cmbCombustible.SelectedIndex =0;
            //this.cmbMarca.SelectedIndex = 0;
            //this.cmbEstilo.SelectedIndex = 0;
            //this.cmbTransmision.SelectedIndex = 0;
            this.nudCantidadPasajeros.Value = 0;

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.mskVIN.Enabled = false;
            this.mskPrecio.Enabled = false;
            this.mskAnno.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtColor.Enabled = false;
            this.txtExtras.Enabled = false;
            this.pbImagen.Enabled = false;
            this.pbDocumentacion.Enabled = false;
            this.cmbCombustible.Enabled = false;
            this.cmbMarca.Enabled = false;
            this.cmbEstilo.Enabled = false;
            this.cmbTransmision.Enabled = false;
            this.nudCantidadPasajeros.Enabled = false;


            this.pbImagen.SizeMode = PictureBoxSizeMode.CenterImage;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.mskVIN.Enabled = true;
                    this.mskPrecio.Enabled = true;
                    this.mskAnno.Enabled = true;
                    this.txtDescripcion.Enabled = true;
                    this.txtColor.Enabled = true;
                    this.txtExtras.Enabled = true;
                    this.pbImagen.Enabled = true;
                    this.pbDocumentacion.Enabled = true;
                    this.cmbCombustible.Enabled = true;
                    this.cmbMarca.Enabled = true;
                    this.cmbEstilo.Enabled = true;
                    this.cmbTransmision.Enabled = true;
                    this.nudCantidadPasajeros.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    mskVIN.Focus();
                    break;
                case EstadoMantenimiento.Editar:
                    this.mskVIN.Enabled = false;
                    this.mskPrecio.Enabled = true;
                    this.mskAnno.Enabled = true;
                    this.txtDescripcion.Enabled = true;
                    this.txtColor.Enabled = true;
                    this.txtExtras.Enabled = true;
                    this.pbImagen.Enabled = true;
                    this.pbDocumentacion.Enabled = true;
                    this.cmbCombustible.Enabled = true;
                    this.cmbMarca.Enabled = true;
                    this.cmbEstilo.Enabled = true;
                    this.cmbTransmision.Enabled = true;
                    this.nudCantidadPasajeros.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtDescripcion.Focus();
                    break;
                case EstadoMantenimiento.Borrar:
                    break;
                case EstadoMantenimiento.Ninguno:
                    break;
            }
        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            this.ChangeState(EstadoMantenimiento.Nuevo);
        }

        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            Vehiculo oVehiculo = null;
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.ChangeState(EstadoMantenimiento.Editar);
                    oVehiculo = this.dgvDatos.SelectedRows[0].DataBoundItem as Vehiculo;

                    this.mskVIN.Text = oVehiculo.IdVIN;
                    this.mskPrecio.Text = oVehiculo.IdMarca.ToString();
                    this.mskAnno.Text = oVehiculo.Anno.ToString();
                    this.txtDescripcion.Text = oVehiculo.DescripcionVehiculo;
                    this.txtColor.Text = oVehiculo.Color;
                    this.txtExtras.Text = oVehiculo.Extras;
                    this.pbImagen.Tag = oVehiculo.Foto;
                    this.pbDocumentacion.Tag = oVehiculo.Documento;
                    this.cmbCombustible.SelectedItem = oVehiculo.CantidadPaasajero;
                    this.cmbMarca.SelectedIndex = oVehiculo.IdMarca;
                    this.cmbEstilo.SelectedIndex = oVehiculo.IdEstilo;
                    this.cmbTransmision.SelectedItem = oVehiculo.TipoTransmision;
                    this.nudCantidadPasajeros.Value = oVehiculo.CantidadPaasajero;


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
            IBLLVehiculo bllVehiculo = new BLLVehiculo();

            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    this.ChangeState(EstadoMantenimiento.Borrar);

                    Vehiculo oVehiculo = this.dgvDatos.SelectedRows[0].DataBoundItem as Vehiculo;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oVehiculo.IdVIN} {oVehiculo.DescripcionVehiculo.Trim()}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bllVehiculo.Delete(oVehiculo.IdVIN);
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

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
