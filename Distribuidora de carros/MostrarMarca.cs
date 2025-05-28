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
    public partial class MostrarMarca : Form
    {
        public MostrarMarca()
        {
            InitializeComponent();
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Visible = false;
            frm.Visible = true;
        }

        private void MostrarMarca_Load(object sender, EventArgs e)
        {
            cbxMarca.SelectedItem = "Toyota";
        }

        private void cbxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string marca = cbxMarca.SelectedItem.ToString();
            switch(marca)
            {
                case "Toyota":
                    break;
                case "Mitsubishi":
                    break;
                case "Nissan":
                    break;
                case "Mazda":
                    break;
                case "Subaru":
                    break;
                case "Honda":
                    break;
                default:
                    MessageBox.Show("Programadro revisa que los nombres coincidan xd");
                    break;
            }
        }
    }
}
