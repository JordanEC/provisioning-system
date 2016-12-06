using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LibreriasSistemaDeAprovisionamiento
{   [Serializable]
    public class ProveedorSerializable // : ISerializable
    {
        private int iDProveedor;
        private string nombreUsuario;
        private string correo;
        private string empresa;
        private int accion;                 //1= iniciar sesion, 2= registrarse    
        private bool habilitado;
        private bool accionCompletada;      //Determina si se completo correctamente la accion
        private string mensaje;             //Mensaje de error
        private string contrasena;
        private byte[] bytesContr;
        private ArrayList productos;        //Productos del proveedor

        public ProveedorSerializable()
        {
            IDProveedor = 0;
            NombreUsuario = null;
            Correo = null;
            Empresa = null;
            Accion = 0;
            Habilitado = false;
            AccionCompletada = false;
            mensaje = null;
            productos = new ArrayList();     
        }

        public ProveedorSerializable(int iDProveedor, string nombreUsuario, string empresa, string correo, bool habilitado)
        {
            IDProveedor = iDProveedor;
            NombreUsuario = nombreUsuario;
            Empresa = empresa;
            Correo = correo;
            Habilitado = habilitado;
        }

        public ProveedorSerializable copiar(ProveedorSerializable original) {   //Copia la informacion de un proveedor
            ProveedorSerializable copia = new ProveedorSerializable();
            copia.IDProveedor = original.IDProveedor;
            copia.NombreUsuario = original.NombreUsuario;
            copia.Empresa = original.Empresa;
            copia.Correo = original.Correo;
            copia.Habilitado = original.Habilitado;
            for (int i = 0; i < original.Productos.Count; i++)
            {
                copia.Productos.Add(new ProductoSerializable(
                    ((ProductoSerializable)original.Productos[i]).IDProducto,
                    ((ProductoSerializable)original.Productos[i]).Descripcion,
                    ((ProductoSerializable)original.Productos[i]).Fabricante,
                    ((ProductoSerializable)original.Productos[i]).Cantidad,
                    ((ProductoSerializable)original.Productos[i]).Precio,
                    ((ProductoSerializable)original.Productos[i]).DescripcionDetallada,
                    ((ProductoSerializable)original.Productos[i]).IDProveedor));
            } 
            
            return copia;
        }

        public ArrayList Productos
        {
            get { return productos; }

            set { productos = value; }
        }

        public int IDProveedor
        {
            get { return iDProveedor; }
            set { iDProveedor = value; }
        }

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
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

        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }
        
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public byte[] BytesContr
        {
            get { return bytesContr; }
            set { bytesContr = value; }
        }

        public ProductoSerializable ProductoSerializable
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
