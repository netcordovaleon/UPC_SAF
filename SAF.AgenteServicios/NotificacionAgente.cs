using Microsoft.AspNet.SignalR.Client;
using System;
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
            var hubConnection = new HubConnection("http://localhost:3405", string.Format("name={0}", codUsuario));
            var webProxy = hubConnection.CreateHubProxy("NotificacionHub");
            await hubConnection.Start();
            await webProxy.Invoke("NotificarUsuario", codUsuario, totalNotificaciones);
        }


        public string mensaje()
        {
            NotificarCliente("10101010101");
            return "ya esta";

        }

    }
}
