using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;


namespace SAF.AccesoDatos
{

    public interface ISafAsistenciaData : IBaseRepository<SAF_ASISTENCIA> { }


    public class SafAsistenciaData : BaseRepository<SAF_ASISTENCIA>, ISafAsistenciaData
    {
        public SafAsistenciaData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
