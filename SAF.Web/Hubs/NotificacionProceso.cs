using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using AutoMapper;
//using CGR.INFOSAF.Entity;
//using CGR.INFOSAF.Service;
//using CGR.INFOSAF.Infraestructure.Estensions;
//using CGR.INFOSAF.Infraestructure.Enums;
//using CGR.INFOSAF.Infraestructure.Constants;
using System.Text;
//using CGR.INFOSAF.Data.Infrastructure;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SAF.Web.Hubs
{
    public class NotificacionProceso
    {
        //public void Registrar(SAF_NOTIFICACION pSAF_NOTIFICACION, ISAF_NOTIFICACIONService pNotificacionService)
        //{
        //    //string codUsuario = pSAF_NOTIFICACION.NUSR_CODIGO.ToString();                        
        //    //pNotificacionService.Insert(pSAF_NOTIFICACION);
        //    //var cantNoLeidas = pNotificacionService.ObtenerNoLeidas(codUsuario, TipoRespuesta.No, (int)TipoUsuario.Interno);
        //    //Hubs.Notificacion.Instance.NotificarTotalMensajes(codUsuario, cantNoLeidas.ToString());            
        //}

        public void Notificar(string codigo)/*, ISAF_NOTIFICACIONService pNotificacionService*/
        {
            //var cantNoLeidas = pNotificacionService.ObtenerNoLeidas(codigo, TipoRespuesta.No, (int)TipoUsuario.Interno);
            Hubs.Notificacion.Instance.NotificarTotalMensajes(codigo, /*cantNoLeidas.ToString()*/ "");
        }

        public void NotificarEnvioSolicitud(string codigo) /*, ISAF_NOTIFICACIONService pNotificacionService*/
        {
            //var cantNoLeidas = pNotificacionService.ObtenerNoLeidas(codigo, TipoRespuesta.No, (int)TipoUsuario.Interno);
            Hubs.Notificacion.Instance.NotificarTotalMensajes(codigo, "" /*cantNoLeidas.ToString()*/);
        }

    }
}