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

        private readonly IVwSafPublicacionLogic _vwSafPublicacionLogic;
        public SafRestLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safPublicacionLogic = new SafPublicacionLogic();
            this._safConsultaLogic = new SafConsultaLogic();

            this._safAuditorLogic = new SafAuditorLogic();
            this._safSoaLogic = new SafSoaLogic();

            this._vwSafPublicacionLogic = new VwSafPublicacionLogic();
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
    }
}
