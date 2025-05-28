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
    
    public partial class VehiculoSeleccionado: Form
    {
        private MarcaSeleccionada MarcaSeleccionada;

        public VehiculoSeleccionado(string valorcito, MarcaSeleccionada marca)
        {
            
            InitializeComponent();
            label1.Text = valorcito;
            this.MarcaSeleccionada = marca;
            pcb_logo.Image = Properties.Resources.Logo;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
           
            this.Close();
            MarcaSeleccionada.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void VehiculoSeleccionado_Load(object sender, EventArgs e)
        {

        }
    }
}
