using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.AgenteServicios.ProxyServicioConcursoPublicoMerito;
using SAF.DTO;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.Enum;
using SAF.Configuracion.ExcepcionNegocio;

namespace SAF.AgenteServicios
{
    public class ConcursoPublicoMeritoAgente
    {

        ConcursoPublicoMeritoLogicClient _servicesConcursoPublicoMeritoProxy = new ConcursoPublicoMeritoLogicClient();


        public IEnumerable<PublicacionViewDTO> listarPublicacion()
        {
            var result = this._servicesConcursoPublicoMeritoProxy.ListarPublicacion();
            return result;
        }

        public MensajeRespuesta PublicarPublicacion(int id)
        {
            try
            {
                var result = this._servicesConcursoPublicoMeritoProxy.PublicarPublicacion(id);
                return new MensajeRespuesta(Mensaje.MensajeOperacionRealizadaExito, true);
            }
            catch (Exception)
            {
                return new MensajeRespuesta(Mensaje.MensajeErrorNoControlado, false);
            }
        }

        public IEnumerable<ResultadoCorteSpDTO> VerResultadoCorte(int idPublicacion){
            var result = this._servicesConcursoPublicoMeritoProxy.VerResultadoCorte(idPublicacion);
            return result;
        }

  


    }
}
