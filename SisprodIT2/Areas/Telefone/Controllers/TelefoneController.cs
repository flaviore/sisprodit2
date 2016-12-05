using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Telefone.Models;
using SisprodIT2.Map;
using SisprodIT2.Areas.Funcionario.Models;

namespace SisprodIT2.Areas.Telefone.Controllers
{
    [Authorize]
    [SessionExpire]
    public class TelefoneController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Telefone/Telefone/

        public ActionResult Index(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            FuncionarioModel funcionariomodel = db.Funcionarios.Find(id);

            //var telefones = db.Telefones.Include(t => t.Funcionario);
            var telefones = db.Telefones.Where(x => x.FuncionarioModelId == funcionariomodel.FuncionarioModelId).ToList();
            //return View(telefones.ToList());
            return View(telefones);
        }

        public ActionResult List(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }

            FuncionarioModel funcionariomodel = db.Funcionarios.Find(id);
            if (funcionariomodel == null)
            {
                return HttpNotFound();
            }

            var telefones = db.Telefones.Where(x => x.FuncionarioModelId == funcionariomodel.FuncionarioModelId).ToList();

            return View(telefones);
        }

        //
        // GET: /Telefone/Telefone/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }

            TelefoneModel telefonemodel = db.Telefones.Find(id);
            if (telefonemodel == null)
            {
                return HttpNotFound();
            }
            return View(telefonemodel);
        }

        //
        // GET: /Telefone/Telefone/Create

        public ActionResult Create()
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }

            ViewBag.FuncionarioModelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome");
            return View();
        }

        //
        // POST: /Telefone/Telefone/Create

        [HttpPost]
        public ActionResult Create(TelefoneModel telefonemodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }

            if (ModelState.IsValid)
            {
                db.Telefones.Add(telefonemodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioModelId = telefonemodel.FuncionarioModelId;
            return View(telefonemodel);
        }

        //
        // GET: /Telefone/Telefone/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }

            TelefoneModel telefonemodel = db.Telefones.Find(id);
            if (telefonemodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            
            return View("Edit",telefonemodel);
        }

        //
        // POST: /Telefone/Telefone/Edit/5

        [HttpPost]
        public ActionResult Edit(TelefoneModel telefonemodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }

            if (ModelState.IsValid)
            {
                db.Entry(telefonemodel).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                ViewBag.Mensagem = "Telefone Alterado com sucesso.";
                ViewBag.FuncionarioModelId = telefonemodel.FuncionarioModelId;
                return View();
            }
            
            //return View(telefonemodel);
            return View("Edit", "Telefone", new { area = "Telefone", model = telefonemodel });
            
        }

        //
        // GET: /Telefone/Telefone/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }

            TelefoneModel telefonemodel = db.Telefones.Find(id);
            if (telefonemodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            return View(telefonemodel);
        }

        //
        // POST: /Telefone/Telefone/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }

            TelefoneModel telefonemodel = db.Telefones.Find(id);
            db.Telefones.Remove(telefonemodel);
            db.SaveChanges();
            var mensagem = "Telefone Excluído com sucesso.";
            return RedirectToAction("Edit", "Funcionario", new { area = "Funcionario", id = telefonemodel.FuncionarioModelId, mensagem });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}