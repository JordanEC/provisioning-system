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
    public partial class FNuevoProducto : Form
    {
        private ProductoSerializable nuevoProducto, productosRegistrados;
        private ConectorServidor conectorServidor;
        private int iDProveedor;
        private int contador;
        private int error = 0;

        public FNuevoProducto(ConectorServidor conectorServidor, int iDProveedor)
        {
            InitializeComponent();
            this.conectorServidor = conectorServidor;
            this.iDProveedor = iDProveedor;
            getProductosRegistrados();
        }

        private void getProductosRegistrados()
        {
            productosRegistrados = new ProductoSerializable();
            productosRegistrados.Accion = 3;
            conectorServidor.EnviarAServidor(productosRegistrados);
            
            //ESPERAR RESPUESTA
            contador = 0;
            while (conectorServidor.ProductoRecibido == null)
            {
                Thread.Sleep(200);
                if (++contador == 10)
                    break;
            }

            productosRegistrados = conectorServidor.ProductoRecibido;
            conectorServidor.ProductoRecibido = null;

            if (productosRegistrados == null || contador == 10)
            {
                cmbDescripcion.Enabled = false;
                MessageBox.Show("No pudieron leerse los productos registrados por otros proveedores.");
                return;
            }

            cmbDescripcion.Items.Add("");

            for (int i = 0; i < productosRegistrados.ProductosRegistrados.Count; i++)
                    cmbDescripcion.Items.Add(((ProductoSerializable)productosRegistrados.ProductosRegistrados[i]).Descripcion);

            cmbDescripcion.SelectedIndexChanged += new System.EventHandler(cmbDescripcion_SelectedIndexChanged);
            cmbDescripcion.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void cmbDescripcion_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedItem.Equals(""))
            {
                txtDescripcion.Enabled = true;
                txtFabricante.Enabled = true;
                txtPrecio.Enabled = true;
                txtDescripcionDetallada.Enabled = true;
                txtDescripcion.Text = null;
                txtFabricante.Text = null;
                txtPrecio.Text = null;
                txtDescripcionDetallada.Text = null;
                
            }

            for (int i = 0; i < productosRegistrados.ProductosRegistrados.Count; i++)
                if (comboBox.SelectedItem.Equals(((ProductoSerializable)productosRegistrados.ProductosRegistrados[i]).Descripcion))
                {
                    txtDescripcion.Text = ((ProductoSerializable)productosRegistrados.ProductosRegistrados[i]).Descripcion;
                    txtFabricante.Text = ((ProductoSerializable)productosRegistrados.ProductosRegistrados[i]).Fabricante;
                    txtPrecio.Text = ((ProductoSerializable)productosRegistrados.ProductosRegistrados[i]).Precio.ToString();
                    txtDescripcionDetallada.Text = ((ProductoSerializable)productosRegistrados.ProductosRegistrados[i]).DescripcionDetallada;
                    numericUpDownCantidad.Value = ((ProductoSerializable)productosRegistrados.ProductosRegistrados[i]).Cantidad;
                    txtDescripcion.Enabled = false;
                    txtFabricante.Enabled = false;
                    txtPrecio.Enabled = false;
                    txtDescripcionDetallada.Enabled = false;
                };
        }

        public int Error{
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

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtFabricante.Text) 
                || string.IsNullOrWhiteSpace(txtPrecio.Text) || string.IsNullOrWhiteSpace(txtDescripcionDetallada.Text) || numericUpDownCantidad.Value == 0)
            {
                MessageBox.Show("No deje campos vacios o en cantidad 0.");
                return;
            }

            nuevoProducto = new ProductoSerializable(0, txtDescripcion.Text, txtFabricante.Text, (int)numericUpDownCantidad.Value, decimal.Parse(txtPrecio.Text), txtDescripcionDetallada.Text, iDProveedor);
            nuevoProducto.Accion = 1;
            conectorServidor.EnviarAServidor(nuevoProducto);

            //ESPERAR RESPUESTA
            contador = 0;
            while (conectorServidor.ProductoRecibido == null)
            {
                Thread.Sleep(200);
                if (++contador == 10)
                    break;
            }
            
            if (contador ==10)
                nuevoProducto.Mensaje = "El servidor no se encuentra en ejecución.";
            else
                nuevoProducto = conectorServidor.ProductoRecibido;

            if (nuevoProducto.Mensaje != null) //si hubo un error
            {
                MessageBox.Show("Error al ingresar el producto: " + nuevoProducto.Mensaje);
                //txtUsuario.Text = null;
                conectorServidor.ProductoRecibido = null;
                nuevoProducto = null;
                return;
            }
            else                              //Si se agregó correctamente
            {
                MessageBox.Show("Producto agregado correctamente");
                conectorServidor.ProductoRecibido = null;
                this.Hide();
                this.Close();
                this.Dispose();
            }
        }

        public ProductoSerializable NuevoProducto
        {
            get { return nuevoProducto; }
            set { nuevoProducto = value; }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')  //Si no ingresó un número, borró un carácter o ingresó un punto
                e.KeyChar = '\0';           //Descarta el carácter ingresado
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text != null)
            {
                try
                {
                    decimal.Parse(txtPrecio.Text);
                }
                catch (Exception)
                {
                    txtPrecio.Text = null;
                }
            }
        }

        private void FNuevoProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Close();
            this.Dispose();
        }
    }
}
