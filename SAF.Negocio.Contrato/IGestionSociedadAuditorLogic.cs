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
    public interface IGestionSociedadAuditorLogic
    {
        [OperationContract]
        IEnumerable<TipoSolicitudDTO> ListarTodoTipoSolicitud();
        [OperationContract]
        SolicitudInsActDTO GrabarSolicitud(SolicitudInsActDTO entidad);
    }
}
