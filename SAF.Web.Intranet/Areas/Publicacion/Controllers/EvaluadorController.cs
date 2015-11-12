using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAF.Configuracion.Enum;
using SAF.DTO;
using SAF.AgenteServicios;
using SAF.Web.Intranet.Areas.Publicacion.Models;
using SAF.Configuracion.Constantes;

namespace SAF.Web.Intranet.Areas.Publicacion.Controllers
{
    public class EvaluadorController : Controller
    {


        private readonly SI_SOCAUDEntities modeloEntity = new SI_SOCAUDEntities();
        private readonly ConcursoPublicoMeritoAgente _agenteConcursoPublicoMerito;

        public EvaluadorController()
        {
            this._agenteConcursoPublicoMerito = new ConcursoPublicoMeritoAgente();
        }

        public ActionResult Bandeja()
        {
            return View();
        }

        public ActionResult Publicacion(int idPub) {
            var publicacion = this.modeloEntity.SAF_PUBLICACION.Where(c => c.CODPUB == idPub).FirstOrDefault();
            var model = new PublicacionViewModel();

            model.CodigoPublicacion = publicacion.CODPUB;
            model.FechaMaximaCreacionConsulta = publicacion.FECMAXCONS.GetValueOrDefault().ToShortDateString();
            model.FechaMaximaPublicacionConcurso = publicacion.FECMAXCRECON.GetValueOrDefault().ToShortDateString();
            model.FechaMaximaResponderConsultas = publicacion.FECMAXRESCONS.GetValueOrDefault().ToShortDateString();
            model.FechaMaximaPresentacionPropuestas = publicacion.FECMAXPREPROP.GetValueOrDefault().ToShortDateString();
            model.estadoPublicacion = publicacion.ESTPUB.GetValueOrDefault();
            return View(model);

        }

        public JsonResult GrabarPublicacion(PublicacionViewModel model) {
            try
            {
                var publicacion = this.modeloEntity.SAF_PUBLICACION.Where(c => c.CODPUB == model.CodigoPublicacion).FirstOrDefault();
                publicacion.FECMAXCRECON = Convert.ToDateTime(model.FechaMaximaPublicacionConcurso);
                publicacion.FECMAXCONS = Convert.ToDateTime(model.FechaMaximaCreacionConsulta);
                publicacion.FECMAXRESCONS = Convert.ToDateTime(model.FechaMaximaResponderConsultas);
                publicacion.FECMAXPREPROP = Convert.ToDateTime(model.FechaMaximaPresentacionPropuestas);

                var noti = new Helper.NotificacionAdmin();
                string mensaje = string.Empty;
                mensaje = "Se realizaron los siguientes cambios en la publicacion, debe tener en cuenta que las fechas mostradas son los limites para realizar cada accion: <br /><br />";
                mensaje = mensaje + "*) Fecha publicacion concurso : <strong>" + model.FechaMaximaPublicacionConcurso + "</strong><br/>";
                mensaje = mensaje + "*) Fecha elaboracion consultas : <strong>" + model.FechaMaximaCreacionConsulta + "</strong><br/>";
                mensaje = mensaje + "*) Fecha elaboracion absolucion de consultas : <strong>" + model.FechaMaximaResponderConsultas + "</strong><br/>";
                mensaje = mensaje + "*) Fecha elaboracion de propuestas : <strong>" + model.FechaMaximaPresentacionPropuestas + "</strong><br/>";
                noti.grabarNotificacionTodosUsuarios(Notificacion.asuntoCambiosConcurso, mensaje);

                this.modeloEntity.SaveChanges();
                return Json(new MensajeRespuesta("Se grabo la publicacion satisfactoriamente", true));
            }
            catch (Exception)
            {
                return Json(new MensajeRespuesta("No se pudo grabar la publicacion", false));
            }
        }

        public JsonResult ListarPublicaciones()
        {
            var lista = this._agenteConcursoPublicoMerito.listarPublicacion();
            var data = lista.Select(c => new string[] {
                c.CODPUB.ToString(),
                c.NUMPUB,
                c.DESBAS,
                c.NOMPAR,
                c.ESTPUB.GetValueOrDefault().ToString()
            }).ToArray();
            return Json(data);
        }

        public JsonResult PublicarPublicacion(int id)
        {
            var result = this._agenteConcursoPublicoMerito.PublicarPublicacion(id);
            return Json(result);
        }

        public JsonResult EliminarPublicacion(int id) {
            try
            {
                var publicacion = this.modeloEntity.SAF_PUBLICACION.Where(c => c.CODPUB == id).FirstOrDefault();
                publicacion.ESTREG = "0";
                this.modeloEntity.SaveChanges();
                return Json(new MensajeRespuesta("Se elimino el registro satisfactoriamente", true));
            }
            catch (Exception)
            {

                return Json(new MensajeRespuesta("No se pudo elimino el registro", false));
            }
        }

        public PartialViewResult VerResultadoCortePublicacion(int id)
        {
            var model = new PublicacionViewModel();
            model.CodigoPublicacion = id;
            return PartialView("_ResultadoCorte", model);
        }

        public JsonResult ListarResultadoCortePublicacion(int id)
        {
            var lista = this._agenteConcursoPublicoMerito.VerResultadoCorte(id);
            var data = lista.Select(c => new string[] { 
                c.NOMCOMAUD,
                c.NOMCAR.ToString(),
                c.CAPAPUNT.GetValueOrDefault().ToString(),
                c.EXPPUNT.GetValueOrDefault().ToString(),
                c.TOTALPUNT.GetValueOrDefault().ToString()
            }).ToArray();
            return Json(data);
        }
	}
}