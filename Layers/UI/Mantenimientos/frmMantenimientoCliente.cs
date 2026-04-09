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
using UTN.WinForms.ApCars.Enums;
using UTN.WinForms.ApCars.Extensions;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.BLL;
using UTN.WinForms.ApCars.Layers.Entities;
using UTN.WinForms.ApCars.Layers.Entities.DTO;

namespace UTN.WinForms.ApCars.Layers.UI
{
    public partial class frmMantenimientoCliente : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoCliente()
        {
            InitializeComponent();
        }

        private void toolStripBtnBorrar_Click(object sender, EventArgs e)
        {
            BLLCliente bllCliente = new BLLCliente();

            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    this.ChangeState(EstadoMantenimiento.Borrar);

                    Cliente oCliente = this.dgvDatos.SelectedRows[0].DataBoundItem as Cliente;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oCliente.IdCliente} {oCliente.Nombre} {oCliente.Apellido1} {oCliente.Apellido2} ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bllCliente.Delete(oCliente.IdCliente);
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

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            IBLLCliente bllCliente = new BLLCliente();
            erp = new ErrorProvider();
            try
            {
                erp.Clear();
                Cliente oCliente = new Cliente();


                if (this.pbImagen.Tag == null)
                {
                    MessageBox.Show("La Imagen  es un dato requerido !", "Atención");
                    return;
                }

                if (string.IsNullOrEmpty(txtIdCliente.Text))
                {
                    erp.SetError(txtIdCliente, "Dato Requerido");
                    txtIdCliente.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    erp.SetError(txtNombre, "Dato Requerido");
                    txtNombre.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtApellido1.Text))
                {
                    erp.SetError(txtApellido1, "Dato Requerido");
                    txtApellido1.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    erp.SetError(txtEmail, "Dato Requerido");
                    txtEmail.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTelefono.Text))
                {
                    erp.SetError(txtTelefono, "Dato Requerido");
                    txtTelefono.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtDireccion.Text))
                {
                    erp.SetError(txtDireccion, "Dato Requerido");
                    txtDireccion.Focus();
                    return;
                }



                oCliente.IdCliente = this.txtIdCliente.Text;
                oCliente.Nombre = this.txtNombre.Text;
                oCliente.Apellido1 = this.txtApellido1.Text;
                oCliente.Apellido2 = this.txtApellido2.Text;
                oCliente.Correo = this.txtEmail.Text;
                oCliente.Telefono = this.txtTelefono.Text;
                oCliente.Direccion = this.txtDireccion.Text;
                oCliente.Foto = (byte[])this.pbImagen.Tag;
                oCliente.IdProvincia = (cmbProvincia.SelectedItem as Provincia).IdProvincia;
                oCliente.Sexo = rdbFemenino.Checked ? 2 : 1;
                oCliente.TipoCliente = rdbNacional.Checked ? TipoCliente.Nacional : TipoCliente.Extranjero;

                oCliente = await bllCliente.Save(oCliente);


                if (oCliente != null)
                    this.LoadData();

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

        private void frmMantenimientoCliente_Load(object sender, EventArgs e)
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
        /// <summary>
        /// Cambia el estado del proceso
        /// </summary>
        /// <param name="estado">Enum del proceso</param>
        private void ChangeState(EstadoMantenimiento estado)
        {
            erp.Clear();
            this.txtIdCliente.Clear();
            this.txtNombre.Clear();
            this.txtApellido1.Clear();
            this.txtApellido2.Clear();
            this.txtEmail.Clear();
            this.txtIdCliente.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtApellido1.Enabled = false;
            this.txtApellido2.Enabled = false;
            this.txtEmail.Enabled = false;
            this.gpbResidencia.Enabled = false;
            this.rdbFemenino.Enabled = false;
            this.rdbMasculino.Enabled = false;
            this.pbImagen.Enabled = false;

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnBuscarCliente.Enabled = false;
            this.cmbProvincia.Enabled = false;

            // Coloca el primer item por defecto
            if (cmbProvincia.Items.Count > 0)
                this.cmbProvincia.SelectedIndex = 0;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.txtIdCliente.Enabled = true;
                    this.txtNombre.Enabled = true;
                    this.txtApellido1.Enabled = true;
                    this.txtApellido2.Enabled = true;
                    this.txtEmail.Enabled = true;
                    this.cmbProvincia.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnBuscarCliente.Enabled = true;
                    this.gpbResidencia.Enabled = true;
                    this.rdbMasculino.Enabled = true;
                    this.rdbFemenino.Enabled = true;
                    this.pbImagen.Enabled = true;
                    txtIdCliente.Focus();
                    break;
                case EstadoMantenimiento.Editar:
                    this.txtIdCliente.Enabled = false;
                    this.txtNombre.Enabled = true;
                    this.txtApellido1.Enabled = true;
                    this.txtApellido2.Enabled = true;
                    this.txtEmail.Enabled = true;
                    this.cmbProvincia.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.gpbResidencia.Enabled = true;
                    this.rdbMasculino.Enabled = true;
                    this.rdbFemenino.Enabled = true;
                    this.btnBuscarCliente.Enabled = false;
                    this.pbImagen.Enabled = true;
                    txtNombre.Focus();
                    break;
                case EstadoMantenimiento.Borrar:
                    break;
                case EstadoMantenimiento.Ninguno:
                    break;
            }
        }



        private async void LoadData()
        {
            IBLLCliente bllCliente = new BLLCliente();
            IBLLProvincia bllProvincia = new BLLProvincia();
            List<Provincia> lista = null;
            try
            {

                // Cambiar el estado
                this.ChangeState(EstadoMantenimiento.Ninguno);

                // Configuracion del DataGridView para que se vea bien la imagen.
                dgvDatos.AutoGenerateColumns = false;
                // dgvDatos.RowTemplate.Height = 100;
                dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                // Delay forzado
                await Task.Delay(500);

                // Cargar el DataGridView
                this.dgvDatos.DataSource = await bllCliente.GetAll();

                // Cargar el combo
                this.cmbProvincia.Items.Clear();
                lista = bllProvincia.GetAll();
                foreach (Provincia oProvincia in lista)
                {
                    this.cmbProvincia.Items.Add(oProvincia);
                }
                // Colocar el primero como default
                this.cmbProvincia.SelectedIndex = 0;
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

        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            Cliente oCliente = null;
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.ChangeState(EstadoMantenimiento.Editar);
                    oCliente = this.dgvDatos.SelectedRows[0].DataBoundItem as Cliente;
                    this.txtIdCliente.Text = oCliente.IdCliente;
                    this.txtApellido1.Text = oCliente.Apellido1;
                    this.txtApellido2.Text = oCliente.Apellido2;
                    this.txtEmail.Text = oCliente.Correo;
                    this.txtNombre.Text = oCliente.Nombre;
                    this.pbImagen.Tag = oCliente.Foto;
                    this.txtTelefono.Text = oCliente.Telefono;
                    this.rdbNacional.Checked = oCliente.TipoCliente == TipoCliente.Nacional ? true : false;
                    this.rdbNacional.Checked = oCliente.TipoCliente == TipoCliente.Extranjero ? true : false;
                    this.rdbFemenino.Checked = oCliente.Sexo == 2 ? true : false;
                    this.rdbMasculino.Checked = oCliente.Sexo == 1 ? true : false;
                    this.txtDireccion.Text = oCliente.Direccion;

                    cmbProvincia.SelectedIndex = cmbProvincia.FindString(oCliente.IdProvincia.ToString());

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

        private void btnBuscarCliente_Click_1(object sender, EventArgs e)
        {

            IBLLPadron bllPadron = new BLLPadron();
            try
            {
                erp.Clear();

                if (string.IsNullOrEmpty(txtIdCliente.Text))
                {
                    erp.SetError(txtIdCliente, "Id Requerido");
                    txtNombre.Focus();
                    return;
                }

                if (txtIdCliente.Text.Trim().Length != 9)
                {
                    erp.SetError(txtIdCliente, "Largo de la Cédula 9 digitos");
                    txtNombre.Focus();
                    return;
                }


                // ToDo: Cree La validación que solo permita números en la cédula 

                PadronDTO oPadronDTO = bllPadron.GetById(txtIdCliente.Text.Trim());


                string[] array = oPadronDTO.nombre.Split(' ');

                // 1 nombres y dos apellidos
                if (array.Length == 3)
                {
                    txtNombre.Text = array[0];
                    txtApellido1.Text = array[1];
                    txtApellido2.Text = array[2];
                }

                // 2 nombres y dos apellidos
                if (array.Length == 4)
                {
                    txtNombre.Text = array[0] + " " + array[1];
                    txtApellido1.Text = array[2];
                    txtApellido2.Text = array[3];
                }


                // 3 nombres y dos apellidos

                if (array.Length == 5)
                {
                    txtNombre.Text = array[0] + " " + array[1] + " " + array[2];
                    txtApellido1.Text = array[array.Length - 2];
                    txtApellido2.Text = array[array.Length - 1];
                }
                // 4 nombres y dos apellidos
                if (array.Length == 6)
                {
                    txtNombre.Text = array[0] + " " + array[1] + " " + array[2] + " " + array[3];
                    txtApellido1.Text = array[array.Length - 2];
                    txtApellido2.Text = array[array.Length - 1];
                }

                // Ejemplo con varios nombres. 203960070 - ANTONIO MARIA DE LA TRINIDAD RODRIGUEZ CHAVES 
                // 5 nombres y dos apellidos

                if (array.Length == 7)
                {
                    txtNombre.Text = array[0] + " " + array[1] + " " + array[2] + " " + array[3] + " " + array[4];
                    txtApellido1.Text = array[array.Length - 2];
                    txtApellido2.Text = array[array.Length - 1];
                }

            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripBtnSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}

