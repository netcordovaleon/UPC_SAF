﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
using SAF.DTO;
using SAF.AgenteServicios;
using SAF.Web.Intranet.Areas.Publicacion.Models;

namespace SAF.Web.Intranet.Areas.Publicacion.Controllers
{
    public class EvaluadorController : Controller
    {

        private readonly ConcursoPublicoMeritoAgente _agenteConcursoPublicoMerito;

        public EvaluadorController()
        {
            this._agenteConcursoPublicoMerito = new ConcursoPublicoMeritoAgente();
        }

        public ActionResult Bandeja()
        {
            return View();
        }

        public JsonResult ListarPublicaciones()
        {
            var lista = this._agenteConcursoPublicoMerito.listarPublicacion();
            var data = lista.Select(c => new string[] {
                c.CODPUB.ToString(),
                c.NUMPUB,
                c.DESBAS,
                c.NOMPAR
            }).ToArray();
            return Json(data);
        }

        public JsonResult PublicarPublicacion(int id)
        {
            var result = this._agenteConcursoPublicoMerito.PublicarPublicacion(id);
            return Json(result);
        }

        public PartialViewResult VerResultadoCortePublicacion(int id)
        {
            var model = new PublicacionViewModel();
            model.CodigoPublicacion = id;
            return PartialView("_ResultadoCorte", model);
        }

        public JsonResult ListarResultadoCortePublicacion(int id)
        {
            var lista = this._agenteConcursoPublicoMerito.VerResultadoCorte(id);
            var data = lista.Select(c => new string[] { 
                c.NOMCOMAUD,
                c.NOMCAR.ToString(),
                c.CAPAPUNT.GetValueOrDefault().ToString(),
                c.EXPPUNT.GetValueOrDefault().ToString(),
                c.TOTALPUNT.GetValueOrDefault().ToString()
            }).ToArray();
            return Json(data);
        }
	}
}