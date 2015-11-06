using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    [DataContract]
    public class SolicitudInsActDTO
    {
        [DataMember(Name = "Solicitud", Order = 1)]
        public SolicitudDTO Solicitud { get; set; }
        [DataMember(Name = "Auditor", Order = 2)]
        public AuditorDTO Auditor { get; set; }
        [DataMember(Name = "SOA", Order = 3)]
        public SoaDTO Soa { get; set; }
        public SolicitudInsActDTO(){
            this.Auditor = new AuditorDTO();
            this.Soa = new SoaDTO();
            this.Solicitud = new SolicitudDTO();
        }
    }
}
