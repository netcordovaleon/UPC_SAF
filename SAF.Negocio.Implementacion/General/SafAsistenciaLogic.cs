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
    public class SafAsistenciaLogic : ISafAsistenciaLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly ISafAsistenciaData _safAsistenciaData;
        public SafAsistenciaLogic()
        {
            this._uow = new UnitOfWork();
            this._safAsistenciaData = new SafAsistenciaData(_uow);
        }

        public SAF_ASISTENCIA Registrar(SAF_ASISTENCIA entidad)
        {
            return this._safAsistenciaData.Add(entidad);
        }

        public SAF_ASISTENCIA Actualizar(SAF_ASISTENCIA entidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public SAF_ASISTENCIA BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SAF_ASISTENCIA> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
