//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAF.Web.Intranet
{
    using System;
    using System.Collections.Generic;
    
    public partial class SAF_CORTE_AUDITOR_CARGO
    {
        public int CODCORAUDCAR { get; set; }
        public Nullable<System.DateTime> FECREG { get; set; }
        public Nullable<System.DateTime> FECMOD { get; set; }
        public string USUREG { get; set; }
        public string USUMOD { get; set; }
        public string ESTREG { get; set; }
        public Nullable<int> CODCAR { get; set; }
        public Nullable<int> CODPUB { get; set; }
        public Nullable<int> CODAUD { get; set; }
        public Nullable<int> CODCORAUD { get; set; }
    
        public virtual SAF_CARGO SAF_CARGO { get; set; }
        public virtual SAF_PUBLICACION SAF_PUBLICACION { get; set; }
        public virtual SAF_AUDITOR SAF_AUDITOR { get; set; }
    }
}
