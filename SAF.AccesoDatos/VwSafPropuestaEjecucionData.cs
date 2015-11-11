using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{
    public interface IVwSafPropuestaEjecucionData : IBaseRepository<VW_SAF_PROPUESTAEJECUCION> { }
    public class VwSafPropuestaEjecucionData : BaseRepository<VW_SAF_PROPUESTAEJECUCION>, IVwSafPropuestaEjecucionData
    {
        public VwSafPropuestaEjecucionData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
