using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LibreriasSistemaDeAprovisionamiento
{
    public static class Encriptador
    {
        public const int TAMANO_SALT = 24;
        public const int INDICE_SALT = 1;
        public const int TAMANO_HASH = 24;
        public const int INDICE_HASH = 2;
        public const int ITERACIONES = 1000;
        public const int INDICE_ITERACIONES = 0;
              
        public static string crearHashMasSalto(string pswd)
        {
            RNGCryptoServiceProvider generador = new RNGCryptoServiceProvider();    //Generador de salt
            byte[] salt = new byte[TAMANO_SALT];                //arreglo de bytes que almacena el salt
            generador.GetBytes(salt);                           //genera un salt y lo copia al arreglo de bytes
            byte[] hash = aByteHash(pswd, salt, ITERACIONES, TAMANO_HASH);  //genera el hash con salt
            return ITERACIONES + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);   //retorna cadena con iteraciones, hash y salt
        }

        public static bool validarContrasena(string contrasenaIngresada, string iterHashSalt)
        {
            string[] split = iterHashSalt.Split(':');                                //Divide la cadena
            int iteraciones = Int32.Parse(split[INDICE_ITERACIONES]);               //Obtiene los
            byte[] salt = Convert.FromBase64String(split[INDICE_SALT]);             //respectivos valores
            byte[] hash = Convert.FromBase64String(split[INDICE_HASH]);             //de la division de la cadena
            byte[] hashAProbar = aByteHash(contrasenaIngresada, salt, iteraciones, hash.Length);   //Genera el arreglo de bytes con la contraseña ingresada y el salt
            return sonEquivalentes(hash, hashAProbar);                              //Comprueba la igualdad
        }

        public static bool validarContrasena(byte[] bytesContraIngresada, string iterHashSalt)
        {
            string[] split = iterHashSalt.Split(':');                            //Divide la cadena
            int iteraciones = Int32.Parse(split[INDICE_ITERACIONES]);               //Obtiene los
            byte[] salt = Convert.FromBase64String(split[INDICE_SALT]);             //respectivos valores
            byte[] hash = Convert.FromBase64String(split[INDICE_HASH]);             //de la division de la cadena
            byte[] hashAProbar = aByteHash(bytesContraIngresada, salt, iteraciones, hash.Length);   //Genera el arreglo de bytes con la contraseña ingresada y el salt
            return sonEquivalentes(hash, hashAProbar);
        }

        private static bool sonEquivalentes(byte[] hash, byte[] hashAProbar)
        {
            uint diferencia = (uint)hash.Length ^ (uint)hashAProbar.Length; //Se aplica un XOR a nivel lógico para determinar si hay igualdad

            for(int i = 0; i<hash.Length && i < hashAProbar.Length; i++)    //Itera por ambos arreglos
                diferencia |= (uint)(hash[i] ^ hashAProbar[i]);             //Se aplica un XOR a nivel lógico para determinar si hay igualdad
            return diferencia == 0;                                         //Si diferencia es 0 la contraseña es correcta
        }

        private static byte[] aByteHash(string pswd, byte[] salt, int iteraciones, int bytesDeSalida)
        {
            Rfc2898DeriveBytes derivador = new Rfc2898DeriveBytes(pswd, salt);  //Inicializa el derivador con la contrasena y el salt
            derivador.IterationCount = iteraciones;         //Establece el numero de iteraciones
            return derivador.GetBytes(bytesDeSalida);       //Obtiene el arreglo de bytes del tamaño establecido
        }
        private static byte[] aByteHash(byte[] pswd, byte[] salt, int iteraciones, int bytesDeSalida)
        {
            Rfc2898DeriveBytes derivador = new Rfc2898DeriveBytes(pswd, salt, iteraciones);  //Inicializa el derivador con la contrasena y el salt
            //derivador.IterationCount = iteraciones;         //Establece el numero de iteraciones
            return derivador.GetBytes(bytesDeSalida);       //Obtiene el arreglo de bytes del tamaño establecido
        }
    }
}