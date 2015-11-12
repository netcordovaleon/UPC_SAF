using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.Enum;

namespace SAF.Web.Intranet.Areas.Publicacion.Models
{
    public class PublicacionViewModel
    {
        [Required(ErrorMessage=Mensaje.MensajeCampoRequerido)]
        [Display(Name="Codigo Publicaicion")]
        public int CodigoPublicacion { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Fecha Maxima elaborar consulta")]
        public string  FechaMaximaCreacionConsulta { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Fecha maxima publicar concurso")]
        public string FechaMaximaPublicacionConcurso { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Fecha maxima responder consulta")]
        public string FechaMaximaResponderConsultas { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Fecha maxima presentacion propuestas")]
        public string FechaMaximaPresentacionPropuestas { get; set; }

        public int estadoPublicacion { get; set; }
    }
}