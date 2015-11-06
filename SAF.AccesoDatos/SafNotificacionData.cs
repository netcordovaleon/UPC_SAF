﻿using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;


namespace SAF.AccesoDatos
{
    public interface ISafNotificacionData : IBaseRepository<SAF_NOTIFICACION> { }
    public class SafNotificacionData : BaseRepository<SAF_NOTIFICACION>, ISafNotificacionData
    {
        public SafNotificacionData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
