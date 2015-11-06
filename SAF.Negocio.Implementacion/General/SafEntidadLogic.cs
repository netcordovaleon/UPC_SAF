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
    public class SafEntidadLogic : ISafEntidadLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly ISafEntidadData _safEntidadData;
        public SafEntidadLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safEntidadData = new SafEntidadData(_uow);
        }

        public SAF_ENTIDADES Registrar(SAF_ENTIDADES entidad)
        {
            throw new NotImplementedException();
        }

        public SAF_ENTIDADES Actualizar(SAF_ENTIDADES entidad)
        {
            throw new NotImplementedException();
        }

        public SAF_ENTIDADES BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SAF_ENTIDADES> ListarTodos()
        {
            return this._safEntidadData.GetAll();
        }


        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
