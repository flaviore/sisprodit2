using System.Web.Mvc;

namespace SisprodIT2.Areas.Finalizacao
{
    public class FinalizacaoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Finalizacao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Finalizacao_default",
                "Finalizacao/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
