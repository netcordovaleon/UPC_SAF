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
    
    public partial class SAF_TIPOPARAMETRICA
    {
        public SAF_TIPOPARAMETRICA()
        {
            this.SAF_PARAMETRICA = new HashSet<SAF_PARAMETRICA>();
        }
    
        public int CODTIPPAR { get; set; }
        public string NOMTIPPAR { get; set; }
        public Nullable<System.DateTime> FECREG { get; set; }
        public Nullable<System.DateTime> FECMOD { get; set; }
        public string USUREG { get; set; }
        public string USUMOD { get; set; }
        public string ESTREG { get; set; }
    
        public virtual ICollection<SAF_PARAMETRICA> SAF_PARAMETRICA { get; set; }
    }
}