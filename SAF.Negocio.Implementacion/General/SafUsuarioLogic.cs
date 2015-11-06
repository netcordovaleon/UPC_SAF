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
    public class SafUsuarioLogic : ISafUsuarioLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly ISafUsuarioData _safUsuarioData;

        public SafUsuarioLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._safUsuarioData = new SafUsuarioData(_uow);
        }

        public SAF_USUARIO Registrar(SAF_USUARIO entidad)
        {
            throw new NotImplementedException();
        }

        public SAF_USUARIO Actualizar(SAF_USUARIO entidad)
        {
            throw new NotImplementedException();
        }

        public SAF_USUARIO BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SAF_USUARIO> ListarTodos()
        {
            throw new NotImplementedException();
        }


        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
