using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SAF.DTO
{
    [DataContract]
    public class NotificacionDTO
    {
        [DataMember(Name = "CodigoNotificacion")]
        public int CODNOT { get; set; }
        [DataMember(Name = "UsuEmision")]
        public string USUEMI { get; set; }
        [DataMember(Name = "UsuRecepcion")]
        public string USUREC { get; set; }
        [DataMember(Name = "Asunto")]
        public string ASUNOT { get; set; }
        [DataMember(Name = "Descripcion")]
        public string DESNOT { get; set; }
        [DataMember(Name = "IndNotificacion")]
        public string INDNOT { get; set; }
        [DataMember(Name = "EstadoNotificacion")]
        public string ESTNOT { get; set; }
    }
}
