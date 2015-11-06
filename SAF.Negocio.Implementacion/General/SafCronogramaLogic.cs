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
    public class SafCronogramaLogic : ISafCronogramaLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly ISafCronogramaData _safCronogramaData;
        public SafCronogramaLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safCronogramaData = new SafCronogramaData(_uow);
        }

        public SAF_CRONOGRAMA Registrar(SAF_CRONOGRAMA entidad)
        {
            return this._safCronogramaData.Add(entidad);
        }

        public SAF_CRONOGRAMA Actualizar(SAF_CRONOGRAMA entidad)
        {
            return this._safCronogramaData.Update(entidad);
        }

        public SAF_CRONOGRAMA BuscarPorId(int id)
        {
            return this._safCronogramaData.GetById(id);
        }

        public IEnumerable<SAF_CRONOGRAMA> ListarTodos()
        {
            return this._safCronogramaData.GetAll();
        }


        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
