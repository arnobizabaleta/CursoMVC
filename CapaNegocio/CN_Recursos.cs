using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CapaNegocio
{
    public class CN_Recursos
    {
        //Encripacion de texto en SHA256
        public static string ConvertirSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            //USAR REFERENCES System.Security.Cryptography

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding en = Encoding.UTF8;
                byte[] result = hash.ComputeHash(en.GetBytes(texto));
                foreach (byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }

                return Sb.ToString();
            }
        }

    }
}
