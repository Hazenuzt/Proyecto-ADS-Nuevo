using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using Distribuidora_de_caroos;
using System.Windows.Forms;

namespace Distribuidora_de_caroos
{
    public class ConexionBD
    {
        private string servidor, db, cadena; //atributos para conexion de bd
        public string usuario, contras; //atributos para validacion de usuario y contraseña
        public ConexionBD()
        {
            servidor = "localhost";
            db = "Catalogo_Ventas";
            cadena = "Data Source=" + servidor + ";Initial Catalog=" + db + "; Integrated Security = true";
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }

        public ConexionBD(string user, string contra) // constructor que recibe los parametros usuario y contraseña
        {
            usuario = user;
            contras = contra;
        }

        public void ProbarConexion()
        {
            try
            {
                using (SqlConnection conn= new SqlConnection(cadena))
                {
                    conn.Open();
                    MessageBox.Show("Conexion exitosa a la bd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string Usuario //método de validacion de usuario
        {
            get { return usuario; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Ingrese un usuario");
                }
                usuario = value;
            }
        }

        public string Contras //método de validacion de contraseña
        {
            get { return contras; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Ingrese una constraseña.");
                }
                contras = value;
            }
        }

        public string ValidacionUsuario()
        {
            string tipoUsuario = null;
            string query = "SELECT tipoUsuario FROM Usuarios WHERE Username = @usuario AND Contra = @contras";

            try
            {
                using (SqlConnection conn = new SqlConnection(cadena))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand (query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contras", contras);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    tipoUsuario = reader["tipoUsuario"].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontró un usuario con esas credenciales");
                            }
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al validar el usuario: " + ex.Message);
            }
            return tipoUsuario;
        }
    }
}
