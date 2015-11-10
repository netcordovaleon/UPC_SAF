using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SAF.AgenteServicios;
using SAF.DTO;
using SAF.Configuracion.Enum;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.ExcepcionNegocio;
using SAF.Web.Intranet.Models;
using System.Transactions;

namespace SAF.Web.Intranet.Controllers
{
    public class AccesoController : Controller
    {

        SI_SOCAUDEntities modelEntity = new SI_SOCAUDEntities();
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        public JsonResult AccederSistema(string usuario, string contrasenia) {
            var result = this.modelEntity.SP_ACCEDERSISTEMAADMIN(usuario, contrasenia).ToList().FirstOrDefault();
            var datosUsuario = this.modelEntity.SAF_USUARIO.Where(c => c.NOMUSU == usuario).FirstOrDefault();
            if (result.EXITO.Equals(0)) {
                return Json(new MensajeRespuesta(result.MENSAJE, false));
            }
            else {
                Session["sessionUsuarioNombreCompleto"] = string.Format("{0} {1}", datosUsuario.NOMPERUSU, datosUsuario.APEPERUSU);
                return Json(new MensajeRespuesta(result.MENSAJE, true));
            }
        }
    }
}