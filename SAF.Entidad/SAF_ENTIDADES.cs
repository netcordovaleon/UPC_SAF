//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAF.Entidad
{
    using System;
    using System.Collections.Generic;
    
    public partial class SAF_ENTIDADES
    {
        public SAF_ENTIDADES()
        {
            this.SAF_CRONOENTIDAD = new HashSet<SAF_CRONOENTIDAD>();
        }
    
        public int CODENT { get; set; }
        public string RAZSOCENT { get; set; }
        public string RUCENT { get; set; }
        public string VISENT { get; set; }
        public string MISENT { get; set; }
        public string ACTPRIENT { get; set; }
        public string BASLEGENT { get; set; }
        public byte[] ORGENT { get; set; }
        public string DOMLEGENT { get; set; }
        public string CODDEPENT { get; set; }
        public string CODPROENT { get; set; }
        public string CODDISENT { get; set; }
        public string PAGWEBENT { get; set; }
        public string NOMREPLEGENT { get; set; }
        public string APEREPLEGENT { get; set; }
        public string CORREPLEGENT { get; set; }
        public string TELREPLEGENT { get; set; }
        public string CELREPLEGENT { get; set; }
        public Nullable<System.DateTime> FECREG { get; set; }
        public Nullable<System.DateTime> FECMOD { get; set; }
        public string USUREG { get; set; }
        public string USUMOD { get; set; }
        public string ESTREG { get; set; }
    
        public virtual ICollection<SAF_CRONOENTIDAD> SAF_CRONOENTIDAD { get; set; }
    }
}
