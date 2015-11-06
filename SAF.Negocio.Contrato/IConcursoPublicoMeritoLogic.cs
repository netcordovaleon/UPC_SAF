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
    public interface IConcursoPublicoMeritoLogic
    {
        #region Cronograma
        [OperationContract]
        CronogramaDTO GrabarCronograma(CronogramaDTO entidad);
        [OperationContract]
        CronoEntidadDTO GrabarCronoEntidad(CronoEntidadDTO entidad);
        #endregion

        #region Publicaciones
        [OperationContract]
        IEnumerable<PublicacionViewDTO> ListarPublicacion();
        [OperationContract]
        PublicacionDTO PublicarPublicacion(int id);
        #endregion

        #region Inteligencia Negocio
        [OperationContract]
        SP_SAF_CORTEPUBLICACION_Result GenerarCortePublicacion(int idPublicacion);
        #endregion
        [OperationContract]
        IEnumerable<ResultadoCorteSpDTO> VerResultadoCorte(int idPublicacion);

    }
}
