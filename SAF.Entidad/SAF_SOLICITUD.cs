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
    
    public partial class SAF_SOLICITUD
    {
        public SAF_SOLICITUD()
        {
            this.SAF_SOLCAPACITACION = new HashSet<SAF_SOLCAPACITACION>();
            this.SAF_SOLEXPERIENCIA = new HashSet<SAF_SOLEXPERIENCIA>();
        }
    
        public int CODSOL { get; set; }
        public string NUMSOL { get; set; }
        public string DESSOL { get; set; }
        public Nullable<System.DateTime> FECREG { get; set; }
        public Nullable<System.DateTime> FECMOD { get; set; }
        public string USUREG { get; set; }
        public string USUMOD { get; set; }
        public string ESTREG { get; set; }
        public Nullable<int> CODTIPSOL { get; set; }
        public Nullable<int> ESTSOL { get; set; }
        public Nullable<int> CODSOA { get; set; }
        public Nullable<int> CODAUD { get; set; }
        public string OBSSOL { get; set; }
    
        public virtual SAF_SOA SAF_SOA { get; set; }
        public virtual SAF_TIPOSOLICITUD SAF_TIPOSOLICITUD { get; set; }
        public virtual SAF_AUDITOR SAF_AUDITOR { get; set; }
        public virtual ICollection<SAF_SOLCAPACITACION> SAF_SOLCAPACITACION { get; set; }
        public virtual ICollection<SAF_SOLEXPERIENCIA> SAF_SOLEXPERIENCIA { get; set; }
    }
}
