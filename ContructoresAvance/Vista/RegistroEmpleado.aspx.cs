using System;
using Negocio;

namespace ProyectoDos
{
    public partial class RegistroEmpleado : System.Web.UI.Page
    {
        // Declarar los controles con los tipos adecuados
        protected System.Web.UI.WebControls.TextBox txtNumeroCarnet;
        protected System.Web.UI.WebControls.TextBox txtNombre;
        protected System.Web.UI.WebControls.TextBox txtFechaNacimiento;
        protected System.Web.UI.WebControls.DropDownList ddlCategoria;
        protected System.Web.UI.WebControls.TextBox txtSalario;
        protected System.Web.UI.WebControls.TextBox txtDireccion;
        protected System.Web.UI.WebControls.TextBox txtTelefono;
        protected System.Web.UI.WebControls.TextBox txtCorreo;
        protected System.Web.UI.WebControls.Label lblMensaje;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Aquí podrías agregar lógica si necesitas hacer algo al cargar la página
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validación de los campos
            if (string.IsNullOrEmpty(txtNumeroCarnet.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtFechaNacimiento.Text)
                || string.IsNullOrEmpty(ddlCategoria.SelectedValue) || string.IsNullOrEmpty(txtSalario.Text) || string.IsNullOrEmpty(txtDireccion.Text)
                || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(txtCorreo.Text))
            {
                lblMensaje.Text = "Por favor, completa todos los campos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                // Crear el objeto empleado
                EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
                var empleado = new Modelo.Empleado
                {
                    NumeroCarnet = txtNumeroCarnet.Text,
                    Nombre = txtNombre.Text,
                    FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                    Categoria = ddlCategoria.SelectedValue,
                    Salario = decimal.Parse(txtSalario.Text),
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text
                };

                // Registrar el empleado
                string mensaje = empleadoNegocio.RegistrarEmpleado(empleado);

                // Mostrar el mensaje de éxito o error
                lblMensaje.Text = mensaje;
                lblMensaje.ForeColor = mensaje.Contains("éxitosamente") ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al registrar el empleado: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
