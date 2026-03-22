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
using UTN.WinForms.ApCars.Extensions;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.BLL;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Layers.UI.Mantenimientos
{
    public partial class frmMarca : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmMarca()
        {
            InitializeComponent();
        }


        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            this.ChangeState(EstadoMantenimiento.Nuevo);
        }

        private void LoadData()
        {
            IBLLMarca bllMarca = new BLLMarca();

            try
            {

                // Cambiar el estado
                this.ChangeState(EstadoMantenimiento.Ninguno);

                // Configuracion del DataGridView para que se vea bien la imagen.
                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.RowTemplate.Height = 100;
                dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


                // Cargar el DataGridView
                this.dgvDatos.DataSource = bllMarca.GetAll();

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
            this.mskIdMarca.Clear();
            this.txtMarca.Clear();
            this.pbImagen.Tag = null;

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.mskIdMarca.Enabled = false;
            this.txtMarca.Enabled = false;


            this.pbImagen.Enabled = false;


            this.pbImagen.SizeMode = PictureBoxSizeMode.CenterImage;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.mskIdMarca.Enabled = true;
                    this.txtMarca.Enabled = true;
                    this.pbImagen.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    mskIdMarca.Focus();
                    break;
                case EstadoMantenimiento.Editar:
                    this.mskIdMarca.Enabled = true;
                    this.txtMarca.Enabled = true;
                    this.pbImagen.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtMarca.Focus();
                    break;
                case EstadoMantenimiento.Borrar:
                    break;
                case EstadoMantenimiento.Ninguno:
                    break;
            }
        }

        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            Marca oMarca = null;
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.ChangeState(EstadoMantenimiento.Editar);
                    oMarca = this.dgvDatos.SelectedRows[0].DataBoundItem as Marca;
                    this.mskIdMarca.Text = oMarca.IdMarca.ToString();
                    this.txtMarca.Text = oMarca.DescripcionMarca;
                    this.pbImagen.Tag = oMarca.Logo;


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

        private void frmMarca_Load(object sender, EventArgs e)
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

        private void pbImagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opt = new OpenFileDialog();
                opt.Title = "Seleccione la Imagen ";
                opt.SupportMultiDottedExtensions = true;
                opt.DefaultExt = "*.jpg";
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

        private void toolStripBtnBorrar_Click(object sender, EventArgs e)
        {

            IBLLMarca bllMarca = new BLLMarca();

            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    this.ChangeState(EstadoMantenimiento.Borrar);

                    Marca oMarca = this.dgvDatos.SelectedRows[0].DataBoundItem as Marca;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oMarca.IdMarca} {oMarca.DescripcionMarca.Trim()}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bllMarca.Delete(oMarca.IdMarca);
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            IBLLMarca bllBodega = new BLLMarca();
            epError = new ErrorProvider();
            try
            {
                epError.Clear();
                Marca oMarca = new Marca();

                if (string.IsNullOrEmpty(mskIdMarca.Text))
                {
                    epError.SetError(mskIdMarca, "Dato Requerido");
                    mskIdMarca.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtMarca.Text))
                {
                    epError.SetError(txtMarca, "Dato Requerido");
                    txtMarca.Focus();
                    return;
                }

                if (this.pbImagen.Tag == null)
                {
                    MessageBox.Show("La Imagen  es un dato requerido !", "Atención");
                    return;
                }


                oMarca.IdMarca = Convert.ToInt32(this.mskIdMarca.Text);
                oMarca.DescripcionMarca = txtMarca.Text.Trim();
                oMarca.Logo = (byte[])this.pbImagen.Tag;

                oMarca = bllBodega.Save(oMarca);

                if (oMarca != null)
                    this.LoadData();


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
