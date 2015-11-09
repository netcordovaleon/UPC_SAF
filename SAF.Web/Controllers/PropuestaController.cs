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
    public class PropuestaController : Controller
    {
        ModeloExtranet modelEntity = new ModeloExtranet();
        //
        // GET: /Propuesta/
        public ActionResult Index()
        {
            var model = new PropuestaModel();
            model.cboPublicaciones = (from c in modelEntity.SAF_PUBLICACION.ToList() select new SelectListItem() { Text = c.NUMPUB, Value = c.CODPUB.ToString() }).ToList();
            return View(model);
        }

        public JsonResult CrearPropuesta(int idPub)
        {
            try
            {
                var resut = this.modelEntity.SP_SAF_CREARPROPUESTA(idPub, (int)Session["sessionCodigoResponsableLogin"]).FirstOrDefault();
                if (resut.RESULTADO.Equals(0))
                    return Json(new MensajeRespuesta(resut.MENSAJE, false));
                else
                    return Json(new MensajeRespuesta(resut.MENSAJE, true));
            }
            catch (Exception)
            {
                return Json(new MensajeRespuesta("Se produjo un error no controlado al crear la propuesta", true));
            }
        }

        public JsonResult ListadoPropuestas()
        {
            var propuestas = this.modelEntity.SP_SAF_PROPUESTAS().ToList();
            propuestas = propuestas.Where(c => c.CODSOA == (int)Session["sessionCodigoResponsableLogin"]).ToList();
            var data = propuestas.Select(c => new string[] { 
                c.CODPRO.ToString(),
                c.DESBAS,
                c.RETRECOTOTAL.ToString(),
                c.IGVTOTAL.ToString(),
                c.MONTVIATICO.ToString(),
                c.VALOR
            }).ToArray();
            return Json(data);
        }

        public ActionResult VerPropuesta(int idPropuesta)
        {
            var propuesta = this.modelEntity.SP_SAF_PROPUESTAS().ToList().Where(c=>c.CODPRO == idPropuesta).FirstOrDefault();
            var model = new PropuestaModel();
            model.CODPRO = propuesta.CODPRO;
            model.RAZSOCSOA = propuesta.RAZSOCSOA;
            model.RUCSOA = propuesta.RUCSOA;
            model.NOMREPLEGSOA = propuesta.NOMREPLEGSOA;
            model.CORREPLEGSOA = propuesta.CORREPLEGSOA;
            model.CELREPLEGSOA = propuesta.CELREPLEGSOA;
            model.TOTRETECOBASREQ = propuesta.TOTRETECOBASREQ;
            model.TOTIGVBASREQ = propuesta.TOTIGVBASREQ;
            model.TOTVIABASREQ = propuesta.TOTVIABASREQ;
            return View(model);
        }

        public JsonResult ListarAuditorias(int idPropuesta)
        {
            var auditorias = this.modelEntity.SP_SAF_AUDITORIAS(idPropuesta).ToList();
            var data = auditorias.Select(c => new string[] { 
                c.CODAUDITORIA.ToString(),
                c.PERAUD,
                c.DESBAS
            }).ToArray();
            return Json(data);
        }

        public JsonResult VerEquipoAuditoria(int idAuditoria)
        {
            var equipoAuditoria = this.modelEntity.SP_SAF_EQUIPOAUDITORIA(idAuditoria).ToList();
            var data = equipoAuditoria.Select(c => new string[] { 
                c.CODPROEQU.ToString(),
                c.PERAUD,
                c.DNIAUD,
                c.NOMCOMAUD,
                c.NOMCAR,
                c.CELAUD,
                c.CORAUD
            }).ToArray();
            return Json(data);
        }

        public PartialViewResult AsignarFechaEquipoPropuesta(int idEquipo)
        {
            var model = new EquipoAuditoriaModel();
            model.CODPROEQU = idEquipo;
            return PartialView("_AsignarFechaEquipo", model);
        }

        public JsonResult listadoFechasInvitadas(int idEquipo)
        {
            var equipo = this.modelEntity.SAF_PROPEQUIPO.ToList().Where(c => c.CODPROEQU == idEquipo).FirstOrDefault();
            var fechasInvitadas = this.modelEntity.SAF_INVITACIONDETALLE.ToList().Where(c => c.CODINV == equipo.CODINV);
            var data = fechasInvitadas.Select(c => new string[] { 
                c.FECINVDET.Value.ToString("dd/MM/yyyy")
            }).ToArray();
            return Json(data);
        }

        public JsonResult listadoFechasAsignadas(int idEquipo)
        {
            var fechasAsignadas = this.modelEntity.SAF_PROPEQUIPODETALLE.ToList().Where(c => c.CODPROEQU == idEquipo);
            var data = fechasAsignadas.Select(c => new string[] { 
                c.FECPROEQUIDET.Value.ToString("dd/MM/yyyy"),
                c.CODPROEQUDET.ToString()
            }).ToArray();
            return Json(data);
        }

        public JsonResult asignarFechasPropuesta(int idEquipo, string fechasAsgnar)
        {
            var result = this.modelEntity.SP_SAF_ASIGNARFECHASPROPUESTA(idEquipo, fechasAsgnar).FirstOrDefault();
            if (result.RESULTADO.Equals(1))
            {
                return Json(new MensajeRespuesta(result.MENSAJE,true));
            }
            else
            {
                return Json(new MensajeRespuesta("No se pudo asignar las fechas", false));
            }
            
        }
	}
}