using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.AgenteServicios.ProxyServicioSeguridad;
using SAF.DTO;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.Enum;
using SAF.Configuracion.ExcepcionNegocio;

namespace SAF.AgenteServicios
{
    public class SeguridadAgente
    {
        SeguridadLogicClient _servicesSeguridadProxy = new SeguridadLogicClient();
        public MensajeRespuesta AccederSistemaExtranet(string usuario, string password, Tipo.TipoUsuarioExtranet tipoUsuario)
        {
            try
            {
                var result = _servicesSeguridadProxy.AccederSistemaExtranet(usuario, password, (int)tipoUsuario);
                if (result)
                    return new MensajeRespuesta("Ingreso al Sistema satisfactoriamente", true);
                else
                    return new MensajeRespuesta("Usuario y/o contraseña no coinciden", false);
            }
            catch (Exception)
            {
                return new MensajeRespuesta(Mensaje.MensajeErrorNoControlado, false);
            }
        }
    }
}
