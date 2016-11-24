using System.Web.Mvc;

namespace SisprodIT2.Areas.Perfil
{
    public class PerfilAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Perfil";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Perfil_default",
                "Perfil/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
