using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{

    public interface ISpSafMejorEquipoData : IBaseRepository<SP_SAF_MEJOREQUIPO_Result>
    {
        IEnumerable<SP_SAF_MEJOREQUIPO_Result> VerMejorEquipoAuditoria(int idPublicacion, int idServicioAud);
    }


    public class SpSafMejorEquipoData : BaseRepository<SP_SAF_MEJOREQUIPO_Result>, ISpSafMejorEquipoData
    {
        private readonly IUnitOfWork _uow;

        public SpSafMejorEquipoData(IDatabaseFactory databaseFactory, IUnitOfWork uow)
            : base(uow)
        {
            _uow = uow;
        }

        public IEnumerable<SP_SAF_MEJOREQUIPO_Result> VerMejorEquipoAuditoria(int idPublicacion, int idServicioAud)
        {
            return this._uow.DataContext().SP_SAF_MEJOREQUIPO(idPublicacion, idServicioAud);
        }
    }
}
