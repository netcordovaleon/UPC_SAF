using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{

    [DataContract]
    public class ResultadoCorteSpDTO
    {
        [DataMember(Name="CodigoAuditor")]
        public Nullable<int> CODAUD { get; set; }
        [DataMember(Name = "NombreCompletoAuditor")]
        public string NOMCOMAUD { get; set; }
        [DataMember(Name = "NombreCargo")]
        public string NOMCAR { get; set; }
        [DataMember(Name = "CodigoCargo")]
        public Nullable<int> CODCAR { get; set; }
        [DataMember(Name = "HoraExpAudFinan")]
        public Nullable<int> EXPHORAUDFIN { get; set; }
        [DataMember(Name = "HoraExpGesPub")]
        public Nullable<int> EXPHORGESPUB { get; set; }
        [DataMember(Name = "HoraCapAudFinan")]
        public Nullable<int> CAPAHORAUDFIN { get; set; }
        [DataMember(Name = "HoraCapGesPub")]
        public Nullable<int> CAPAHORGESPUB { get; set; }
        [DataMember(Name = "PuntosExperiencia")]
        public Nullable<int> EXPPUNT { get; set; }
        [DataMember(Name = "PuntosCapacitacion")]
        public Nullable<int> CAPAPUNT { get; set; }
        [DataMember(Name = "TotalPuntos")]
        public Nullable<int> TOTALPUNT { get; set; }
    }
}
