//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAF.Web
{
    using System;
    using System.Collections.Generic;
    
    public partial class SAF_BASEENTREGABLE
    {
        public int CODBASENT { get; set; }
        public string NOMBASENT { get; set; }
        public Nullable<System.DateTime> FECENTBASENT { get; set; }
        public Nullable<int> NUMCOPBASENT { get; set; }
        public Nullable<System.DateTime> FECREG { get; set; }
        public Nullable<System.DateTime> FECMOD { get; set; }
        public string USUREG { get; set; }
        public string USUMOD { get; set; }
        public string ESTREG { get; set; }
        public Nullable<int> CODBAS { get; set; }
    
        public virtual SAF_BASE SAF_BASE { get; set; }
    }
}