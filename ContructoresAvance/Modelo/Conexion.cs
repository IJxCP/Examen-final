using System.Configuration;
using System.Data.SqlClient;

namespace Modelo
{
    public static class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            // Aseguramos que coincida con el nombre en el Web.config: "conexion"
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            return new SqlConnection(cadenaConexion);
        }
    }
}
