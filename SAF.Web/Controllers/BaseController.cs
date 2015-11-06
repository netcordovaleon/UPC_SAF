using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAF.Web.Controllers
{
    public class BaseController : Controller
    {
        public static string usuarioLogueado { get; set; }
	}
}