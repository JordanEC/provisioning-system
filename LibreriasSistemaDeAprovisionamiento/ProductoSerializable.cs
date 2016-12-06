using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriasSistemaDeAprovisionamiento
{
    [Serializable]
    public class ProductoSerializable
    {
        private int iDProducto;                 
        private string descripcion;             
        private string fabricante;              
        private int cantidad;                   
        private decimal precio;                 
        private string descripcionDetallada;    
        private int accion;                     //Accion por realizar
        private bool accionCompletada;          //Determina si se completo correctamente la accion
        private int iDProveedor;                //
        private string mensaje;                 //Mensaje de error
        private ArrayList productosRegistrados; //Productos registrados en la BD por otros proveedores
        
        public ProductoSerializable()
        {
            IDProducto = 0;
            Descripcion = null;
            Fabricante = null;
            Cantidad = 0;
            Precio = 0;
            DescripcionDetallada = null;
            Accion = 0;
            AccionCompletada = false;
            IDProveedor = 0;
            mensaje = null;
            productosRegistrados = new ArrayList();
        }

        public ProductoSerializable(int iDPD, string desc, string fabri, int canti, decimal prec, string descDetall, int iDPV)
        {
            IDProducto = iDPD;
            Descripcion= desc;
            Fabricante = fabri;
            Cantidad = canti;
            Precio = prec;
            DescripcionDetallada = descDetall;
            IDProveedor = iDPV;
        }

        public int IDProducto
        {
            get { return iDProducto; }
            set { iDProducto = value; }
        }

        public int IDProveedor
        {
            get { return iDProveedor; }
            set { iDProveedor = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Fabricante
        {
            get { return fabricante; }
            set { fabricante = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string DescripcionDetallada
        {
            get { return descripcionDetallada; }
            set { descripcionDetallada = value; }
        }

        public int Accion
        {
            get { return accion; }
            set { accion = value; }
        }

        public bool AccionCompletada
        {
            get { return accionCompletada; }
            set { accionCompletada = value; }
        }

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
        public ArrayList ProductosRegistrados
        {
            get { return productosRegistrados; }
            set { productosRegistrados = value; }
        }

    }
}
