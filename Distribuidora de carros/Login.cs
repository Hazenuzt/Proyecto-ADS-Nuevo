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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            pcb_logo.Image = Properties.Resources.Logo;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            InicioUsuario frmMarca = new InicioUsuario();
            Administrador frmadmin = new Administrador();
            string usuario = txtuser.Text.Trim();
            string contrasenia = txtpassword.Text.Trim();

            ConexionBD validando = new ConexionBD();
            validando.usuario = usuario;
            validando.contras = contrasenia;
            string tipoUsuario = validando.ValidacionUsuario();

            if (tipoUsuario == "Administrador")
            {
                this.Visible = false;
                frmadmin.Visible = true;
            }
            else if (tipoUsuario == "Cliente")
            {
                this.Visible = false;
                frmMarca.Visible = true;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña inválido");
                txtpassword.Clear();
                txtuser.Clear();
                txtuser.Focus();
            }
        }

        private void btnProgramadores_Click(object sender, EventArgs e)
        {
            Programadores frmProgramadores = new Programadores();
            this.Hide();
            frmProgramadores.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btnCerrarMac.Width, btnCerrarMac.Height);
            btnCerrarMac.Region = new System.Drawing.Region(path);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Singup frmSingup = new Singup();
            this.Hide();
            frmSingup.Visible = true;
        }

        private void btnCerrarMac_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
