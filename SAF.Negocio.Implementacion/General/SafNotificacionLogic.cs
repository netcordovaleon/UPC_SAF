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
    public class SafNotificacionLogic : ISafNotificacionLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly ISafNotificacionData _safNotificacionData;
        public SafNotificacionLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safNotificacionData = new SafNotificacionData(_uow);
        }

        public SAF_NOTIFICACION Registrar(SAF_NOTIFICACION entidad)
        {
            var result = _safNotificacionData.Add(entidad);
            return result;
        }

        public SAF_NOTIFICACION Actualizar(SAF_NOTIFICACION entidad)
        {
            var result = _safNotificacionData.Update(entidad);
            return result;
        }

        public SAF_NOTIFICACION BuscarPorId(int id)
        {
            var result = _safNotificacionData.GetById(id);
            return result;
        }

        public IEnumerable<SAF_NOTIFICACION> ListarTodos()
        {
            var result = _safNotificacionData.GetAll();
            return result;
        }

        public int ContadorNotificacionNoLeida(string usuario)
        {
            var result = this._safNotificacionData.GetMany(c => c.USUNOTREC == usuario);
            return Convert.ToInt32(result.Count());
        }


        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
