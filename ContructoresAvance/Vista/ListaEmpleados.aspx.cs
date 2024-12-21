    using System;
    using Negocio;

    namespace ProyectoDos
    {
        public partial class ListaEmpleados : System.Web.UI.Page
        {
        
            protected System.Web.UI.WebControls.GridView gvEmpleados;
            protected System.Web.UI.WebControls.DropDownList ddlCategoriaFiltro;
            protected System.Web.UI.WebControls.Button btnFiltrar;

            protected void Page_Load(object sender, EventArgs e)
            {
            
                if (!IsPostBack)
                {
                    CargarEmpleados();
                }
            }

            protected void btnFiltrar_Click(object sender, EventArgs e)
            {
            
                CargarEmpleados(ddlCategoriaFiltro.SelectedValue);
            }

        
            private void CargarEmpleados(string categoria = null)
            {
            
                EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();

            
                gvEmpleados.DataSource = empleadoNegocio.ObtenerEmpleados(categoria);
                gvEmpleados.DataBind(); // Vincular los datos al GridView
            }
        }
    }
