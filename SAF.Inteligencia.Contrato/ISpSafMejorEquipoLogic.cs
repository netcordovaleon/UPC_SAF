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
    public interface ISpSafMejorEquipoLogic
    {
        IEnumerable<SP_SAF_MEJOREQUIPO_Result> VerMejorEquipoAuditoria(int idPublicacion, int idServicioAud);
    }
}
