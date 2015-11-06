﻿using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;


namespace SAF.AccesoDatos
{
    public interface ISafSolExperienciaData : IBaseRepository<SAF_SOLEXPERIENCIA> { }
    public class SafSolExperienciaData: BaseRepository<SAF_SOLEXPERIENCIA>, ISafSolExperienciaData
    {
        public SafSolExperienciaData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
