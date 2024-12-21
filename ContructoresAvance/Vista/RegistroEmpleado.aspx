<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroEmpleado.aspx.cs" Inherits="ProyectoDos.RegistroEmpleado" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Registrar Empleado</h2>

    <form id="form1" runat="server">
        <div>
            <label for="txtNumeroCarnet">Número de Carnet:</label>
            <asp:TextBox ID="txtNumeroCarnet" runat="server" /><br />

            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" /><br />

            <label for="txtFechaNacimiento">Fecha de Nacimiento:</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" /><br />

            <label for="ddlCategoria">Categoría:</label>
            <asp:DropDownList ID="ddlCategoria" runat="server">
                <asp:ListItem Value="1">Categoria 1</asp:ListItem>
                <asp:ListItem Value="2">Categoria 2</asp:ListItem>
            </asp:DropDownList><br />

            <label for="txtSalario">Salario:</label>
            <asp:TextBox ID="txtSalario" runat="server" /><br />

            <label for="txtDireccion">Dirección:</label>
            <asp:TextBox ID="txtDireccion" runat="server" /><br />

            <label for="txtTelefono">Teléfono:</label>
            <asp:TextBox ID="txtTelefono" runat="server" /><br />

            <label for="txtCorreo">Correo:</label>
            <asp:TextBox ID="txtCorreo" runat="server" /><br />

            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Empleado" OnClick="btnRegistrar_Click" />
        </div>

        <asp:Label ID="lblMensaje" runat="server" />
    </form>
</asp:Content>
