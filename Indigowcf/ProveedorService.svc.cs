using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Indigowcf
{
    public class ProveedorService : IProveedorService
    {
        String cadenaConexion = ConfigurationManager.ConnectionStrings["myConexion"].ConnectionString;

        public Proveedor buscarProveedor(int idProveedor)
        {
            Proveedor newProveedor = new Proveedor();

            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_find_proveedor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idProveedor);

                SqlDataReader rd = cmd.ExecuteReader();


                if (rd.HasRows)
                {
                    if (rd.Read())
                    {
                        newProveedor.Id = rd.GetInt32(0);
                        newProveedor.Codigo = rd.GetString(1);
                        newProveedor.Nombre = rd.GetString(2);
                        newProveedor.Direccion = rd.GetString(3);
                        newProveedor.Telefono = rd.GetString(4);
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

            return newProveedor;
        }

        public DataTable consultarProveedor()
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();

            SqlCommand cmd = new SqlCommand("sp_find_all_proveedores", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            data.Fill(table);

            return table;
        }

        public int editarProveedor(Proveedor proveedor)
        {
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_update_Proveedor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", proveedor.Id);
                cmd.Parameters.AddWithValue("@codigo", proveedor.Codigo);
                cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);

                res = cmd.ExecuteNonQuery();

                cnn.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al Editar", ex);
            }

            return res;
        }

        public int eliminarProveedor(int idProveedor)
        {
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_delete_proveedor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idProveedor);

                res = cmd.ExecuteNonQuery();

                cnn.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al Eliminar", ex);
            }

            return res;
        }

        public List<Proveedor> mostrarProveedor()
        {
            List<Proveedor> lista = new List<Proveedor>();
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_find_all_proveedores", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@id", "");

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new Proveedor
                        {
                            Id = rd.GetInt32(0),
                            Codigo = rd.GetString(1),
                            Nombre = rd.GetString(2),
                            Direccion = rd.GetString(3),
                            Telefono = rd.GetString(4)

                        });
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
            Console.WriteLine(lista);
            return lista;
        }

        public int nuevoProveedor(Proveedor proveedor)
        {
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_insert_Proveedor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", proveedor.Id);
                cmd.Parameters.AddWithValue("@codigo", proveedor.Codigo);
                cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                
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
