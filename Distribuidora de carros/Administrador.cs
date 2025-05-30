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
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
            CargarIdsVehiculos();
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
            EliminarUsuario frmDltUser = new EliminarUsuario();
            this.Close();
            frmDltUser.ShowDialog();

        }

        private void btnEliminarCarro_Click(object sender, EventArgs e)
        {
            EliminarVehiculo frmDltCar = new EliminarVehiculo();
            this.Close();
            frmDltCar.ShowDialog();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string username = txtUsername.Text.Trim();
            string contra = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(contra))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                ConexionBD conexion = new ConexionBD();
                using (SqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"INSERT INTO Usuarios (Nombre, Username, Contra, tipoUsuario)
                             VALUES (@Nombre, @Username, @Contra, 'Administrador')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Contra", contra);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Administrador agregado correctamente.");
                            txtNombre.Clear();
                            txtUsername.Clear();
                            txtPassword.Clear();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el administrador.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar administrador: " + ex.Message);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            this.Hide();
            frmLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            this.Hide();
            frmLogin.Show();
        }
        private void CargarIdsVehiculos()
        {
            cbIdVehiculo.Items.Clear();
            try
            {
                ConexionBD conexion = new ConexionBD();
                using (SqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT Id_Vehiculo FROM Vehiculo";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbIdVehiculo.Items.Add(reader["Id_Vehiculo"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar IDs: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cbIdVehiculo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un vehículo.");
                return;
            }

            int idVehiculo = int.Parse(cbIdVehiculo.SelectedItem.ToString());
            string motor = txtMotor.Text.Trim();
            string transmision = cbTransmision.Text;
            decimal kilometraje = 0;
            if (!decimal.TryParse(txtKilometraje.Text.Trim(), out kilometraje))
            {
                MessageBox.Show("Kilometraje inválido.");
                return;
            }
            string color = txtColor.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            try
            {
                ConexionBD conexion = new ConexionBD();
                using (SqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"UPDATE Detalle_Vehiculo SET 
                             Motor = @Motor,
                             Transmision = @Transmision,
                             Kilometraje = @Kilometraje,
                             Color = @Color,
                             Descripcion = @Descripcion
                             WHERE Id_Vehiculo = @IdVehiculo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Motor", motor);
                        cmd.Parameters.AddWithValue("@Transmision", transmision);
                        cmd.Parameters.AddWithValue("@Kilometraje", kilometraje);
                        cmd.Parameters.AddWithValue("@Color", color);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@IdVehiculo", idVehiculo);

                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0)
                        {
                            MessageBox.Show("Vehículo actualizado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el vehículo.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

    }
}

