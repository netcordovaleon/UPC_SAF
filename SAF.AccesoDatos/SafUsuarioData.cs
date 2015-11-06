using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{
    public interface ISafUsuarioData : IBaseRepository<SAF_USUARIO> { }

    public class SafUsuarioData : BaseRepository<SAF_USUARIO>, ISafUsuarioData
    {
        public SafUsuarioData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
