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
using SAF.Configuracion.Enum;
using SAF.Configuracion.ExcepcionNegocio;

namespace SAF.Negocio.Implementacion
{
    public class SafRestLogic : ISafRestLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly ISafPublicacionLogic _safPublicacionLogic;
        private readonly ISafConsultaLogic _safConsultaLogic;

        private readonly ISafAuditorLogic _safAuditorLogic;
        private readonly ISafSoaLogic _safSoaLogic;


        private readonly ISafNotificacionLogic _notificacionLogic;

        private readonly IVwSafPublicacionLogic _vwSafPublicacionLogic;

        private readonly ISafAsistenciaLogic _safAsistenciaLogic;
        private readonly ISafFaltaJustificadaLogic _safJustificarFaltaLogic;

        private readonly IVwSafPropuestaEjecucionLogic _vwSafPropuestaEjecucionLogic;
        private readonly IVwSafAuditoriaEquipoLogic _vwSafAuditoriaEquipoLogic;


        public SafRestLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safPublicacionLogic = new SafPublicacionLogic();
            this._safConsultaLogic = new SafConsultaLogic();

            this._safAuditorLogic = new SafAuditorLogic();
            this._safSoaLogic = new SafSoaLogic();

            this._notificacionLogic = new SafNotificacionLogic();

            this._vwSafPublicacionLogic = new VwSafPublicacionLogic();

            this._safAsistenciaLogic = new SafAsistenciaLogic();
            this._safJustificarFaltaLogic = new SafFaltaJustificadaLogic();

            this._vwSafPropuestaEjecucionLogic = new VwSafPropuestaEjecucionLogic();
            this._vwSafAuditoriaEquipoLogic = new VwSafAuditoriaEquipoLogic();
        }

        public bool AccederSistemaExtranet(string usuario, string password, int tipoUsuario)
        {
            var result = false;
            if (tipoUsuario == (int)Tipo.TipoUsuarioExtranet.Auditor)
                result = this._safAuditorLogic.AccederAuditor(usuario, password);
            else
                result = this._safSoaLogic.AccederSoa(usuario, password);
            return result;
        }

        #region Formulario:::REGISTRO DE CONSULTA

        public IEnumerable<PublicacionViewDTO> listarPublicacion()
        {
            var lista = this._vwSafPublicacionLogic.ListarPublicacion();
            var result = lista.Select(c => new PublicacionViewDTO() { CODPUB = c.CODPUB, CODBAS = c.CODBAS, NUMPUB = c.NUMPUB, DESBAS = c.DESBAS, ESTPUB = c.ESTPUB, NOMPAR = c.NOMPAR });
            return result;
        }


        public MensajeRespuesta ValidarFechaRegConsulta(int idPub)
        {

            var pub = this._safPublicacionLogic.BuscarPorId(idPub);


            var fechaString = pub.FECMAXCRECON.GetValueOrDefault().ToShortDateString();
            var fechaMaxConsulta = Convert.ToDateTime(fechaString);

            if (fechaMaxConsulta < DateTime.Now)
            {
                return new MensajeRespuesta("Fecha para registro de consultas finalizado", false);
            }

            return new MensajeRespuesta("Ok", true);
        }

        public MensajeRespuesta registrarConsulta(int idSoa, int idPub, string desCon)
        {
            try
            {

                var entidad = new SAF_CONSULTA()
                {
                    CODPUB = idPub,
                    CODSOA = idSoa,
                    DESCON = desCon,
                    ESTCON = (int)Estado.ConsultasPublicacion.Elaboracion
                };

                var result = this._safConsultaLogic.Registrar(entidad);
                return new MensajeRespuesta(Mensaje.MensajeOperacionRealizadaExito, true);
            }
            catch (Exception)
            {
                return new MensajeRespuesta(Mensaje.MensajeErrorNoControlado, false);
            }
        }

        public MensajeRespuesta eliminarConsulta(int idCon)
        {
            try
            {
                var result = this._safConsultaLogic.Eliminar(idCon);
                if (result)
                    return new MensajeRespuesta(Mensaje.MensajeOperacionRealizadaExito, true);
                else
                    return new MensajeRespuesta(Mensaje.MensajeErrorNoControlado, false);
            }
            catch (Exception)
            {
                return new MensajeRespuesta(Mensaje.MensajeErrorNoControlado, false);
            }
        }

        public MensajeRespuesta enviarConsulta(int idCon)
        {
            try
            {

                var consulta = this._safConsultaLogic.BuscarPorId(idCon);

                var pub = this._safPublicacionLogic.BuscarPorId(consulta.CODPUB.GetValueOrDefault());


                var fechaString = pub.FECMAXCRECON.GetValueOrDefault().ToShortDateString();
                var fechaMaxConsulta = Convert.ToDateTime(fechaString);

                if (fechaMaxConsulta < DateTime.Now)
                {
                    return new MensajeRespuesta("Fecha para registro de consultas finalizado", false);
                }


                if (consulta.ESTCON == (int)Estado.ConsultasPublicacion.Enviado)
                {
                    return new MensajeRespuesta("La consulta ya fue enviada", false);
                }

                consulta.ESTCON = (int)Estado.ConsultasPublicacion.Enviado;
                this._safConsultaLogic.Actualizar(consulta);
                return new MensajeRespuesta(Mensaje.MensajeOperacionRealizadaExito, true);
            }
            catch (Exception)
            {
                return new MensajeRespuesta(Mensaje.MensajeErrorNoControlado, false);
            }

        }

        public IEnumerable<ConsultaDTO> listarConsulta(int idSoa, int idPub)
        {
            var lista = this._safConsultaLogic.ListarTodos().Where(c=>c.CODSOA == idSoa && c.CODPUB == idPub);
            var result = lista.Select(c => new ConsultaDTO() { CODSOA = c.CODSOA, CODCON = c.CODCON, CODPUB =c.CODPUB, DESCON = c.DESCON, ESTCON = c.ESTCON }).ToList();
            return result;
        }

        #endregion


        public IEnumerable<PropuestaEjecucionDTO> listarPropuestasEjecucion(int idSoa)
        {
            var lista = this._vwSafPropuestaEjecucionLogic.ListarPropuestasEnEjecucion(idSoa);
            var result = (from c in lista select new PropuestaEjecucionDTO() { CODAUD = c.CODAUD, CODPRO = c.CODPRO, CODPUB = c.CODPUB, CODSOA = c.CODSOA, DESBAS = c.DESBAS, PERAUD = c.PERAUD });
            return result;
        }

        public IEnumerable<AuditoriaEquipoDTO> listarEquipoAuditoria(int idAuditoria)
        {
            var lista = this._vwSafAuditoriaEquipoLogic.ListarEquipoPorAuditoria(idAuditoria);
            var result = (from c in lista select new AuditoriaEquipoDTO() { CODAUD = c.CODAUD, CODAUDITORIA = c.CODAUDITORIA, CODCAR = c.CODCAR, CODPROEQU = c.CODPROEQU, NOMCAR = c.NOMCAR, NOMCOMAUD = c.NOMCOMAUD });
            return result;
        }


        public MensajeRespuesta grabarJustificacionFalta(string strIdsEquipo, string observacion)
        {   
            try 
        	{	        
                var arr = strIdsEquipo.Split(',');
                foreach (var item in arr)
	            {
		            this._safJustificarFaltaLogic.Registrar(new SAF_FALTAJUSTIFICA(){
                        CODPROEQU = Convert.ToInt32(item),
                        FECFALJUS = DateTime.Now,
                        COMENTFALJUS = observacion
                    });
	            }
                return new MensajeRespuesta("Se grabo la justificacion satisfactoriamente", true);
	        }
	        catch (Exception)
	        {
                return new MensajeRespuesta(Mensaje.MensajeErrorNoControlado, false);
	        }
        }

        public MensajeRespuesta grabarAsistencia(string strIdsEquipo)
        {
            try 
        	{	        
                var arr = strIdsEquipo.Split(',');
                foreach (var item in arr)
	            {
		            this._safAsistenciaLogic.Registrar(new SAF_ASISTENCIA(){
                        CODPROEQU = Convert.ToInt32(item),
                        FECASIS = DateTime.Now,
                        COMENTASIS = string.Format("{0} dia {1}", "Asistencia", DateTime.Now.ToShortDateString())
                    });
	            }
                return new MensajeRespuesta("Se grabo la asistencia satisfactoriamente", true);
	        }
	        catch (Exception)
	        {
                return new MensajeRespuesta(Mensaje.MensajeErrorNoControlado, false);
	        }
        }


        public IEnumerable<NotificacionDTO> ListarNotificaciones(string usuario)
        {
           var lista = this._notificacionLogic.ListarNotificaciones(usuario);
            var result = (from c in lista select new NotificacionDTO(){ ASUNOT = c.ASUNOT, DESNOT = c.DESNOT, CODNOT = c.CODNOT });
            return result;
        }

        public NotificacionDTO GetNotificacion(int idNotificacion)
        {
            var noti = this._notificacionLogic.GetNotificacion(idNotificacion);
            noti.INDNOT = "L";
            this._notificacionLogic.Actualizar(noti);

            var result = new NotificacionDTO();
            result.ASUNOT = noti.ASUNOT;
            result.DESNOT = noti.DESNOT;
            return result;
        }


        public SoaDTO ObtenerSoaPorUsuario(string usuario)
        {
            var infoSOA = this._safSoaLogic.InformacionPorUsuario(usuario);

            var result = new SoaDTO();
            result.CODSOA = infoSOA.CODSOA;
            result.RAZSOCSOA = infoSOA.RAZSOCSOA;
            result.RUCSOA = infoSOA.RUCSOA;
            return result;

        }
    }
}
