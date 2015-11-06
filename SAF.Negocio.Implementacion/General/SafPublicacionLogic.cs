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
    public class SafPublicacionLogic : ISafPublicacionLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly ISafPublicacionData _safPublicacionData;

        public SafPublicacionLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safPublicacionData = new SafPublicacionData(_uow);
        }

 
        public SAF_PUBLICACION Registrar(SAF_PUBLICACION entidad)
        {
            return this._safPublicacionData.Add(entidad);
        }

        public SAF_PUBLICACION Actualizar(SAF_PUBLICACION entidad)
        {
            return this._safPublicacionData.Update(entidad);
        }

        public SAF_PUBLICACION BuscarPorId(int id)
        {
            return this._safPublicacionData.GetById(id);
        }

        public IEnumerable<SAF_PUBLICACION> ListarTodos()
        {
            return this._safPublicacionData.GetAll();
        }


        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
