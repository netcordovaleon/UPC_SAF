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
    public class VwSafPublicacionLogic : IVwSafPublicacionLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly IVwSafPublicacionData _vwSafPublicacionData;

        public VwSafPublicacionLogic()
        {
            Mapear.Do();
            this._uow = new UnitOfWork();
            this._vwSafPublicacionData = new VwSafPublicacionData(_uow);
        }


        public IEnumerable<VW_SAF_PUBLICACION> ListarPublicacion()
        {
            return this._vwSafPublicacionData.GetAll();
        }
    }
}
