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
    public class SafFaltaJustificadaLogic : ISafFaltaJustificadaLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly ISafFaltaJustificadaData _safFaltaJustificadaData;
        public SafFaltaJustificadaLogic()
        {
            this._uow = new UnitOfWork();
            this._safFaltaJustificadaData = new SafFaltaJustificadaData(_uow);
        }

        public SAF_FALTAJUSTIFICA Registrar(SAF_FALTAJUSTIFICA entidad)
        {
            return this._safFaltaJustificadaData.Add(entidad);
        }

        public SAF_FALTAJUSTIFICA Actualizar(SAF_FALTAJUSTIFICA entidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public SAF_FALTAJUSTIFICA BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SAF_FALTAJUSTIFICA> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
