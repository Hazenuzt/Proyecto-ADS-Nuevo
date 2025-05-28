using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Distribuidora_de_caroos
{
    using System;
    using System.Windows.Forms;

    public partial class InicioUsuario : Form
    {
        public static string seleccion;

        public InicioUsuario()
        {
            InitializeComponent();

            pcb_logo.Image = Properties.Resources.Logo;

            // Agregar marcas al ComboBox
            cmbSeleccionMarcas.Items.Add("Toyota");
            cmbSeleccionMarcas.Items.Add("Honda");
            cmbSeleccionMarcas.Items.Add("Nissan");
            cmbSeleccionMarcas.Items.Add("Mitsubishi");
            cmbSeleccionMarcas.Items.Add("Subaru");

            // Evento para cambiar imagen cuando se seleccione una marca
            cmbSeleccionMarcas.SelectedIndexChanged += cmbSeleccionMarcas_SelectedIndexChanged;
        }

        public string Seleccion
        {
            get => seleccion;
            set => seleccion = value;
        }

        // Método para actualizar la imagen según la marca seleccionada
        private void cmbSeleccionMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeleccionMarcas.SelectedIndex >= 0)
            {
                CambiarImagen(cmbSeleccionMarcas.SelectedItem.ToString());
                seleccion = cmbSeleccionMarcas.SelectedItem.ToString(); // Guardar la selección
            }
        }

        // Método que cambia la imagen según la marca
        private void CambiarImagen(string marca)
        {
            switch (marca)
            {
                case "Toyota":
                    picb_marca.Image = Properties.Resources.ToyotaGif;
                    break;
                case "Honda":
                    picb_marca.Image = Properties.Resources.HondaGif;
                    break;
                case "Mitsubishi":
                    picb_marca.Image = Properties.Resources.MitsubishiGif;
                    break;
                case "Nissan":
                    picb_marca.Image = Properties.Resources.NissanGif;
                    break;
                case "Subaru":
                    picb_marca.Image = Properties.Resources.SubaruGif;
                    break;
                default:
                    picb_marca.Image = null;
                    break;
            }
        }

        
       

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form1 loginnn = new Form1();
            this.Hide();
            loginnn.Show();
        }

        

        private void btn_Continuar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(seleccion))
            {
                MarcaSeleccionada seleccionado = new MarcaSeleccionada(this,cmbSeleccionMarcas.Text); // Pasar referencia al formulario actual
                this.Visible = false; // Ocultar sin cerrar
                seleccionado.ShowDialog();
                this.Visible = true; // Mostrar de nuevo cuando se cierre MarcaSeleccionada
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una marca antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }


}
