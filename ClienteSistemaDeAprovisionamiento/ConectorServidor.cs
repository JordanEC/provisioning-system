using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using LibreriasSistemaDeAprovisionamiento;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ClienteSistemaDeAprovisionamiento
{
    public class ConectorServidor       //Maneja conexiones con el servidor
    {
        private TcpClient cliente;                          //Cliente TCP (Servidor)
        private NetworkStream flujo;                        //Flujo para recibir datos
        private IPEndPoint ipServidor;                      //IP del servidor
        private Thread lecturaThread;                       //Hilo para procesar mensajes entrantes
        private MemoryStream flujoMemoriaLectura;           //Flujo de memoria de lectura
        private MemoryStream flujoMemoriaEscritura;         //Flujo de memoria de escritura
        private Object objetoRecibido;                      //Objeto recibido del servidor
        private ProveedorSerializable proveedorRecibido;    //Proveedor recibido del servidor
        private ProductoSerializable productoRecibido;      //Producto recibido del servidor
        private BinaryFormatter formatterLectura;           //Deserializador
        private BinaryFormatter formatterEscritura;         //Serializador
        private byte[] bufferLectura;                       //Buffer de lectura
        private byte[] bufferEscritura;                     //Buffer de escritura
        private string error;
        private bool activo = false;

        public ConectorServidor()
        {
            proveedorRecibido = null;
            productoRecibido = null;
            objetoRecibido = null;
            try
            {
                ipServidor = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 50000);
                //ipServidor = new IPEndPoint(IPAddress.Parse("192.168.1.3"), 50000);
                cliente = new TcpClient();
                cliente.Connect(ipServidor);
                flujo = cliente.GetStream();
                lecturaThread = new Thread(new ThreadStart(ejecutarCliente));
                lecturaThread.Start();
                activo = true;
            }
            catch (Exception)
            {
                Error = "No se pudo establecer conexión con el servidor, ejecute la aplicación servidor.";
            }
        }

        public TcpClient Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public string Error {
            get{ return error; }
            set { error = value; }
        }

        public void ejecutarCliente()
        {
            //En espera de respuestas del servidor permanentemente
            while (true)
            {
                try
                {
                    bufferLectura = new byte[10000];                        //Buffer de lectura
                    if (!cliente.Connected)
                    {
                        MessageBox.Show("Error al enviar la petición al servidor, el servidor no responde");
                        break;
                    }
                    cliente.Client.Receive(bufferLectura);                  //Se bloquea hasta recibir respuesta del servidor
                    formatterLectura = new BinaryFormatter();               //Deserializador
                    flujoMemoriaLectura = new MemoryStream(bufferLectura);  //Flujo de memoria de lectura
                    objetoRecibido = formatterLectura.Deserialize(flujoMemoriaLectura); //Deserializa el objeto recibido
                    //Determina el tipo de objeto recibido
                    if (objetoRecibido.GetType() == typeof(ProveedorSerializable))
                        ProveedorRecibido = (ProveedorSerializable)objetoRecibido;
                    else
                        if (objetoRecibido.GetType() == typeof(ProductoSerializable))
                           ProductoRecibido = (ProductoSerializable)objetoRecibido;
                    bufferLectura = null;
                    formatterLectura = null;
                    flujoMemoriaLectura = null;
                    objetoRecibido = null;
                }
                
                catch (Exception) //Si hubo algún error durante la escucha del servidor
                {
                    MessageBox.Show("Se ha perdido la conexión con el servidor.");
                    activo = false;
                    break;
                }
            }

            cliente.Close();       //Cirra la conexion con el cliente TCP (Servidor)
        }

        public void EnviarAServidor(Object objetoEnviado)   //Envia un objeto al servidor
        {
            if (!estaConectado())
                return;
            
            flujoMemoriaEscritura = new MemoryStream();                         //Nuevo flujo de memoria de escritura
            formatterEscritura = new BinaryFormatter();                         //Nuevo serializador
            formatterEscritura.Serialize(flujoMemoriaEscritura, objetoEnviado); //Serializa el objeto
            bufferEscritura = flujoMemoriaEscritura.ToArray();                  //Convierte el objeto a un arreglo de bytes y lo copia en el buffer de escritura
            cliente.Client.Send(bufferEscritura);                               //Envia el buffer al servidor
            flujoMemoriaEscritura.Flush();
            flujoMemoriaEscritura = null;
            formatterEscritura = null;
            bufferEscritura = null;
        }

        public ProveedorSerializable ProveedorRecibido
        {
            get { return proveedorRecibido;}
            set { proveedorRecibido = value; }
        }

        public ProductoSerializable ProductoRecibido
        {
            get { return productoRecibido; }
            set { productoRecibido = value; }
        }

        public bool estaConectado() {                               //Determina si el servidor esta ejecutando
            return lecturaThread != null && lecturaThread.IsAlive;  //el hilo de escucha de conexiones o si ya acabó
        }

        public Thread LecturaThread
        {
            get { return lecturaThread; }
            set { lecturaThread = value; }
        }

    }
}