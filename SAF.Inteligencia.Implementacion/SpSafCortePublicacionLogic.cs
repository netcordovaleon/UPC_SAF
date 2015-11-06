using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.AccesoDatos;
using SAF.AccesoDatos.Repository;
using SAF.Entidad;
using SAF.DTO;
using SAF.Configuracion;
using SAF.Inteligencia.Contrato;

namespace SAF.Inteligencia.Implementacion
{
    public class SpSafCortePublicacionLogic : ISpSafCortePublicacionLogic
    {

        private readonly IUnitOfWork _uow;
        private readonly IDatabaseFactory _dataFactory;
        private readonly ISpSafCortePublicacionData _spSafCortePublicacionData;
        public SpSafCortePublicacionLogic ()
        {
            this._uow = new UnitOfWork();
            this._dataFactory = new DatabaseFactory();
            this._spSafCortePublicacionData = new SpSafCortePublicacionData(_dataFactory, _uow);
        }

        public SP_SAF_CORTEPUBLICACION_Result GenerarCortePublicacion(int idPublicacion)
        {
            return _spSafCortePublicacionData.GenerarCortePublicacion(idPublicacion);
        }
    }
}
