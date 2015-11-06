using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAF.Web.Models
{
    public class InvitacionModel
    {

        public int codigoPublicacionBusqueda { get; set; }
        public int codigoServicioAudBusqueda { get; set; }


        [Display(Name="Codigo Invitacion")]
        public int CODINV { get; set; }

        [Display(Name = "Numero Invitacion")]
        public string NUMINV { get; set; }
        public string INDCANINV { get; set; }
        [Display(Name = "Fec. Acepta Invitacion")]
        public string FECACEPINV { get; set; }
        [Display(Name = "Fec. Acepta Invitacion")]
        public string FECMAXPREPROINV { get; set; }
        public Nullable<int> CODSOA { get; set; }
        public Nullable<int> CODAUD { get; set; }
        [Display(Name = "Serv. Auditoria")]
        public Nullable<int> CODSERAUD { get; set; }

        [Display(Name="Publicacion")]
        public Nullable<int> CODPUB { get; set; }

        public string ESTINV { get; set; }

        public List<SelectListItem> cboPublicaciones { get; set; }

        public List<SelectListItem> cboServiciosAuditoria { get; set; }

        public InvitacionModel() {
            this.cboPublicaciones = new List<SelectListItem>();
            this.cboServiciosAuditoria = new List<SelectListItem>();   
        }

    }
}