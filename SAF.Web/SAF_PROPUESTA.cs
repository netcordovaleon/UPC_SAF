//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAF.Web
{
    using System;
    using System.Collections.Generic;
    
    public partial class SAF_PROPUESTA
    {
        public SAF_PROPUESTA()
        {
            this.SAF_AUDITORIA = new HashSet<SAF_AUDITORIA>();
        }
    
        public int CODPRO { get; set; }
        public string NUMPRO { get; set; }
        public Nullable<System.DateTime> FECREG { get; set; }
        public Nullable<System.DateTime> FECMOD { get; set; }
        public string USUREG { get; set; }
        public string USUMOD { get; set; }
        public string ESTREG { get; set; }
        public Nullable<int> CODSOA { get; set; }
        public Nullable<int> CODPUB { get; set; }
        public string INDREQFIRINT { get; set; }
        public string INDREQFIRPCAOB { get; set; }
        public Nullable<decimal> RETRECO { get; set; }
        public Nullable<decimal> IGVTOTAL { get; set; }
        public Nullable<decimal> RETRECOTOTAL { get; set; }
        public Nullable<decimal> MONTVIATICO { get; set; }
        public Nullable<long> CODARCFIRINT { get; set; }
        public string NOMBLABELFIRINT { get; set; }
        public Nullable<long> CODARCFIRPCAOB { get; set; }
        public string NOMBLABELFIRPCAOB { get; set; }
        public Nullable<decimal> RETRECOREQ { get; set; }
        public Nullable<decimal> IGVTOTALREQ { get; set; }
        public Nullable<decimal> RETRECOTOTALREQ { get; set; }
        public Nullable<decimal> MONTVIATICOREQ { get; set; }
        public Nullable<int> ESTPROP { get; set; }
    
        public virtual ICollection<SAF_AUDITORIA> SAF_AUDITORIA { get; set; }
        public virtual SAF_SOA SAF_SOA { get; set; }
        public virtual SAF_PUBLICACION SAF_PUBLICACION { get; set; }
    }
}
