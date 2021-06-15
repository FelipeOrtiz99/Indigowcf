using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppProducto.proveedorServiceRef;

namespace WebAppProducto
{
    public partial class ProveedoresForm : System.Web.UI.Page
    {
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ProveedorServiceClient cliente = new ProveedorServiceClient();
            Proveedor proveedor = new Proveedor();

            proveedor.Id = int.Parse(txtID.Text);
            proveedor.Codigo = txtCodigo.Text;
            proveedor.Nombre = txtNombre.Text;
            proveedor.Direccion = txtDirec.Text;
            proveedor.Telefono = txtTel.Text;

            if (cliente.nuevoProveedor(proveedor) > 0)
            {
                lbMensaje1.Text = "Proveedor creado correctamente!";
            }
            else
            {
                lbMensaje1.Text = "Error al crear el proveedor";
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ProveedorServiceClient cliente = new ProveedorServiceClient();
            Proveedor proveedor = new Proveedor();

            proveedor.Id = int.Parse(txtID.Text);
            proveedor.Codigo = txtCodigo.Text;
            proveedor.Nombre = txtNombre.Text;
            proveedor.Direccion = txtDirec.Text;
            proveedor.Telefono = txtTel.Text;

            if (cliente.nuevoProveedor(proveedor) > 0)
            {
                lbMensaje1.Text = "Proveedor editado correctamente!";
            }
            else
            {
                lbMensaje1.Text = "Error al editar el proveedor";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ProveedorServiceClient cliente = new ProveedorServiceClient();

            if (cliente.eliminarProveedor(int.Parse(txtID.Text)) > 0)
            {
                lbMensaje1.Text = "Proveedor eliminado correctamente!";
            }
            else
            {
                lbMensaje1.Text = "Error al eliminar al proveedor";
            }
        }

        protected void btnBuscarId_Click(object sender, EventArgs e)
        {
            ProveedorServiceClient cliente = new ProveedorServiceClient();
            Proveedor provedor = new Proveedor();

            if (txtBuscarId.Text.Trim() != "") { 
            
            provedor = cliente.buscarProveedor(int.Parse(txtBuscarId.Text));
                txtID.Text = provedor.Id.ToString();
                txtCodigo.Text = provedor.Codigo;
                txtNombre.Text = provedor.Nombre;
                txtDirec.Text = provedor.Direccion;
                txtTel.Text = provedor.Telefono;
                
            }
            else
            {
                lbMensaje1.Text = "Porfavor ingresa un ID "; 
            }



        }

        protected void btnMostarProveedores_Click(object sender, EventArgs e)
        {
            ProveedorServiceClient cliente = new ProveedorServiceClient();

            dvProveedores.DataSource = cliente.mostrarProveedor();

            dvProveedores.DataBind();
        }
    }
}