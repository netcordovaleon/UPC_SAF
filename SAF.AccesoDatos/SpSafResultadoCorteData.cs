using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;
using System.Data.Objects;

namespace SAF.AccesoDatos
{


    public interface ISpSafResultadoCorteData : IBaseRepository<SP_SAF_RESULTADOCORTE_Result>
    {
        IEnumerable<SP_SAF_RESULTADOCORTE_Result> VerResultadoCorte(int idPublicacion);
    }


    public class SpSafResultadoCorteData : BaseRepository<SP_SAF_RESULTADOCORTE_Result>, ISpSafResultadoCorteData
    {
        private readonly IUnitOfWork _uow;

        public SpSafResultadoCorteData(IDatabaseFactory databaseFactory, IUnitOfWork uow)
            : base(uow)
        {
            _uow = uow;
        }

        public IEnumerable<SP_SAF_RESULTADOCORTE_Result> VerResultadoCorte(int idPublicacion)
        {
            return this._uow.DataContext().SP_SAF_RESULTADOCORTE(idPublicacion);
        }

    }
}
