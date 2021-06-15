using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppProducto.productoServiceRef;

namespace WebAppProducto
{
    public partial class ProductoForm : System.Web.UI.Page
    {

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ProductoServiceClient cliente = new ProductoServiceClient();
            Producto producto = new Producto();

            producto.Id = int.Parse(txtID.Text);
            producto.Codigo = txtCodigo.Text;
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescrip.Text;
            producto.PrecioVenta = int.Parse(txtPrecio.Text);
            producto.StockMinimo = int.Parse(txtStockMin.Text);
            producto.StockMaximo = int.Parse(txtStockMax.Text);

            if (cliente.nuevoProducto(producto)>0){
                lbMensaje1.Text = "Producto creado correctamente!";
            }
            else
            {
                lbMensaje1.Text = "Error al crear el producto";
            }
        }

        protected void btnBuscarId_Click(object sender, EventArgs e)
        {
            ProductoServiceClient cliente = new ProductoServiceClient();
            Producto producto = new Producto();

            if (txtBuscarId.Text.Trim() != "")
            {
            producto = cliente.buscarProducto(int.Parse(txtBuscarId.Text));
                txtID.Text = producto.Id.ToString();
                txtCodigo.Text = producto.Codigo;
                txtNombre.Text = producto.Nombre;
                txtDescrip.Text = producto.Descripcion;
                txtPrecio.Text = producto.PrecioVenta.ToString();
                txtStockMin.Text = producto.StockMinimo.ToString();
                txtStockMax.Text = producto.StockMaximo.ToString();


            }
            else
            {
                lbMensaje1.Text = "Ingrese una ID";
            }




        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ProductoServiceClient cliente = new ProductoServiceClient();
            Producto producto = new Producto();

            producto.Id = int.Parse(txtID.Text);
            producto.Codigo = txtCodigo.Text;
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescrip.Text;
            producto.PrecioVenta = int.Parse(txtPrecio.Text);
            producto.StockMinimo = int.Parse(txtStockMin.Text);
            producto.StockMaximo = int.Parse(txtStockMax.Text);

            if (cliente.editarProducto(producto) > 0)
            {
                lbMensaje1.Text = "Producto editado correctamente!";
            }
            else
            {
                lbMensaje1.Text = "Error al editar el producto";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ProductoServiceClient cliente = new ProductoServiceClient();

            if (cliente.eliminarProducto(int.Parse(txtID.Text))>0)
            {
                lbMensaje1.Text = "Producto eliminado correctamente!";
            }

            else
            {
                lbMensaje1.Text = "Error al eliminar el producto";
            }
        }

        protected void btnMostarProductos_Click(object sender, EventArgs e)
        {
            ProductoServiceClient cliente = new ProductoServiceClient();

            dvProductos.DataSource = cliente.mostrarProductos();

            dvProductos.DataBind();
            
        }
    }
}