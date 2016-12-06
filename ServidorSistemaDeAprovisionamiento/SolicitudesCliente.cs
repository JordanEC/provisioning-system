using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriasSistemaDeAprovisionamiento;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ServidorSistemaDeAprovisionamiento
{
    public class SolicitudesCliente
    {
        private SqlConnection conexion;     //Conector con BD
        private SqlDataAdapter adaptador;   //Adaptador SQL
        private SqlDataReader reader;       //Lector de registros
        private DataSet dataSet;            //DataSet

        public SolicitudesCliente()
        {
            conexion = new SqlConnection("Data Source=localhost;Initial Catalog = SistemaDeAprovisionamiento; Integrated Security=True");
        }
        public void iniciarSesion(ProveedorSerializable proveedorRecibido)
        {
            Object[] fila;              //Fila leida de la BD
            try
            {
                conexion.Open();            //Abre la conexion con la BD
                adaptador = new SqlDataAdapter(string.Format("SELECT iDProveedor, nombreUsuario, empresa, correo, habilitado, contrasena "+
                /*Comando seleccionar proveedor*/            "FROM PROVEEDOR WHERE nombreUsuario = '{0}' OR correo = '{0}'", 
                                                             proveedorRecibido.NombreUsuario), conexion);
                dataSet = new DataSet();                            //Nuevo DataSet
                adaptador.Fill(dataSet, "PROVEEDOR");               //Llena el dataSet con el registro obtenido
                if (dataSet.Tables[0].Rows.Count != 1)              //Si no se obtuvo un registro
                    throw new Exception("El usuario no existe");    //El usuario o correo ingredado no se encuentra registrado

                fila = dataSet.Tables[0].Rows[0].ItemArray;         //Obtiene la fila con los datos del proveedor
//////////////  if (Encriptador.validarContrasena(proveedorRecibido.Contrasena, (string)fila[5]))   //Si la contraseña ngresada es válida
                if (Encriptador.validarContrasena(proveedorRecibido.BytesContr, (string)fila[5]))   //Si la contraseña ngresada es válida
                {
                    if (proveedorRecibido.Habilitado = (bool)fila[4])       //Si la cuenta está habilitada
                    {
                        proveedorRecibido.IDProveedor = (int)fila[0];       //Copia los
                        proveedorRecibido.NombreUsuario = (string)fila[1];  //datos de
                        proveedorRecibido.Empresa = (string)fila[2];        //la BD
                        proveedorRecibido.Correo = (string)fila[3];         //al objeto proveedorRecibido
                        adaptador = new SqlDataAdapter(String.Format("SELECT PD.iDProducto, PD.descripcion, PD.fabricante, PV_PD.cantidad, PD.precio, PD.descripcionDetallada, PV.iDProveedor " +
                        /*Obtiene los productos del proveedor*/      "FROM PROVEEDOR AS PV, PRODUCTO AS PD, PROVEEDOR_PRODUCTO AS PV_PD "+
                                                                     "WHERE PD.iDProducto = PV_PD.iDProducto AND PV_PD.iDProveedor = PV.iDProveedor AND PV.iDProveedor = {0}", proveedorRecibido.IDProveedor), conexion);
                        dataSet = new DataSet();                            //Nuevo DataSet
                        adaptador.Fill(dataSet, "PRODUCTO");                //Llena el DataSet con las filas de productos
                        if (dataSet.Tables[0].Rows.Count != 0)              //Si no se obtuvieron 0 filas
                        {
                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)  //Para cada fila de productos
                            {
                                fila = dataSet.Tables[0].Rows[i].ItemArray;   //Obtiene la fila con los datos del producto 
                                proveedorRecibido.Productos.Add(new ProductoSerializable((int)fila[0], 
                                                                                      (string)fila[1], //Agrega un nuevo objeto
                                                                                      (string)fila[2],
                                                                                         (int)fila[3], //ProductoSerializable al 
                                                                                     (decimal)fila[4], 
                                                                                      (string)fila[5], //proveedor
                                                                                       (int)fila[6]));
                            }
                        }
                        proveedorRecibido.AccionCompletada = true;      //La accion se completo correctamente
                    }
                    else            //Si la cuenta no esta habilitada
                        proveedorRecibido.Mensaje = "Su cuenta no ha sido habilitada por el administrador";
                }
                else                //Si la contraseña es incorrecta
                    proveedorRecibido.Mensaje = "Contraseña incorrecta";
////////        proveedorRecibido.Contrasena = null;        //Borra la contraseña del objeto
                proveedorRecibido.BytesContr = null;
            }
            catch (Exception e)
            {
                proveedorRecibido.Mensaje = e.Message;
            }
            conexion.Close();           //Cierra la conexion con la BD
            
        }

        public void crearCuenta(ProveedorSerializable nuevoProveedor)
        {
            conexion.Open();            //Abre la conexion con la BD
            try
            {
                adaptador = new SqlDataAdapter();       //nuevo adaptador SQL
                adaptador.InsertCommand = new SqlCommand(string.Format("INSERT INTO PROVEEDOR (nombreUsuario, empresa, correo, contrasena) "+
                /*Comando registrar nueva cuenta de proveedor*/        "VALUES ('{0}', '{1}', '{2}', '{3}')", nuevoProveedor.NombreUsuario, 
                                                                       nuevoProveedor.Empresa, nuevoProveedor.Correo, nuevoProveedor.Contrasena), conexion);
                adaptador.InsertCommand.ExecuteNonQuery();      //Ejecuta el comando
                nuevoProveedor.AccionCompletada = true;         //La accion se completo correctamente
            }
            catch (Exception e) {                       //Hubo un error en la ejecucion del comando
                nuevoProveedor.Mensaje = e.Message;
            }
            conexion.Close();           //Cierra la conexion con la BD
        }

        public void actualizarProveedor(ProveedorSerializable actProveedor)
        {
            conexion.Open();                //Abre la conexion con la BD
            string cadenaConsulta = "UPDATE PROVEEDOR SET  WHERE iDProveedor = " + actProveedor.IDProveedor;
            string columnas = "";           //columnas que se modificaron
            int columnasPorActualizar = 0;  //Cantidad de columnas que se modificaron
            int comas = 0;                  //Total de comas
            
            if (actProveedor.NombreUsuario != null)     //Si la columna NombreUsuario se modifico
                columnasPorActualizar++;                //Incrementa el total de columnas por actualizar
            if (actProveedor.Empresa != null)           //Si la columna Empresa se modifico
                columnasPorActualizar++;                //Incrementa el total de columnas por actualizar
            if (actProveedor.Correo != null)            //Si la columna Correo se modifico
                columnasPorActualizar++;                //Incrementa el total de columnas por actualizar

            if (actProveedor.NombreUsuario != null)     
            {
                if (comas == columnasPorActualizar - 1)     //Si el total de comas colocadas es el total de columnas - 1
                    columnas = string.Concat(columnas, "nombreUsuario = '"+actProveedor.NombreUsuario+"'");     //Concatena sin coma al final
                else
                {
                    columnas = string.Concat(columnas, "nombreUsuario = '"+actProveedor.NombreUsuario + "', "); //Concatena con coma al final
                    comas++;    //Incrementa el total de comas colocadas
                }
            }

            if (actProveedor.Empresa != null)
            {
                if (comas == columnasPorActualizar - 1)     //Si el total de comas colocadas es el total de columnas - 1
                    columnas = string.Concat(columnas, "empresa = '" + actProveedor.Empresa + "'");             //Concatena sin coma al final
                else
                {
                    columnas = string.Concat(columnas, "empresa = '" + actProveedor.Empresa + "', ");           //Concatena con coma al final
                    comas++;
                }
            }

            if (actProveedor.Correo != null)    
            {
                if (comas == columnasPorActualizar - 1)     //Si el total de comas colocadas es el total de columnas - 1
                    columnas = string.Concat(columnas, "correo = '" + actProveedor.Correo + "'");               //Concatena sin coma al final
                else
                {
                    columnas = string.Concat(columnas, "correo = '" + actProveedor.Correo + "', ");             //Concatena con coma al final
                    comas++;
                }
            }

            cadenaConsulta = cadenaConsulta.Insert(cadenaConsulta.IndexOf("SET") + 4, columnas);    //Inserta las columnas y sus nuevos valores a la cadena de la consulta

            try
            {
                adaptador = new SqlDataAdapter();                                       //Nuevo adaptador SQL
                adaptador.UpdateCommand = new SqlCommand(cadenaConsulta, conexion);     //Asigna el comando de actualizacion
                adaptador.UpdateCommand.ExecuteNonQuery();                              //Ejecuta el comando
                actProveedor.AccionCompletada = true;                                   //La accion se completo correctamente
            }
            catch (Exception e) {                       //Hubo un error al ejecutar la consulta
                actProveedor.Mensaje = e.Message;
            }
            conexion.Close();       //Cierra la conexion con la BD
        }

        public void cambiarContrasena(ProveedorSerializable camContrasProvee)
        {
            conexion.Open();        //Abre la conexion con la BD
            try
            {
                adaptador = new SqlDataAdapter();       
                adaptador.UpdateCommand = new SqlCommand(string.Format("UPDATE PROVEEDOR "+
                /*Comando actualizar la contraseña del proveedor*/     "SET contrasena = '{0}' " +
                                                                       "WHERE iDProveedor = {1}", camContrasProvee.Contrasena, 
                                                                       camContrasProvee.IDProveedor), conexion);
                adaptador.UpdateCommand.ExecuteNonQuery();      //Ejecuta el comando
                camContrasProvee.AccionCompletada = true;       //La accion se completo correctamente
            }
            catch(Exception e)              //Hubo un error al ejecutar la accion
            {
                camContrasProvee.Mensaje = e.Message;
            }

            camContrasProvee.Contrasena = null;
            conexion.Close();       //Cierra la conexion con la BD
        }

        public void agregarProducto(ProductoSerializable nuevoProducto) 
        {
            conexion.Open();            //Abre la conexion con la BD
            try
            {
                adaptador = new SqlDataAdapter();
                adaptador.InsertCommand = new SqlCommand(string.Format("EXECUTE Insertar_Producto '{0}', '{1}', {2}, {3}, '{4}', {5}", nuevoProducto.Descripcion, nuevoProducto.Fabricante,
                /*Comando insertar nuevo producto*/                 nuevoProducto.Cantidad, nuevoProducto.Precio, nuevoProducto.DescripcionDetallada, nuevoProducto.IDProveedor), conexion);
                
                adaptador.InsertCommand.ExecuteNonQuery();      //Ejecuta el comando
                
                reader = new SqlCommand(string.Format("SELECT PD.iDProducto "+
                                                      "FROM PRODUCTO as PD "+
                /*Comando obtener el produto*/        "WHERE PD.descripcion = '{0}' AND PD.fabricante = '{1}' AND "+
                /*recien ingresado a la BD*/          "PD.descripcionDetallada = '{2}'", nuevoProducto.Descripcion, 
                                                      nuevoProducto.Fabricante, nuevoProducto.DescripcionDetallada), conexion).ExecuteReader();
                while (reader.Read())
                    nuevoProducto.IDProducto = (int)reader["iDProducto"];   //Lee el iD que se asignó al producto

                reader.Close();                     //Cierra el lector
                nuevoProducto.AccionCompletada = true;                  //Accion completada correctamente
            }
            catch (Exception e)             //Hubo un error al insertar el producto
            {
                nuevoProducto.Mensaje = e.Message;
                nuevoProducto.IDProducto = 0;
            }
            conexion.Close();               //Cierra la conexion con la BD
        }

        public void eliminarProductoProve(ProductoSerializable eliminarProducto) 
        {
            conexion.Open();                //Abre la conexion con la BD

            try
            {
                adaptador = new SqlDataAdapter();
                adaptador.DeleteCommand = new SqlCommand(string.Format("DELETE FROM PROVEEDOR_PRODUCTO "+
                /*Comando borrar registro del proveedor*/              "WHERE iDProveedor = {0} AND "+
                                                                       "iDProducto = {1}", eliminarProducto.IDProveedor, 
                                                                       eliminarProducto.IDProducto), conexion);
                adaptador.DeleteCommand.ExecuteNonQuery();      //Ejecutar comando
                eliminarProducto.AccionCompletada = true;       //La accion se completo correctamente
            }
            catch (Exception e)             //Hubo un error en la ejecucion del comando
            {
                eliminarProducto.Mensaje = e.Message;
            }

            conexion.Close();               //Cierra la conexion con la BD
        }

        public void actualizarProductosProve(ProveedorSerializable actualizarProductos)
        {
            conexion.Open();                //Abre la conexion con la BD
            for (int i = 0; i < actualizarProductos.Productos.Count; i++)   //Para cada producto del proveedor
            {
                if (((ProductoSerializable)actualizarProductos.Productos[i]).Accion == 3)   //Si hubo modificaciones
                {
                    try
                    {
                        adaptador = new SqlDataAdapter();
                        //Obtiene los valores modificados
                        string descripcion = ((ProductoSerializable)actualizarProductos.Productos[i]).Descripcion;
                        string fabricante = ((ProductoSerializable)actualizarProductos.Productos[i]).Fabricante;
                        string descripcionDetallada = ((ProductoSerializable)actualizarProductos.Productos[i]).DescripcionDetallada;
                        int cantidad = ((ProductoSerializable)actualizarProductos.Productos[i]).Cantidad;
                        int iDProducto = ((ProductoSerializable)actualizarProductos.Productos[i]).IDProducto;
                        decimal precio = ((ProductoSerializable)actualizarProductos.Productos[i]).Precio;
                        
                        adaptador.UpdateCommand = new SqlCommand(string.Format("UPDATE PRODUCTO "+
                        /*Comando actualizar fila de productos*/               "SET descripcion = '{0}', fabricante = '{1}', "+
                                                                               "precio = {2}, descripcionDetallada = '{3}' "+
                                                                               "WHERE iDProducto = {4}", descripcion, fabricante,  
                                                                               precio, descripcionDetallada, iDProducto), conexion);
                        adaptador.UpdateCommand.ExecuteNonQuery();          //Ejecuta el comando
                        adaptador.UpdateCommand = new SqlCommand(string.Format("UPDATE PROVEEDOR_PRODUCTO "+
                        /*Comando actualizar cantidad*/                        "SET cantidad = {0} WHERE iDProducto = {1} "+
                                                                               "AND iDProveedor = {2}", cantidad, iDProducto, actualizarProductos.IDProveedor), conexion);
                        adaptador.UpdateCommand.ExecuteNonQuery();          //Ejecuta el comando

                        ((ProductoSerializable)actualizarProductos.Productos[i]).AccionCompletada = true;   //La accion se completo correctamente
                    }
                    catch (Exception e)         //Si hubo algun error durante con la ejecucion del comando
                    {
                        ((ProductoSerializable)actualizarProductos.Productos[i]).Mensaje = e.Message;
                    }
                }
            }
            actualizarProductos.AccionCompletada = true;        //La accion se completó
            conexion.Close();           //Cierra la conexion con la BD
        }

        public void listarProductos(ProductoSerializable listarProductos)
        {
            Object[] fila;              //Fila leida de la BD
            try
            {
                conexion.Open();            //Abre la conexion con la BD
                adaptador = new SqlDataAdapter("SELECT pr.iDProducto, pr.descripcion, pr.fabricante, pr.precio, pr.descripcionDetallada "+
                                               "FROM PRODUCTO as pr", conexion);
                dataSet = new DataSet();                            //Nuevo DataSet
                adaptador.Fill(dataSet, "PRODUCTO");               //Llena el dataSet con el registro obtenido
                if (dataSet.Tables[0].Rows.Count == 0)              //Si no se obtuvieron registros
                    throw new Exception("No hay productos");        //No hay productos registrados

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)  //Para cada fila de productos
                {
                    fila = dataSet.Tables[0].Rows[i].ItemArray;   //Obtiene la fila con los datos del producto 
                    listarProductos.ProductosRegistrados.Add(new ProductoSerializable((int)fila[0],
                                                                          (string)fila[1],  //Agrega un nuevo objeto
                                                                          (string)fila[2],
                                                                                        0,  //ProductoSerializable a 
                                                                         (decimal)fila[3],
                                                                          (string)fila[4],  //la lista de productos
                                                                                      0));
               }
                
                listarProductos.AccionCompletada = true;      //La accion se completo correctamente
            }
            catch (Exception e)
            {
                listarProductos.Mensaje = e.Message;
            }
            conexion.Close();           //Cierra la conexion con la BD
        }
    }
}