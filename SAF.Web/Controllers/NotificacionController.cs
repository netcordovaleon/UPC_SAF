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
        ModeloExtranet modelEntity = new ModeloExtranet();
        
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

        public ActionResult Bandeja()
        {
            return View();
        }

        public JsonResult ListarMensajes(string bandeja)
        {
            IEnumerable<SAF_NOTIFICACION> mensajes = new List<SAF_NOTIFICACION>();
            mensajes = modelEntity.SAF_NOTIFICACION.Where(c => c.ESTNOT.Equals(bandeja) && c.USUREC.Equals("")).ToList();

            var data = mensajes.Select(c => new string[] { 
                c.CODNOT.ToString(),
                c.USUEMI,
                c.USUREC,
                c.FECREG.GetValueOrDefault().ToString("dd/MM/yyyy"),
                c.ASUNOT,
                c.INDNOT.Equals("R") ? "1" : "0"
            });

            return Json(new { });
        }

        public JsonResult LeerMensaje(int mensaje) 
        {
            var data = modelEntity.SAF_NOTIFICACION.Where(c => c.CODNOT.Equals(mensaje) && c.USUREC.Equals("")).FirstOrDefault();

            if (data.INDNOT.Equals("R"))
            {
                data.INDNOT = "L";

                modelEntity.SaveChanges();
            }

            return Json(new { USUNOT = data.USUEMI, ASUNOT = data.ASUNOT, DESNOT = data.DESNOT, FECNOT = data.FECREG.GetValueOrDefault().ToString("dd/MM/yyyy") });
        }
	}
}