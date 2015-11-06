using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{
    public interface ISafAuditorData : IBaseRepository<SAF_AUDITOR> { }
    public class SafAuditorData : BaseRepository<SAF_AUDITOR>, ISafAuditorData
    {
        public SafAuditorData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
