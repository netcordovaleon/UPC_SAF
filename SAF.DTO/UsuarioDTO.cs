using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    [DataContract]
    public class UsuarioDTO
    {
        [DataMember(Name = "CodigoUsuario", Order = 1)]
        public int CODUSU { get; set; }
        [DataMember(Name = "NombreUsuario", Order = 2)]
        public string NOMUSU { get; set; }
        [DataMember(Name = "ContraseniaUsuario", Order = 3)]
        public string PASUSU { get; set; }
        [DataMember(Name = "NombreRepresentaUsuario", Order = 4)]
        public string NOMPERUSU { get; set; }
        [DataMember(Name = "ApellidoRepresentaUsuario", Order = 5)]
        public string APEPERUSU { get; set; }
        [DataMember(Name = "DocumentoUsuario", Order = 6)]
        public string DNIUSU { get; set; }
        [DataMember(Name = "TipoCargoUsuario", Order = 7)]
        public Nullable<int> TIPCARUSU { get; set; }
    }
}
