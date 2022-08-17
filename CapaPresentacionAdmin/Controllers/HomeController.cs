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
        public JsonResult ListarUsuarios()
        {
            List<USUARIO> oLista = new List<USUARIO>();
            oLista = new CN_USUARIOS().Listar();

            return Json( oLista, JsonRequestBehavior.AllowGet);
        }


    }
}