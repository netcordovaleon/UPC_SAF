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
    
    public partial class SAF_CAPACITACION
    {
        public int CODCAP { get; set; }
        public string DESCAP { get; set; }
        public Nullable<System.DateTime> FECINICAP { get; set; }
        public Nullable<System.DateTime> FECFINCAP { get; set; }
        public Nullable<int> NUMHORCAP { get; set; }
        public Nullable<System.DateTime> FECREG { get; set; }
        public Nullable<System.DateTime> FECMOD { get; set; }
        public string USUREG { get; set; }
        public string USUMOD { get; set; }
        public string ESTREG { get; set; }
        public Nullable<int> CODAUD { get; set; }
        public Nullable<int> CODUNI { get; set; }
        public Nullable<int> CODCAR { get; set; }
        public Nullable<int> CODTIPCAPA { get; set; }
        public Nullable<int> CODCATCAPA { get; set; }
        public Nullable<long> CODARC { get; set; }
        public string NOMBLABEL { get; set; }
    
        public virtual SAF_ARCHIVO SAF_ARCHIVO { get; set; }
        public virtual SAF_AUDITOR SAF_AUDITOR { get; set; }
        public virtual SAF_PARAMETRICA SAF_PARAMETRICA { get; set; }
        public virtual SAF_PARAMETRICA SAF_PARAMETRICA1 { get; set; }
        public virtual SAF_UNIVERSIDAD SAF_UNIVERSIDAD { get; set; }
        public virtual SAF_CARRERA SAF_CARRERA { get; set; }
    }
}
