//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppProducto.proveedorServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Proveedor", Namespace="http://schemas.datacontract.org/2004/07/Indigowcf")]
    [System.SerializableAttribute()]
    public partial class Proveedor : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DireccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelefonoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Codigo {
            get {
                return this.CodigoField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoField, value) != true)) {
                    this.CodigoField = value;
                    this.RaisePropertyChanged("Codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Direccion {
            get {
                return this.DireccionField;
            }
            set {
                if ((object.ReferenceEquals(this.DireccionField, value) != true)) {
                    this.DireccionField = value;
                    this.RaisePropertyChanged("Direccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefono {
            get {
                return this.TelefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.TelefonoField, value) != true)) {
                    this.TelefonoField = value;
                    this.RaisePropertyChanged("Telefono");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="proveedorServiceRef.IProveedorService")]
    public interface IProveedorService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProveedorService/nuevoProveedor", ReplyAction="http://tempuri.org/IProveedorService/nuevoProveedorResponse")]
        int nuevoProveedor(WebAppProducto.proveedorServiceRef.Proveedor proveedor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProveedorService/nuevoProveedor", ReplyAction="http://tempuri.org/IProveedorService/nuevoProveedorResponse")]
        System.Threading.Tasks.Task<int> nuevoProveedorAsync(WebAppProducto.proveedorServiceRef.Proveedor proveedor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProveedorService/editarProveedor", ReplyAction="http://tempuri.org/IProveedorService/editarProveedorResponse")]
        int editarProveedor(WebAppProducto.proveedorServiceRef.Proveedor proveedor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProveedorService/editarProveedor", ReplyAction="http://tempuri.org/IProveedorService/editarProveedorResponse")]
        System.Threading.Tasks.Task<int> editarProveedorAsync(WebAppProducto.proveedorServiceRef.Proveedor proveedor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProveedorService/eliminarProveedor", ReplyAction="http://tempuri.org/IProveedorService/eliminarProveedorResponse")]
        int eliminarProveedor(int idProveedor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProveedorService/eliminarProveedor", ReplyAction="http://tempuri.org/IProveedorService/eliminarProveedorResponse")]
        System.Threading.Tasks.Task<int> eliminarProveedorAsync(int idProveedor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProveedorService/buscarProveedor", ReplyAction="http://tempuri.org/IProveedorService/buscarProveedorResponse")]
        WebAppProducto.proveedorServiceRef.Proveedor buscarProveedor(int idProveedor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProveedorService/buscarProveedor", ReplyAction="http://tempuri.org/IProveedorService/buscarProveedorResponse")]
        System.Threading.Tasks.Task<WebAppProducto.proveedorServiceRef.Proveedor> buscarProveedorAsync(int idProveedor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProveedorService/mostrarProveedor", ReplyAction="http://tempuri.org/IProveedorService/mostrarProveedorResponse")]
        WebAppProducto.proveedorServiceRef.Proveedor[] mostrarProveedor();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProveedorService/mostrarProveedor", ReplyAction="http://tempuri.org/IProveedorService/mostrarProveedorResponse")]
        System.Threading.Tasks.Task<WebAppProducto.proveedorServiceRef.Proveedor[]> mostrarProveedorAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProveedorServiceChannel : WebAppProducto.proveedorServiceRef.IProveedorService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProveedorServiceClient : System.ServiceModel.ClientBase<WebAppProducto.proveedorServiceRef.IProveedorService>, WebAppProducto.proveedorServiceRef.IProveedorService {
        
        public ProveedorServiceClient() {
        }
        
        public ProveedorServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProveedorServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProveedorServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProveedorServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int nuevoProveedor(WebAppProducto.proveedorServiceRef.Proveedor proveedor) {
            return base.Channel.nuevoProveedor(proveedor);
        }
        
        public System.Threading.Tasks.Task<int> nuevoProveedorAsync(WebAppProducto.proveedorServiceRef.Proveedor proveedor) {
            return base.Channel.nuevoProveedorAsync(proveedor);
        }
        
        public int editarProveedor(WebAppProducto.proveedorServiceRef.Proveedor proveedor) {
            return base.Channel.editarProveedor(proveedor);
        }
        
        public System.Threading.Tasks.Task<int> editarProveedorAsync(WebAppProducto.proveedorServiceRef.Proveedor proveedor) {
            return base.Channel.editarProveedorAsync(proveedor);
        }
        
        public int eliminarProveedor(int idProveedor) {
            return base.Channel.eliminarProveedor(idProveedor);
        }
        
        public System.Threading.Tasks.Task<int> eliminarProveedorAsync(int idProveedor) {
            return base.Channel.eliminarProveedorAsync(idProveedor);
        }
        
        public WebAppProducto.proveedorServiceRef.Proveedor buscarProveedor(int idProveedor) {
            return base.Channel.buscarProveedor(idProveedor);
        }
        
        public System.Threading.Tasks.Task<WebAppProducto.proveedorServiceRef.Proveedor> buscarProveedorAsync(int idProveedor) {
            return base.Channel.buscarProveedorAsync(idProveedor);
        }
        
        public WebAppProducto.proveedorServiceRef.Proveedor[] mostrarProveedor() {
            return base.Channel.mostrarProveedor();
        }
        
        public System.Threading.Tasks.Task<WebAppProducto.proveedorServiceRef.Proveedor[]> mostrarProveedorAsync() {
            return base.Channel.mostrarProveedorAsync();
        }
    }
}
