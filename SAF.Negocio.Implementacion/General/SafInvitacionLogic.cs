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
    public class SafInvitacionLogic : ISafInvitacionLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly ISafInvitacionData _safInvitacionData;
        public SafInvitacionLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safInvitacionData = new SafInvitacionData(_uow);
        }
 
        public SAF_INVITACION Registrar(SAF_INVITACION entidad)
        {
            return this._safInvitacionData.Add(entidad);
        }

        public SAF_INVITACION Actualizar(SAF_INVITACION entidad)
        {
            return this._safInvitacionData.Update(entidad);
        }

        public bool Eliminar(int id)
        {
            try { this._safInvitacionData.Delete(id); return true; }
            catch (Exception) { return false; }
        }

        public SAF_INVITACION BuscarPorId(int id)
        {
            return this._safInvitacionData.GetById(id);
        }

        public IEnumerable<SAF_INVITACION> ListarTodos()
        {
            return this._safInvitacionData.GetAll();
        }
    }
}
