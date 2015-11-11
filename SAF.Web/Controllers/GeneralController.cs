using SAF.Configuracion.Funcion;
using SAF.Web.Helper;
using System.Web.Mvc;
using System.Linq;

namespace SAF.Web.Controllers
{
    public class GeneralController : BaseController
    {

        ModeloExtranet modelEntity = new ModeloExtranet();


        // GET: General
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DescargarArchivo(long id)
        {
            var archivo = Archivo.DescargarArchivo(id);
            if (archivo == null || archivo.fileBytes == null)
            {
                return HttpNotFound();
            }
            return File(archivo.fileBytes, Texto.TipoMime(archivo.ARCNOMBFISICO), archivo.NOMBLABEL);
        }

        public JsonResult ContarNotificacionesUsuario() {
            string usu = Session["sessionUsuario"].ToString();
            var cantidadNotificaciones = modelEntity.SAF_NOTIFICACION.Where(c => c.USUREC == usu).Count();

            return Json(cantidadNotificaciones, JsonRequestBehavior.AllowGet);
        }
    }
}