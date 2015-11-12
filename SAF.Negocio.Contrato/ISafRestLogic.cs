using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;
using SAF.DTO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using SAF.Configuracion.Constantes;

namespace SAF.Negocio.Contrato
{
    [ServiceContract]
    public interface ISafRestLogic
    {

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "IniciarSession?usuario={usuario}&password={password}&tipoUsuario={tipoUsuario}")]
        bool AccederSistemaExtranet(string usuario, string password, int tipoUsuario);


        #region Formulario:::REGISTRO DE CONSULTA

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetPublicaciones")]
        IEnumerable<PublicacionViewDTO> listarPublicacion();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "InsertConsulta?idSoa={idSoa}&idPub={idPub}&desCon={desCon}")]
        MensajeRespuesta registrarConsulta(int idSoa, int idPub, string desCon);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "DeleteConsulta?idCon={idCon}")]
        MensajeRespuesta eliminarConsulta(int idCon);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "SendConsulta?idCon={idCon}")]
        MensajeRespuesta enviarConsulta(int idCon);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetConsultas?idSoa={idSoa}&idPub={idPub}")]
        IEnumerable<ConsultaDTO> listarConsulta(int idSoa, int idPub);
        
        #endregion

        #region :: ASISTENCIA

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetPropuestasEjec?idSoa={idSoa}")]
        IEnumerable<PropuestaEjecucionDTO> listarPropuestasEjecucion(int idSoa);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetEquipoAuditoria?idAuditoria={idAuditoria}")]
        IEnumerable<AuditoriaEquipoDTO> listarEquipoAuditoria(int idAuditoria);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "InsertJustificacion?strIdsEquipo={strIdsEquipo}&observacion={observacion}")]
        MensajeRespuesta grabarJustificacionFalta(string strIdsEquipo, string observacion);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "InsertAsistencia?strIdsEquipo={strIdsEquipo}")]
        MensajeRespuesta grabarAsistencia(string strIdsEquipo);
        #endregion


        #region NOTIFICACION

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetNotificaciones?usuario={usuario}")]
        IEnumerable<NotificacionDTO> ListarNotificaciones(string usuario);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetNotificacion?idNotificacion={idNotificacion}")]
        NotificacionDTO GetNotificacion(int idNotificacion);

        #endregion
    }
}
