﻿using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;

namespace SAF.AccesoDatos
{

    public interface ISafFaltaJustificadaData : IBaseRepository<SAF_FALTAJUSTIFICA> { }
    public class SafFaltaJustificadaData : BaseRepository<SAF_FALTAJUSTIFICA>, ISafFaltaJustificadaData
    {
        public SafFaltaJustificadaData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
