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
    
    public partial class SAF_EMPRESA
    {
        public SAF_EMPRESA()
        {
            this.SAF_SOLEXPERIENCIA = new HashSet<SAF_SOLEXPERIENCIA>();
            this.SAF_EXPERIENCIA = new HashSet<SAF_EXPERIENCIA>();
        }
    
        public int CODEMP { get; set; }
        public string RAZSOCEMP { get; set; }
        public string RUCEMP { get; set; }
        public Nullable<System.DateTime> FECREG { get; set; }
        public Nullable<System.DateTime> FECMOD { get; set; }
        public string USUREG { get; set; }
        public string USUMOD { get; set; }
        public string ESTREG { get; set; }
    
        public virtual ICollection<SAF_SOLEXPERIENCIA> SAF_SOLEXPERIENCIA { get; set; }
        public virtual ICollection<SAF_EXPERIENCIA> SAF_EXPERIENCIA { get; set; }
    }
}
