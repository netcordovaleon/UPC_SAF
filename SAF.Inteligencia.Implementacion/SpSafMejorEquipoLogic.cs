using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.AccesoDatos;
using SAF.AccesoDatos.Repository;
using SAF.Entidad;
using SAF.DTO;
using SAF.Configuracion;
using SAF.Inteligencia.Contrato;

namespace SAF.Inteligencia.Implementacion
{
    public class SpSafMejorEquipoLogic : ISpSafMejorEquipoLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IDatabaseFactory _dataFactory;
        private readonly ISpSafMejorEquipoData _sSpSafMejorEquipoData;
        public SpSafMejorEquipoLogic()
        {
            this._uow = new UnitOfWork();
            this._dataFactory = new DatabaseFactory();
            this._sSpSafMejorEquipoData = new SpSafMejorEquipoData(_dataFactory, _uow);
        }


        public IEnumerable<SP_SAF_MEJOREQUIPO_Result> VerMejorEquipoAuditoria(int idPublicacion, int idServicioAud)
        {
            return this._sSpSafMejorEquipoData.VerMejorEquipoAuditoria(idPublicacion, idServicioAud);
        }
    }
}
