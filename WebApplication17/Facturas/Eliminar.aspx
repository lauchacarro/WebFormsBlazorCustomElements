<%@ Page Title="Eliminar Factura" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="WebApplication17.Facturas.Eliminar" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <h2><%: Title %>.</h2>
    <asp:Label runat="server" ID="LblMessage">¿Realmente desea eliminar la factura con codigo: ?</asp:Label>



    <asp:Button runat="server" CssClass="btn btn-danger" Text="Eliminar" ID="BtnEliminar" OnClick="BtnEliminar_Click" />
    <asp:Button runat="server" CssClass="btn btn-default" Text="Cancelar" ID="BtnCancelar" OnClick="BtnCancelar_Click" />

</asp:Content>
