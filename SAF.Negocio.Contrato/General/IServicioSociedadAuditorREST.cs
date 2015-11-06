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
    public interface IServicioSociedadAuditorREST
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Publicacion")]
        IEnumerable<PublicacionDTO> ListarPublicacionJson();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ConsultaReg?idSoa={idSoa}&idPub={idPub}&desCon={desCon}")]
        MensajeRespuesta RegistroConsultaJson(int idSoa, int idPub, string desCon);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ConsultaEli?idCon={idCon}")]
        MensajeRespuesta EliminarConsultaJson(int idCon);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ConsultaLis?idSoa={idSoa}&idPub={idPub}")]
        IEnumerable<ConsultaDTO> ListarConsultaJson(int idSoa, int idPub);
    }
}
