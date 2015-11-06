using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAF.Web.Models;
using SAF.AgenteServicios;
using SAF.DTO;
using SAF.Configuracion.Enum;


namespace SAF.Web.Controllers
{
    public class NotificacionController : BaseController
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ContarNoLeidas()
        {
            //string tipoRespuesta = TipoRespuesta.No;
            //int cantNoLeidas = 0;
            //int tipoUsuario = (int)TipoUsuario.Externo;
            //string codUsuario = MiSesion.Codigo.ToString();

            //cantNoLeidas = _notificacionService.ObtenerNoLeidas(codUsuario, tipoRespuesta, tipoUsuario);

            //if (!codUsuario.Equals(""))
            //    return Json(new { exito = true, total = cantNoLeidas }, JsonRequestBehavior.AllowGet);
            var usu = usuarioLogueado;
            return Json(new { exito = false, total = 0 }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult mensaje()
        {
            var agenteNotificacion = new NotificacionAgente();
            return Json(agenteNotificacion.mensaje());


        }
	}
}