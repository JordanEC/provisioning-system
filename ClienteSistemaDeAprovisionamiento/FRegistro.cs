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
    public partial class FRegistro : Form
    {
        private ProveedorSerializable nuevoProveedor;       //Almacena informacion del proveedor
        private ConectorServidor conectorServidor;          //Maneja conexiones con el servidor
        private int error = 0;

        public FRegistro(ConectorServidor conectorServidor)
        {
            InitializeComponent();
            this.conectorServidor = conectorServidor;
        }

        public int Error
        {
            get { return error; }
            set { error = value; }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (!conectorServidor.estaConectado())  //Si el hilo de escucha no se esta ejecutando
            {
                MessageBox.Show("No se pudo establecer conexión con el servidor. Ejecute la aplicación servidor e inicie sesión nuevamente.");
                error = 1;
                this.Hide();
                return;
            }
            //Si quedaron campos vacios
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || string.IsNullOrWhiteSpace(txtEmpresa.Text)
                || string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))    //Falta la contrasena
            {
                MessageBox.Show("No deje espacios en blanco");
                return;
            }
            else
            {
                nuevoProveedor = new ProveedorSerializable();
                nuevoProveedor.NombreUsuario = txtNombreUsuario.Text;
                nuevoProveedor.Empresa = txtEmpresa.Text;
                nuevoProveedor.Correo = txtCorreo.Text;
                nuevoProveedor.Contrasena = Encriptador.crearHashMasSalto(txtContrasena.Text);  //Encripta la contraseña con un hash + salt
                nuevoProveedor.Accion = 2;                          //Establece la accion por realizar, 2= registrar usuario
                conectorServidor.EnviarAServidor(nuevoProveedor);   //Envia el nuevo proveedor al servidor

                //Espera respuesta del servidor
                while (conectorServidor.ProveedorRecibido == null)  //Mientras no haya recibido un proveedor del servidor
                    Thread.Sleep(200);                              //Espera 200 ms
                
                if (conectorServidor.ProveedorRecibido.AccionCompletada)    //Si la accion se realizó correctamente
                {
                    MessageBox.Show("Registrado correctamente");
                    nuevoProveedor = null;
                    conectorServidor.ProveedorRecibido = null;
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Fallo en el registro: " + conectorServidor.ProveedorRecibido.Mensaje);
                    nuevoProveedor = null;
                    conectorServidor.ProveedorRecibido = null;
                }
            }
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')  //Si presiono enter
            {
                e.KeyChar = '\0';
                btnRegistrarse_Click(null, null);   //Ejecuta la accion del evento click en el boton registrarse
            }
        }
    }
}
