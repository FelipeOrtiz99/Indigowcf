using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Indigowcf
{
    [ServiceContract]
    public interface IRemisionService
    {
        [OperationContract]
        int nuevaRemision(Remision remision);

        [OperationContract]
        int actualizarEstado(Remision remision);

        [OperationContract]
        int nuevaRemisionEntrada(RemisionDetalle remisiondetalle);

        [OperationContract]
        int actualizarInventarioFisico(Remision remision, RemisionDetalle remisiondetalle);

        [OperationContract]
        Remision buscarRemision(int idRemision);

        [OperationContract]
        int suma(int x, int y);

    }

    [DataContract]
    public class Remision
    {
        int _Id;
        String _Codigo;
        String _Fecha;
        int _IdProveedor;
        int _IdAlmacen;
        int _Estado;

        [DataMember]
        public int Id { get => _Id; set => _Id = value; }
        [DataMember]
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        [DataMember]
        public string Fecha { get => _Fecha; set => _Fecha = value; }
        [DataMember]
        public int IdProveedor { get => _IdProveedor; set => _IdProveedor = value; }
        [DataMember]
        public int IdAlmacen { get => _IdAlmacen; set => _IdAlmacen = value; }
        [DataMember]
        public int Estado { get => _Estado; set => _Estado = value; }
    }

    [DataContract]
    public class RemisionDetalle
    {
        //int _Id;
        int _IdRemisionEntrada;
        int _IdProducto;
        int _Cantidad;

        //[DataMember]
        //public int Id { get => _Id; set => _Id = value; }
        [DataMember]
        public int IdRemisionEntrada { get => _IdRemisionEntrada; set => _IdRemisionEntrada = value; }
        [DataMember]
        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        [DataMember]
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
    }

}
