using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    [DataContract]
    public class CronogramaDTO
    {
        [DataMember(Name = "CodigoCronograma", Order = 1)]
        public int CODCRO { get; set; }
        [DataMember(Name = "AñoCronograma", Order = 2)]
        public Nullable<int> ANIOCRO { get; set; }
        [DataMember(Name = "FechaPublicaCronograma", Order = 3)]
        public Nullable<System.DateTime> FECPUBCRO { get; set; }
        [DataMember(Name = "FechaMaximaCreaBase", Order = 4)]
        public Nullable<System.DateTime> FECMAXCREBASCRO { get; set; }
        [DataMember(Name = "NumRepCronograma", Order = 5)]
        public Nullable<int> NUMREPCRO { get; set; }
        [DataMember(Name = "EstadoCronograma", Order = 6)]
        public Nullable<int> ESTCRO { get; set; }
    }
}
