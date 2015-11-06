﻿using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{

    public interface IVwSafInvitacionData : IBaseRepository<VW_SAF_INVITACION> { }
    public class VwSafInvitacionData : BaseRepository<VW_SAF_INVITACION>, IVwSafInvitacionData
    {
        public VwSafInvitacionData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
