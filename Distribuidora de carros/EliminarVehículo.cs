using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distribuidora_de_caroos
{
    public partial class EliminarVehículo : Form
    {
        ConexionBD conec = new ConexionBD();
        public EliminarVehículo()
        {
            InitializeComponent();
            ObtenerVehiculos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login frmlog = new Login();
            this.Close();
            frmlog.ShowDialog();
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            Administrador frmADM = new Administrador();
            this.Close();
            frmADM.ShowDialog();
        }
        private void ObtenerVehiculos()
        {
            using (SqlConnection conn = conec.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Vehiculo";

                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conn);

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvvehiculos.DataSource = tabla;

                }
                catch
                {
                    MessageBox.Show("Error al cargar vehículos");
                }
            }
        }

        private void dgvvehiculos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //obteniendo el id de la fila seleccionada
                int idVehiculo = Convert.ToInt32(dgvvehiculos.Rows[e.RowIndex].Cells["Id_Vehiculo"].Value);
                using (SqlConnection connection = conec.ObtenerConexion())
                {
                    try
                    {
                        string query = "DELETE FROM Usuarios WHERE Id_Usuario = @Id";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Id", idVehiculo);
                        connection.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            dgvvehiculos.Rows.RemoveAt(e.RowIndex); //eliminando del datagrid
                            MessageBox.Show("Vehículo eliminado correctamente");
                        }
                        else
                        {
                            MessageBox.Show("Hubo problemas para eliminar el vehículo.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hubo un error en el proceso: " + ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("Seleccion una fila válida");
        }
    }
}
