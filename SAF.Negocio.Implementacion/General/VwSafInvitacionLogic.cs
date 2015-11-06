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

using SAF.Inteligencia.Contrato;
using SAF.Inteligencia.Implementacion;

namespace SAF.Negocio.Implementacion 
{
    public class VwSafInvitacionLogic : IVwSafInvitacionLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly IVwSafInvitacionData _vwSafInvitacionData;

        public VwSafInvitacionLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._vwSafInvitacionData = new VwSafInvitacionData(_uow);
        }

  
        public IEnumerable<VW_SAF_INVITACION> ListarInvitacion()
        {
            return this._vwSafInvitacionData.GetAll();
        }
    }
}
