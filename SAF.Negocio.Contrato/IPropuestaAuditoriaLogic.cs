using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;
using SAF.DTO;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.Fachada;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace SAF.Negocio.Contrato
{
    [ServiceContract]
    public interface IPropuestaAuditoriaLogic
    {
        [OperationContract]
        InvitacionDTO GrabarInvitacion(InvitacionDTO entidad);
        [OperationContract]
        IEnumerable<InvitacionViewDTO> ListarInvitacion();
        [OperationContract]
        IEnumerable<SP_SAF_MEJOREQUIPO_Result> VerMejorEquipoAuditoria(int idPublicacion, int idServicioAud);
        
    }
}
