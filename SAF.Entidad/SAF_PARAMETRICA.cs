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
    
    public partial class SAF_PARAMETRICA
    {
        public SAF_PARAMETRICA()
        {
            this.SAF_CAPACITACION = new HashSet<SAF_CAPACITACION>();
            this.SAF_CAPACITACION1 = new HashSet<SAF_CAPACITACION>();
            this.SAF_EXPERIENCIA = new HashSet<SAF_EXPERIENCIA>();
        }
    
        public int CODPAR { get; set; }
        public string NOMPAR { get; set; }
        public string VALOR { get; set; }
        public Nullable<int> CODTIPPAR { get; set; }
        public Nullable<System.DateTime> FECREG { get; set; }
        public Nullable<System.DateTime> FECMOD { get; set; }
        public string USUREG { get; set; }
        public string USUMOD { get; set; }
        public string ESTREG { get; set; }
    
        public virtual SAF_TIPOPARAMETRICA SAF_TIPOPARAMETRICA { get; set; }
        public virtual ICollection<SAF_CAPACITACION> SAF_CAPACITACION { get; set; }
        public virtual ICollection<SAF_CAPACITACION> SAF_CAPACITACION1 { get; set; }
        public virtual ICollection<SAF_EXPERIENCIA> SAF_EXPERIENCIA { get; set; }
    }
}