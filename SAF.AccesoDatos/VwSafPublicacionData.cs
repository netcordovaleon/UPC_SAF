using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{

    public interface IVwSafPublicacionData : IBaseRepository<VW_SAF_PUBLICACION> { }
    public class VwSafPublicacionData : BaseRepository<VW_SAF_PUBLICACION>, IVwSafPublicacionData
    {
        public VwSafPublicacionData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
