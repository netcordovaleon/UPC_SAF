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
 
using SAF.Negocio.Contrato;


namespace SAF.Negocio.Implementacion 
{
    public class SpSafResultadoCorteLogic : ISpSafResultadoCorteLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IDatabaseFactory _dataFactory;
        private readonly ISpSafResultadoCorteData _spSafResultadoCorteLogic;
        public SpSafResultadoCorteLogic()
        {
            this._uow = new UnitOfWork();
            this._dataFactory = new DatabaseFactory();
            this._spSafResultadoCorteLogic = new SpSafResultadoCorteData(_dataFactory, _uow);
        }

        public IEnumerable<SP_SAF_RESULTADOCORTE_Result> VerResultadoCorte(int idPublicacion)
        {
            return _spSafResultadoCorteLogic.VerResultadoCorte(idPublicacion);
        }

        public IEnumerable<SP_SAF_RESULTADOCORTE_Result> VerInvitaciones(int idPublicacion, int idServicioAud)
        {
            throw new NotImplementedException();
        }
    }
}
