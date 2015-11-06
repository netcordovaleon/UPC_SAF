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
    public class SafSolicitudLogic : ISafSolicitudLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly ISafSolicitudData _safSolicitudData;
      

        public SafSolicitudLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safSolicitudData = new SafSolicitudData(_uow);
         
        }

        public SAF_SOLICITUD Registrar(SAF_SOLICITUD entidad)
        {
            var result = _safSolicitudData.Add(entidad);
            return result;
        }

        public SAF_SOLICITUD Actualizar(SAF_SOLICITUD entidad)
        {
            var result = _safSolicitudData.Update(entidad);
            return result;
        }

        public SAF_SOLICITUD BuscarPorId(int id)
        {
            var result = _safSolicitudData.GetById(id);
            return result;
        }

        public IEnumerable<SAF_SOLICITUD> ListarTodos()
        {
            var result = _safSolicitudData.GetAll();
            return result;
        }


        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}

