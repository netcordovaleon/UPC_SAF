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
using SAF.Web.Helper;

namespace SAF.Web.Controllers
{
    public class PropuestaController : Controller
    {
        ModeloExtranet modelEntity = new ModeloExtranet();

        #region Creacion de Propuesto

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
                return Json(new MensajeRespuesta("Se produjo un error no controlado al crear la propuesta", false));
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
            var propuesta = this.modelEntity.SP_SAF_PROPUESTAS().ToList().Where(c => c.CODPRO == idPropuesta).FirstOrDefault();
            var model = new PropuestaModel();
            model.CODPRO = propuesta.CODPRO;
            model.codigoPropuestaSustento = propuesta.CODPRO;
            model.RAZSOCSOA = propuesta.RAZSOCSOA;
            model.RUCSOA = propuesta.RUCSOA;
            model.NOMREPLEGSOA = propuesta.NOMREPLEGSOA;
            model.CORREPLEGSOA = propuesta.CORREPLEGSOA;
            model.CELREPLEGSOA = propuesta.CELREPLEGSOA;
            model.TOTRETECOBASREQ = propuesta.TOTRETECOBASREQ;
            model.TOTIGVBASREQ = propuesta.TOTIGVBASREQ;
            model.TOTVIABASREQ = propuesta.TOTVIABASREQ;

            model.RETRECO = propuesta.RETRECO;
            model.RETRECOTOTAL = propuesta.RETRECOTOTAL;
            model.IGVTOTAL = propuesta.IGVTOTAL;
            model.MONTVIATICO = propuesta.MONTVIATICO;

            model.codArchivoFirmaInternacional = propuesta.CODARCFIRINT;
            model.codArchivoFirmaPCAOB = propuesta.CODARCFIRPCAOB;
            model.nombreArchivoFirmaInternacional = propuesta.NOMBLABELFIRINT;
            model.nombreArchivoFirmaPCAOB = propuesta.NOMBLABELFIRPCAOB;
            model.INDREQFIRINT = propuesta.INDREQFIRINT;
            model.INDREQFIRPCAOB = propuesta.INDREQFIRPCAOB;
            model.ESTPRO = propuesta.ESTPROP;
            return View(model);
        }

        public JsonResult GrabarRetribucionEconomica(int idProp, decimal retribucion, decimal igv, decimal totalretrib, decimal viatico)
        {

            try
            {
                var propuesta = this.modelEntity.SAF_PROPUESTA.Where(c => c.CODPRO == idProp).FirstOrDefault();
                propuesta.RETRECO = retribucion;
                propuesta.IGVTOTAL = igv;
                propuesta.RETRECOTOTAL = totalretrib;
                propuesta.MONTVIATICO = viatico;
                this.modelEntity.SaveChanges();
                return Json(new MensajeRespuesta("Se registro la retribucion economica satisfactoriamente", true));
            }
            catch (Exception)
            {
                return Json(new MensajeRespuesta("No se pudo registrar la retribucion economica", false));
            }
        }

        [HttpPost]
        public string guardarSustentoAdicional(PropuestaModel model) {
            try
            {
                var propuesta = this.modelEntity.SAF_PROPUESTA.Where(c=>c.CODPRO == model.codigoPropuestaSustento).FirstOrDefault();

                var filebeFirInter = new FileBe();

                if (model.archivoFirmaInternacional != null)
                {
                    filebeFirInter.NarcCodigo = model.codArchivoFirmaInternacional;
                    filebeFirInter.CarcNombre = model.nombreArchivoFirmaInternacional;
                    filebeFirInter.FileData = model.archivoFirmaInternacional;
                }

                var filebeFirPCAOB = new FileBe();

                if (model.archivoFirmaPCAOB!= null)
                {
                    filebeFirPCAOB.NarcCodigo = model.codArchivoFirmaPCAOB;
                    filebeFirPCAOB.CarcNombre = model.nombreArchivoFirmaPCAOB;
                    filebeFirPCAOB.FileData = model.archivoFirmaPCAOB;
                }



                var idFirmaInter = Archivo.RegistrarArchivo(propuesta.CODARCFIRINT, filebeFirInter);
                var idFirmaPcaob = Archivo.RegistrarArchivo(propuesta.CODARCFIRINT, filebeFirPCAOB);

                propuesta.CODARCFIRINT = idFirmaInter;
                propuesta.CODARCFIRPCAOB = idFirmaPcaob;
                propuesta.NOMBLABELFIRINT = model.nombreArchivoFirmaInternacional;
                propuesta.NOMBLABELFIRPCAOB = model.nombreArchivoFirmaPCAOB;
                this.modelEntity.SaveChanges();

                //var id = Archivo.RegistrarArchivo(capacitacion.CODARC, filebe);

                return JsonConvert.SerializeObject(new MensajeRespuesta("Se guardó la sustentacion adicional satisfactoriamente", true));
            }
            catch (Exception)
            {
                return JsonConvert.SerializeObject(new MensajeRespuesta("No se pudo guardar la sustentacion adicional", false));
            }
            
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

        public PartialViewResult AsignarFechaEquipoPropuesta(int idPropuesta, int idEquipo)
        {
            var model = new EquipoAuditoriaModel();
            model.CODPROEQU = idEquipo;
            model.codigoPropuestaAsigFecha = idPropuesta;
            return PartialView("_AsignarFechaEquipo", model);
        }

        public JsonResult listadoFechasInvitadas(int idEquipo)
        {
            //var equipo = this.modelEntity.SAF_PROPEQUIPO.ToList().Where(c => c.CODPROEQU == idEquipo).FirstOrDefault();
            //var fechasInvitadas = this.modelEntity.SAF_INVITACIONDETALLE.ToList().Where(c => c.CODINV == equipo.CODINV);
            var fechasInvitadas = this.modelEntity.SP_SAF_FECHASINVITADAS(idEquipo).ToList();
            var data = fechasInvitadas.Select(c => new string[] { 
                c.FECINVDET.Value.ToString("dd/MM/yyyy")
            }).ToArray();
            return Json(data);
        }

        public JsonResult listadoFechasAsignadas(int idEquipo)
        {
            var fechasAsignadas = this.modelEntity.SAF_PROPEQUIPODETALLE.ToList().Where(c => c.CODPROEQU == idEquipo && c.ESTREG == "1").OrderBy(c=>c.FECPROEQUIDET);
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
                return Json(new MensajeRespuesta(result.MENSAJE, true));
            }
            else
            {
                return Json(new MensajeRespuesta("No se pudo asignar las fechas", false));
            }
        }

        public JsonResult EliminarFechaAsignadas(int idPropuesta, string fechasAsignadas) {
            var result = this.modelEntity.SP_SAF_ELIMINARFECHASASIGPROP(idPropuesta, fechasAsignadas).FirstOrDefault();
            if (result.RESULTADO.Equals(1))
                return Json(new MensajeRespuesta(result.MENSAJE, true));
            else
                return Json(new MensajeRespuesta("No se pudo eliminar las fechas asignadas", false));
        }


        public JsonResult PresentarPropuesta(int idPropuesta) {
            try
            {
                var propuesta = this.modelEntity.SAF_PROPUESTA.Where(c => c.CODPRO == idPropuesta).FirstOrDefault();
                propuesta.ESTPROP = (int)Estado.Propuesta.Enviada;
                this.modelEntity.SaveChanges();
                return Json(new MensajeRespuesta("Se presento la propuesta satisfactoriamente", true));
            }
            catch (Exception)
            {
                return Json(new MensajeRespuesta("No se pudo presentar la propuesta", false));
            }
        }

        #endregion

    }
}