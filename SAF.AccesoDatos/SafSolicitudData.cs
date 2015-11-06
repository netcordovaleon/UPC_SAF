using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;
namespace SAF.AccesoDatos
{
    public interface ISafSolicitudData : IBaseRepository<SAF_SOLICITUD> { }
    public class SafSolicitudData : BaseRepository<SAF_SOLICITUD>, ISafSolicitudData
    {
         public SafSolicitudData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }

}
