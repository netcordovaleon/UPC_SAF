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
    public class SafSoaLogic : ISafSoaLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly ISafSoaData _safSoaData;
        private readonly ISafUsuarioData _safUsuarioData;

        public SafSoaLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safSoaData = new SafSoaData(_uow);
            this._safUsuarioData = new SafUsuarioData(_uow);
        }

        public SAF_SOA Registrar(SAF_SOA entidad)
        {
            var result = _safSoaData.Add(entidad);
            return result;
        }

        public SAF_SOA Actualizar(SAF_SOA entidad)
        {
 
            var result = _safSoaData.Update(entidad);
            return result;
        }

        public SAF_SOA BuscarPorId(int id)
        {
            var result = _safSoaData.GetById(id);
            return result;
        }

        public IEnumerable<SAF_SOA> ListarTodos()
        {
            return _safSoaData.GetAll();
        }

        public bool AccederSoa(string usuario, string password)
        {
            var result = _safSoaData.GetMany(c => c.NOMUSU == usuario && c.PASUSU == password).Any();
            return result;
        }


        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
