using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAF.Web.Models
{
    public class PropuestaModel
    {
        public int CODPRO { get; set; }
        public string NUMPRO { get; set; }
        public int CODSOA { get; set; }
        [Display(Name="Publicacion")]
        public int CODPUB { get; set; }

        public List<SelectListItem> cboPublicaciones { get; set; }

        public PropuestaModel()
        {
            this.cboPublicaciones = new List<SelectListItem>();
        }

    }
}