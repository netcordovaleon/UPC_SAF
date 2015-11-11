using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAF.Configuracion.Constantes
{
    public static class Mensaje
    {

        public const string MensajeOperacionRealizadaExito = "La Operacion se realizo con exito";
        public const string MensajeErrorNoControlado = "El sistema tiene no responde, comuniquese con su administrador";

#region MENSAJE DE VALIDACION
        public const string MensajeCampoRequerido = "Este campo es obligatorio";
        public const string MensajeCampoDebeSerCorreo = "No es un correo electrónico válido.";
#endregion
    }
}
