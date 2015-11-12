using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    [DataContract]
    public class AuditoriaEquipoDTO
    {
        [DataMember(Name = "CodigoProEquipo")]
        public int CODPROEQU { get; set; }
        [DataMember(Name = "CodigoAuditor")]
        public Nullable<int> CODAUD { get; set;}
        [DataMember(Name = "CodigoCargo")]
        public Nullable<int> CODCAR { get; set; }
        [DataMember(Name = "CodigoAuditoria")]
        public Nullable<int> CODAUDITORIA { get; set; }
        [DataMember(Name = "NombreAuditor")]
        public string NOMCOMAUD { get; set; }
        [DataMember(Name = "NombreCargo")]
        public string NOMCAR { get; set; }


    }

}
