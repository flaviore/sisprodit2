using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Map;
using SisprodIT2.Areas.Chamado.Models;

namespace SisprodIT2.Controllers
{
    [Authorize]
    [SessionExpire]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            var chamados = db.Chamados.Include(c => c.FuncionarioCriador).Include(c => c.Categoria).Include(c => c.Finalizacao).Include(c => c.FuncionarioResponsavel);
            
            return View(chamados.ToList().OrderByDescending(x => x.DataCadastro));
        }

        public ActionResult SemPermissao()
        {
            return View("~/Views/Shared/SemPermissao.cshtml");
        }

    }
}
