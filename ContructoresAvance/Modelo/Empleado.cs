using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class Empleado
    {
        public int Id { get; set; }
        public string NumeroCarnet { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Categoria { get; set; }
        public decimal Salario { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        
        public static int InsertarEmpleado(Empleado empleado)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("InsertarEmpleado", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@NumeroCarnet", empleado.NumeroCarnet);
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Categoria", empleado.Categoria);
                cmd.Parameters.AddWithValue("@Salario", empleado.Salario);
                cmd.Parameters.AddWithValue("@Direccion", empleado.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                cmd.Parameters.AddWithValue("@Correo", empleado.Correo);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        
        public static List<Empleado> ListarEmpleados(string categoria = null)
        {
            List<Empleado> lista = new List<Empleado>();
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ListarEmpleados", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (!string.IsNullOrEmpty(categoria))
                {
                    cmd.Parameters.AddWithValue("@Categoria", categoria);
                }

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Empleado
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        NumeroCarnet = dr["NumeroCarnet"].ToString(),
                        Nombre = dr["Nombre"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                        Categoria = dr["Categoria"].ToString(),
                        Salario = Convert.ToDecimal(dr["Salario"]),
                        Direccion = dr["Direccion"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString()
                    });
                }
            }
            return lista;
        }
    }
}
