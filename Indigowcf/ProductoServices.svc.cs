using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Indigowcf
{
    public class ProductoService : IProductoService
    {
        String cadenaConexion = ConfigurationManager.ConnectionStrings["myConexion"].ConnectionString;

        public Producto buscarProducto(int idProducto)
        {
            Producto newProduct = new Producto();
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_find_Product", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idProducto);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    if (rd.Read())
                    {
                        newProduct.Id = rd.GetInt32(0);
                        newProduct.Codigo = rd.GetString(1);
                        newProduct.Nombre = rd.GetString(2);
                        newProduct.Descripcion = rd.GetString(3);
                        newProduct.PrecioVenta = (int)rd.GetDecimal(4);
                        newProduct.StockMinimo = rd.GetInt32(5);
                        newProduct.StockMaximo = rd.GetInt32(6);
                    }

                }
                else
                {
                    throw new Exception("No hay Registros");
                }
 

                cnn.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al buscar", ex);
            }

            return newProduct;
        }

        public DataTable consultarProducto()
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();

            SqlCommand cmd = new SqlCommand("sp_find_all_products", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            data.Fill(table);

            for(int i =0; i<table.Rows.Count; i++)
            {
                Console.WriteLine(table.Rows[i]["Id"].ToString());
                Console.WriteLine(table.Rows[i]["Codigo"].ToString());
                Console.WriteLine(table.Rows[i]["Nombre"].ToString());
                Console.WriteLine(table.Rows[i]["Descripcion"].ToString());
                Console.WriteLine(table.Rows[i]["PrecioVenta"].ToString());
                Console.WriteLine(table.Rows[i]["StockMinimo"].ToString());
                Console.WriteLine(table.Rows[i]["StockMaximo"].ToString());






            }

            return table;
        }

        public int editarProducto(Producto producto)
        {
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_update_Product", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", producto.Id);
                cmd.Parameters.AddWithValue("@codigo", producto.Codigo);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@precioventa", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("@stockminimo", producto.StockMinimo);
                cmd.Parameters.AddWithValue("@stockmaximo", producto.StockMaximo);

                res = cmd.ExecuteNonQuery();

                cnn.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al Editar", ex);
            }

            return res;
        }

        public int eliminarProducto(int idProducto)
        {
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_delete_Product", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idProducto);

                res = cmd.ExecuteNonQuery();

                cnn.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al Eliminar", ex);
            }

            return res;
        }

        public List<Producto> mostrarProductos()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_find_all_products", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@id", "");

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new Producto
                        {
                            Id = rd.GetInt32(0),
                            Codigo = rd.GetString(1),
                            Nombre = rd.GetString(2),
                            Descripcion = rd.GetString(3),
                            PrecioVenta = (int)rd.GetDecimal(4),
                            StockMinimo = rd.GetInt32(5),
                            StockMaximo = rd.GetInt32(6)

                        }) ;
                    }  
                }
                else
                {
                    throw new Exception("No hay Registros");
                }


                cnn.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al Listar los productos!", ex);
            }

            return lista;
        }

        public int nuevoProducto(Producto producto)
        {
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_insert_Product", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", producto.Id);
                cmd.Parameters.AddWithValue("@codigo", producto.Codigo);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@precioventa", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("@stockminimo", producto.StockMinimo);
                cmd.Parameters.AddWithValue("@stockmaximo", producto.StockMaximo);

                res = cmd.ExecuteNonQuery();

                cnn.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al Insertar", ex);
            }

            return res;
        }
    }
}