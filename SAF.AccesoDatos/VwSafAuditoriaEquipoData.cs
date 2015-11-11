using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{

    public interface IVwSafAuditoriaEquipoData : IBaseRepository<VW_SAF_AUDITORIAEQUIPO> { }
    public class VwSafAuditoriaEquipoData : BaseRepository<VW_SAF_AUDITORIAEQUIPO>, IVwSafAuditoriaEquipoData
    {
        public VwSafAuditoriaEquipoData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
