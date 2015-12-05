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
namespace SAF.Web.Controllers
{
    public class SolRegController : Controller
    {

        ModeloExtranet modelEntity = new ModeloExtranet();
        GestionSociedadAuditorAgente _agenteGestionSoaAuditor = new GestionSociedadAuditorAgente();
        public ActionResult Registro()
        {
            var model = new SolRegModel();
            var listaTipoEntidad = this._agenteGestionSoaAuditor.listarRegistroTipoSolicitud();
            model.cboTipoSolicitud = (from c in listaTipoEntidad select new SelectListItem() { 
                Text = c.NOMTIPSOL,
                Value = c.CODTIPSOL.ToString()
            });
            model.auditor.cboDepartamento = (from c in modelEntity.SAF_DEPARTAMENTO.ToList().Where(c=>c.ESTREG == "1") select new SelectListItem() { Text = c.NOMDEP, Value = c.CODDEP.ToString() }).ToList();
            //model.auditor.cboProvincia = (from c in modelEntity.SAF_PROVINCIA.ToList() select new SelectListItem() { Text = c.NOMDEP, Value = c.CODPROV.ToString() }).ToList();
            //model.auditor.cboDistrito = (from c in modelEntity.SAF_DISTRITO.ToList() select new SelectListItem() { Text = c.NOMDEP, Value = c.CODDIS.ToString() }).ToList();
            return View(model);
        }

        public JsonResult CargarProvincia(int id) {
            var lista = (from c in modelEntity.SAF_PROVINCIA.ToList().Where(c => c.CODDEP == id && c.ESTREG == "1") select new SelectListItem() { Text = c.NOMDEP, Value = c.CODPROV.ToString() }).ToList();
            return Json(lista);
        }

        public JsonResult CargarDistrito(int id)
        {
            var lista = (from c in modelEntity.SAF_DISTRITO.ToList().Where(c => c.CODPROV == id && c.ESTREG == "1") select new SelectListItem() { Text = c.NOMDEP, Value = c.CODDIS.ToString() }).ToList();
            return Json(lista);
        }

        public JsonResult GrabarSolicitudRegistro(SolRegModel model)
        {

            if (model.solicitud.codTipSol.GetValueOrDefault() == 1)
            { // SI ES SOA
                var existeUsuario = modelEntity.SAF_SOA.Where(c => c.NOMUSU.Equals(model.soa.nomUsu)).ToList().Any();
                if (existeUsuario)
                {
                    return Json(new MensajeRespuesta("El usuario que intenta registrar ya existe", false));
                }
            }
            else {
                var existeUsuario = modelEntity.SAF_AUDITOR.Where(c => c.NOMUSU.Equals(model.auditor.nomUsu)).ToList().Any();
                if (existeUsuario)
                {
                    return Json(new MensajeRespuesta("El usuario que intenta registrar ya existe", false));
                }
            }
            var entidad = new SolicitudInsActDTO();
            entidad.Solicitud.CODTIPSOL = model.solicitud.codTipSol;
            entidad.Solicitud.ESTSOL = (int)Estado.Solicitud.Elaboracion;
            entidad.Soa.RAZSOCSOA = model.soa.razSocSoa;
            entidad.Soa.RUCSOA = model.soa.rucSoa;
            entidad.Soa.MISSOA = model.soa.misSoa;
            entidad.Soa.VISSOA = model.soa.visSoa;
            entidad.Soa.NOMUSU = model.soa.nomUsu;
            entidad.Soa.PASUSU = model.soa.pasUsu;

            entidad.Auditor.DNIAUD = model.auditor.dniAud;
            entidad.Auditor.SEXAUD = model.auditor.sexAud;
            entidad.Auditor.FECNACAUD = Convert.ToDateTime(model.auditor.fecNacAud);
            entidad.Auditor.NOMAUD = model.auditor.nomAud;
            entidad.Auditor.APEAUD = model.auditor.apeComAud;

            entidad.Auditor.CODDEPAUD = model.auditor.codDeparAud;
            entidad.Auditor.CODPROVAUD = model.auditor.codProvAud;
            entidad.Auditor.CODDISAUD = model.auditor.codDisAud;
            entidad.Auditor.CORAUD = model.auditor.corAud;
            entidad.Auditor.TELAUD = model.auditor.telAud;
            entidad.Auditor.CELAUD = model.auditor.celAud;
            entidad.Auditor.NOMUSU = model.auditor.nomUsu;
            entidad.Auditor.PASUSU = model.auditor.pasUsu;
            var result = _agenteGestionSoaAuditor.GrabarSolicitudRegistro(entidad);
            return Json(result);
        }
	}
}