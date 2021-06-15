<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productoform.aspx.cs" Inherits="WebAppProducto.ProductoForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="productoForm" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
            <br/>
            <br/>
            <asp:Label ID="Label2" runat="server" Text="Codigo: "></asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <br/>
            <br/>
            <asp:Label ID="Label3" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br/>
            <br/>
            <asp:Label ID="Label4" runat="server" Text="Descripcion: "></asp:Label>
            <asp:TextBox ID="txtDescrip" runat="server"></asp:TextBox>
            <br/>
            <br/>
            <asp:Label ID="Label5" runat="server" Text="Precio: "></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br/>
            <br/>
            <asp:Label ID="Label6" runat="server" Text="Stock Minimo: "></asp:Label>
            <asp:TextBox ID="txtStockMin" runat="server"></asp:TextBox>
            <br/>
            <br/>
            <asp:Label ID="Label7" runat="server" Text="Stock Maximo: "></asp:Label>
            <asp:TextBox ID="txtStockMax" runat="server"></asp:TextBox>
            <br/>
            <br/>
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>
            <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click"/>
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>
            <br/>
            <br/>
            <asp:Label ID="lbMensaje1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="label8" runat="server" Text="Buscar producto por ID: "></asp:Label>
            <asp:TextBox ID="txtBuscarId" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscarId" runat="server" Text="Buscar" OnClick="btnBuscarId_Click"/>
            <br />
            <br />
            <asp:Button ID="btnMostarProductos" runat="server" Text="Mostrar Productos" OnClick="btnMostarProductos_Click"/> 
            <br />
            <br />
            <asp:GridView ID="dvProductos" runat="server"></asp:GridView>

        </div>
    </form>
</body>
</html>
