using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    [DataContract]
    public class InvitacionViewDTO
    {
        [DataMember(Name = "CodigoInvitacion")]
        public int CODINV { get; set; }
        [DataMember(Name = "CodigoEstadoInvitacion")]
        public Nullable<int> ESTINV { get; set; }
        [DataMember(Name = "NombreEstadoInvitacion")]
        public string VALOR { get; set; }
        [DataMember(Name = "FechaMaxAceptaInvitacion")]
        public string FECACEPINV { get; set; }
        [DataMember(Name = "FechaMaxPreparaPropuesta")]
        public string FECMAXPREPROINV { get; set; }
        [DataMember(Name = "NumeroInvitacion")]
        public string NUMINV { get; set; }
        [DataMember(Name = "CodigoPublicacion")]
        public Nullable<int> CODPUB { get; set; }
        [DataMember(Name = "CodigoServicioAuditoria")]
        public Nullable<int> CODSERAUD { get; set; }
        [DataMember(Name = "CodigoAuditor")]
        public int CODAUD { get; set; }
        [DataMember(Name = "NombreCompletoAuditor")]
        public string NOMCOMAUD { get; set; }
        [DataMember(Name = "DNIAuditor")]
        public string DNIAUD { get; set; }
        [DataMember(Name = "CodigoSOA")]
        public int CODSOA { get; set; }
        [DataMember(Name = "RazonSocialSOA")]
        public string RAZSOCSOA { get; set; }
    }
}
