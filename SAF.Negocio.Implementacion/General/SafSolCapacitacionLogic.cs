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
    public class SafSolCapacitacionLogic : ISafSolCapacitacionLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly ISafSolCapacitacionData _safSolCapacitacionData;
        public SafSolCapacitacionLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safSolCapacitacionData = new SafSolCapacitacionData(_uow);
        }


        public SAF_SOLCAPACITACION Registrar(SAF_SOLCAPACITACION entidad)
        {
            var result = _safSolCapacitacionData.Add(entidad);
            return result;
        }

        public SAF_SOLCAPACITACION Actualizar(SAF_SOLCAPACITACION entidad)
        {
            var result = _safSolCapacitacionData.Update(entidad);
            return result;
        }

        public SAF_SOLCAPACITACION BuscarPorId(int id)
        {
            var result = _safSolCapacitacionData.GetById(id);
            return result;
        }

        public IEnumerable<SAF_SOLCAPACITACION> ListarTodos()
        {
            var result = _safSolCapacitacionData.GetAll();
            return result;
        }


        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
