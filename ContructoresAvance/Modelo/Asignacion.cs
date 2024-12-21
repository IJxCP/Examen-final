using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class Asignacion
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int ProyectoId { get; set; }
        public DateTime FechaAsignacion { get; set; }

        
        public static int InsertarAsignacion(Asignacion asignacion)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("InsertarAsignacion", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmpleadoId", asignacion.EmpleadoId);
                cmd.Parameters.AddWithValue("@ProyectoId", asignacion.ProyectoId);
                cmd.Parameters.AddWithValue("@FechaAsignacion", asignacion.FechaAsignacion);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        
        public static List<Asignacion> ListarAsignacionesPorProyecto(int proyectoId)
        {
            List<Asignacion> lista = new List<Asignacion>();
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ListarAsignacionesPorProyecto", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProyectoId", proyectoId);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Asignacion
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        EmpleadoId = Convert.ToInt32(dr["EmpleadoId"]),
                        ProyectoId = Convert.ToInt32(dr["ProyectoId"]),
                        FechaAsignacion = Convert.ToDateTime(dr["FechaAsignacion"])
                    });
                }
            }
            return lista;
        }
    }
}
