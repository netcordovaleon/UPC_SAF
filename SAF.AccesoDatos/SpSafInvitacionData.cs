using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{
    public interface ISpSafInvitacionData : IBaseRepository<SP_SAF_INVITACION_Result> {
        IEnumerable<SP_SAF_INVITACION_Result> VerInvitaciones(int idPublicacion, int idServicioAud);
    }
    public class SpSafInvitacionData : BaseRepository<SP_SAF_INVITACION_Result>, ISpSafInvitacionData
    {
        private readonly IUnitOfWork _uow;

        public SpSafInvitacionData(IDatabaseFactory databaseFactory, IUnitOfWork uow)
            : base(uow)
        {
            _uow = uow;
        }

        public IEnumerable<SP_SAF_INVITACION_Result> VerInvitaciones(int idPublicacion, int idServicioAud)
        {
            return this._uow.DataContext().SP_SAF_INVITACION(idPublicacion, idServicioAud);
        }
    }
}
