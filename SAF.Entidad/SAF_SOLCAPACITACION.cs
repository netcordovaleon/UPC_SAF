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
    
    public partial class SAF_SOLCAPACITACION
    {
        public int CODSOLCAP { get; set; }
        public string DESSOLCAP { get; set; }
        public Nullable<System.DateTime> FECINISOLCAP { get; set; }
        public Nullable<System.DateTime> FECFINSOLCAP { get; set; }
        public Nullable<int> NUMHORSOLCAP { get; set; }
        public Nullable<System.DateTime> FECREG { get; set; }
        public Nullable<System.DateTime> FECMOD { get; set; }
        public string USUREG { get; set; }
        public string USUMOD { get; set; }
        public string ESTREG { get; set; }
        public Nullable<int> CODSOL { get; set; }
        public Nullable<int> CODUNI { get; set; }
        public Nullable<int> CODCAR { get; set; }
        public Nullable<int> CODTIPCAPA { get; set; }
        public Nullable<int> CODCATCAPA { get; set; }
        public Nullable<long> CODARC { get; set; }
        public string NOMBLABEL { get; set; }
    
        public virtual SAF_ARCHIVO SAF_ARCHIVO { get; set; }
        public virtual SAF_CARRERA SAF_CARRERA { get; set; }
        public virtual SAF_PARAMETRICA SAF_PARAMETRICA { get; set; }
        public virtual SAF_PARAMETRICA SAF_PARAMETRICA1 { get; set; }
        public virtual SAF_SOLICITUD SAF_SOLICITUD { get; set; }
        public virtual SAF_UNIVERSIDAD SAF_UNIVERSIDAD { get; set; }
    }
}
