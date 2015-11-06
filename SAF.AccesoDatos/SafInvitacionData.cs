using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{

    public interface ISafInvitacionData : IBaseRepository<SAF_INVITACION> { }
    public class SafInvitacionData : BaseRepository<SAF_INVITACION>, ISafInvitacionData
    {
        public SafInvitacionData(IUnitOfWork databaseFactory) : base(databaseFactory) { }

    }
}
