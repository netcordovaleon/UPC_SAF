using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.Entidad;
using SAF.DTO;
using SAF.Configuracion.Constantes;
using System.ServiceModel;
using System.Runtime.Serialization;
using SAF.Configuracion.Fachada;

namespace SAF.Negocio.Contrato
{
    public interface ISafCronogramaLogic : IFacadeOperacionCRUD<SAF_CRONOGRAMA>
    {
    }
}
