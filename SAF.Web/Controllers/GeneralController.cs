using SAF.Configuracion.Funcion;
using SAF.Web.Helper;
using System.Web.Mvc;
namespace SAF.Web.Controllers
{
    public class GeneralController : BaseController
    {
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
    }
}