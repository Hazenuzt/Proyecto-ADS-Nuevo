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
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login inicio = new Login();
            this.Hide();
            inicio.Show();
        }

        private void btnSalirE_Click(object sender, EventArgs e)
        {
            Login inicio = new Login();
            this.Hide();
            inicio.Show();
        }

        private void btnSalirB_Click(object sender, EventArgs e)
        {
            Login inicio = new Login();
            this.Hide();
            inicio.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ElimnarUsuario frmDltUser = new ElimnarUsuario();
            this.Close();
            frmDltUser.ShowDialog();
            
        }

        private void btnEliminarCarro_Click(object sender, EventArgs e)
        {
            EliminarVehículo frmDltCar = new EliminarVehículo(); 
            this.Close();
            frmDltCar.ShowDialog();
           
        }
    }
}
