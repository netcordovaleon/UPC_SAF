using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    [DataContract]
    public class InvitacionDTO
    {
        [DataMember(Name = "CodigoInvitacion")]
        public int CODINV { get; set; }
        [DataMember(Name = "NumeroInvitacion")]
        public string NUMINV { get; set; }
        [DataMember(Name = "IndCancelaInvitacion")]
        public string INDCANINV { get; set; }
        [DataMember(Name = "FechaMaxAceptarInvitacion")]
        public Nullable<System.DateTime> FECACEPINV { get; set; }
        [DataMember(Name = "FechaMaxPreparaPropuesta")]
        public Nullable<System.DateTime> FECMAXPREPROINV { get; set; }
        [DataMember(Name = "CodigoSOA")]
        public Nullable<int> CODSOA { get; set; }
        [DataMember(Name = "CodigoAuditor")]
        public Nullable<int> CODAUD { get; set; }
        [DataMember(Name = "CodigoServicioAuditoria")]
        public Nullable<int> CODSERAUD { get; set; }
        [DataMember(Name = "CodigoPublicacion")]
        public Nullable<int> CODPUB { get; set; }
        [DataMember(Name = "EstadoInvitacion")]
        public Nullable<int> ESTINV { get; set; }
    }
}
