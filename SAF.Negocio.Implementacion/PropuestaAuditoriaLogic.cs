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
using SAF.Inteligencia.Contrato;
using SAF.Inteligencia.Implementacion;

namespace SAF.Negocio.Implementacion
{
    public class PropuestaAuditoriaLogic : IPropuestaAuditoriaLogic
    {
        private readonly ISafInvitacionLogic _safInvitacionLogic;
        private readonly IVwSafInvitacionLogic _safVwInvitacionLogic;

        private readonly ISpSafMejorEquipoLogic _spSafMejorEquipoLogic;
        public PropuestaAuditoriaLogic()
        {
            Mapear.Do();
            this._safInvitacionLogic = new SafInvitacionLogic();
            this._safVwInvitacionLogic = new VwSafInvitacionLogic();
            this._spSafMejorEquipoLogic = new SpSafMejorEquipoLogic();
        }



        public InvitacionDTO GrabarInvitacion(InvitacionDTO entidad)
        {
            var invitacion = Mapper.Map<InvitacionDTO, SAF_INVITACION>(entidad);
            if (invitacion.CODINV.Equals(0))
            {
               invitacion = this._safInvitacionLogic.Registrar(invitacion);
            } else {
                var invitacionActual = this._safInvitacionLogic.BuscarPorId(invitacion.CODINV);
                invitacionActual.FECACEPINV = invitacion.FECACEPINV;
                invitacionActual.FECMAXPREPROINV = invitacion.FECMAXPREPROINV;
                invitacion = this._safInvitacionLogic.Actualizar(invitacionActual);
            }

            entidad.CODINV = invitacion.CODINV;
            return entidad;
        }

        public IEnumerable<InvitacionViewDTO> ListarInvitacion()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<SP_SAF_MEJOREQUIPO_Result> VerMejorEquipoAuditoria(int idPublicacion, int idServicioAud)
        {
            return this._spSafMejorEquipoLogic.VerMejorEquipoAuditoria(idPublicacion, idServicioAud);
        }
    }
}
