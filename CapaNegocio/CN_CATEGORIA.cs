using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_CATEGORIA
    {
        private CD_CATEGORIA objCapaDato = new CD_CATEGORIA();
        public List<CATEGORIA> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(CATEGORIA obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.DESCRIPCION) || string.IsNullOrWhiteSpace(obj.DESCRIPCION))
            {
                mensaje = "La descripción de la categoría no puede ser vacío";
            }

           
            if (string.IsNullOrEmpty(mensaje))
            {
                
               
               return  objCapaDato.Registrar(obj, out mensaje);
               
              
              
            }
            else
            {

                return 0;
            }
        }

        public bool Editar(CATEGORIA obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.DESCRIPCION) || string.IsNullOrWhiteSpace(obj.DESCRIPCION))
            {
                mensaje = "La descripción de la categoría no puede ser vacío";
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
