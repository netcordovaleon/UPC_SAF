using Microsoft.AspNet.SignalR.Client;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAF.AgenteServicios
{
    public class NotificacionAgente
    {

        private async Task NotificarCliente(string codUsuario)
        {
            var totalNotificaciones = 2; //ContarNoLeidas(codUsuario, tipoUsuario);
            //var server = tipoUsuario == TipoUsuario.Interno ? string.Format("{0}/signalr", Config.InfosafUrlProyWeb) : string.Format("{0}/signalr", Config.InfosafUrlProyWebPub);
            var hubConnection = new HubConnection(System.Configuration.ConfigurationManager.AppSettings["HostSignalR"].ToString(), string.Format("name={0}", codUsuario));
            var webProxy = hubConnection.CreateHubProxy("NotificacionHub");
            await hubConnection.Start();
            await webProxy.Invoke("NotificarUsuario", codUsuario, totalNotificaciones);
        }


        public string mensaje(string usuarioNotificacion)
        {
            NotificarCliente(usuarioNotificacion);
            return SAF.Configuracion.Enum.TipoMensaje.satisfaccion.ToString();
        }
    }
}
