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
    public class SafSolExperienciaLogic : ISafSolExperienciaLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly ISafSolExperienciaData _safSolExperienciaData;
        public SafSolExperienciaLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safSolExperienciaData = new SafSolExperienciaData(_uow);
        }


        public SAF_SOLEXPERIENCIA Registrar(SAF_SOLEXPERIENCIA entidad)
        {
            var result = _safSolExperienciaData.Add(entidad);
            return result;
        }

        public SAF_SOLEXPERIENCIA Actualizar(SAF_SOLEXPERIENCIA entidad)
        {
            var result = _safSolExperienciaData.Update(entidad);
            return result;
        }

        public SAF_SOLEXPERIENCIA BuscarPorId(int id)
        {
            try
            {
                var result = _safSolExperienciaData.GetById(id);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<SAF_SOLEXPERIENCIA> ListarTodos()
        {
            var result = _safSolExperienciaData.GetAll();
            return result;
        }


        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
