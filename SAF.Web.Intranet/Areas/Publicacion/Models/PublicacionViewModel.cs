using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAF.Web.Intranet.Areas.Publicacion.Models
{
    public class PublicacionViewModel
    {
        [Display(Name="Codigo Publicaicion")]
        public int CodigoPublicacion { get; set; }
        [Display(Name = "Fecha Maxima elaborar consulta")]
        public string  FechaMaximaCreacionConsulta { get; set; }
        [Display(Name = "Fecha maxima publicar concurso")]
        public string FechaMaximaPublicacionConcurso { get; set; }
        [Display(Name = "Fecha maxima responder consulta")]
        public string FechaMaximaResponderConsultas { get; set; }
        [Display(Name = "Fecha maxima presentacion propuestas")]
        public string FechaMaximaPresentacionPropuestas { get; set; }

        public int estadoPublicacion { get; set; }
    }
}