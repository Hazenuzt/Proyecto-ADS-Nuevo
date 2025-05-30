using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Drawing.Drawing2D;

namespace Distribuidora_de_caroos
{
    public partial class Singup : Form
    {
        public Singup()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string user = txtuser.Text.Trim();
            string pass = txtContraseña.Text.Trim();
            string confirmpass = txtConfrimPass.Text.Trim();
            string tipoUser = "Cliente";

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(confirmpass))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pass != confirmpass)
            {
                MessageBox.Show("Los campos de las contraseñas deben ser el mismo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Clear();
                txtConfrimPass.Clear();
                txtContraseña.Focus();
                return;
            }
            if (pass.Length <= 3)
            {
                MessageBox.Show("La contraseña debe tener por lo menos cuatro caracteres","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfrimPass.Clear();
                txtContraseña.Focus();
                return;
            }
            if (user.Length <= 3)
            {
                MessageBox.Show("El usuario debe tener por lo menos cuatro caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtuser.Clear();
                txtuser.Focus();
                return;
            }
            if (nombre.Length <= 3)
            {
                MessageBox.Show("El nombre debe tener por lo menos cuatro caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Clear();
                txtNombre.Focus();
                return;
            }

             string query1 = @"SELECT COUNT(*) FROM Usuarios WHERE UserName=@NombreDeUsuario;";
             string query2 = @"INSERT INTO Usuarios (Nombre,Username,contra,tipoUsuario)
                              VALUES(@Nombre,@NombreDeUsuario,@contraseña,@tipoUsuario);";
            try 
            {
                ConexionBD claseConexion = new ConexionBD();
                using (SqlConnection conn = claseConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query1, conn))
                    {
                        cmd.Parameters.AddWithValue("@NombreDeUsuario", user);
                        int cantidadUsuarios = Convert.ToInt32(cmd.ExecuteScalar());
                        if (cantidadUsuarios >0)
                        {
                            MessageBox.Show("El username ya esta en uso", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtuser.Clear();
                            txtuser.Focus();
                            return;
                        }
                        else
                        {
                            using(SqlCommand cmd2=new SqlCommand(query2, conn))
                            {
                                cmd2.Parameters.AddWithValue("@Nombre", nombre);
                                cmd2.Parameters.AddWithValue("@NombreDeUsuario", user);
                                cmd2.Parameters.AddWithValue("@contraseña", pass);
                                cmd2.Parameters.AddWithValue("@tipoUsuario", tipoUser);
                                cmd2.ExecuteNonQuery();
                                MessageBox.Show("Nuevo usuario creado", "Accion completada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos: "+ex,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Singup_Load(object sender, EventArgs e)
        {
            GraphicsPath path=new GraphicsPath();
            path.AddEllipse(0,0,btnMinimizarMac.Width,btnMinimizarMac.Height);
            btnMinimizarMac.Region = new System.Drawing.Region(path);
        }

        private void btnMinimizarMac_Click(object sender, EventArgs e)
        {
            this.Close();
            Login frmlogin = new Login();
            frmlogin.Show();
        }
    }
}
