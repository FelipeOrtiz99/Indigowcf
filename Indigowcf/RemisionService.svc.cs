using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Indigowcf
{
    public class RemisionService : IRemisionService
    {
        String cadenaConexion = ConfigurationManager.ConnectionStrings["myConexion"].ConnectionString;

        public int actualizarEstado(Remision remision)
        {
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_update_estado_remision", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", remision.Id);
                cmd.Parameters.AddWithValue("@estado", remision.Estado);
 
                res = cmd.ExecuteNonQuery();

                cnn.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al Editar", ex);
            }

            return res;
        }

        public int actualizarInventarioFisico(Remision remision, RemisionDetalle remisiondetalle)
        {
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_update_inventariofisico", cnn);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlCommand cmd1 = new SqlCommand("SELECT MAX(Id) FROM RemisionEntradaDetalle", cnn);
                cmd1.CommandType = CommandType.Text;
                int maxId = (Convert.ToInt32(cmd1.ExecuteScalar())) + 1;


                cmd.Parameters.AddWithValue("@id", maxId);
                cmd.Parameters.AddWithValue("@idalmacen", remision.IdAlmacen);
                cmd.Parameters.AddWithValue("@idproducto", remisiondetalle.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", remisiondetalle.Cantidad);

                res = cmd.ExecuteNonQuery();

                cnn.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al actualizar", ex);
            }
            return res;
        }

        public Remision buscarRemision(int idRemision)
        {
            Remision newRemision = new Remision(); 
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_find_remision", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idRemision);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    if (rd.Read())
                    {
                        
                        newRemision.Codigo = rd.GetString(1);
                        newRemision.Fecha = rd.GetDateTime(2).ToString();
                        newRemision.IdProveedor = rd.GetInt32(3);
                        newRemision.IdAlmacen = rd.GetInt32(4);

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

            return newRemision;
        }

        public int nuevaRemision(Remision remision)
        {
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_insert_remision", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", remision.Id);
                cmd.Parameters.AddWithValue("@codigo", remision.Codigo);
                cmd.Parameters.AddWithValue("@fecha", remision.Fecha);
                cmd.Parameters.AddWithValue("@idproveedores", remision.IdProveedor);
                cmd.Parameters.AddWithValue("@idalmacen", remision.IdAlmacen);
                cmd.Parameters.AddWithValue("@estado", remision.Estado);

                res = cmd.ExecuteNonQuery();

                cnn.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al Insertar", ex);
            }

            return res;
        }

        public int nuevaRemisionEntrada(RemisionDetalle remisiondetalle)
        {
            int res = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadenaConexion);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_insert_remision_detalle", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlCommand cmd1 = new SqlCommand("SELECT MAX(Id) FROM RemisionEntradaDetalle", cnn);
                cmd1.CommandType = CommandType.Text;

               
                int maxId = (Convert.ToInt32(cmd1.ExecuteScalar())) + 1;

                cmd.Parameters.AddWithValue("@id", maxId);
                cmd.Parameters.AddWithValue("@idremision", remisiondetalle.IdRemisionEntrada);
                cmd.Parameters.AddWithValue("@idproducto", remisiondetalle.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", remisiondetalle.Cantidad);

                res = cmd.ExecuteNonQuery();

                cnn.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al Insertar", ex);
            }

            return res;
        }

        public int suma(int x, int y)
        {
            int suma = x + y;

            return suma;
        }
    }
}
