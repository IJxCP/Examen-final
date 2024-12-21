    using System;
    using System.Collections.Generic;
    using Modelo;

    namespace Negocio
    {
        public class AsignacionNegocio
        {
        
            public string AsignarEmpleadoAProyecto(Asignacion asignacion)
            {
            
                List<Asignacion> asignacionesExistentes = Asignacion.ListarAsignacionesPorProyecto(asignacion.ProyectoId);
                if (asignacionesExistentes.Exists(a => a.EmpleadoId == asignacion.EmpleadoId))
                {
                    return "El empleado ya está asignado a este proyecto.";
                }

            
                int resultado = Asignacion.InsertarAsignacion(asignacion);
                return resultado > 0 ? "Empleado asignado exitosamente al proyecto." : "Error al asignar el empleado al proyecto.";
            }

        
            public List<Asignacion> ObtenerAsignacionesPorProyecto(int proyectoId)
            {
                return Asignacion.ListarAsignacionesPorProyecto(proyectoId);
            }
        }
    }
