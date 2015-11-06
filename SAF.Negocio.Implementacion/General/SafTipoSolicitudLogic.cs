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
using SAF.Configuracion.Constantes;
using SAF.Entidad;
using SAF.DTO;
using AutoMapper.Mappers;
using AutoMapper;

namespace SAF.Negocio.Implementacion
{
    public class SafTipoSolicitudLogic : ISafTipoSolicitudLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly ISafTipoSolicitudData _safTipoSolicitudData;
        public SafTipoSolicitudLogic() 
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safTipoSolicitudData = new SafTipoSolicitudData(_uow);
        }


        public SAF_TIPOSOLICITUD Registrar(SAF_TIPOSOLICITUD entidad)
        {
            throw new NotImplementedException();
        }

        public SAF_TIPOSOLICITUD Actualizar(SAF_TIPOSOLICITUD entidad)
        {
            throw new NotImplementedException();
        }

        public SAF_TIPOSOLICITUD BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SAF_TIPOSOLICITUD> ListarTodos()
        {
            var result = _safTipoSolicitudData.GetAll();
            return result;
        }


        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
