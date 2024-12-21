using System;
using System.Collections.Generic;
using Modelo;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        
        public string RegistrarEmpleado(Empleado empleado)
        {
            
            if (CalcularEdad(empleado.FechaNacimiento) < 18)
            {
                return "El empleado debe ser mayor de edad.";
            }

            
            if (!EsCategoriaValida(empleado.Categoria))
            {
                return "La categoría no es válida. Las categorías válidas son: Administrador, Operario, Peón.";
            }

            
            List<Empleado> empleadosExistentes = Empleado.ListarEmpleados();
            if (empleadosExistentes.Exists(e => e.Correo == empleado.Correo))
            {
                return "El correo ya está registrado.";
            }
            if (empleadosExistentes.Exists(e => e.NumeroCarnet == empleado.NumeroCarnet))
            {
                return "El número de carnet ya está registrado.";
            }

            
            int resultado = Empleado.InsertarEmpleado(empleado);
            return resultado > 0 ? "Empleado registrado exitosamente." : "Error al registrar el empleado.";
        }

        
        private int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear)
                edad--;
            return edad;
        }

        
        private bool EsCategoriaValida(string categoria)
        {
            string[] categoriasValidas = { "Administrador", "Operario", "Peón" };
            return Array.Exists(categoriasValidas, c => c.Equals(categoria, StringComparison.OrdinalIgnoreCase));
        }

        
        public List<Empleado> ObtenerEmpleados(string categoria = null)
        {
            return Empleado.ListarEmpleados(categoria);
        }
    }
}
