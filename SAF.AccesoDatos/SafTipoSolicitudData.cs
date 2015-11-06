using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{
 

    public interface ISafTipoSolicitudData : IBaseRepository<SAF_TIPOSOLICITUD> { }
    public class SafTipoSolicitudData : BaseRepository<SAF_TIPOSOLICITUD>, ISafTipoSolicitudData
    {
        public SafTipoSolicitudData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
