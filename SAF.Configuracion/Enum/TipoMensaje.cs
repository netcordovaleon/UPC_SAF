using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAF.Configuracion.Enum
{
    public enum TipoMensaje
    {
        [Description("Error")]
        error,
        [Description("Advertencia")]
        advertencia,
        [Description("Satisfaccion")]
        satisfaccion

    }
}
