using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<USUARIO> oLista = new List<USUARIO>();
            oLista = new CN_USUARIOS().Listar();

            return Json( new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult GuardarUsuario(USUARIO objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.ID_USUARIO == 0)
            {
                resultado = new CN_USUARIOS().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_USUARIOS().Editar(objeto,out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje},JsonRequestBehavior.AllowGet);
        }

    }
}