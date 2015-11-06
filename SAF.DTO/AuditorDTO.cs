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
    public class AuditorDTO
    {
        [DataMember(Name = "CodigoAuditor", Order = 1)]
        public int CODAUD { get; set; }
        [DataMember(Name = "NombreAuditor", Order = 2)]
        public string NOMAUD { get; set; }
        [DataMember(Name = "ApellidoAuditor", Order = 3)]
        public string APEAUD { get; set; }
        [DataMember(Name = "DNIAuditor", Order = 4)]
        public string DNIAUD { get; set; }
        [DataMember(Name = "CelularAuditor", Order = 5)]
        public string CELAUD { get; set; }
        [DataMember(Name = "TelefonoAuditor", Order = 6)]
        public string TELAUD { get; set; }
        [DataMember(Name = "DireccionAuditor", Order = 7)]
        public string DIRAUD { get; set; }
        [DataMember(Name = "CodigoDepartamentoAuditor", Order = 8)]
        public Nullable<int> CODDEPAUD { get; set; }
        [DataMember(Name = "CodigoProvinciaAuditor", Order = 9)]
        public Nullable<int> CODPROVAUD { get; set; }
        [DataMember(Name = "CodigoDistritoAuditor", Order = 10)]
        public Nullable<int> CODDISAUD { get; set; }
        [DataMember(Name = "CorreoAuditor", Order = 11)]
        public string CORAUD { get; set; }
        [DataMember(Name = "SexoAuditor", Order = 12)]
        public string SEXAUD { get; set; }
        [DataMember(Name = "FechaNacimientoAuditor", Order = 13)]
        public Nullable<System.DateTime> FECNACAUD { get; set; }
        [DataMember(Name = "IndicadorAuditorAuditor", Order = 14)]
        public string INDAUDAUD { get; set; }
        [DataMember(Name = "IndicadorEspecialistaAuditor", Order = 15)]
        public string INDESPAUD { get; set; }
        [DataMember(Name = "IndicadorSocioAuditor", Order = 16)]
        public string INDSOCAUD { get; set; }
        [DataMember(Name = "CodigoCertificadoAuditor", Order = 17)]
        public string CODCERAUD { get; set; }
        [DataMember(Name = "ArchivoCertificadoAuditor", Order = 18)]
        public byte[] ARCCERAUD { get; set; }

        [DataMember(Name = "NombreUsuario", Order = 19)]
        public string NOMUSU { get; set; }
        [DataMember(Name = "PasswordUsuario", Order = 20)]
        public string PASUSU { get; set; }       
    }
}
