using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriasSistemaDeAprovisionamiento;
using System.Threading;

namespace ClienteSistemaDeAprovisionamiento
{
    public partial class FIniciarSesion : Form
    {
        private ConectorServidor conectorServidor;          //Maneja conexiones con el servidor
        private ProveedorSerializable proveedor;            //Almacena informacion del proveedor
        private int error;                                  //Error en el servidor
        public FIniciarSesion(ConectorServidor conectorServidor)
        {
            InitializeComponent();
            this.conectorServidor = conectorServidor;
        }

        private void btnIngresar_Click(object sender, EventArgs e)  //Evento click en boton ingresar
        {
            if (!conectorServidor.estaConectado())  //Si el hilo de escucha no se esta ejecutando
            {
                MessageBox.Show("El servidor no responde, verifique que se encuentre en ejecución");
                error = 1;
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))    //Si el campo de texto o la contraseña estan vacios
                return;

            proveedor = new ProveedorSerializable();
            proveedor.NombreUsuario = txtUsuario.Text;
////////    proveedor.Contrasena = txtContrasena.Text;
            
            ///convertir a byt[]
            proveedor.BytesContr = System.Text.Encoding.UTF8.GetBytes(txtContrasena.Text);
 
            proveedor.Accion = 1;                           //Establece la accion a ejecutar, 1 = Iniciar sesion
            conectorServidor.EnviarAServidor(proveedor);    //Envia el objeto al servidor
            
            //Espera respuesta del servidor
            while (conectorServidor.ProveedorRecibido == null)  //Mientras no haya recibido un proveedor
            {
                Thread.Sleep(200);                              //Espera 200 ms
                if (!conectorServidor.estaConectado()){
                    MessageBox.Show("El servidor no se está ejecutando.");
                    return;
                }
            }

            proveedor = conectorServidor.ProveedorRecibido;
            conectorServidor.ProveedorRecibido = null;

            if (proveedor.Mensaje != null)          //Si hubo algún error
            { 
                MessageBox.Show(proveedor.Mensaje); //Lo muestra
                txtUsuario.Text = null;
                txtContrasena.Text = null;
                proveedor = null;
                return;
            }
            else
            {
                MessageBox.Show(string.Format("Bienvenido {0}", proveedor.NombreUsuario));
                this.Hide();                        //Oculta el formulario
                this.Close();
                this.Dispose();
            }
        }

        public int Error
        {
            get { return error; }
            set { error = value; }
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)   //Evento click en boton crear cuenta
        {
            FRegistro registro = new FRegistro(conectorServidor);   //Crea un nuevo formulario de registro
            registro.ShowDialog();                                  //Muestra el formulario
            
            if (registro.Error == 1)
            {
                error = 1;
                registro.Close();
                registro.Dispose();
                this.Hide();
            }
            registro = null;
        }

        public ProveedorSerializable Proveedor
        {
            get { return proveedor; }
        }

        private void FIniciarSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();        //Oculta el formulario
            this.Close();
            this.Dispose();
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')              //Si presionó enter en el campo de texto
            {
                e.KeyChar = '\0';               //Descarta el caracter
                btnIngresar_Click(null, null);  //Ejecuta accion del evento click en el boton ingresar
            }
        }
    }
}
