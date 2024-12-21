<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaEmpleados.aspx.cs" Inherits="ProyectoDos.ListaEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Listado de Empleados</h2>
    <form runat="server">
        <label for="ddlCategoriaFiltro">Filtrar por Categoría:</label>
        <asp:DropDownList ID="ddlCategoriaFiltro" runat="server">
            <asp:ListItem Value="">--Todas--</asp:ListItem>
            <asp:ListItem Value="Administrador">Administrador</asp:ListItem>
            <asp:ListItem Value="Operario">Operario</asp:ListItem>
            <asp:ListItem Value="Peón">Peón</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
        <br /><br />
        <asp:GridView ID="gvEmpleados" runat="server"></asp:GridView>
    </form>
</asp:Content>
