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
    public class VwSafAuditoriaEquipoLogic : IVwSafAuditoriaEquipoLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly IVwSafAuditoriaEquipoData _vwSafAuditoriaEquipoData;
        public VwSafAuditoriaEquipoLogic()
        {
            this._uow = new UnitOfWork();
            this._vwSafAuditoriaEquipoData = new VwSafAuditoriaEquipoData(_uow);
        }


        public IEnumerable<VW_SAF_AUDITORIAEQUIPO> ListarEquipoPorAuditoria(int idAuditoria)
        {
            return this._vwSafAuditoriaEquipoData.GetMany(c => c.CODAUDITORIA == idAuditoria).ToList();
        }
    }
}
