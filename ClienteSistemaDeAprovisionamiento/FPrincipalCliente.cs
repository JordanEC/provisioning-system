using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriasSistemaDeAprovisionamiento;
using System.Threading;


namespace ClienteSistemaDeAprovisionamiento
{
    public partial class FPrincipalCliente : Form
    {
        private ProveedorSerializable proveedor;                //Almacena información leida de la BD del proveedor logueado
        private ProveedorSerializable proveedorActualizado;     //Almacena información leida de la BD y actualizada del proveedor logueado
        private ProductoSerializable producto;                  //Almacena informacion de un producto
        private ConectorServidor conectorServidor;              //Maneja conexiones con el servidor                

        public FPrincipalCliente()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        }

        private void opcIniciarSesion_Click(object sender, EventArgs e)
        {
            if (conectorServidor != null)  //Si no se ha conectado al servidor
            {
                if (!conectorServidor.estaConectado())
                {
                    //conectorServidor.LecturaThread.Abort();
                    conectorServidor = null;
                    conectorServidor = new ConectorServidor();

                    if (conectorServidor.Error != null)
                    {
                        MessageBox.Show(conectorServidor.Error);
                        conectorServidor = null;
                        return;
                    }
                }
            }
            else
            {
                conectorServidor = new ConectorServidor();

                if (conectorServidor.Error != null)
                {
                    MessageBox.Show(conectorServidor.Error);
                    conectorServidor = null;
                    return;
                }
            }

            FIniciarSesion inicioSesion = new FIniciarSesion(conectorServidor);
            inicioSesion.ShowDialog();

            if (inicioSesion.Error == 1)
            {
                inicioSesion.Close();
                inicioSesion.Dispose();
                inicioSesion = null;
                opcCerrarSesion_Click(null, null);
                return;
            }

            proveedor = inicioSesion.Proveedor;

            if (proveedor == null)
                return;
            
            if (proveedor.Mensaje == null) //Si no hubo errores 
            {
                //Agrega la informacion del proveedor a la tabla proveedor
                tablaProveedor.Rows.Add(new Object[] { proveedor.NombreUsuario, proveedor.Empresa, proveedor.Correo, proveedor.Habilitado });

                for (int i = 0; i < proveedor.Productos.Count; i++) //Agrega los productos del proveedor
                    tablaProductos.Rows.Add(new Object[] { ((ProductoSerializable)proveedor.Productos[i]).IDProducto, ((ProductoSerializable)proveedor.Productos[i]).Descripcion, ((ProductoSerializable)proveedor.Productos[i]).Fabricante, ((ProductoSerializable)proveedor.Productos[i]).Cantidad, ((ProductoSerializable)proveedor.Productos[i]).Precio, ((ProductoSerializable)proveedor.Productos[i]).DescripcionDetallada });
                
                opcIniciarSesion.Enabled = false;
                opcCerrarSesion.Enabled = true;
                lblArticulos.Visible = true;
                lblProveedor.Visible = true;
                tablaProveedor.Visible = true;
                tablaProductos.Visible = true;
                btnActualizarProveedor.Visible = true;
                btnCambiarContrasena.Visible = true;
                btnAgregarProducto.Visible = true;
                btnEliminarProducto.Visible = true;
                btnActualizarProductos.Visible = true;
                tablaProductos.CellValueChanged += new DataGridViewCellEventHandler(tablaProductos_CellValueChanged);   //Maneja el evento de cambio de valor de una celda de la tabla de productos
                tablaProductos.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(tablaProductos_EditingControlShowing);    //Maneja el evento de muestra de cuadro de edicion de una celda
            }
            proveedor.Accion = 0;
            inicioSesion.Close();
            inicioSesion.Dispose();
            inicioSesion = null;
        }

        private void tablaProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(tablaProductos_KeyPress);    //Maneja el evento presionar una tecla de en el cuadro de edicion de una celda
        }

        private void tablaProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tablaProductos.CurrentCell.ColumnIndex == 3)        //Si está editando la columna cantidad
            {
                if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')      //Si no ingresó un número o no presionó la tecla de borrar
                    e.KeyChar = '\0';               //Descarta el carácter ingresado
            }
            else
               if (tablaProductos.CurrentCell.ColumnIndex == 4)     //Si está editando la columna precio
                {
                    if (char.IsNumber(e.KeyChar) || e.KeyChar == '\b')//Si ingresó un número o borró un espacio
                        return;                     //El carácter es válido
                    else
                        if (e.KeyChar == '.')       //Si ingresó un punto (decimales)
                        {
                            if (tablaProductos.CurrentCell.Value.ToString().Contains('.')) //Si ya había ingresado otro punto
                                e.KeyChar = '\0';   //Descarta el carácter ingresado
                        }
                        else                        //No ingresó un punto
                            e.KeyChar = '\0';       //Descarta el carácter ingresado
                }
        }

        private void tablaProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (proveedorActualizado == null)
                proveedorActualizado = proveedor.copiar(proveedor);     //Copia los valores del proveedor original a un nuevo objeto proveedor

            switch(e.ColumnIndex)   //Determina la columna que se editó
            {
                case 1:
                    if (tablaProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) //Si la celda quedó vacía
                    {
                        ((ProductoSerializable)proveedorActualizado.Productos[e.RowIndex]).Descripcion = null;
                        proveedorActualizado.Mensaje = "Celdas vacías";
                    }
                    else
                    {
                        proveedorActualizado.Mensaje = null;
                        ((ProductoSerializable)proveedorActualizado.Productos[e.RowIndex]).Descripcion = (string)tablaProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    }
                    break;
                case 2:
                    if (tablaProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) //Si la celda quedó vacía
                    {
                        ((ProductoSerializable)proveedorActualizado.Productos[e.RowIndex]).Fabricante = null;
                        proveedorActualizado.Mensaje = "Celdas vacías";
                    }
                    else
                    {
                        proveedorActualizado.Mensaje = null;
                        ((ProductoSerializable)proveedorActualizado.Productos[e.RowIndex]).Fabricante = (string)tablaProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    }
                    break;
                case 3:
                    if (tablaProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) //Si la celda quedó vacía
                    {
                        ((ProductoSerializable)proveedorActualizado.Productos[e.RowIndex]).Cantidad = 0;
                        proveedorActualizado.Mensaje = "Celdas vacías";
                    }
                    else
                    {
                        proveedorActualizado.Mensaje = null;
                        try
                        {
                            ((ProductoSerializable)proveedorActualizado.Productos[e.RowIndex]).Cantidad = Int32.Parse(tablaProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        }
                        catch (Exception) { }
                    }
                    break;
                case 4:
                    if (tablaProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) //Si la celda quedó vacía
                    {
                        ((ProductoSerializable)proveedorActualizado.Productos[e.RowIndex]).Precio = 0;
                        proveedorActualizado.Mensaje = "Celdas vacías";
                    }
                    else
                    {
                        try
                        {
                            ((ProductoSerializable)proveedorActualizado.Productos[e.RowIndex]).Precio = decimal.Parse(tablaProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                            proveedorActualizado.Mensaje = null;
                        }
                        catch (Exception)
                        {
                            tablaProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                            proveedorActualizado.Mensaje = "Celdas vacías";
                        }
                    }
                    break;
                case 5:
                    ((ProductoSerializable)proveedorActualizado.Productos[e.RowIndex]).DescripcionDetallada = (string)((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    break;
            }
            ((ProductoSerializable)proveedorActualizado.Productos[e.RowIndex]).Accion = 3; //Accion = 3: si hubo cambios, Accion != 3 no hubo cambios   
        }

        private void opcCerrarSesion_Click(object sender, EventArgs e)
        {
            tablaProveedor.Rows.RemoveAt(0);            //Borra la fila de la tabla proveedor

            while (tablaProductos.Rows.Count != 0)
                tablaProductos.Rows.RemoveAt(0);        //Borra las filas de la table productos

            btnActualizarProveedor.Visible = false;
            btnActualizarProductos.Visible = false;
            btnAgregarProducto.Visible = false;
            btnCambiarContrasena.Visible = false;
            btnEliminarProducto.Visible = false;
            tablaProductos.Visible = false;
            tablaProveedor.Visible = false;
            lblArticulos.Visible = false;
            lblProveedor.Visible = false;
            proveedor = null;
            conectorServidor = null;
            opcIniciarSesion.Enabled = true;
            opcCerrarSesion.Enabled = false;
        }

        private void opcSalir_Click(object sender, EventArgs e)
        {
            if (conectorServidor != null && conectorServidor.LecturaThread != null)
            {
                conectorServidor.Activo = false;        //Desactiva bandera de conexion con el servidor
                conectorServidor.Cliente.Close();       //Fuerza la desconexion

                while (conectorServidor.LecturaThread.ThreadState == ThreadState.Running)   //Espera a que los subprocesos finalicen 
                    Thread.Sleep(200);

                conectorServidor.LecturaThread = null;
            }

            Application.Exit();
        }

        private void btnActualizarProveedor_Click(object sender, EventArgs e)
        {
            if (!conectorServidor.estaConectado())
            {
                MessageBox.Show("No se pudo establecer conexión con el servidor. Ejecute la aplicación servidor e inicie sesión nuevamente.");
                opcCerrarSesion_Click(null, null);
                return;
            }
            string oldNombreUsuario = proveedor.NombreUsuario;  //Copia
            string oldEmpresa = proveedor.Empresa;              //los valores
            string oldCorreo = proveedor.Correo;                //antiguos del proveedor

            if (tablaProveedor.Rows[0].Cells[0].Value.ToString().Equals(oldNombreUsuario) && //Si los datos antiguos
                tablaProveedor.Rows[0].Cells[1].Value.ToString().Equals(oldEmpresa) &&       //son iguales
                tablaProveedor.Rows[0].Cells[2].Value.ToString().Equals(oldCorreo))          //a los datos actualizados
            {
                MessageBox.Show("No se modificó ningún dato.");     //No hace falta actualizar los datos
                return;
            }

            //Las columnas que no se modificaron se marcan como null
            if (tablaProveedor.Rows[0].Cells[0].Value.ToString().Equals(oldNombreUsuario))
                proveedor.NombreUsuario = null;
            else
                proveedor.NombreUsuario = tablaProveedor.Rows[0].Cells[0].Value.ToString();
            if (tablaProveedor.Rows[0].Cells[1].Value.ToString().Equals(oldEmpresa))
                proveedor.Empresa = null;
            else
                proveedor.Empresa = tablaProveedor.Rows[0].Cells[1].Value.ToString();
            if (tablaProveedor.Rows[0].Cells[2].Value.ToString().Equals(oldCorreo))
                proveedor.Correo = null;
            else
                proveedor.Correo = tablaProveedor.Rows[0].Cells[2].Value.ToString();
            
            proveedor.AccionCompletada = false;
            proveedor.Accion = 3;               //Establece la accion requerida, 3 = actualizar proveedor 
            proveedor.Mensaje = null;
            
            conectorServidor.EnviarAServidor(proveedor);        //Envia el objeto al servidor

            while (conectorServidor.ProveedorRecibido == null)  //Mientras no haya recibido un proveedor
                Thread.Sleep(200);                              //Espera 200 ms
            
            proveedor = conectorServidor.ProveedorRecibido;
            conectorServidor.ProveedorRecibido = null;

            if (proveedor.Mensaje != null)  //Si hubo algún error
            {                               //Revierte los cambios
                tablaProveedor.Rows[0].Cells[0].Value = proveedor.NombreUsuario = oldNombreUsuario;
                tablaProveedor.Rows[0].Cells[1].Value = proveedor.Empresa = oldEmpresa;
                tablaProveedor.Rows[0].Cells[2].Value = proveedor.Correo = oldCorreo;
                MessageBox.Show(proveedor.Mensaje);     //Muestra el error
            }
            else
            {   //Copia los datos al objeto proveedor
                proveedor.NombreUsuario = tablaProveedor.Rows[0].Cells[0].Value.ToString();
                proveedor.Empresa = tablaProveedor.Rows[0].Cells[1].Value.ToString();
                proveedor.Correo = tablaProveedor.Rows[0].Cells[2].Value.ToString();
                MessageBox.Show("La información se actualizó correctamente.");
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (!conectorServidor.estaConectado())  //Si el hilo de escucha no se esta ejecutando
            {
                MessageBox.Show("No se pudo establecer conexión con el servidor. Ejecute la aplicación servidor e inicie sesión nuevamente.");
                opcCerrarSesion_Click(null, null);
                return;
            }
            FNuevoProducto agregarNuevoProducto = new FNuevoProducto(conectorServidor, proveedor.IDProveedor); //Crea un formulario para un nuevo producto
            agregarNuevoProducto.ShowDialog();                     //Muestra el formulario
            producto = agregarNuevoProducto.NuevoProducto;
            agregarNuevoProducto.NuevoProducto = null;

            if (agregarNuevoProducto.Error == 1)
            {
                opcCerrarSesion_Click(null, null);
                return;
            }

            if (producto == null)               //Si hubo un error
                return;
            
            agregarNuevoProducto.NuevoProducto = null;
            //Agrega el producto a la tabla
            for (int i = 0; i < tablaProductos.Rows.Count; i++)
                if (int.Parse(tablaProductos.Rows[i].Cells[0].Value.ToString()) == producto.IDProducto)
                {
                    tablaProductos.Rows[i].Cells[3].Value = int.Parse(tablaProductos.Rows[i].Cells[3].Value.ToString()) + producto.Cantidad;
                    ((ProductoSerializable)proveedor.Productos[i]).Cantidad = ((ProductoSerializable)proveedor.Productos[i]).Cantidad + producto.Cantidad;
                    producto = null;
                    agregarNuevoProducto = null;
                    return;
                }
            tablaProductos.Rows.Add(new Object[] {producto.IDProducto, producto.Descripcion, producto.Fabricante, producto.Cantidad, producto.Precio, producto.DescripcionDetallada });
            proveedor.Productos.Add(producto);  //Agrega el producto al proveedor
            producto = null;
            agregarNuevoProducto = null;
        }

        private void btnActualizarProductos_Click(object sender, EventArgs e)
        {
            if (!conectorServidor.estaConectado())  //Si el hilo no se esta ejecutando
            {
                MessageBox.Show("No se pudo establecer conexión con el servidor. Ejecute la aplicación servidor e inicie sesión nuevamente.");
                opcCerrarSesion_Click(null, null);
                return;
            }
            string errores = null;              //Almacena los errores que se producen

            if (proveedorActualizado == null)   //Si no se hizo alguna actualizacion a las celdas de la tabla proveedor
            {
                MessageBox.Show("No se han modificado los datos.");
                return;
            }

            //Comprobar que no hayan quedado celdas en blanco
            if (proveedorActualizado.Mensaje != null)
            {
                MessageBox.Show("No debe dejar celdas en blanco");
                return;
            }

            proveedorActualizado.Accion = 4;    //Estable la accion requerida, 4 = actualizar productos del proveedor

            conectorServidor.EnviarAServidor(proveedorActualizado); //Envia el proveedor al servidor

            while (conectorServidor.ProveedorRecibido == null)      //Mientras no haya recibido un proveedor del servidor
                Thread.Sleep(200);
            
            proveedorActualizado = conectorServidor.ProveedorRecibido;          
            conectorServidor.ProveedorRecibido = null;
            for (int i = 0; i < proveedorActualizado.Productos.Count; i++)
            {
                if (((ProductoSerializable)proveedor.Productos[i]).Accion == 3) //Si la fila se modificó
                {
                    if (((ProductoSerializable)proveedorActualizado.Productos[i]).Mensaje != null)  //Si no hubo mensajes de error
                    {
                        tablaProductos.Rows[i].Cells[1].Value = ((ProductoSerializable)proveedor.Productos[i]).Descripcion;
                        tablaProductos.Rows[i].Cells[2].Value = ((ProductoSerializable)proveedor.Productos[i]).Fabricante;
                        tablaProductos.Rows[i].Cells[3].Value = ((ProductoSerializable)proveedor.Productos[i]).Cantidad;
                        tablaProductos.Rows[i].Cells[4].Value = ((ProductoSerializable)proveedor.Productos[i]).Precio;
                        tablaProductos.Rows[i].Cells[5].Value = ((ProductoSerializable)proveedor.Productos[i]).DescripcionDetallada;
                        errores += "Error al actualizar los datos de la fila "+i+". Compruebe que no se repita algún producto.\n";
                    }
                    else
                    {
                        ((ProductoSerializable)proveedor.Productos[i]).Descripcion = ((ProductoSerializable)proveedorActualizado.Productos[i]).Descripcion;
                        ((ProductoSerializable)proveedor.Productos[i]).Fabricante = ((ProductoSerializable)proveedorActualizado.Productos[i]).Fabricante;
                        ((ProductoSerializable)proveedor.Productos[i]).Cantidad = ((ProductoSerializable)proveedorActualizado.Productos[i]).Cantidad;
                        ((ProductoSerializable)proveedor.Productos[i]).Precio = ((ProductoSerializable)proveedorActualizado.Productos[i]).Precio;
                        ((ProductoSerializable)proveedor.Productos[i]).DescripcionDetallada = ((ProductoSerializable)proveedorActualizado.Productos[i]).DescripcionDetallada;
                    }
                }
            }

            if (errores != null)
                MessageBox.Show(errores);
            else
                MessageBox.Show("Los datos se actualizaron correctamente");
            proveedorActualizado = null;
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (!conectorServidor.estaConectado())  //Si el hilo de escucha no se esta ejecutando
            {
                MessageBox.Show("No se pudo establecer conexión con el servidor. Ejecute la aplicación servidor e inicie sesión nuevamente.");
                opcCerrarSesion_Click(null, null);
                return;
            }
            DialogResult dr = MessageBox.Show(string.Format("¿Desea eliminar el producto {0} ?",             //Confirmacion para borrar el producto
                tablaProductos.CurrentRow.Cells[1].Value), "Eliminar producto", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)     //Si selecciono que si
            {

                if (!conectorServidor.estaConectado())          //Si el hilo no se esta ejecutando
                {
                    MessageBox.Show("El servidor no responde, verifique que se encuentre en ejecución");
                    return;
                }

                if (tablaProductos.Rows.Count == 0)             //Si no hay productos en la tabla
                {
                    MessageBox.Show("No hay más productos.");
                    return;
                }

                producto = (ProductoSerializable)proveedor.Productos[tablaProductos.CurrentRow.Index];  //Obtiene la fila enfocada de la tabla de productos
                producto.Accion = 2;                    //Establece la accion, 2 = eliminar producto
                producto.AccionCompletada = false;
                producto.Mensaje = null;

                conectorServidor.EnviarAServidor(producto);         //Envia el producto al servidor

                while (conectorServidor.ProductoRecibido == null)   //Mientras no haya recibido un producto
                    Thread.Sleep(200);

                producto = conectorServidor.ProductoRecibido;
                conectorServidor.ProductoRecibido = null;

                if (producto.Mensaje != null)
                {
                    MessageBox.Show("Error al eliminar el producto: " + producto.Mensaje);
                    return;
                }

                proveedor.Productos.RemoveAt(tablaProductos.CurrentRow.Index);    //Borra el producto del proveedor
                tablaProductos.Rows.RemoveAt(tablaProductos.CurrentRow.Index);    //Borra la fila enfocada de la tabla de productos
                MessageBox.Show("Se eliminó el producto correctamente.");
                producto = null;
            }
        }

        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            if (!conectorServidor.estaConectado())          //Si el hilo no se esta ejecutando
            {
                MessageBox.Show("No se pudo establecer conexión con el servidor. Ejecute la aplicación servidor e inicie sesión nuevamente.");
                opcCerrarSesion_Click(null, null);
                return;
            }
            
            FCambioContrasena cambiarContrasena = new FCambioContrasena(proveedor, conectorServidor);   //Formulario para cambio de contraseña
            cambiarContrasena.ShowDialog();                 //Muestra el formulario
            if (cambiarContrasena.Error == 1)
            {
                opcCerrarSesion_Click(null, null);
                return;
            }

            proveedor = cambiarContrasena.Proveedor;        
            cambiarContrasena.Proveedor = null;             

            if (proveedor.Mensaje == null && proveedor.Accion == 5)     //Si no hubo errores y si la accion fue asignada (no se canceló)
            {
                MessageBox.Show("Contraseña cambiada correctamente");
                cambiarContrasena.Close();
                cambiarContrasena.Dispose();
                cambiarContrasena = null;
            }
            else
                if (proveedor.Mensaje != null)              //Si hubo errores
                {
                    MessageBox.Show(proveedor.Mensaje);
                    return;
                }
            proveedor.Accion = 0;
        }

        private void FPrincipalCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conectorServidor != null && conectorServidor.LecturaThread != null)
            {
                conectorServidor.Activo = false;
                conectorServidor.Cliente.Close();
                while (conectorServidor.LecturaThread.ThreadState == ThreadState.Running)
                    Thread.Sleep(200);
                conectorServidor.LecturaThread = null;
            }
            Application.Exit();
        }
    
    }
}
