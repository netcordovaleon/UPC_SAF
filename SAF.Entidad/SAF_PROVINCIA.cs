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
    
    public partial class SAF_PROVINCIA
    {
        public SAF_PROVINCIA()
        {
            this.SAF_DISTRITO = new HashSet<SAF_DISTRITO>();
        }
    
        public int CODPROV { get; set; }
        public Nullable<int> CODDEP { get; set; }
        public string NOMDEP { get; set; }
        public Nullable<System.DateTime> FECREG { get; set; }
        public Nullable<System.DateTime> FECMOD { get; set; }
        public string USUREG { get; set; }
        public string USUMOD { get; set; }
        public string ESTREG { get; set; }
    
        public virtual SAF_DEPARTAMENTO SAF_DEPARTAMENTO { get; set; }
        public virtual ICollection<SAF_DISTRITO> SAF_DISTRITO { get; set; }
    }
}
