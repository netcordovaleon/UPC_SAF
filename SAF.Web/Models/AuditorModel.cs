using SAF.Configuracion.Constantes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAF.Web.Models
{
    public class AuditorModel
    {

        [AllowHtml]
        [Display(Name = "Observaciones")]
        public string observacionSolicitud { get; set; }

        public int codigoSolicitud { get; set; }

        [Display(Name="Codigo Auditor")]
        public int codAud { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Nombre")]
        public string nomAud { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Apellidos")]
        public string apeComAud { get; set; }


        [MaxLength(8, ErrorMessage = "Debe tener solo 8 digitos")]
        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "DNI")]
        public string dniAud { get; set; }
        [Display(Name = "Celular")]

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        public string celAud { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Telefono")]
        public string telAud { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Direccion")]
        public string dirAud { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Departamento")]
        public Nullable<int> codDeparAud { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Provincia")]
        public Nullable<int> codProvAud { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Distrito")]
        public Nullable<int> codDisAud { get; set; }

        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = Mensaje.MensajeCampoDebeSerCorreo)]
        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Correo")]
        public string corAud { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Sexo")]
        public string sexAud { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Fecha Nacimiento")]
        public string fecNacAud { get; set; }
        [Display(Name = "Auditor")]
        public string indEsAud { get; set; }
        [Display(Name = "Especialista")]
        public string indEsEsp { get; set; }
        [Display(Name = "Socio")]
        public string indEsSoc { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "N° Certificado")]
        public string codCerAud { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Archivo Certificado")]
        public byte[] arcCerAud { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Usuario")]
        public string nomUsu { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Contraseña")]
        public string pasUsu { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("pasUsu")]
        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Repetir Contraseña")]
        public string repPasUsu { get; set; }


        [Display(Name = "Archivo")]
        public string nombreArchivo { get; set; }

        public List<SelectListItem> cboDepartamento { get; set; }
        public List<SelectListItem> cboProvincia { get; set; }
        public List<SelectListItem> cboDistrito { get; set; }
        public Nullable<long> codArchivo { get; set; }
        public int estadoSolicitud { get; set; }
        
        public HttpPostedFileBase archivoCertificadoAuditor { get; set; }

        public AuditorModel() {
            this.cboDepartamento = new List<SelectListItem>();
            this.cboProvincia = new List<SelectListItem>();
            this.cboDistrito = new List<SelectListItem>();
        }


        
    }

    public class CapacitacionModel {
        public int? codSolCap { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage=Mensaje.MensajeCampoRequerido)]
        public string desSolCap { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        public string fechaInicioSolCap { get; set; }

        [Display(Name = "Fecha Fin")]
        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        public string fechaFinSolCap { get; set; }

        [Display(Name = "Horas")]
        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        public int? numHorasSolCap { get; set; }  
      
        public int? codSol { get; set; }

        [Display(Name = "Universidad")]
        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        public int? codUni { get; set; }

        [Display(Name = "Especialidad")]
        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        public int? codCar { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        public int? codTipCapa { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        public int? codCatCapa { get; set; }

        [Display(Name = "Archivo")]
        public string nombreArchivoCapa { get; set; }
        public long? codArchivoCapa { get; set; }

        public List<SelectListItem> Universidades { get; set; }
        public List<SelectListItem> Especialidades { get; set; }
        public List<SelectListItem> Tipos { get; set; }
        public List<SelectListItem> Categorias { get; set; }                

        public HttpPostedFileBase archivoCapaFile { get; set; }
    }

    public class ExperienciaModel
    {
        public int?  codSolExp{ get; set; }
        [Required(ErrorMessage=Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Descripción")]
        public string descSolExp { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Fecha Inicio")]
        public string fechaInicioSolExp { get; set; }


        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Fecha Fin")]
        public string fechaFinSolExp { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Horas")]
        public int? numHorasSolExp { get; set; }
        public int? codSol { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Empresa")]
        public int? codEmpresa { get; set; }

        [Required(ErrorMessage = Mensaje.MensajeCampoRequerido)]
        [Display(Name = "Tipo")]
        public int? codTipExp { get; set; }
        public long? codArchivoExp { get; set; }

        [Display(Name = "Archivo")]
        public string nombreArchivoExp { get; set; }

        public List<SelectListItem> Tipos { get; set; }
        public List<SelectListItem> Empresas { get; set; }

        public HttpPostedFileBase archivoExpFile { get; set; }
    }
}