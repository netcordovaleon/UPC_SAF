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
    public class TipoSolicitudDTO  
    {
        [DataMember(Name = "CodigoTipoSolicitud", Order = 1)]
        public int CODTIPSOL { get; set; }
        [DataMember(Name = "NombreTipoSolicitud", Order = 2)]
        public string NOMTIPSOL { get; set; }
        [DataMember(Name = "DescripcionTipoSolicitud", Order = 3)]
        public string DESTIPSOL { get; set; }
    }
}
