using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Map;
using SisprodIT2.Areas.Funcionario.Models;

namespace SisprodIT2.Controllers
{
    public class ContaController : Controller
    {
        //
        // GET: /Conta/

        private DataContext db = new DataContext();

        public ActionResult Login()
        {
            LimpaSessoes();
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, string ReturnUrl)
        {
            string usuario = form["Login"];
            FuncionarioModel funcionario = db.Funcionarios.Where(x => x.Usuario == usuario).Where(x => x.Ativo == true).FirstOrDefault();
            funcionario.Perfil = db.Perfis.Where(x => x.PerfilModelId == funcionario.PerfilModelId).FirstOrDefault();
            if (form["senha"] == funcionario.Senha)
            {

                System.Web.Security.FormsAuthentication.SetAuthCookie(form["login"], false);
                Session["NomeUsuario"] = funcionario.Nome;
                Session["FuncionarioModelId"] = funcionario.FuncionarioModelId;
                Session["Perfil"] = funcionario.Perfil.Descricao; 
                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logoff()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            LimpaSessoes();
            return Redirect("/Home/Index");
        }

        private void LimpaSessoes()
        {
            Session["NomeUsuario"] = null;
            Session["FuncionarioModelId"] = null;
        }

    }
}
