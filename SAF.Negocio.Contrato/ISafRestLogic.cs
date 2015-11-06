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
    }
}
