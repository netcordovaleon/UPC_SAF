using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;


namespace SAF.AccesoDatos
{

    public interface IVwSafSolicitudData : IBaseRepository<VW_SAF_SOLICITUD> { }
    public class VwSafSolicitudData : BaseRepository<VW_SAF_SOLICITUD>, IVwSafSolicitudData
    {
        public VwSafSolicitudData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
