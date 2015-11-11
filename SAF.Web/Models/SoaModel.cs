using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAF.Configuracion.Constantes;
using System.ComponentModel.DataAnnotations;
namespace SAF.Web.Models
{
    public class SoaModel
    {

        public int codSolicitud { get; set; }
        public string numSolicitud { get; set; }

        public int estadoSolicitud { get; set; }

        [AllowHtml]
        [Display(Name="Observaciones")]
        public string observacionSolicitud { get; set; }

        [Required(ErrorMessage=Mensaje.MensajeCampoRequerido)]
        [Display(Name="Codigo SOA")]        
        public int codSoa { get; set; }

        [Required(ErrorMessage=Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Razon Social")]        
        public string razSocSoa { get; set; }

        [Required(ErrorMessage=Mensaje.MensajeCampoRequerido)]
        [Display(Name = "R.U.C")]        
        public string rucSoa { get; set; }

        [Required(ErrorMessage=Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Nombre")]        
        public string nomRepLegSoa { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Apellido Paterno")]        
        public string apeRepLegSoa { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = Mensaje.MensajeCampoDebeSerCorreo)]
        [Display(Name = "Correo Electronico")]        
        public string corRepLegSoa { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Celular")]        
        public string celRepLegSoa { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Telefono")]        
        public string telRepLegSoa { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Codigo Colegio Contadores")]        
        public string codColConSoa { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Nº Partida Sunarp")]        
        public string numParSunSoa { get; set; }

        [Display(Name = "Firma PCAOB")]        
        public string firPcaobSoa { get; set; }

        [Display(Name = "Firma Internacional")]        
        public string firIntSoa { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Mision")]        
        public string misSoa { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Vision")]        
        public string visSoa { get; set; }


        [Display(Name = "Archivo Colegio Contadores")]        
        public byte[] ARCCOLCONSOA { get; set; }


        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Usuario")]        
        public string nomUsu { get; set; }


        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        
        [Display(Name = "Contraseña")]                
        public string pasUsu { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [System.ComponentModel.DataAnnotations.Compare("pasUsu")]
        [Display(Name = "Repetir Contraseña")]
        public string repPasUsu { get; set; }
    }
}