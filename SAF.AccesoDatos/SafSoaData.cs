using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{
    public interface ISafSoaData : IBaseRepository<SAF_SOA> { }
    public class SafSoaData : BaseRepository<SAF_SOA>, ISafSoaData
    {
        public SafSoaData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
