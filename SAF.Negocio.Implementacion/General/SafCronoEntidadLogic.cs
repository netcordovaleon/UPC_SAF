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
    public class SafCronoEntidadLogic : ISafCronoEntidadLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly ISafCronoEntidadData _safCronoEntidadData;
        public SafCronoEntidadLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safCronoEntidadData = new SafCronoEntidadData(_uow);
        }

        public SAF_CRONOENTIDAD Registrar(SAF_CRONOENTIDAD entidad)
        {
            return this._safCronoEntidadData.Add(entidad);
        }

        public SAF_CRONOENTIDAD Actualizar(SAF_CRONOENTIDAD entidad)
        {
            return this._safCronoEntidadData.Update(entidad);
        }

        public SAF_CRONOENTIDAD BuscarPorId(int id)
        {
            return this._safCronoEntidadData.GetById(id);
        }

        public IEnumerable<SAF_CRONOENTIDAD> ListarTodos()
        {
            return this._safCronoEntidadData.GetAll();
        }


        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
