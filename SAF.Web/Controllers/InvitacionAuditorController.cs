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
            var publicaciones  = modelEntity.SAF_PUBLICACION.ToList().Where(c=>c.ESTREG == "1");
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

        public JsonResult ListarMejorEquipo(int idPub, int idSerAud) {

            var listadoMejorEquipo = this.modelEntity.SP_SAF_MEJOREQUIPO(idPub, idSerAud).ToList();
            var data = listadoMejorEquipo.Select(c => new string[] { 
                c.CODAUD.GetValueOrDefault().ToString(),
                c.NOMCOMAUD,
                c.NOMCAR,
                c.EXPPUNT.GetValueOrDefault().ToString(),
                c.CAPAPUNT.GetValueOrDefault().ToString(),
                c.TOTALPUNT.GetValueOrDefault().ToString(),
                c.DISPON.GetValueOrDefault().ToString()
            });

            return Json(data);

        }

        public JsonResult ListarAuditoresAptos(int idPub, int idSerAud) {
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
    }
}