using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.AgenteServicios.ProxyServicioGestionSoaAuditor;
using SAF.DTO;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.Enum;
using SAF.Configuracion.ExcepcionNegocio;
namespace SAF.AgenteServicios
{


    public class GestionSociedadAuditorAgente
    {
        GestionSociedadAuditorLogicClient _servicesGestionSoaAuditorProxy = new GestionSociedadAuditorLogicClient();
        public IEnumerable<TipoSolicitudDTO> listarRegistroTipoSolicitud()
        {
            try
            {
                var lista = this._servicesGestionSoaAuditorProxy.ListarTodoTipoSolicitud();
                var result = lista.Where(c => c.CODTIPSOL >= 1 && c.CODTIPSOL <= 2);
                if (result.Any())
                {
                    return result.ToList();
                }
                else
                {
                    return new List<TipoSolicitudDTO>();
                }
            }
            catch (Exception)
            {
                return new List<TipoSolicitudDTO>();
            }
        }

        public IEnumerable<TipoSolicitudDTO> listarTodoTipoSolicitud()
        {
            try
            {
                var lista = this._servicesGestionSoaAuditorProxy.ListarTodoTipoSolicitud();
                if (lista.Any())
                {
                    return lista.ToList();
                }
                else
                {
                    return new List<TipoSolicitudDTO>();
                }
            }
            catch (Exception)
            {
                return new List<TipoSolicitudDTO>();
            }
        }

        public MensajeRespuesta GrabarSolicitudRegistro(SolicitudInsActDTO entidad)
        {
            try
            {
                if (entidad.Solicitud.CODTIPSOL == (int)Tipo.TipoSolicitud.InscripcionSoa)
                    entidad.Auditor = null;
                else
                    entidad.Soa = null;
                var result = _servicesGestionSoaAuditorProxy.GrabarSolicitud(entidad);
                return new MensajeRespuesta(Mensaje.MensajeOperacionRealizadaExito, true, result);
            }
            catch (ExcepcionNegocio exn)
            {
                return new MensajeRespuesta(exn.Message, false);
            }
            catch (Exception)
            {

                return new MensajeRespuesta(Mensaje.MensajeErrorNoControlado, false);
            }
        }
    }
}
