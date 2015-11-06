using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    [DataContract]
    public class SolCapacitacionDTO
    {
        [DataMember(Name = "CodigoSolicitudCapacitacion", Order = 1)]
        public int CODSOLCAP { get; set; }
        [DataMember(Name = "DescripcionSolicitudCapacitacion", Order = 2)]
        public string DESSOLCAP { get; set; }
        [DataMember(Name = "FechaInicioSolicitudCapacitacion", Order = 3)]
        public string FECINISOLCAP { get; set; }
        [DataMember(Name = "FechaFinSolicitudCapacitacion", Order = 4)]
        public string FECFINSOLCAP { get; set; }
        [DataMember(Name = "NumeroHorasSolicitudCapacitacion", Order = 5)]
        public Nullable<int> NUMHORSOLCAP { get; set; }
        [DataMember(Name = "ArchivoSolicitudCapacitacion", Order = 6)]
        public byte[] ARCCAP { get; set; }
        [DataMember(Name = "CodigoSolicitud", Order = 7)]
        public Nullable<int> CODSOL { get; set; }
        [DataMember(Name = "CodigoUniversidad", Order = 8)]
        public Nullable<int> CODUNI { get; set; }
        [DataMember(Name = "CodigoCarrera", Order = 9)]
        public Nullable<int> CODCAR { get; set; }
    }
}
