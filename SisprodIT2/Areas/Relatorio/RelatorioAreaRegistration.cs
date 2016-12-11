using System.Web.Mvc;

namespace SisprodIT2.Areas.Relatorio
{
    public class RelatorioAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Relatorio";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Relatorio_default",
                "Relatorio/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
