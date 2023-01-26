<%@ Page Title="Editar Factura" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WebApplication17.Facturas.Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
    <%= this.Id %>

    <div class="form-group">
        <label>Codigo</label>
        <asp:TextBox ReadOnly="true" runat="server" ID="TxtCodigo" CssClass="form-control" />
    </div>


    <div class="form-group">
        <label>Descripción</label>
        <asp:TextBox TextMode="MultiLine" runat="server" ID="TxtDescripcion" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Total</label>
        <asp:TextBox runat="server" ID="TxtTotal" CssClass="form-control" />
        <asp:RegularExpressionValidator runat="server" ErrorMessage="Decimal Only" ID="RegularExpressionValidator1" ValidationGroup="Insert"
            ControlToValidate="TxtTotal"
            ValidationExpression="^\d+\,\d{0,2}$"></asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <label>SubTotal</label>
        <asp:TextBox runat="server" ID="TxtSubTotal" CssClass="form-control" />
        <asp:RegularExpressionValidator runat="server" ErrorMessage="Decimal Only" ID="RegularExpressionValidator2" ValidationGroup="Insert"
            ControlToValidate="TxtSubTotal"
            ValidationExpression="^\d+\,\d{0,2}$"></asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <label>Vendedor</label>
        <asp:DropDownList ID="CboVendedor" runat="server" CssClass="form-control">

            <asp:ListItem Enabled="true" Text="Seleccionar Vendedor" Value="-1"></asp:ListItem>

            <asp:ListItem Text="Joe Girard" Value="Joe Girard"></asp:ListItem>

            <asp:ListItem Text="Dave Liniger" Value="Dave Liniger"></asp:ListItem>

            <asp:ListItem Text="Jair Hernández" Value="Jair Hernández"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <label>Metodo de Pago</label>

        <asp:DropDownList ID="CboMetodoPago" runat="server" CssClass="form-control">

            <asp:ListItem Enabled="true" Text="Seleccionar Metodo de Pago" Value="-1"></asp:ListItem>

            <asp:ListItem Text="Efectivo" Value="Efectivo"></asp:ListItem>

            <asp:ListItem Text="Debito" Value="Debito"></asp:ListItem>

            <asp:ListItem Text="Credito" Value="Credito"></asp:ListItem>
        </asp:DropDownList>
    </div>


    <div class="form-check">
        <asp:CheckBox runat="server" Text="Pagado" ID="ChkPagado" CssClass="form-check" />
    </div>

    <asp:Button runat="server" ID="BtnSave" CssClass="btn btn-primary" Text="Guardar" OnClick="BtnSave_Click" />



    <editar-factura id="<%= this.Id %>" />

</asp:Content>
