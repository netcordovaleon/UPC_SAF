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
    public interface ISpSafResultadoCorteLogic
    {
        IEnumerable<SP_SAF_RESULTADOCORTE_Result> VerInvitaciones(int idPublicacion, int idServicioAud);
        IEnumerable<SP_SAF_RESULTADOCORTE_Result> VerResultadoCorte(int idPublicacion);
    }
}
