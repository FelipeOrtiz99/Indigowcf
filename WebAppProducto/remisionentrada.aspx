<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="remisionentrada.aspx.cs" Inherits="WebAppProducto.remisionentrada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="remisionForm" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
            <br/>
            <br/>
            <asp:Label ID="Label2" runat="server" Text="Codigo: "></asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <br/>
            <br/>
            <asp:Label ID="Label4" runat="server" Text="Selecciona Proveedor: "></asp:Label>
            <asp:DropDownList runat="server" ID="dropProveedor" DataSourceID="ConsultaProveedor" DataTextField="Nombre" DataValueField="Nombre"></asp:DropDownList>
            <asp:SqlDataSource ID="ConsultaProveedor" runat="server" ConnectionString="<%$ ConnectionStrings:indigoConnectionString %>" SelectCommand="SELECT [Nombre] FROM [Proveedor]"></asp:SqlDataSource>
            <br/>
            <br/>
            <asp:Label ID="Label5" runat="server" Text="Selecciona Almacen: "></asp:Label>
            <asp:DropDownList runat="server" ID="dropAlmacen" DataSourceID="ConsultaAlmacen" DataTextField="Nombre" DataValueField="Nombre"> </asp:DropDownList>
            <asp:SqlDataSource ID="ConsultaAlmacen" runat="server" ConnectionString="<%$ ConnectionStrings:indigoConnectionString %>" SelectCommand="SELECT [Nombre] FROM [Almacen]"></asp:SqlDataSource>
            <br />
            <br/>
            <asp:Panel runat="server" ID="panelProductos">
            <asp:DropDownList ID="dropProducto0" runat="server" DataSourceID="ProductosConsulta" DataTextField="Nombre" DataValueField="Nombre"></asp:DropDownList>
            <asp:TextBox ID="txtCantidadProducto0" runat="server"></asp:TextBox>
            <asp:SqlDataSource ID="ProductosConsulta" runat="server" ConnectionString="<%$ ConnectionStrings:indigoConnectionString %>" SelectCommand="SELECT [Nombre] FROM [Producto]"></asp:SqlDataSource>
            <br />
            <asp:DropDownList ID="dropProducto1" runat="server" DataSourceID="ProductosConsulta" DataTextField="Nombre" DataValueField="Nombre"></asp:DropDownList>
            <asp:TextBox ID="txtCantidadProducto1" runat="server"></asp:TextBox>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:indigoConnectionString %>" SelectCommand="SELECT [Nombre] FROM [Producto]"></asp:SqlDataSource>
            </asp:Panel>
            <br />
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
            <asp:Button ID="btnGuardarConfirmar" runat="server" Text="Guardar y Confirmar" OnClick="btnGuardarConfirmar_Click"/>
            <br/>
            <br/>
            <asp:Label ID="lbMensaje1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" ID="Label16" Text="ID Remision:  "></asp:Label>
            <asp:DropDownList ID="dropBuscarRemision" runat="server" DataSourceID="ConsultarIdRemision" DataTextField="Id" DataValueField="Id"></asp:DropDownList>
            <asp:SqlDataSource ID="ConsultarIdRemision" runat="server" ConnectionString="<%$ ConnectionStrings:indigoConnectionString %>" SelectCommand="SELECT * FROM [RemisionEntrada] WHERE ([Estado] = @Estado)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="Estado" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:Panel runat="server" ID="panelConsulta">
            <asp:Label runat="server" Text="Codigo: "></asp:Label>
            <asp:Label ID="lbCodigo" runat="server"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Fecha: "></asp:Label>
            <asp:Label ID="lbFecha" runat="server"></asp:Label>
            <br />
            <asp:Label runat="server" Text="ID Proveedor: "></asp:Label>
            <asp:Label ID="lbProveedor" runat="server"></asp:Label>
            <br />
            <asp:Label runat="server" Text="ID Almacen: "></asp:Label>
            <asp:Label ID="lbAlmacen" runat="server"></asp:Label>
            <br />
            <asp:Label Text="Estado: " runat="server"></asp:Label> 
            <asp:DropDownList ID="dropEstado" runat="server">
                <asp:ListItem>
                    Confirmar
                </asp:ListItem>
                <asp:ListItem>
                    Cancelar
                </asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="txtProducto3" runat="server" Text="Producto 1: "></asp:Label>
            <asp:DropDownList ID="dropProducto3" runat="server" DataSourceID="ProductosConsulta" DataTextField="Nombre" DataValueField="Nombre"></asp:DropDownList>
            <br />
            <asp:Label ID="txtProducto4" runat="server" Text="Producto 2: "></asp:Label>
            <asp:DropDownList ID="dropProducto4" runat="server" DataSourceID="ProductosConsulta" DataTextField="Nombre" DataValueField="Nombre"></asp:DropDownList>
                <br />
                <br />
            <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar" OnClick="btnFinalizar_Click"/>
            </asp:Panel>
            

        </div>
    </form>
</body>
</html>
