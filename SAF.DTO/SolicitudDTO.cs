using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace SAF.DTO
{
    [DataContract]
    public class SolicitudDTO
    {

        [DataMember(Name="CodigoSolicitud", Order= 1)]
        public int CODSOL { get; set; }
        [DataMember(Name="NumeroSolicitud", Order= 2)]
        public string NUMSOL { get; set; }
        [DataMember(Name="DescripcionSolicitud", Order= 3)]
        public string DESSOL { get; set; }

        [DataMember(Name="CodigoTipoSolicitud", Order= 4)]
        public Nullable<int> CODTIPSOL { get; set; }
        [DataMember(Name="EstadoSolicitud", Order= 5)]
        public Nullable<int> ESTSOL { get; set; }
        [DataMember(Name="CodigoSociedadAuditoria", Order= 6)]
        public Nullable<int> CODSOA { get; set; }

        [DataMember(Name="CodigoAuditor", Order= 7)]
        public Nullable<int> CODAUD { get; set; }
    }
}
