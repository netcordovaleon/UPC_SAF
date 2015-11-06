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
    public class SafConsultaLogic : ISafConsultaLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly ISafConsultaData _safConsultaData;

        public SafConsultaLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safConsultaData = new SafConsultaData(_uow);
        }
        public SAF_CONSULTA Registrar(SAF_CONSULTA entidad)
        {
            var result = _safConsultaData.Add(entidad);
            return result;
        }

        public SAF_CONSULTA Actualizar(SAF_CONSULTA entidad)
        {
            var result = _safConsultaData.Update(entidad);
            return result;
        }

        public SAF_CONSULTA BuscarPorId(int id)
        {
            var result = _safConsultaData.GetById(id);
            return result;
        }

        public IEnumerable<SAF_CONSULTA> ListarTodos()
        {
            var result = _safConsultaData.GetAll();
            return result;
        }


        public bool Eliminar(int id)
        {
            try { this._safConsultaData.Delete(id); return true; } catch (Exception) { return false; }
        }
    }
}
