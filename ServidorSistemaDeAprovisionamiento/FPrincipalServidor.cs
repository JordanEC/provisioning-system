using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using LibreriasSistemaDeAprovisionamiento;
using System.Threading;


namespace ServidorSistemaDeAprovisionamiento
{
    /// <remarks></remarks>
    public partial class FPrincipalServidor : Form
    {
        //private SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog = SistemaDeAprovisionamiento; User ID=<username>;Password=<password>");
        private SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog = SistemaDeAprovisionamiento; Integrated Security=True");
        private SqlDataAdapter adaptador;                       //Adaptador SQL
        private DataSet dataSet;                                //DataSet
        private DataGridViewButtonColumn verProductos = null;   //Columna de botones
        private ArrayList proveedoresDeLaBD;                    //Almacena los proveedores que se leen de la BD
        private ArrayList proveedoresConCambios;                //Almacena los proveedores que se leen de la BD y los cambios que se realizan
        private Servidor servidor;

        public FPrincipalServidor()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            servidor = new Servidor();             //Servidor en espera de conexiones
            tablaProveedores.CellValueChanged += new DataGridViewCellEventHandler(tablaProveedores_CellValueChanged);   //Evento para detectar los cambios en la tabla de la información de los proveedores
        }

        private void opcVerProveedores_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();                                //Abre la conexion a la BD
                lblProveedores.Visible = true;                  //Hace visible la etiqueta
                lblProductos.Visible = false;                   //Oculta la etiqueta
                lblProveedores.Text = "Usuarios registrados";
                
                while (tablaProveedores.Rows.Count != 0)        //Descarta las filas de
                    tablaProveedores.Rows.RemoveAt(0);          //la tabla de proveedores
                
                tablaProveedores.Visible = true;                //Hace visible la tabla de proveedores
                tablaProductosDeProveedor.Visible = false;      //Hace visible la tabla de productos
                btnGuardar.Visible = true;                      
                btnEliminar.Visible = true;

                adaptador = new SqlDataAdapter("SELECT iDProveedor, nombreUsuario, empresa, correo, habilitado "+
                                               "FROM PROVEEDOR", conexion); //Comando para mostrar todos los proveedores regitrados
                dataSet = new DataSet();                        //Nuevo DataSet
                adaptador.Fill(dataSet, "PROVEEDOR");           //Llena el dataSet con los registros obtenidos
                
                proveedoresDeLaBD = new ArrayList();                    //Almacena los datos de cada proveedor que se han leido de la BD
                proveedoresConCambios = new ArrayList();                //Almacena los datos de cada proveedor que se han leido de la BD y los cambios que se hacen
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)  
                {
                    tablaProveedores.Rows.Add(dataSet.Tables[0].Rows[i].ItemArray);     
                    proveedoresDeLaBD.Add(new ProveedorSerializable(                    //Agrega los datos de cada fila del dataSet a un nuevo objeto tipo ProveedorSerializable
                           (int)tablaProveedores.Rows[i].Cells[0].Value,
                        (string)tablaProveedores.Rows[i].Cells[1].Value,
                        (string)tablaProveedores.Rows[i].Cells[2].Value,
                        (string)tablaProveedores.Rows[i].Cells[3].Value,
                          (bool)tablaProveedores.Rows[i].Cells[4].Value));
                    proveedoresConCambios.Add(new ProveedorSerializable(                //Agrega los datos de cada fila del dataSet a un nuevo objeto tipo ProveedorSerializable
                           (int)tablaProveedores.Rows[i].Cells[0].Value,
                        (string)tablaProveedores.Rows[i].Cells[1].Value,
                        (string)tablaProveedores.Rows[i].Cells[2].Value,
                        (string)tablaProveedores.Rows[i].Cells[3].Value,
                          (bool)tablaProveedores.Rows[i].Cells[4].Value));
                }
                
                //Boton para ver productos
                if (verProductos == null)                                           //Si no se han agregado los botones para ver los productos
                {
                    verProductos = new DataGridViewButtonColumn();                  //Nueva columna de botones
                    verProductos.HeaderText = "Productos";                          //Encabezado de la columna
                    verProductos.FlatStyle = FlatStyle.Standard;                    
                    verProductos.CellTemplate.Style.BackColor = Color.LightGreen;   
                    verProductos.UseColumnTextForButtonValue = true;
                    verProductos.Text = "Ver productos";                            //Texto de cada botón
                    tablaProveedores.Columns.Add(verProductos);                     //Agrega la columna
                }
                
                tablaProveedores.Columns[1].ReadOnly = false;                       //Columna Nombre de usuario: solo lectura
                tablaProveedores.Columns[2].ReadOnly = false;                       //Columna Empresa: solo lectura
                tablaProveedores.Columns[3].ReadOnly = false;                       //Columna Correo: solo lectura
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectarse a la base de datos. El servicio SQL Server no está en ejecucion o la base de datos \"SistemaDeAprovisionamiento\" no existe.");
            }
            conexion.Close();                       //Cierra la conexion a la BD
        }

        private void tablaProveedores_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (lblProveedores.Text.Equals("Usuarios con activación pendiente"))        //Si se encuentra en la opcion de proveedores con activacion pendiente
            {
                ((ProveedorSerializable)proveedoresConCambios[e.RowIndex]).Habilitado = (bool)tablaProveedores.Rows[e.RowIndex].Cells[e.ColumnIndex].Value; //Cambia el valor de la celda
                ((ProveedorSerializable)proveedoresConCambios[e.RowIndex]).Accion = 2;                  //Asigna la accion a realizar, 2= habilitar proveedores pendientes                                
                return;
            }
            //Si se encuentra en la opcion de ver proveedores
            switch (e.ColumnIndex)  //Columna que se cambio
            {
                case 1: ((ProveedorSerializable)proveedoresConCambios[e.RowIndex]).NombreUsuario = (string)tablaProveedores.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                break;
                case 2: ((ProveedorSerializable)proveedoresConCambios[e.RowIndex]).Empresa = (string)tablaProveedores.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                break;
                case 3: ((ProveedorSerializable)proveedoresConCambios[e.RowIndex]).Correo = (string)tablaProveedores.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                break;
                case 4: ((ProveedorSerializable)proveedoresConCambios[e.RowIndex]).Habilitado = (bool)tablaProveedores.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                break;
            }

            ((ProveedorSerializable)proveedoresConCambios[e.RowIndex]).Accion = 3; //Asigna la accion a realizar, 3= actualizar proveedor

        }

        private void tablaProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)   //Si se hizo click en algún boton de la columna de botones de la tabla proveedores
            {
                while (tablaProductosDeProveedor.Rows.Count != 0)       //Descarta las filas de 
                    tablaProductosDeProveedor.Rows.RemoveAt(0);         //la tabla de productos

                tablaProductosDeProveedor.Visible = true;
                lblProductos.Visible = true;
                lblProductos.Text = string.Format("Productos de \"{0}\"", senderGrid.CurrentRow.Cells[1].Value);

                conexion.Open();                                //Abre la conexion a la BD
                adaptador = new SqlDataAdapter(string.Format("SELECT pd.iDProducto, pd.descripcion, pd.fabricante, pv_pd.cantidad, pd.precio, pd.descripcionDetallada " +
                /*Consulta de los productos del proveedor*/  "FROM PROVEEDOR as pv, PRODUCTO as pd, PROVEEDOR_PRODUCTO as pv_pd "+
                                                             "WHERE pd.iDProducto = pv_pd.idProducto and pv_pd.idProveedor = pv.iDProveedor and pv.idProveedor = {0}", 
                                                             tablaProveedores.Rows[e.RowIndex].Cells[tablaProveedores.Columns["idProveedor"].Index].Value.ToString()), conexion);
                dataSet = new DataSet();                                    //Nuevo DataSet
                adaptador.Fill(dataSet, "PRODUCTO");                        //Llena el dataSet con los registros obtenidos
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    tablaProductosDeProveedor.Rows.Add(dataSet.Tables[0].Rows[i].ItemArray);    //Agrega las filas del DataSet a la tabla de productos

                conexion.Close();                               //Cierra la conexion a la BD

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();                                //Abre la conexion a la BD

                for (int i = 0; i < proveedoresConCambios.Count; i++)
                {
                    if (((ProveedorSerializable)proveedoresConCambios[i]).Accion == 3)  //Si la accion es actualizar proveedores en opcion ver proveedores
                    {
                        int iDProveedor = ((ProveedorSerializable)proveedoresConCambios[i]).IDProveedor;            //Obtiene
                        string nombreDeUsuario = ((ProveedorSerializable)proveedoresConCambios[i]).NombreUsuario;   //los
                        string empresa = ((ProveedorSerializable)proveedoresConCambios[i]).Empresa;                 //valores
                        string correo = ((ProveedorSerializable)proveedoresConCambios[i]).Correo;                   //de las
                        bool habilitado = ((ProveedorSerializable)proveedoresConCambios[i]).Habilitado;             //celdas
                        adaptador = new SqlDataAdapter();                           //Nuevo adaptador
                        adaptador.UpdateCommand = new SqlCommand(string.Format("UPDATE PROVEEDOR SET nombreUsuario = '{0}', empresa = '{1}', correo= '{2}', habilitado = {3} "+
                        /*Actualizar el registro con los nuevos valores*/      "WHERE iDProveedor = {4}", nombreDeUsuario, empresa, correo, habilitado ? 1:0, iDProveedor), conexion);
                        adaptador.UpdateCommand.ExecuteNonQuery();              //Ejecuta el comando
                        ((ProveedorSerializable)proveedoresConCambios[i]).AccionCompletada = true;  //La accion se realizó correctamente
                    }
                    else
                        if (((ProveedorSerializable)proveedoresConCambios[i]).Accion == 2)  //actualizar proveedores con activacion pendiente
                        {
                            int iDProveedor = ((ProveedorSerializable)proveedoresConCambios[i]).IDProveedor;
                            bool habilitado = ((ProveedorSerializable)proveedoresConCambios[i]).Habilitado;
                            adaptador = new SqlDataAdapter();
                            adaptador.UpdateCommand = new SqlCommand(string.Format("UPDATE PROVEEDOR "+
                                /*Actualizar el registro con el nuevo valor*/      "SET habilitado = {0} " +
                                                                                   "WHERE iDProveedor = {1}", habilitado ? 1 : 0, iDProveedor), conexion);
                            adaptador.UpdateCommand.ExecuteNonQuery();          //Ejecuta el comando
                            ((ProveedorSerializable)proveedoresConCambios[i]).AccionCompletada = true;  //La accion se realizó correctamente
                        }
                }
                
                MessageBox.Show("Se actualizó correctamente la información");
                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexion.Close();                   //Cierra la conexion a la BD

            if (lblProveedores.Text.Equals("Usuarios con activación pendiente"))    //Si se encuentra en la opcion habilitar nuevas cuentas
                opcHabilitarNuevasCuentas_Click(null, null);            //Actualiza los valores de la opcion habilitar nuevas cuentas
            else
                opcVerProveedores_Click(null, null);                    //Actualiza los valores de la opcion ver proveedores
                    
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(string.Format("¿Desea eliminar el usuario {0} ?",             //Confirmacion para borrar al usuario
                tablaProveedores.CurrentRow.Cells[1].Value), "Eliminar cuenta", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)     //Si selecciono que si
            {
                try
                {
                    conexion.Open();                    //Abre la conexion a la BD
                    adaptador = new SqlDataAdapter();   //Nuevo adaptador
                    adaptador.UpdateCommand = new SqlCommand(string.Format("DELETE FROM PROVEEDOR "+
                    /*Comando para borrar la fila seleccionada*/           "WHERE iDProveedor = {0}", tablaProveedores.CurrentRow.Cells[0].Value), conexion);
                    adaptador.UpdateCommand.ExecuteNonQuery();                  //Ejecuta el comando
                    tablaProveedores.Rows.Remove(tablaProveedores.CurrentRow);  //Borra la fila de la tabla
                    MessageBox.Show("Se eliminó correctamente el usuario");

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conexion.Close();                   //Cierra la conexion a la BD
            }

        }

        private void opcHabilitarNuevasCuentas_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();                            //Abre la conexion a la BD
                while (tablaProveedores.Rows.Count != 0)    //Descarta las filas de la tabla proveedores
                    tablaProveedores.Rows.RemoveAt(0);

                tablaProveedores.Visible = true;
                lblProveedores.Visible = true;
                lblProveedores.Text = "Usuarios con activación pendiente";
                lblProductos.Visible = false;
                btnGuardar.Visible = true;
                btnEliminar.Visible = false;
                tablaProductosDeProveedor.Visible = false;

                adaptador = new SqlDataAdapter("SELECT pv.idProveedor, pv.nombreUsuario, pv.empresa, pv.correo, pv.habilitado " +
                    /*Muestra los proveedores*/"FROM PROVEEDOR as pv where pv.habilitado = 0", conexion);
                //con la cuenta sin habilitar
                dataSet = new DataSet();                        //Nuevo DataSet
                adaptador.Fill(dataSet, "PROVEEDOR");           //Llena el DataSet con el resultado de la consulta
                proveedoresDeLaBD = new ArrayList();            //Almacena los proveedores que se leen de la BD
                proveedoresConCambios = new ArrayList();        //Almacena los proveedores que se leen de la BD y los cambios que se realizan
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    tablaProveedores.Rows.Add(dataSet.Tables[0].Rows[i].ItemArray);
                    proveedoresDeLaBD.Add(new ProveedorSerializable(            //Agrega los datos de cada fila del dataSet a un nuevo objeto tipo ProveedorSerializable
                           (int)tablaProveedores.Rows[i].Cells[0].Value,
                        (string)tablaProveedores.Rows[i].Cells[1].Value,
                        (string)tablaProveedores.Rows[i].Cells[2].Value,
                        (string)tablaProveedores.Rows[i].Cells[3].Value,
                          (bool)tablaProveedores.Rows[i].Cells[4].Value));
                    proveedoresConCambios.Add(new ProveedorSerializable(        //Agrega los datos de cada fila del dataSet a un nuevo objeto tipo ProveedorSerializable
                           (int)tablaProveedores.Rows[i].Cells[0].Value,
                        (string)tablaProveedores.Rows[i].Cells[1].Value,
                        (string)tablaProveedores.Rows[i].Cells[2].Value,
                        (string)tablaProveedores.Rows[i].Cells[3].Value,
                          (bool)tablaProveedores.Rows[i].Cells[4].Value));
                }

                if (tablaProveedores.Columns.Contains(verProductos))        //Si la tabla contiene una columna de botones
                {
                    tablaProveedores.Columns.Remove(verProductos);          //La elimina
                    verProductos = null;
                }

                tablaProveedores.Columns[1].ReadOnly = true;                //Columna Nombre de usuario: solo lectura
                tablaProveedores.Columns[2].ReadOnly = true;                //Columna Empresa: solo lectura
                tablaProveedores.Columns[3].ReadOnly = true;                //Columna Correo: solo lectura

                conexion.Close();                    //Cierra la conexion a la BD
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectarse a la base de datos. El servicio SQL Server no está en ejecucion o la base de datos \"SistemaDeAprovisionamiento\" no existe.");
            }
        }

        private void opcSalir_Click(object sender, EventArgs e)
        {
            servidor.FinalizarSubprocesos();
            Application.Exit();
        }

        private void FPrincipalServidor_FormClosed(object sender, FormClosedEventArgs e)
        {
            servidor.FinalizarSubprocesos();
            Application.Exit();
        }

    }
}
