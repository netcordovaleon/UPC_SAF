using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    [DataContract]
    public class SolExperienciaDTO
    {
        [DataMember(Name = "CodigoSolicitudExperiencia", Order = 1)]
        public int CODSOLEXP { get; set; }
        [DataMember(Name = "DescripcionSolicitudExperiencia", Order = 2)]
        public string DESSOLEXP { get; set; }
        [DataMember(Name = "TiempoSolicitudExperiencia", Order = 3)]
        public Nullable<int> TIPEMPSOLEXP { get; set; }
        [DataMember(Name = "FechaInicioSolicitudExperiencia", Order = 4)]
        public string FECINISOLEXP { get; set; }
        [DataMember(Name = "FechaFinSolicitudExperiencia", Order = 5)]
        public string FECFINSOLEXP { get; set; }
        [DataMember(Name = "NumeroHoraSolicitudExperiencia", Order = 6)]   
        public Nullable<int> NUMHORSOLEXP { get; set; }
        [DataMember(Name = "CodigoSolicitud", Order = 7)]
        public Nullable<int> CODSOL { get; set; }
        [DataMember(Name = "CodigoEmpresa", Order = 8)]
        public Nullable<int> CODEMP { get; set; }
    }
}
