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

namespace SAF.Negocio.Implementacion {
    public class VwSafPropuestaEjecucionLogic : IVwSafPropuestaEjecucionLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IVwSafPropuestaEjecucionData _vwSafPropuestaEjecucionData;
        public VwSafPropuestaEjecucionLogic()
        {
            this._uow = new UnitOfWork();
            this._vwSafPropuestaEjecucionData = new VwSafPropuestaEjecucionData(_uow);
        }

        public IEnumerable<VW_SAF_PROPUESTAEJECUCION> ListarPropuestasEnEjecucion(int idSOA)
        {
            return this._vwSafPropuestaEjecucionData.GetMany(c => c.CODSOA == idSOA).ToList();
        }
    }
}
