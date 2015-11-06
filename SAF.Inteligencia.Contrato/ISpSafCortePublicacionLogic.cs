using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.AccesoDatos;
using SAF.Entidad;
using SAF.DTO;
using SAF.Configuracion;
namespace SAF.Inteligencia.Contrato
{
    public interface ISpSafCortePublicacionLogic
    {
        SP_SAF_CORTEPUBLICACION_Result GenerarCortePublicacion(int idPublicacion);
    }
}
