using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distribuidora_de_caroos
{
    public class DatosVehiculosBD //clase que almacenará los datos que se encuentran en la base de datos
    {
        public int IdVehiculo { get; set; }
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public int IdDetalle { get; set; }
        public string Motor { get; set; }
        public string Cilindrada { get; set; }
        public string TipoCombustible { get; set; }
        public string Transmision { get; set; }
        public decimal Kilometraje { get; set; }
        public string Color { get; set; }
        public string Descripcion { get; set; }

        public string RutaImagen { get; set; } //propiedad para la ruta de imagen
    }


    //clase que cargará los datos de la base de datos con instrucciones sql
    public class CargarBD
    {
        private ConexionBD conexion;

        public CargarBD()
        {
            conexion = new ConexionBD();
        }

        //método tipo Lista para obtener los datos del vehiculo por medio del modelo del mismo
        public DatosVehiculosBD ObtenerVehiculo(string modelo)
        {
            DatosVehiculosBD vehiculo = null;
            string query = "Select * from VistaCliente where Modelo = @Modelo";

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Modelo", modelo);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        vehiculo = new DatosVehiculosBD
                        {
                            IdVehiculo = (int)reader["Id_Vehiculo"],
                            IdDetalle = (int)reader["Id_Detalle"],
                            IdMarca = (int)reader["Id_Marca"],
                            NombreMarca = reader["NombreMarca"].ToString(),
                            IdProveedor = (int)reader["Id_Proveedor"],
                            NombreProveedor = reader["NombreProveedor"].ToString(),
                            Modelo = reader["Modelo"].ToString(),
                            Año = (int)reader["Año"],
                            Motor = reader["Motor"].ToString(),
                            Cilindrada = reader["Cilindra"].ToString(),
                            TipoCombustible = reader["Tipo_combustible"].ToString(),
                            Transmision = reader["Transmision"].ToString(),
                            Kilometraje = (decimal)reader["Kilometraje"],
                            Color = reader["Color"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            RutaImagen = reader["Ruta_Imagen"].ToString()
                        };
                    }
                }
            }
            return vehiculo;
        }

        //método para cargar marcas en el combobox
        public List<string> ObtenerNombresMarcas()
        {
            List<string> marcas = new List<string>();
            string query = "Select distinct Nombre from Marca order by Nombre";
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        marcas.Add(reader["Nombre"].ToString());
                    }
                }
            }
            return marcas;
        }

        //método para cargar modelos según la marca seleccionada
        public List<string> ObtenerNombresModelos(string nombreMarca)
        {
            List<string> modelos = new List<string>();
            string query = "select distinct V.Modelo " +
                "from Vehiculo V " +
                "inner join Marca M on V.Id_Marca = M.Id_Marca " +
                "where M.Nombre = @NombreMarca " +
                "order by V.Modelo";

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreMarca", nombreMarca);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        modelos.Add(reader["Modelo"].ToString());
                    }
                }
            }
            return modelos;
        }

        //metodo para obtener la ruta base de las imagenes
        private string ObtenerRutaBaseImagenes()
        {
            // Obtener la ruta del directorio de la aplicación
            string rutaAplicacion = Application.StartupPath;

            // Buscar la carpeta del proyecto (subir niveles hasta encontrar las carpetas de marca)
            string rutaBase = rutaAplicacion;

            // Verificar diferentes niveles para encontrar la carpeta con las imágenes
            for (int i = 0; i < 5; i++) // Buscar hasta 5 niveles arriba
            {
                string rutaImagenes = Path.Combine(rutaBase, "Marcas");
                if (Directory.Exists(rutaImagenes))
                {
                    return rutaBase;
                }
                rutaBase = Directory.GetParent(rutaBase)?.FullName;
                if (rutaBase == null) break;
            }

            // Si no encuentra, usar la ruta del ejecutable
            return Application.StartupPath;
        }

        //método para obtener la ruta completa de la imagen
        public string ObtenerRutaCompletaImagen(string rutaRelativa)
        {
            if (string.IsNullOrEmpty(rutaRelativa))
                return null;

            string rutaBase = ObtenerRutaBaseImagenes();
            string rutaCompleta = Path.Combine(rutaBase, rutaRelativa);

            // Verificar si el archivo existe
            if (File.Exists(rutaCompleta))
            {
                return rutaCompleta;
            }

            return null; // Si no existe el archivo
        }
    }
}

