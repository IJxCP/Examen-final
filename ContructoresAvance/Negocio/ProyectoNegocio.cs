using System;
using System.Collections.Generic;
using Modelo;

namespace Negocio
{
    public class ProyectoNegocio
    {
        
        public string RegistrarProyecto(Proyecto proyecto)
        {
            
            List<Proyecto> proyectosExistentes = Proyecto.ListarProyectos();
            if (proyectosExistentes.Exists(p => p.Nombre == proyecto.Nombre))
            {
                return "El nombre del proyecto ya está registrado.";
            }

            
            int resultado = Proyecto.InsertarProyecto(proyecto);
            return resultado > 0 ? "Proyecto registrado exitosamente." : "Error al registrar el proyecto.";
        }

        
        public List<Proyecto> ObtenerProyectos()
        {
            return Proyecto.ListarProyectos();
        }
    }
}
