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
    
    public partial class SAF_PROPEQUIPO
    {
        public SAF_PROPEQUIPO()
        {
            this.SAF_ASISTENCIA = new HashSet<SAF_ASISTENCIA>();
            this.SAF_FALTAJUSTIFICA = new HashSet<SAF_FALTAJUSTIFICA>();
        }
    
        public int CODPROEQU { get; set; }
        public Nullable<int> CODAUDITORIA { get; set; }
        public Nullable<int> CODAUD { get; set; }
        public Nullable<int> CODCAR { get; set; }
        public Nullable<int> CODINV { get; set; }
        public Nullable<System.DateTime> FECREG { get; set; }
        public Nullable<System.DateTime> FECMOD { get; set; }
        public string USUREG { get; set; }
        public string USUMOD { get; set; }
        public string ESTREG { get; set; }
    
        public virtual ICollection<SAF_ASISTENCIA> SAF_ASISTENCIA { get; set; }
        public virtual ICollection<SAF_FALTAJUSTIFICA> SAF_FALTAJUSTIFICA { get; set; }
    }
}
