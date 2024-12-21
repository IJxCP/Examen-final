using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        
        public static int InsertarProyecto(Proyecto proyecto)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("InsertarProyecto", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Codigo", proyecto.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", proyecto.Nombre);
                cmd.Parameters.AddWithValue("@FechaInicio", proyecto.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", proyecto.FechaFin);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        
        public static List<Proyecto> ListarProyectos()
        {
            List<Proyecto> lista = new List<Proyecto>();
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ListarProyectos", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Proyecto
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Codigo = dr["Codigo"].ToString(),
                        Nombre = dr["Nombre"].ToString(),
                        FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                        FechaFin = Convert.ToDateTime(dr["FechaFin"])
                    });
                }
            }
            return lista;
        }
    }
}
