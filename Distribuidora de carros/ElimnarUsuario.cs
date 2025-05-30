using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distribuidora_de_caroos
{
    public partial class ElimnarUsuario : Form
    {
        ConexionBD conec = new ConexionBD();
        public ElimnarUsuario()
        {
            InitializeComponent();
            ObtenerUsuarios();
        }
        private void ObtenerUsuarios()
        {
            
            using (SqlConnection conn = conec.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Usuarios";

                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conn);

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvusuarios.DataSource = tabla;

                }
                catch
                {
                    MessageBox.Show("Error al cargar usuarios");
                }
            }
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            Administrador frmad = new Administrador();
            frmad.Visible = true;
            this.Visible = false;
        }

        private void dgvusuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //obteniendo el id de la fila seleccionada
                int idUsuario = Convert.ToInt32(dgvusuarios.Rows[e.RowIndex].Cells["Id_Usuario"].Value);
                using (SqlConnection connection = conec.ObtenerConexion())
                {
                    try
                    {
                        string query = "DELETE FROM Usuarios WHERE Id_Usuario = @Id";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Id", idUsuario);
                        connection.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            dgvusuarios.Rows.RemoveAt(e.RowIndex); //eliminando del datagris
                            MessageBox.Show("Usuario eliminado correctamente");
                        }
                        else
                        {
                            MessageBox.Show("Hubo problemas para eliminar el usuario.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hubo un error en el proceso: " + ex.Message);
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login frmlog = new Login();
            this.Close();
            frmlog.ShowDialog();
        }
    }
}
