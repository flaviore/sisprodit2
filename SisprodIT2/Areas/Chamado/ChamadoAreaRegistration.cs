using System.Web.Mvc;

namespace SisprodIT2.Areas.Chamado
{
    public class ChamadoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Chamado";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Chamado_default",
                "Chamado/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
