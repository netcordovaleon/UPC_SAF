using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAF.Web.Models;
using SAF.AgenteServicios;
using SAF.DTO;
using SAF.Configuracion.Enum;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.ExcepcionNegocio;
using Newtonsoft.Json;
using System.IO;


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
            mensajes = modelEntity.SAF_NOTIFICACION.ToList().Where(c => c.ESTNOT == bandeja && c.USUREC == Session["sessionUsuario"].ToString());

            var data = mensajes.Select(c => new string[] { 
                c.CODNOT.ToString(),
                c.USUEMI,
                c.ASUNOT,
                GetReciveNota(c.FECREG),
                c.INDNOT.Equals("R") ? "1" : "0",
                c.ESTNOT.Equals(TIPOBANDEJA.BANDEJA_RECIBIDOS) ? "1" : "0"
            });

            return Json(data);
        }

        private string GetReciveNota(DateTime? fecha)
        {
            var time = (DateTime.Now - fecha.GetValueOrDefault());

            if (time.TotalMinutes < 60) return ((int)time.TotalMinutes).ToString() + " minuto(s)";
            if (time.TotalHours < 24) return ((int)time.TotalHours).ToString() + " hora(s)";
            return ((int)time.TotalDays).ToString() + " dia(s)";
        }

        public JsonResult LeerMensaje(int mensaje)
        {
            var data = modelEntity.SAF_NOTIFICACION.ToList().Where(c => c.CODNOT.Equals(mensaje) && c.USUREC.Equals(Session["sessionUsuario"])).FirstOrDefault();

            if (data.INDNOT.Equals("R"))
            {
                data.INDNOT = "L";

                modelEntity.SaveChanges();
            }

            return Json(new { USUNOT = data.USUEMI, ASUNOT = data.ASUNOT, DESNOT = data.DESNOT, FECNOT = data.FECREG.GetValueOrDefault().ToString("dd/MM/yyyy hh:mm tt") });
        }

        public JsonResult EliminarMensaje(int mensaje)
        {
            try
            {
                var data = modelEntity.SAF_NOTIFICACION.ToList().Where(c => c.CODNOT.Equals(mensaje) && c.USUREC.Equals(Session["sessionUsuario"])).FirstOrDefault();

                if (data.ESTNOT.Equals(TIPOBANDEJA.BANDEJA_RECIBIDOS))
                {
                    data.ESTNOT = TIPOBANDEJA.BANDEJA_PAPELERA;

                    modelEntity.SaveChanges();

                    return Json(new MensajeRespuesta("Se proceso satisfactoriamente.", true));
                }

                return Json(new MensajeRespuesta("No se pudo eliminar la notificación.", false));
            }
            catch (Exception)
            {
                return Json(new MensajeRespuesta("Se produjo un error al eliminar la notificación", false));
            }
        }



    }
}