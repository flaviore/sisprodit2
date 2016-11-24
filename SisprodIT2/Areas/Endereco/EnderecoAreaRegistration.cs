using System.Web.Mvc;

namespace SisprodIT2.Areas.Endereco
{
    public class EnderecoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Endereco";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Endereco_default",
                "Endereco/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
