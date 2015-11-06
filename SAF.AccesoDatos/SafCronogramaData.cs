using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{
    public interface ISafCronogramaData : IBaseRepository<SAF_CRONOGRAMA> { }
    public class SafCronogramaData : BaseRepository<SAF_CRONOGRAMA>, ISafCronogramaData
    {
        public SafCronogramaData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
