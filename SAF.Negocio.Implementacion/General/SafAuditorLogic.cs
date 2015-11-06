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
    public class SafAuditorLogic : ISafAuditorLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly ISafAuditorData _safAuditorData;
        public SafAuditorLogic() {
            this._uow = new UnitOfWork();
            this._safAuditorData = new SafAuditorData(_uow);
        }

        public SAF_AUDITOR Registrar(SAF_AUDITOR entidad)
        {
           
            var result = _safAuditorData.Add(entidad);
            return (SAF_AUDITOR)result;
        }

        public SAF_AUDITOR Actualizar(SAF_AUDITOR entidad)
        {
            var result = _safAuditorData.Update(entidad);
            return (SAF_AUDITOR)result;
        }

        public SAF_AUDITOR BuscarPorId(int id)
        {
            var result = _safAuditorData.GetById(id);
            return (SAF_AUDITOR)result;
        }

        public IEnumerable<SAF_AUDITOR> ListarTodos()
        {
            var result = _safAuditorData.GetAll();
            return result;
        }

        public bool AccederAuditor(string usuario, string password)
        {
            var result = _safAuditorData.GetMany(c => c.NOMUSU == usuario && c.PASUSU == password).Any();
            return result;
        }


        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
