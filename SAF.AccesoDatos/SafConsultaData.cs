﻿using SAF.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;


namespace SAF.AccesoDatos
{

    public interface ISafConsultaData : IBaseRepository<SAF_CONSULTA> { }
     public class SafConsultaData: BaseRepository<SAF_CONSULTA>, ISafConsultaData
    {
         public SafConsultaData(IUnitOfWork databaseFactory) : base(databaseFactory) { }
    }
}
