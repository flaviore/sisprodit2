using System.Web.Mvc;

namespace SisprodIT2.Areas.Telefone
{
    public class TelefoneAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Telefone";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Telefone_default",
                "Telefone/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
