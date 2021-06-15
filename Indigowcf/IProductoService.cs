using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Indigowcf
{

    [ServiceContract]
    public interface IProductoService
    {
        [OperationContract]
        int nuevoProducto(Producto producto);

        [OperationContract]
        int editarProducto(Producto producto);

        [OperationContract]
        int eliminarProducto(int idProducto);

        [OperationContract]
        Producto buscarProducto(int idProducto);

        [OperationContract]
        DataTable consultarProducto();

        [OperationContract]
        List<Producto> mostrarProductos();


    }

    [DataContract]
    public class Producto
    {

        int _Id;
        String _Codigo;
        String _Nombre;
        String _Descripcion;
        int _precioVenta;
        int _stockMinimo;
        int _stockMaximo;

        [DataMember]
        public int Id { get => _Id; set => _Id = value; }
        [DataMember]
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        [DataMember]
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        [DataMember]
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        [DataMember]
        public int PrecioVenta { get => _precioVenta; set => _precioVenta = value; }
        [DataMember]
        public int StockMinimo { get => _stockMinimo; set => _stockMinimo = value; }
        [DataMember]
        public int StockMaximo { get => _stockMaximo; set => _stockMaximo = value; }
    }
}
