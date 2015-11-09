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
        [Display(Name = "RUC")]
        public string RUCSOA { get; set; }
        [Display(Name = "Razon Social")]
        public string RAZSOCSOA { get; set; }
        [Display(Name = "Nombre Representante Legal")]
        public string NOMREPLEGSOA { get; set; }
        [Display(Name = "Celular Representante Legal")]
        public string CELREPLEGSOA { get; set; }
        [Display(Name = "Correo Representante Legal")]
        public string CORREPLEGSOA { get; set; }

        [Display(Name = "Retribucion")]
        public decimal TOTRETECOBASREQ { get; set; }
        [Display(Name = "IGV")]
        public decimal TOTIGVBASREQ { get; set; }
        [Display(Name = "Viaticos")]
        public decimal TOTVIABASREQ { get; set; }


        [Display(Name = "Monto Retribucion")]
        public decimal RETRECO { get; set; }
        [Display(Name = "IGV")]
        public decimal IGVTOTAL { get; set; }
        [Display(Name = "Total Retribucion")]
        public decimal RETRECOTOTAL { get; set; }
        [Display(Name = "Viaticos")]
        public decimal MONTVIATICO { get; set; }
        

            
            
            

        public List<SelectListItem> cboPublicaciones { get; set; }
        public PropuestaModel()
        {
            this.cboPublicaciones = new List<SelectListItem>();
        }

    }
}