using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAF.Web.Models;
using SAF.AgenteServicios;
using SAF.DTO;
using SAF.Configuracion.Enum;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.ExcepcionNegocio;
using Newtonsoft.Json;
using System.IO;

namespace SAF.Web.Controllers
{
    public class PropuestaController : Controller
    {
        ModeloExtranet modelEntity = new ModeloExtranet();
        //
        // GET: /Propuesta/
        public ActionResult Index()
        {
            var model = new PropuestaModel();
            model.cboPublicaciones = (from c in modelEntity.SAF_PUBLICACION.ToList() select new SelectListItem() { Text = c.NUMPUB, Value = c.CODPUB.ToString() }).ToList();
            return View(model);
        }
	}
}