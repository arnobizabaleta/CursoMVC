using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_USUARIOS
    {
        private CDUsuarios objCapaDato = new CDUsuarios();
        public List<USUARIO> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(USUARIO obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.NOMBRES) || string.IsNullOrWhiteSpace(obj.NOMBRES))
            {
                mensaje = "El nombre del usuario no puede ser vacío";
            }

            else if (string.IsNullOrEmpty(obj.APELLIDOS) || string.IsNullOrWhiteSpace(obj.APELLIDOS))
            {
                mensaje = "Los appelidos del usuario no pueden ser vacíos";
            }

            else if (string.IsNullOrEmpty(obj.CORREO) || string.IsNullOrWhiteSpace(obj.CORREO))
            {
                mensaje = "El correo del usuario no puede ser vacío";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                string clave = CN_Recursos.GenerarClave();
                obj.CLAVE = CN_Recursos.ConvertirSha256(clave);
                int idNuevoUsuario;
                idNuevoUsuario = objCapaDato.Registrar(obj, out mensaje);
                    if(idNuevoUsuario> 0)
                {
                    string asunto = "Creación de cuenta";
                    string mensaje_correo = "<h3> Su cuenta fue creada correctamente </h3> </br> <p> Su contraseña para acceder es ¡clave!</p>";
                    mensaje_correo = mensaje_correo.Replace("¡clave!", clave);
                    bool respuesta = CN_Recursos.EnviarCorreo(obj.CORREO, asunto, mensaje_correo);
                    if (respuesta)
                    {//Correo enviado
                        return idNuevoUsuario;
                    }
                    else
                    {
                        mensaje = "No se puede enviar el correo";
                        return 0;
                    }
                    
                  
                }
                else
                {
                    return 0;//Usuario no registrado
                }
                

                //Logica vieja: Envía correo aunque el usuario no haya sido guardado por repiticion de correo
                //string clave = CN_Recursos.GenerarClave();
                //string asunto = "Creación de cuenta";
                //string mensaje_correo = "<h3> Su cuenta fue creada correctamente </h3> </br> <p> Su contraseña para acceder es ¡clave!</p>";
                //mensaje_correo = mensaje_correo.Replace("¡clave!", clave);

                //bool respuesta = CN_Recursos.EnviarCorreo(obj.CORREO, asunto, mensaje_correo);

                //if (respuesta)
                //{
                //    obj.CLAVE = CN_Recursos.ConvertirSha256(clave);
                //    return objCapaDato.Registrar(obj, out mensaje);
                //}
                //else
                //{
                //    mensaje = "No se puede enviar el correo";
                //    return 0;
                //}


            }
            else
            {

                return 0;
            }
        }

        public bool Editar(USUARIO obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.NOMBRES) || string.IsNullOrWhiteSpace(obj.NOMBRES))
            {
                mensaje = "El nombre del usuario no puede ser vacío";
            }

            else if (string.IsNullOrEmpty(obj.APELLIDOS) || string.IsNullOrWhiteSpace(obj.APELLIDOS))
            {
                mensaje = "Los appelidos del usuario no pueden ser vacíos";
            }

            else if (string.IsNullOrEmpty(obj.CORREO) || string.IsNullOrWhiteSpace(obj.CORREO))
            {
                mensaje = "El correo del usuario no puede ser vacío";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                return objCapaDato.Editar(obj, out mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string mensaje)
        {
            return objCapaDato.Eliminar(id, out mensaje);
        }
    }
}
