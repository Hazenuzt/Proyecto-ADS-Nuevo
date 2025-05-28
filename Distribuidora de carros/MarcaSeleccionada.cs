using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distribuidora_de_caroos
{
    public partial class MarcaSeleccionada : Form
    {
        private InicioUsuario form1;



        public MarcaSeleccionada(InicioUsuario form1, string marca)
        {
            InitializeComponent();
            pcx_logo.Image = Properties.Resources.Logo;
            this.form1 = form1;
            label_NombreMarca.Text = marca;
            ImagenLogo(marca);

            cmb_auto.Items.Add("Toyota Hillux");
            cmb_auto.Items.Add("Toyota Tacoma");
            cmb_auto.Items.Add("Toyota Corolla");

            

        }

        private void ImagenLogo(string marca)
        {
            switch (marca)
            {
                case "Toyota":
                    pcb_logo.Image = Properties.Resources.toyotaLogo;
                    break;
                case "Honda":
                    pcb_logo.Image = Properties.Resources.hondaLogo;
                    break;
                case "Mitsubishi":
                    pcb_logo.Image = Properties.Resources.mitsubishiLogo;
                    break;
                default:
                    pcb_logo.Image = null;
                    break;
            }
        }

        private void CambiarImagen(string marca)
        {
            switch (marca)
            {
                case "Toyota Hillux":
                    pcb_auto.Image = Properties.Resources.Hillux;
                    break;
                case "Toyota Tacoma":
                    pcb_auto.Image = Properties.Resources.Tacoma;
                    break;
                case "Toyota Corolla":
                    pcb_auto.Image = Properties.Resources.Corolla;
                    break;
                default:
                    pcb_auto.Image = null;
                    break;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            //InicioUsuario form1 = new InicioUsuario();
            
            form1.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {


            try
            {
                if (cmb_auto == null)
                {
                    MessageBox.Show("Error: El ComboBox no está inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el valor seleccionado de forma segura
                string valor = cmb_auto.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(valor))
                {
                    MessageBox.Show("Seleccione un valor antes de continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear solo una instancia de VehiculoSeleccionado y pasar la referencia correcta
                VehiculoSeleccionado seleccion = new VehiculoSeleccionado(valor, this);
                this.Hide(); 
                seleccion.ShowDialog(); 
                this.Show(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

        private void cmb_auto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarImagen(cmb_auto.SelectedItem?.ToString());
        }
    }
}
