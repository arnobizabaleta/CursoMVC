using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using System.IO;


namespace CapaNegocio
{
    public class CN_Recursos
    {
        public static string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0, 6);//Retornar codigo unico de 6 digitos
            return clave; //Retorna clave aleatoria de 6 digitos
        }
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

        public static bool EnviarCorreo(string correo, string asunto, string mensaje)
        {
            bool resultado = false;

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("arnobizabaleta@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                var smpt = new SmtpClient()
                {
                    Credentials = new NetworkCredential("arnobizabaleta@gmail.com", "jxasnkctyumtidpa"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true
                };

                smpt.Send(mail);
                resultado = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                resultado = false;
            }
            
            return resultado;
        }

    }
}
