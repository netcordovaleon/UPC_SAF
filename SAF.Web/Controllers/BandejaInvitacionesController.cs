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
    public class BandejaInvitacionesController : Controller
    {
        ModeloExtranet modelEntity = new ModeloExtranet();
        //
        // GET: /BandejaInvitaciones/
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

        public JsonResult ListadoInvitaciones(int? idPub, int? idSerAud)
        {
            var invitaciones = this.modelEntity.SP_SAF_INVITACION(idPub, idSerAud).ToList().Where(c => c.ESTINV == (int)Estado.Invitacion.Enviada || c.ESTINV == (int)Estado.Invitacion.Cancelada || c.ESTINV == (int)Estado.Invitacion.Aceptado);
            invitaciones = invitaciones.Where(c => c.CODAUD == (int)Session["sessionCodigoResponsableLogin"]).ToList();
            var data = invitaciones.Select(c => new string[] {
                c.CODINV.ToString(),
                c.RUCSOA,
                c.RAZSOCSOA,
                c.DESBAS,
                c.PERSERAUD,
                c.VALOR,
                c.ESTINV.GetValueOrDefault().ToString()
            });
            return Json(data);
        }

        public JsonResult AceptarInvitacion(int id)
        {
            try
            {
                var invitacion = this.modelEntity.SAF_INVITACION.Where(c => c.CODINV == id).FirstOrDefault();
                invitacion.ESTINV = (int)Estado.Invitacion.Aceptado;
                invitacion.FECACEPINV = DateTime.Now;
                modelEntity.SaveChanges();
                return Json(new MensajeRespuesta("Se acepto la invitacion satisfactoriamente", true));
            }
            catch (Exception)
            {
                return Json(new MensajeRespuesta("No se pudo aceptar la invitacion", false));
            }
        }

        public JsonResult CancelarInvitacion(int id)
        {
            try
            {
                var invitacion = this.modelEntity.SAF_INVITACION.Where(c => c.CODINV == id).FirstOrDefault();
                invitacion.ESTINV = (int)Estado.Invitacion.Cancelada;
                invitacion.INDCANINV = "A";
                modelEntity.SaveChanges();
                return Json(new MensajeRespuesta("Se cancelo la invitacion satisfactoriamente", true));
            }
            catch (Exception)
            {
                return Json(new MensajeRespuesta("No se pudo cancelar la invitacion", false));
            }
        }
    }
}