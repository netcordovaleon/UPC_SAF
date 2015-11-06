﻿using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;


namespace SAF.AccesoDatos
{
    public interface ISafSolCapacitacionData : IBaseRepository<SAF_SOLCAPACITACION> { }
    public class SafSolCapacitacionData : BaseRepository<SAF_SOLCAPACITACION>, ISafSolCapacitacionData
    {
        public SafSolCapacitacionData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
