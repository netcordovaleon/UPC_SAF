using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    [DataContract]
    public class CronoEntidadDTO
    {
        [DataMember(Name = "CodigoCroEntidad", Order = 1)]
        public int CODCROENT { get; set; }
        [DataMember(Name = "FechaInicioCroEntidad", Order = 2)]
        public Nullable<System.DateTime> FECINICROENT { get; set; }
        [DataMember(Name = "FechaFinCroEntidad", Order = 3)]
        public Nullable<System.DateTime> FECFINCROENT { get; set; }
        [DataMember(Name = "CodigoTipoContrato", Order = 4)]
        public Nullable<int> TIPCONTCROENT { get; set; }
        [DataMember(Name = "CodigoTipoEntidad", Order = 5)]
        public Nullable<int> TIPENTCROENT { get; set; }
        [DataMember(Name = "DescripcionCroEntidad", Order = 6)]
        public string DESCROENT { get; set; }
        [DataMember(Name = "CodigoEntidad", Order = 7)]
        public Nullable<int> CODENT { get; set; }
        [DataMember(Name = "CodigoCronograma", Order = 8)]
        public Nullable<int> CODCRO { get; set; }
    }
}
