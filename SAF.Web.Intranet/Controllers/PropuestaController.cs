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
using Microsoft.Reporting.WebForms;
namespace SAF.Web.Intranet.Controllers
{
    public class PropuestaController : Controller
    {
        SI_SOCAUDEntities modelEntity = new SI_SOCAUDEntities();
        private List<SP_SAF_EQUIPOAUDITORIA_RPT_Result> equipoAuditoriaRpt;        

        public ActionResult Index()
        {
            var publicaciones = this.modelEntity.SAF_PUBLICACION.ToList();
            var model = new PropuestaModel();
            model.cboPublicaciones = (from c in publicaciones select new SelectListItem() { Text = c.NUMPUB, Value = c.CODPUB.ToString() }).ToList();
            return View(model);
        }

        public JsonResult ListadoPropuestasCalificar(int? idPub)
        {

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

        public ActionResult DescargarReportePropuesta(int id)
        {
            var file = ObtenerPropuestaRPT(id);            
            return File(file, "application/pdf", "rptPropuesta.pdf");
        }

        public Byte[] ObtenerPropuestaRPT(int id)
        {
            /* Carga de lista de datos */
            var propuesta = modelEntity.SP_SAF_PROPUESTA_RPT(id).ToList();
            equipoAuditoriaRpt = modelEntity.SP_SAF_EQUIPOAUDITORIA_RPT(id).ToList();

            /* Creación de reporte */
            const string reportPath = "~/Reports/rptPropuesta.rdlc";
            var localReport = new LocalReport { ReportPath = Server.MapPath(reportPath) };

            /* Seteando el datasource */
            var dtPropuesta = new ReportDataSource("dtPropuesta") { Value = propuesta };
            var dtEquipoAuditoria = new ReportDataSource("dtEquipoAuditoria") { Value = equipoAuditoriaRpt };

            localReport.DataSources.Add(dtPropuesta);
            localReport.DataSources.Add(dtEquipoAuditoria);
            //localReport.SubreportProcessing += ReportePropuestaSubreportProcessingEventHandler;
            localReport.Refresh();

            //Configuración del reporte           

            string deviceInfoA4 = "<DeviceInfo>" +
                                         "  <OutputFormat>A4</OutputFormat>" +
                                         "  <PageWidth>21cm</PageWidth>" +
                                         "  <PageHeight>29.7cm</PageHeight>" +
                                         "  <MarginTop>1cm</MarginTop>" +
                                         "  <MarginLeft>1cm</MarginLeft>" +
                                         "  <MarginRight>1cm</MarginRight>" +
                                         "  <MarginBottom>1cm</MarginBottom>" +
                                         "</DeviceInfo>";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            var file = localReport.Render("pdf", deviceInfoA4, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

            return file;
        }

        //public void ReportePropuestaSubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        //{
        //    e.DataSources.Add(new ReportDataSource("dtEquipoAuditoria", equipoAuditoriaRpt));
        //}
    }
}