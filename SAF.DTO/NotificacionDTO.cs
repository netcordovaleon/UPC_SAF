using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    public class NotificacionDTO
    {
        [DataMember(Name = "CodigoNotificacion", Order = 1)]
        public int CODNOT { get; set; }
        [DataMember(Name = "UsuarioRecibeNotificacion", Order = 2)]
        public string USUNOTREC { get; set; }
        [DataMember(Name = "AsuntoNotificacion", Order = 3)]
        public string ASUNOT { get; set; }
        [DataMember(Name = "DescripcionNotificacion", Order = 4)]
        public string DESNOT { get; set; }
        [DataMember(Name = "IndNoLeido", Order = 5)]
        public string INDLEIDO { get; set; }
 
    }
}
