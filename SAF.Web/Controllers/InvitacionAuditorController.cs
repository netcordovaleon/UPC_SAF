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
    public class InvitacionAuditorController : Controller
    {

        ModeloExtranet modelEntity = new ModeloExtranet();

        // GET: InvitacionAuditor
        public ActionResult Index()
        {
            var model = new InvitacionModel();
            var publicaciones = modelEntity.SAF_PUBLICACION.ToList().Where(c => c.ESTREG == "1");
            model.cboPublicaciones = (from c in publicaciones select new SelectListItem() { Value = string.Format("{0}-{1}", c.CODPUB, c.CODBAS), Text = c.NUMPUB }).ToList();
            return View(model);
        }

        public JsonResult listarServicios(int idBase)
        {
            var serviciosAuditoria = modelEntity.SAF_SERVICIOAUDITORIA.ToList().Where(c => c.CODBAS == idBase && c.ESTREG == "1");
            var result = (from c in serviciosAuditoria select new SelectListItem() { Text = c.PERSERAUD, Value = c.CODSERAUD.ToString() });
            return Json(result);
        }

        public PartialViewResult BusquedaAuditores(int idPub, int idSerAud)
        {
            var model = new InvitacionModel();
            model.codigoPublicacionBusqueda = idPub;
            model.codigoServicioAudBusqueda = idSerAud;
            return PartialView("_BusquedaAuditores", model);
        }

        public PartialViewResult AgendaAuditor(int idInvitacion)
        {

            var invitacion = this.modelEntity.SAF_INVITACION.ToList().Where(c => c.CODINV == idInvitacion).FirstOrDefault();
            var auditor = this.modelEntity.SAF_AUDITOR.ToList().Where(c => c.CODAUD == invitacion.CODAUD).FirstOrDefault();
            var cargo = this.modelEntity.SAF_CARGO.ToList().Where(c => c.CODCAR == invitacion.CODCAR).FirstOrDefault();
            var model = new InvitacionModel();
            model.codigoInvitacionAgenda = idInvitacion;
            model.nomCompletoAuditor = string.Format("{0} {1}", auditor.NOMAUD, auditor.APEAUD);
            model.cargoInvitacionAuditor = cargo.NOMCAR;
            model.numeroHorasLaboral = 8;
            return PartialView("_AgendaAuditor", model);
        }

        public JsonResult ListarMejorEquipo(int idPub, int idSerAud)
        {

            var listadoMejorEquipo = this.modelEntity.SP_SAF_MEJOREQUIPO(idPub, idSerAud).ToList();
            var data = listadoMejorEquipo.Select(c => new string[] { 
                c.CODAUD.GetValueOrDefault().ToString(),
                c.NOMCOMAUD,
                c.NOMCAR,
                c.EXPPUNT.GetValueOrDefault().ToString(),
                c.CAPAPUNT.GetValueOrDefault().ToString(),
                c.TOTALPUNT.GetValueOrDefault().ToString(),
                c.DISPON.GetValueOrDefault().ToString(),
                c.CODCAR.GetValueOrDefault().ToString()
            });

            return Json(data);

        }

        public JsonResult ListarAuditoresAptos(int idPub, int idSerAud)
        {
            var listadoAuditoresAptos = this.modelEntity.SP_SAF_AUDITORAPTOINVITAR(idPub, idSerAud);
            var data = listadoAuditoresAptos.Select(c => new string[] { 
                c.CODAUD.GetValueOrDefault().ToString(),
                c.NOMCOMAUD,
                c.NOMCAR,
                c.EXPPUNT.GetValueOrDefault().ToString(),
                c.CAPAPUNT.GetValueOrDefault().ToString(),
                c.TOTALPUNT.GetValueOrDefault().ToString(),
                "0"
            });

            return Json(data);
        }

        public JsonResult InvitarAuditores(int idPub, int idSerAud, string strAudCargo)
        {
            try
            {
                var resultadoInvitarAuditor = this.modelEntity.SP_SAF_INVITARAUDITORES(((int)Session["sessionCodigoResponsableLogin"]), idPub, idSerAud, strAudCargo).FirstOrDefault();
                if (resultadoInvitarAuditor.RESULTADO.Equals(0))
                    return Json(new MensajeRespuesta(resultadoInvitarAuditor.MENSAJE, false));
                else
                    return Json(new MensajeRespuesta(resultadoInvitarAuditor.MENSAJE, true));
            }
            catch (Exception)
            {
                return Json(new MensajeRespuesta("Ocurrio un error al invitar a los auditores", false));
            }
        }

        public JsonResult ListadoInvitacionesPorSOA(int? idPub, int? idSerAud)
        {
            var listado = this.modelEntity.SP_SAF_INVITACION(idPub, idSerAud).Where(c => c.CODSOA == ((int)Session["sessionCodigoResponsableLogin"])).ToList();
            var data = listado.Select(c => new string[] {
                c.CODINV.ToString(),
                c.NOMCOMAUD,
                c.DNIAUD,
                c.DESBAS,
                c.PERSERAUD,
                c.NOMCAR,
                c.FECACEPINV.HasValue ? c.FECACEPINV.Value.ToShortDateString() : "",
                c.VALOR,
                c.ESTINV.GetValueOrDefault().ToString()
            });

            return Json(data);
        }

        public JsonResult EnviarInvitacionAuditor(int id) {
            try
            {
                var invitacion = this.modelEntity.SAF_INVITACION.ToList().Where(c => c.CODINV == id).FirstOrDefault();
                invitacion.ESTINV = (int)Estado.Invitacion.Enviada;
                this.modelEntity.SaveChanges();
                return Json(new MensajeRespuesta("Se envio la invitacion satisfactoriamente", true));
            }
            catch (Exception)
            {
                return Json(new MensajeRespuesta("No se pudo enviar la invitacion", false));
            }
        }

        public JsonResult EliminarInvitacion(int id)
        {
            try
            {
                var invitacion = this.modelEntity.SAF_INVITACION.ToList().Where(c => c.CODINV == id).FirstOrDefault();
                invitacion.ESTREG = "0";//Estado.Auditoria.Inactivo.ToString();
                this.modelEntity.SaveChanges();
                return Json(new MensajeRespuesta("Se elimino la invitacion satisfactoriamente", true));
            }
            catch (Exception)
            {
                return Json(new MensajeRespuesta("No se pudo eliminar la invitacion", false));
            }
        }


        public JsonResult ListadoDisponibilidadAuditor(int idAuditor,string fechaInicio, string fechaFin)
        {
            var listado = this.modelEntity.SP_DISPONIBILIDADAUDITOR(idAuditor, (int)Session["sessionCodigoResponsableLogin"], fechaInicio, fechaFin).ToList();

            var data = listado.Select(c=> new string[]{
                c.FECDIL.HasValue? c.FECDIL.Value.ToString("dd/MM/yyyy") : ""
            }).ToArray();

            return Json(data);
        }

        public JsonResult ListadoFechasAsig(int idInvitacion) {
            var listado = this.modelEntity.SAF_INVITACIONDETALLE.ToList().Where(c => c.CODINV == idInvitacion);
            var data = listado.Select(c => new string[]{
                c.FECINVDET.HasValue ? c.FECINVDET.Value.ToShortDateString() : "",
                c.NUMHORINVDET.GetValueOrDefault().ToString()
            }).ToArray();
            return Json(data);
        }

        public JsonResult RegistrarFechasAgendaAuditor(int idInvitacion, int numHora, string fechas) {
            try
            {
                var resultado = this.modelEntity.SP_SAF_AGENDAREGISTRAR(idInvitacion, numHora, fechas).FirstOrDefault();
                if (resultado.RESULTADO.Equals(1))
                    return Json(new MensajeRespuesta(resultado.MENSAJE, true));
                else
                    return Json(new MensajeRespuesta("No se pudo registrar las fechas", false));
            }
            catch (Exception)
            {
                return Json(new MensajeRespuesta("No se pudo registrar las fechas", false));
            }
        }
    }
}