using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.AccesoDatos;
using SAF.Entidad;
using SAF.DTO;
using SAF.Configuracion;

namespace SAF.Negocio.Contrato
{
    public interface ISpSafInvitacionLogic
    {
        IEnumerable<SP_SAF_INVITACION_Result> VerResultadoCorte(int idPublicacion, int idServicioAud);
    }
}
