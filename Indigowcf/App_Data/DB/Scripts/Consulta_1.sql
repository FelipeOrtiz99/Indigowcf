SELECT Proveedor.Nombre as Nombre_Proveedor, Producto.Codigo as Codigo_Producto, Producto.Nombre as Nombre_Producto, RemisionEntradaDetalle.Cantidad FROM Proveedor JOIN RemisionEntrada ON Proveedor.Id = RemisionEntrada.IdProveedor JOIN Almacen ON RemisionEntrada.IdAlmacen = Almacen.Id JOIN InventarioFisico ON Almacen.Id = InventarioFisico.IdAlmacen JOIN Producto ON InventarioFisico.IdProducto = Producto.Id JOIN RemisionEntradaDetalle ON Producto.Id = RemisionEntradaDetalle.IdProducto ORDER BY Proveedor.Nombre DESC;


