using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.AccesoDatos;
using SAF.AccesoDatos.Repository;
using SAF.Negocio.Contrato;
using SAF.Configuracion;
using SAF.Configuracion.Mapeo;
using SAF.Entidad;
using SAF.DTO;
using System.Transactions;
using AutoMapper.Mappers;
using AutoMapper;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.ExcepcionNegocio;

namespace SAF.Negocio.Implementacion
{
    public class GestionSociedadAuditorLogic : IGestionSociedadAuditorLogic
    {

        private readonly ISafSolicitudLogic _safSolicitudLogic;
        private readonly ISafAuditorLogic _safAuditorLogic;
        private readonly ISafSoaLogic _safSoaLogic;
        private readonly ISafTipoSolicitudLogic _safTipoSolicitudLogic;
        public GestionSociedadAuditorLogic()
        {
            Mapear.Do();
            this._safSolicitudLogic = new SafSolicitudLogic();
            this._safAuditorLogic = new SafAuditorLogic();
            this._safSoaLogic = new SafSoaLogic();
            this._safTipoSolicitudLogic = new SafTipoSolicitudLogic();
        }

        public SolicitudInsActDTO GrabarSolicitud(SolicitudInsActDTO entidad)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    var solicitud = Mapper.Map<SolicitudDTO, SAF_SOLICITUD>(entidad.Solicitud);

                  
                    if (entidad.Auditor != null) {
                        var auditor = Mapper.Map<AuditorDTO, SAF_AUDITOR>(entidad.Auditor);
                        var resultRegAuditor = this._safAuditorLogic.Registrar(auditor);
                        solicitud.CODAUD = resultRegAuditor.CODAUD;
                        entidad.Auditor.CODAUD = resultRegAuditor.CODAUD;
                    }

                    if (entidad.Soa != null) {
                        var soa = Mapper.Map<SoaDTO, SAF_SOA>(entidad.Soa);
                        var resultRegSoa = this._safSoaLogic.Registrar(soa);
                        solicitud.CODSOA = resultRegSoa.CODSOA;
                        entidad.Soa.CODSOA = resultRegSoa.CODSOA;
                    }

                    var resultRegSolicitud = this._safSolicitudLogic.Registrar(solicitud);
                    tran.Complete();
                    return entidad;
                }
                catch (ExcepcionNegocio)
                {
                    tran.Dispose();
                    throw;
                }
                catch (Exception) {
                    tran.Dispose();
                    throw;
                }
            }
        }

        public IEnumerable<TipoSolicitudDTO> ListarTodoTipoSolicitud()
        {
            var lista =  this._safTipoSolicitudLogic.ListarTodos();
            var result = (from c in lista select new TipoSolicitudDTO() {
                CODTIPSOL = c.CODTIPSOL,
                NOMTIPSOL = c.NOMTIPSOL,
                DESTIPSOL = c.DESTIPSOL
            });
            return result;
        }
 
    }
}
