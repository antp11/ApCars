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
using UTN.WinForms.ApCars.Layers.Entities.DTO;

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
                llenarCombos();
                LoadData();

            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void llenarCombos()
        {

            IBLLEstilo bllEstilo;
            IBLLMarca bllMarca;
            IBLLTipoCombustible bllTipoCombustible;
            IBLLTipoTransmision bllTipoTransmision;


            try
            {


                bllEstilo = new BLLEstilo();
                bllMarca = new BLLMarca();
                bllTipoCombustible = new BLLTipoCombustible();
                bllTipoTransmision = new BLLTipoTransmision();

                cmbEstilo.DataSource = bllEstilo.GetAll();
                cmbEstilo.SelectedIndex = 0;
                cmbEstilo.DisplayMember = "Descripcion";
                cmbEstilo.ValueMember = "IdEstilo";

                cmbMarca.DataSource = bllMarca.GetAll();
                cmbMarca.SelectedIndex = 0;
                cmbMarca.DisplayMember = "DescripcionMarca";
                cmbMarca.ValueMember = "IdMarca";


                cmbCombustible.DataSource = bllTipoCombustible.GetAll();
                cmbCombustible.SelectedIndex = 0;
                cmbCombustible.DisplayMember = "DescripcionTipoCombustible";
                cmbCombustible.ValueMember = "IdTipoCombustible";



                cmbTransmision.DataSource = bllTipoTransmision.GetAll();
                cmbTransmision.SelectedIndex = 0;
                cmbTransmision.DisplayMember = "DescripcionTransmision";
                cmbTransmision.ValueMember = "IdTransmision";



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
                    this.pbDocumentacion.Image = Properties.Resources.wordLoad;

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
                oVehiculo.IdMarca = Convert.ToInt16(cmbMarca.SelectedValue);
                oVehiculo.IdEstilo = Convert.ToInt16(cmbEstilo.SelectedValue);
                oVehiculo.DescripcionVehiculo = txtDescripcion.Text;
                oVehiculo.Anno = Convert.ToInt16(mskAnno.Text);
                oVehiculo.CantidadPaasajero = Convert.ToInt16(nudCantidadPasajeros.Value);
                oVehiculo.TipoCombustible = Convert.ToInt16(cmbCombustible.SelectedValue);
                oVehiculo.Color = txtColor.Text;
                oVehiculo.TipoTransmision = Convert.ToInt16(cmbTransmision.SelectedValue);
                oVehiculo.Precio = Convert.ToDouble(mskPrecio.Text);
                oVehiculo.Foto = (byte[])this.pbImagen.Tag;
                oVehiculo.Documento = (byte[])pbDocumentacion.Tag;
                oVehiculo.Extras = txtExtras.Text;
                oVehiculo.Estado = rdbDisponible.Checked ? "Disponible" : "Vendido";





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
                this.dgvDatos.DataSource = bllVehiculo.GetAllDTO();

                this.pbImagen.Image = Properties.Resources.imageInsert;
                this.pbImagen.SizeMode = PictureBoxSizeMode.CenterImage;

                this.pbDocumentacion.Image = Properties.Resources.Word;
                this.pbDocumentacion.SizeMode = PictureBoxSizeMode.CenterImage;



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
            this.cmbCombustible.SelectedIndex = 0;
            this.cmbMarca.SelectedIndex = 0;
            this.cmbEstilo.SelectedIndex = 0;
            this.cmbTransmision.SelectedIndex = 0;
            this.nudCantidadPasajeros.Value = 0;
            this.rdbDisponible.Checked = true;
            this.rdbVendido.Checked = false;


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
            this.rdbDisponible.Enabled = false;
            this.rdbVendido.Enabled = false;

            this.pbDocumentacion.Image = ApCars.Properties.Resources.Word;
            this.pbImagen.Image = ApCars.Properties.Resources.imageInsert;
            this.pbImagen.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pbDocumentacion.SizeMode = PictureBoxSizeMode.CenterImage;

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
                    this.rdbDisponible.Enabled = true;
                    this.rdbVendido.Enabled = true;
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
                    this.rdbDisponible.Enabled = true;
                    this.rdbVendido.Enabled = true;
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
            VehiculoMarcaEstiloDTO oVehiculo = null;
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.ChangeState(EstadoMantenimiento.Editar);
                    oVehiculo = this.dgvDatos.SelectedRows[0].DataBoundItem as VehiculoMarcaEstiloDTO;

                    this.mskVIN.Text = oVehiculo.IdVIN;
                    this.mskPrecio.Text = oVehiculo.Precio.ToString();
                    this.mskAnno.Text = oVehiculo.Anno.ToString();
                    this.txtDescripcion.Text = oVehiculo.DescripcionVehiculo;
                    this.txtColor.Text = oVehiculo.Color;
                    this.txtExtras.Text = oVehiculo.Extras;
                    this.pbImagen.Tag = oVehiculo.Foto;
                    this.pbImagen.Image = new Bitmap(new MemoryStream(oVehiculo.Foto));
                    this.pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pbDocumentacion.Image = ApCars.Properties.Resources.wordLoad;
                    this.pbDocumentacion.Tag = oVehiculo.Documento;
                    this.pbDocumentacion.SizeMode = PictureBoxSizeMode.CenterImage;
                    this.cmbCombustible.SelectedValue = oVehiculo.IdTipoCombustible;
                    this.cmbMarca.SelectedValue = oVehiculo.IdMarca;
                    this.cmbEstilo.SelectedValue = oVehiculo.IdEstilo;
                    this.cmbTransmision.SelectedValue = oVehiculo.IdTransmision;
                    this.nudCantidadPasajeros.Value = oVehiculo.CantidadPaasajero;
                    this.rdbDisponible.Checked = oVehiculo.Estado == "Disponible" ? true : false;
                    this.rdbVendido.Checked = oVehiculo.Estado == "Vendido" ? true : false;


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

                    VehiculoMarcaEstiloDTO oVehiculo = this.dgvDatos.SelectedRows[0].DataBoundItem as VehiculoMarcaEstiloDTO;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ChangeState(EstadoMantenimiento.Ninguno);
        }
    }
}
