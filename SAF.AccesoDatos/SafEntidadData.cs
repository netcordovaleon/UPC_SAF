using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{
    public interface ISafEntidadData : IBaseRepository<SAF_ENTIDADES> { }
    public class SafEntidadData : BaseRepository<SAF_ENTIDADES>, ISafEntidadData
    {
        public SafEntidadData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
