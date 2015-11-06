using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAF.Web.Models;
using SAF.AgenteServicios;
using SAF.DTO;
using SAF.Configuracion.Enum;

namespace SAF.Web.Controllers
{
    public class SegController : BaseController
    {

        ModeloExtranet modelEntity = new ModeloExtranet();

        SeguridadAgente _agenteSeguridad = new SeguridadAgente();
        public ActionResult Acceso()
        {
            return View();
        }

        public JsonResult IngresarSistema(int tipoUsuario, string usuario, string password)
        {
            var result = this._agenteSeguridad.AccederSistemaExtranet(usuario, password, (tipoUsuario == (int)Tipo.TipoUsuarioExtranet.Auditor) ? Tipo.TipoUsuarioExtranet.Auditor : Tipo.TipoUsuarioExtranet.SociedadAuditoria);
            if (result.Exito)
            {
                if (tipoUsuario == (int)Tipo.TipoUsuarioExtranet.Auditor)
                {
                    Session["sessionCodigoResponsableLogin"] = modelEntity.SAF_AUDITOR.Where(c => c.NOMUSU == usuario).FirstOrDefault().CODAUD;
                }
                else
                {
                    Session["sessionCodigoResponsableLogin"] = modelEntity.SAF_SOA.Where(c => c.NOMUSU == usuario).FirstOrDefault().CODSOA;
                }
                Session["sessionUsuario"] = usuario;
                Session["sessionTipoUsuario"] = tipoUsuario;
            }
            return Json(result);
        }
	}
}