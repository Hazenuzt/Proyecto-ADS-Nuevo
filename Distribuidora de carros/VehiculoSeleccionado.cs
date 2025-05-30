using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distribuidora_de_caroos
{
    
    public partial class VehiculoSeleccionado: Form
    {
        private MarcaSeleccionada MarcaSeleccionada;
        private DatosVehiculosBD vehiculoInfo;
        private CargarBD cargaVehi;

        public VehiculoSeleccionado(string modelo, MarcaSeleccionada marca)
        {
            
            InitializeComponent();
            this.MarcaSeleccionada = marca;
            pcb_logo.Image = Properties.Resources.Logo;

            cargaVehi = new CargarBD();
            CargarInfoVehiculo(modelo);
        }

        //método para cargar los datos recuperados de la bd en el form
        private void CargarInfoVehiculo(string modelo)
        {
            try
            {
                vehiculoInfo = cargaVehi.ObtenerVehiculo(modelo);
                if (vehiculoInfo != null)
                {
                    lblMarca.Text = vehiculoInfo.NombreMarca;
                    lblModelo.Text = vehiculoInfo.Modelo;
                    lblAño.Text = Convert.ToString(vehiculoInfo.Año);
                    lblProveedor.Text = vehiculoInfo.NombreProveedor;
                    lblMotor.Text = vehiculoInfo.Motor;
                    lblCilindrada.Text = vehiculoInfo.Cilindrada;
                    lblCombustible.Text = vehiculoInfo.TipoCombustible;
                    lblTransmision.Text = vehiculoInfo.Transmision;
                    lblKilometraje.Text = Convert.ToString(vehiculoInfo.Kilometraje);
                    lblColor.Text = vehiculoInfo.Color;
                    lblDescripcion.Text = vehiculoInfo.Descripcion;
                    CargarImagenVehiculoBD();
                }
                else
                {
                    MessageBox.Show($"No se encontró información para el modelo: {modelo}", "Infromación no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblMarca.Text = modelo;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al cargar informacion del vehiculo" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblMarca.Text = modelo;
            }
        }

        //metodo para cargar la imagen del vehiculo
        private void CargarImagenVehiculoBD()
        {
            try
            {
                if (vehiculoInfo != null && !string.IsNullOrEmpty(vehiculoInfo.RutaImagen))
                {
                    // Obtener la ruta completa usando el DAL
                    string rutaCompleta = cargaVehi.ObtenerRutaCompletaImagen(vehiculoInfo.RutaImagen);

                    if (!string.IsNullOrEmpty(rutaCompleta))
                    {
                        pictureBox1.Image = Image.FromFile(rutaCompleta);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Para ajustar la imagen

                        Console.WriteLine($"Imagen cargada desde: {rutaCompleta}"); // Para debug
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró la imagen en: {vehiculoInfo.RutaImagen}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar imagen: {ex.Message}");
            }
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
