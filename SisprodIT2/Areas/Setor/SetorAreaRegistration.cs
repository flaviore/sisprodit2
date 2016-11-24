using System.Web.Mvc;

namespace SisprodIT2.Areas.Setor
{
    public class SetorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Setor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Setor_default",
                "Setor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
