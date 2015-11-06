using System.Web.Mvc;

namespace SAF.Web.Intranet.Areas.Areas
{
    public class AreasAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Publicacion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Publicacion_default",
                url: "Publicacion/{controller}/{action}/{id}",
                defaults: new { area = "Publicacion", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "SAF.Web.Intranet.Areas.Publicacion.Controllers" }
            );
            //context.MapRoute(
            //    "Publicacion_default",
            //    "Publicacion/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}