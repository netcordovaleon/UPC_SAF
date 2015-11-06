using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    [DataContract]
    public class ConsultaDTO
    {
        [DataMember(Name = "CodigoConsulta", Order = 1)]
        public int CODCON { get; set; }
        [DataMember(Name = "DescripcionConsulta", Order = 2)]
        public string DESCON { get; set; }
        [DataMember(Name = "CodigoPublicacion", Order = 3)]
        public Nullable<int> CODPUB { get; set; }
        [DataMember(Name = "CodigoSOA", Order = 4)]
        public Nullable<int> CODSOA { get; set; }
        [DataMember(Name = "EstadoConsulta", Order = 2)]
        public Nullable<int> ESTCON { get; set; }
        

    }
}
