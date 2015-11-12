using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    [DataContract]
    public class PropuestaEjecucionDTO
    {
        [DataMember(Name = "CodigoPropuesta")]
        public int CODPRO { get; set; }
        [DataMember(Name = "CodigoAuditoria")]
        public int CODAUD { get; set; }
        [DataMember(Name = "Periodo")]
        public string PERAUD { get; set; }
        [DataMember(Name = "CodigoSOA")]
        public Nullable<int> CODSOA { get; set; }
        [DataMember(Name = "CodigoPublicacion")]
        public int CODPUB { get; set; }
        [DataMember(Name = "DescripcionBase")]
        public string DESBAS { get; set; }
    }
}
