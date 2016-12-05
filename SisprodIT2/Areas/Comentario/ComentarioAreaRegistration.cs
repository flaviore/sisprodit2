using System.Web.Mvc;

namespace SisprodIT2.Areas.Comentario
{
    public class ComentarioAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Comentario";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Comentario_default",
                "Comentario/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
