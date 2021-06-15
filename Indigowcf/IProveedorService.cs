using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace Indigowcf
{
    [ServiceContract]
    public interface IProveedorService
    {
        [OperationContract]
        int nuevoProveedor(Proveedor proveedor);

        [OperationContract]
        int editarProveedor(Proveedor proveedor);

        [OperationContract]
        int eliminarProveedor(int idProveedor);

        [OperationContract]
        Proveedor buscarProveedor(int idProveedor);

        [OperationContract]
        List<Proveedor> mostrarProveedor();

        [OperationContract]
        DataTable consultarProveedor();
    }

    [DataContract]

    public class Proveedor
    {
        int _Id;
        String _Codigo;
        String _Nombre;
        String _Direccion;
        String _Telefono;

        [DataMember]
        public int Id { get => _Id; set => _Id = value; }
        [DataMember]
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        [DataMember]
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        [DataMember]
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        [DataMember]
        public string Telefono { get => _Telefono; set => _Telefono = value; }
    }

}
