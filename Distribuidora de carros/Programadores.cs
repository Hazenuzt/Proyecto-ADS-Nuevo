using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distribuidora_de_caroos
{
    public partial class Programadores: Form
    {
        public Programadores()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            
        }

        private void Programadores_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btnMinimizarMac.Width, btnMinimizarMac.Height);
            btnMinimizarMac.Region = new System.Drawing.Region(path);
        }

        private void btnMinimizarMac_Click(object sender, EventArgs e)
        {
            Login inicio = new Login();
            this.Close();
            inicio.Show();
        }
    }
}
