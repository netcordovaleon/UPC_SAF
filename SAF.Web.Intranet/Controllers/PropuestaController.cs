using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SAF.AgenteServicios;
using SAF.DTO;
using SAF.Configuracion.Enum;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.ExcepcionNegocio;
using SAF.Web.Intranet.Models;
using System.Transactions;
namespace SAF.Web.Intranet.Controllers
{
    public class PropuestaController : Controller
    {
        SI_SOCAUDEntities modelEntity = new SI_SOCAUDEntities();
        public ActionResult Index()
        {
            var publicaciones = this.modelEntity.SAF_PUBLICACION.ToList();
            var model = new PropuestaModel();
            model.cboPublicaciones = (from c in publicaciones select new SelectListItem() { Text = c.NUMPUB, Value = c.CODPUB.ToString() }).ToList();
            return View(model);
        }

        public JsonResult ListadoPropuestasCalificar(int? idPub) {

            var propuestas = this.modelEntity.SP_SAF_PROPUESTAS().Where(c => (c.CODPUB == idPub || idPub == null) && (c.ESTPROP == (int)Estado.Propuesta.Enviada || c.ESTPROP == (int)Estado.Propuesta.Ganadora || c.ESTPROP == (int)Estado.Propuesta.Descalifica));
            var data = propuestas.Select(c => new string[] { 
                c.CODPRO.ToString(),
                string.Format("<strong>{0}</strong> - {1}", c.RUCSOA, c.RAZSOCSOA),
                c.NOMREPLEGSOA,
                c.CELREPLEGSOA,
                c.CORREPLEGSOA,
                c.DESBAS,
                c.RETRECO.ToString(),
                c.IGVTOTAL.ToString(),
                c.VALOR,
                c.PUNTAJETOTAL.GetValueOrDefault().ToString(),
                c.ESTPROP.GetValueOrDefault().ToString(),
                c.CODPUB.GetValueOrDefault().ToString()
            }).ToArray();
            return Json(data);
        }

        public JsonResult AsignarPropuestaComoGanadora(int idPropuesta, int idPublicacion)
        {
            try
            {
                var result = this.modelEntity.SP_SAF_ASIGNARGANADORPROPUESTA(idPropuesta, idPublicacion).FirstOrDefault();
                if (result.RESULTADO.Equals(0))
                    return Json(new MensajeRespuesta(result.MENSAJE, false));
                else
                    return Json(new MensajeRespuesta(result.MENSAJE, true));
            }
            catch (Exception)
            {
                return Json(new MensajeRespuesta("Ocurrio un error inesperado al asignar la propuesta", false));
            }

        }
    }
}