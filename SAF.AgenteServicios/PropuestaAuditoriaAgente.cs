using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.AgenteServicios.ProxyServicioPropuestaAuditoria;
using SAF.DTO;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.Enum;
using SAF.Configuracion.ExcepcionNegocio;

namespace SAF.AgenteServicios
{
    public class PropuestaAuditoriaAgente
    {
        PropuestaAuditoriaLogicClient _servicesPropuestaAuditoriaProxy = new PropuestaAuditoriaLogicClient();

        public IEnumerable<InvitacionViewDTO> ListarInvitacion()
        {
            return this._servicesPropuestaAuditoriaProxy.ListarInvitacion();
        }

        public MensajeRespuesta GrabarInvitacion()
        {
            return null;
        }
    }
}
