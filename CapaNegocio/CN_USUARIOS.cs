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
                string clave = "test123"; 
                obj.CLAVE = CN_Recursos.ConvertirSha256(clave);
                return objCapaDato.Registrar(obj, out mensaje);
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
