using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{

    [DataContract]
    public class SoaDTO
    {
        [DataMember(Name = "CodigoSOA", Order = 1)]
        public int CODSOA { get; set; }
        [DataMember(Name = "RazonSocialSOA", Order = 2)]
        public string RAZSOCSOA { get; set; }
        [DataMember(Name = "RucSOA", Order = 1)]
        public string RUCSOA { get; set; }
        [DataMember(Name = "NombreRepLegalSOA", Order = 3)]
        public string NOMREPLEGSOA { get; set; }
        [DataMember(Name = "ApellidoRepLegalSOA", Order = 4)]
        public string APEREPLEGSOA { get; set; }
        [DataMember(Name = "CorreoRepLegalSOA", Order = 5)]
        public string CORREPLEGSOA { get; set; }
        [DataMember(Name = "CelularRepLegalSOA", Order = 6)]
        public string CELREPLEGSOA { get; set; }
        [DataMember(Name = "TelefonoRepLegalSOA", Order = 7)]
        public string TELREPLEGSOA { get; set; }
        [DataMember(Name = "CodigoColegioContadoresSOA", Order = 8)]
        public string CODCOLCONSOA { get; set; }
        [DataMember(Name = "NumeroPartidaSunarpSOA", Order = 9)]
        public string NUMPARSUNARPSOA { get; set; }
        [DataMember(Name = "FirmaPCAOBSOA", Order = 10)]
        public string FIRPCAOBSOA { get; set; }
        [DataMember(Name = "FirmaInternacionalSOA", Order = 11)]
        public string FIRINTSOA { get; set; }
        [DataMember(Name = "MisionSOA", Order = 12)]
        public string MISSOA { get; set; }
        [DataMember(Name = "VisionSOA", Order = 13)]
        public string VISSOA { get; set; }
        [DataMember(Name = "ArchivoColegioContadoresSOA", Order = 14)]
        public byte[] ARCCOLCONSOA { get; set; }

        [DataMember(Name = "NombreUsuario", Order = 15)]
        public string NOMUSU { get; set; }
        [DataMember(Name = "PasswordUsuario", Order = 16)]
        public string PASUSU { get; set; }
    }
}
