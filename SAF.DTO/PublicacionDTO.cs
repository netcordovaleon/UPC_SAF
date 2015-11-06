using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace SAF.DTO
{
    [DataContract]
    public class PublicacionDTO
    {
        [DataMember(Name = "CodigoPublicacion", Order = 1)]
        public int CODPUB { get; set; }
        [DataMember(Name = "NumeroPublicacion", Order = 2)]
        public string NUMPUB { get; set; }
        [DataMember(Name = "FecMaxCreaConsulta", Order = 3)]
        public Nullable<System.DateTime> FECMAXCRECON { get; set; }
        [DataMember(Name = "CodigoBase", Order = 4)]
        public Nullable<int> CODBAS { get; set; }
        [DataMember(Name = "FecMaxConsulta", Order = 5)]
        public Nullable<System.DateTime> FECMAXCONS { get; set; }
        [DataMember(Name = "FecMaxRespConsulta", Order = 6)]
        public Nullable<System.DateTime> FECMAXRESCONS { get; set; }
        [DataMember(Name = "FecMaxPresProp", Order = 7)]
        public Nullable<System.DateTime> FECMAXPREPROP { get; set; }
        [DataMember(Name = "EstadoPublicacion", Order = 8)]
        public Nullable<int> ESTPUB { get; set; }

    }
}
