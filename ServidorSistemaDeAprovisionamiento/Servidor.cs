using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriasSistemaDeAprovisionamiento;
using System.Collections;

namespace ServidorSistemaDeAprovisionamiento
{
    public class Servidor
    {
        private Thread hiloEscuchaConexionesEntrantes;      //Hilo para procesar los mensajes entrantes
        private TcpListener oyente;                         //Oyente TCP
        private List<Thread> hilosClientes;
        private List<TcpClient> tcpClientes;
        private bool activo = false;

        public Servidor() {
            oyente = new TcpListener(IPAddress.Any, 50000);                                 //Escucha a cualquier IP por el puerto 50000
            hiloEscuchaConexionesEntrantes = new Thread(new ThreadStart(ejecutarServidor)); //Crea un nuevo hilo con la funcion especificada
            hiloEscuchaConexionesEntrantes.Name = "Hilo escucha conexiones entrantes";
            activo = true;
            hiloEscuchaConexionesEntrantes.Start();                                         //Inicia el hilo
        }

        public void FinalizarSubprocesos() {
            activo = false;


            while (hiloEscuchaConexionesEntrantes != null && hiloEscuchaConexionesEntrantes.ThreadState == ThreadState.Running)   //Si el hilo de escucha de conexiones esta en ejecucion
            {
                oyente.Stop();                      //Fuerza la detencion
                Thread.Sleep(200);
            }

            hiloEscuchaConexionesEntrantes = null;

            for (int i = 0; i < hilosClientes.Count; i++)
            {
                while (hilosClientes[i] != null && hilosClientes[i].ThreadState == ThreadState.Running) //Si el hilo del host i esta en ejecucion
                {
                    tcpClientes[i].Close();         //Fuerza la detencion
                    Thread.Sleep(200);
                } 
                hilosClientes[i] = null;
            }
        }

        public void ejecutarServidor()
        {
            try{
                hilosClientes = new List<Thread>();
                tcpClientes = new List<TcpClient>();
                oyente.Start();             //Inicia el oyente
                //En espera de conexiones permanentemente
                while (activo)
                {
                    //Cuando se conecta algun cliente
                    tcpClientes.Add(oyente.AcceptTcpClient());
                    //Procesa el cliente en un nuevo hilo y sigue en espera de más conexiones
                    hilosClientes.Add( new Thread(new ParameterizedThreadStart(nuevoClienteConectado)));
                    hilosClientes[hilosClientes.Count - 1].Name = "Hilo cliente "+(hilosClientes.Count - 1);
                    hilosClientes[hilosClientes.Count - 1].Start(new KeyValuePair<int,TcpClient>(tcpClientes.Count - 1, tcpClientes[tcpClientes.Count - 1]));
                }
            } catch(Exception){}       //Si hubo un error durante la escucha de conexiones
                
            oyente.Stop();                  //Detiene el oyente

        }
        private void nuevoClienteConectado(Object objCliente)
        {
            int numeroCliente = ((KeyValuePair<int, TcpClient>)objCliente).Key;
            TcpClient tcpCliente = ((KeyValuePair<int, TcpClient>)objCliente).Value;              //El nuevo cliente TCP
            
            NetworkStream flujo = tcpCliente.GetStream();               //Obtiene el flujo del cliente TCP
            MemoryStream flujoMemoriaLectura;                           //Flujo de memoria de lectura
            MemoryStream flujoMemoriaEscritura;                         //Flujo de memoria de escritura
            Object objetoRecibido = null;                               //Objeto que se recibe del cliente
            ProveedorSerializable proveedorRecibido = null;             //Objeto ProveedorSerializable recibido del cliente 
            ProductoSerializable productoRecibido = null;               //Objeto ProductoSerializable recibido del cliente
            BinaryFormatter formatterLectura;                           //Deserializador
            BinaryFormatter formatterEscritura;                         //Serializador
            SolicitudesCliente solicitudes;
                        
            solicitudes = new SolicitudesCliente();  //Procesa el tipo de solicitud requerida por el cliente
            
            byte[] bufferEscritura;                                     //Buffer de escritura
            byte[] bufferLectura;                                       //Buffer de lectura
            
            //En espera de datos del cliente permanentemente
            while (activo)
            {
                try
                {
                    //LEE DATOS
                    bufferLectura = new byte[10000];                        //Buffer que recibe los datos del cliente
                    tcpCliente.Client.Receive(bufferLectura);               //SE BLOQUE HASTA RECIBIR DATOS DEL CLIENTE
                    formatterLectura = new BinaryFormatter();               //Nuevo deserializador
                    flujoMemoriaLectura = new MemoryStream(bufferLectura);  //Obtiene el flujo de memoria del buffer de lectura
                    objetoRecibido = formatterLectura.Deserialize(flujoMemoriaLectura); //Deserializa el objeto recibido
                    //Determina el tipo de objeto recibido
                    if (objetoRecibido.GetType() == typeof(ProveedorSerializable))  
                        proveedorRecibido = (ProveedorSerializable)objetoRecibido;
                    else
                        if (objetoRecibido.GetType() == typeof(ProductoSerializable))
                            productoRecibido = (ProductoSerializable)objetoRecibido;
                    
                    flujoMemoriaLectura.Flush();
                    flujo.Flush();

                    if (proveedorRecibido != null)              //Si se recibio un objeto tipo ProveedorSerializable
                    {
                        switch (proveedorRecibido.Accion)       //Accion requerida por el cliente
                        {
                            case 1:
                                solicitudes.iniciarSesion(proveedorRecibido);
                                break;
                            case 2:
                                solicitudes.crearCuenta(proveedorRecibido);
                                break;
                            case 3:
                                solicitudes.actualizarProveedor(proveedorRecibido);
                                break;
                            case 4:
                                solicitudes.actualizarProductosProve(proveedorRecibido);
                                break;
                            case 5:
                                solicitudes.cambiarContrasena(proveedorRecibido);
                                break;
                        }
                    }
                    else
                        if (productoRecibido != null)                       //Si se recibio un objeto tipo ProductoSerializable
                        {
                            switch (productoRecibido.Accion)                //Accion requerida por el cliente
                            {
                                case 1:
                                    solicitudes.agregarProducto(productoRecibido);
                                    break;
                                case 2:
                                    solicitudes.eliminarProductoProve(productoRecibido);
                                    break;
                                case 3:
                                    solicitudes.listarProductos(productoRecibido);
                                    break;
                            }
                        }
                        
                    flujoMemoriaEscritura = new MemoryStream();             //Nuevo flujo de memoria de escritura
                    formatterEscritura = new BinaryFormatter();             //Nuevo serializador

                    if (proveedorRecibido != null)              //Si se recibio un objeto tipo ProductoSerializable
                    {
                        formatterEscritura.Serialize(flujoMemoriaEscritura, proveedorRecibido); //Serializa el objeto al flujo de memoria de escritura
                        proveedorRecibido = null;
                    }
                    else
                        if (productoRecibido != null)           //Si se recibio un objeto tipo ProductoSerializable
                        {
                            formatterEscritura.Serialize(flujoMemoriaEscritura, productoRecibido); //Serializa el objeto al flujo de memoria de escritura
                            productoRecibido = null;
                        }
                    bufferEscritura = flujoMemoriaEscritura.ToArray();      //Copia el flujo a un array de bytes (al buffer de escritura)
                    tcpCliente.Client.Send(bufferEscritura);                //Envia respuesta al cliente
                    flujoMemoriaEscritura.Flush();
                    flujo.Flush();
                }
                catch (Exception)                 //Si hubo algún error durante el envio o recibimiento de datos con el cliente 
                {
                    MessageBox.Show("Se ha desconectado del host # " + (numeroCliente+1));
                    break;
                }
                bufferLectura = null;
                formatterLectura = null;
                flujoMemoriaLectura = null;
                objetoRecibido = null;
                flujoMemoriaEscritura = null;
                formatterEscritura = null;
                bufferEscritura = null;

            }

            tcpCliente.Close();                     //Cierra la conexion con el cliente TCP
            tcpCliente = null;
            flujo = null;
            solicitudes = null;
        }

    }
}