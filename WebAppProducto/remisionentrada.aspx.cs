using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using WebAppProducto.remisionServiceRef;

namespace WebAppProducto
{
    public partial class remisionentrada : System.Web.UI.Page
    {
        private int y = 50;
        private int conteo = 1;
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            RemisionServiceClient cliente = new RemisionServiceClient();
            Remision remision = new Remision();


            remision.Id = int.Parse(txtID.Text);
            remision.Codigo = txtCodigo.Text;
            remision.Fecha = DateTime.Now.ToString("dd-MM-yy");
            remision.IdProveedor = dropProveedor.SelectedIndex + 1;
            remision.IdAlmacen = dropAlmacen.SelectedIndex + 1;
            remision.Estado = 1;

            if (dropProducto0.SelectedValue == dropProducto1.SelectedValue)
            {
                lbMensaje1.Text = "Porfavor elija productos diferentes";
            }

            else
            {
                if (cliente.nuevaRemision(remision) > 0)
                {
                    lbMensaje1.Text = "Remision Guardada y creada correctamente!";
                }
                else
                {
                    lbMensaje1.Text = "Error al crear la remision";
                }
            }

            Server.Transfer("remisionentrada.aspx");
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            RemisionServiceClient cliente = new RemisionServiceClient();

            DropDownList temp = new DropDownList();
            TextBox temp1 = new TextBox();
            temp.ID = "dropProductos" + conteo.ToString();
            temp1.ID = "txtCantidadProducto" + conteo.ToString();
            temp.DataSourceID = "ProductosConsulta";
            temp.DataTextField = "Nombre";
            temp.DataValueField = "Nombre";
            panelProductos.Controls.Add(temp);
            panelProductos.Controls.Add(temp1);
            panelProductos.Controls.Add(new LiteralControl("<br/>"));


            conteo++;



        }

        protected void btnGuardarConfirmar_Click(object sender, EventArgs e)
        {
            RemisionServiceClient cliente = new RemisionServiceClient();

            Remision remision = new Remision();

            RemisionDetalle remisiondetalle = new RemisionDetalle();

            RemisionDetalle remisiondetalle1 = new RemisionDetalle();


            remision.Id = int.Parse(txtID.Text);
            remision.Codigo = txtCodigo.Text;
            remision.Fecha = DateTime.Now.ToString("dd-MM-yy");
            remision.IdProveedor = dropProveedor.SelectedIndex + 1;
            remision.IdAlmacen = dropAlmacen.SelectedIndex + 1;
            remision.Estado = 2;

            remisiondetalle.IdRemisionEntrada = remision.Id;
            remisiondetalle.IdProducto = dropProducto0.SelectedIndex + 1;
            remisiondetalle.Cantidad = int.Parse(txtCantidadProducto0.Text);

            remisiondetalle1.IdRemisionEntrada = remision.Id;
            remisiondetalle1.IdProducto = dropProducto1.SelectedIndex + 1;
            remisiondetalle1.Cantidad = int.Parse(txtCantidadProducto0.Text);

            if (dropProducto0.SelectedValue == dropProducto1.SelectedValue)
            {

                lbMensaje1.Text = "Porfavor elija productos diferentes";

            }
            else
            {
                if (cliente.nuevaRemision(remision) > 0)
                {
                    if (cliente.nuevaRemisionEntrada(remisiondetalle) > 0)
                    {
                        if (cliente.nuevaRemisionEntrada(remisiondetalle1) > 0)
                        {
                            cliente.actualizarInventarioFisico(remision, remisiondetalle);
                            cliente.actualizarInventarioFisico(remision, remisiondetalle1);
                            lbMensaje1.Text = "Remision guardada y confirmada!";
                        }
                    }

                    else
                    {
                        lbMensaje1.Text = "Remision erronea";
                    }
                }
            }

            Response.Redirect("pagina.aspx");
        }

        protected void btnBuscarIdRemision_Click(object sender, EventArgs e)
        {
            RemisionServiceClient cliente = new RemisionServiceClient();

            Remision remision = new Remision();
            
                remision = cliente.buscarRemision(int.Parse(dropBuscarRemision.SelectedValue));
                lbCodigo.Text = remision.Codigo;
                lbFecha.Text = remision.Fecha;
                lbProveedor.Text = remision.IdProveedor.ToString();
                lbAlmacen.Text = remision.IdAlmacen.ToString();

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            RemisionServiceClient cliente = new RemisionServiceClient();

            Remision remision = new Remision();

            RemisionDetalle remisiondetalle = new RemisionDetalle();

            RemisionDetalle remisiondetall1 = new RemisionDetalle();

            if (dropEstado.SelectedIndex == 0)
            {

                remision.Id = int.Parse(dropBuscarRemision.SelectedValue);
                remision.Estado = 2;
                remisiondetalle.IdRemisionEntrada = remision.Id;
                remisiondetalle.IdProducto = dropProducto0.SelectedIndex + 1;
                remisiondetalle.Cantidad = int.Parse(txtCantidadProducto0.Text);

                if (cliente.actualizarEstado(remision) > 0)
                {
                    if (cliente.nuevaRemisionEntrada(remisiondetalle) > 0)
                    {
                        cliente.actualizarInventarioFisico(remision, remisiondetalle);
                        cliente.actualizarInventarioFisico(remision, remisiondetall1);
                        lbMensaje1.Text = "Remision guardada y confirmada!";
                    }

                    else
                    {
                        lbMensaje1.Text = "Remision erronea";
                    }
                }

            }

            else
            {
                remision.Id = int.Parse(dropBuscarRemision.SelectedValue);
                remision.Estado = 3;

                if (cliente.actualizarEstado(remision) > 0)
                {
                    lbMensaje1.Text = "Remision Cancelada!";
                }

                else
                {
                    lbMensaje1.Text = "Remision erronea";
                }

            }

            Response.Redirect("pagina.aspx");

        }
    }
}