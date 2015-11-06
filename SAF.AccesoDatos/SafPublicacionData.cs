using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{
    public interface ISafPublicacionData : IBaseRepository<SAF_PUBLICACION> { }
    public class SafPublicacionData : BaseRepository<SAF_PUBLICACION>, ISafPublicacionData
    {
        public SafPublicacionData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
