using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAF.Configuracion.Enum
{
    public static  class Notificacion
    {
        public const string asuntoSolicitudObservada = "Solicitud Observada";
        public const string asuntoSolicitudAceptada = "Solicitud Aceptada";
        public const string asuntoInvitacion = "Invitacion Auditoria";
        public const string asuntoCambiosConcurso = "Cambios en la Convocatoria";


        public const string bodySolicitudObservada = "Su solicitud fue observada <strong>" + DateTime.Now.ToLongDateString() + "</strong>";
        public const string bodySolicitudAceptada = "Su solicitud fue aceptada <strong>" + DateTime.Now.ToLongDateString() + "</strong>";

        public const string bodyCambiosConcurso = "Se realizaron cambios en el concurso " + DateTime.Now.ToLongDateString() + ": <br/>";
        

    }
}
