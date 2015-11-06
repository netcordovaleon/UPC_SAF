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

    public interface ISpSafCortePublicacionData : IBaseRepository<SP_SAF_CORTEPUBLICACION_Result> 
    {
        SP_SAF_CORTEPUBLICACION_Result GenerarCortePublicacion(int idPublicacion);
    }
    public class SpSafCortePublicacionData : BaseRepository<SP_SAF_CORTEPUBLICACION_Result>, ISpSafCortePublicacionData
    {
        private readonly IUnitOfWork _uow;

        public SpSafCortePublicacionData(IDatabaseFactory databaseFactory, IUnitOfWork uow)
            : base(uow)
        {
            _uow = uow;
        }

        public SP_SAF_CORTEPUBLICACION_Result GenerarCortePublicacion(int idPublicacion)
        {
            //return this._uow.GetDataContext().SP_SAF_CORTEPUBLICACION(idPublicacion).FirstOrDefault();
            return this._uow.DataContext().SP_SAF_CORTEPUBLICACION(idPublicacion).FirstOrDefault();
        }
    }
}
