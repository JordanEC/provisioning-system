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
    public partial class FCambioContrasena : Form
    {
        private ConectorServidor conectorServidor;      //Maneja conexiones con el servidor
        private ProveedorSerializable proveedor;        //Informacion del proveedor
        private int error = 0;

        public FCambioContrasena(ProveedorSerializable proveedor, ConectorServidor conectorServidor)
        {
            InitializeComponent();
            this.conectorServidor = conectorServidor;
            this.proveedor = proveedor;                 
        }

        public int Error
        {
            get { return error; }
            set { error = value; }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!conectorServidor.estaConectado())
            {
                MessageBox.Show("No se pudo establecer conexión con el servidor. Ejecute la aplicación servidor e inicie sesión nuevamente.");
                error = 1;
                this.Close();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNuevaContrasena.Text))     //Si el campo de la nueva contraseña esta vacio
            {
                MessageBox.Show("Debe ingresar la nueva contraseña");
                return;
            }

            proveedor.Accion = 5;                       //Asigna la accion a realizar, 5 = cambiar contraseña
            proveedor.Contrasena = Encriptador.crearHashMasSalto(txtNuevaContrasena.Text);  //Encripta la contraseña con un hash + salt
            proveedor.Mensaje = null;
            proveedor.AccionCompletada = false;

            conectorServidor.EnviarAServidor(proveedor);            //Envia el proveedor al servidor

            //Espera respuesta del servidor
            while (conectorServidor.ProveedorRecibido == null)      //Mientras el conector no haya recibido un proveedor
            {
                Thread.Sleep(200);                                  //Espera 200 ms
            }

            proveedor = conectorServidor.ProveedorRecibido;
            conectorServidor.ProveedorRecibido = null;
            this.Hide();                                //Oculta el formulario
        }

        public ProveedorSerializable Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }

        private void txtNuevaContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')                  //Si presionó enter
            {
                e.KeyChar = '\0';                   //Asigna carácter nulo
                btnConfirmar_Click(null, null);     //Llama al evento de hacer click en el boton cofirmar
            }
        }

        private void FCambioContrasena_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtNuevaContrasena;    //Establece el foco
            txtNuevaContrasena.Focus();                 //en el campo de texto
        }
    }
}
