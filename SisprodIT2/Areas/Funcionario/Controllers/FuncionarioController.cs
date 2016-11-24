using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Funcionario.Models;
using SisprodIT2.Map;

namespace SisprodIT2.Areas.Funcionario.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Funcionario/Funcionario/

        public ActionResult Index()
        {
            var funcionarios = db.Funcionarios.Include(f => f.Setor).Include(f => f.Perfil);
            return View(funcionarios.ToList());
        }

        //
        // GET: /Funcionario/Funcionario/Details/5

        public ActionResult Details(int id = 0)
        {
            FuncionarioModel funcionariomodel = db.Funcionarios.Find(id);
            if (funcionariomodel == null)
            {
                return HttpNotFound();
            }
            return View(funcionariomodel);
        }

        //
        // GET: /Funcionario/Funcionario/Create

        public ActionResult Create()
        {
            ViewBag.SetorModelId = new SelectList(db.Setores, "SetorModelId", "Nome");
            ViewBag.PerfilModelId = new SelectList(db.Perfis, "PerfilModelId", "Descricao");
            return View();
        }

        //
        // POST: /Funcionario/Funcionario/Create

        [HttpPost]
        public ActionResult Create(FuncionarioModel funcionariomodel)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionariomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SetorModelId = new SelectList(db.Setores, "SetorModelId", "Nome", funcionariomodel.SetorModelId);
            ViewBag.PerfilModelId = new SelectList(db.Perfis, "PerfilModelId", "Descricao", funcionariomodel.PerfilModelId);
            return View(funcionariomodel);
        }

        //
        // GET: /Funcionario/Funcionario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FuncionarioModel funcionariomodel = db.Funcionarios.Find(id);
            if (funcionariomodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.SetorModelId = new SelectList(db.Setores, "SetorModelId", "Nome", funcionariomodel.SetorModelId);
            ViewBag.PerfilModelId = new SelectList(db.Perfis, "PerfilModelId", "Descricao", funcionariomodel.PerfilModelId);
            return View(funcionariomodel);
        }

        //
        // POST: /Funcionario/Funcionario/Edit/5

        [HttpPost]
        public ActionResult Edit(FuncionarioModel funcionariomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionariomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SetorModelId = new SelectList(db.Setores, "SetorModelId", "Nome", funcionariomodel.SetorModelId);
            ViewBag.PerfilModelId = new SelectList(db.Perfis, "PerfilModelId", "Descricao", funcionariomodel.PerfilModelId);
            return View(funcionariomodel);
        }

        //
        // GET: /Funcionario/Funcionario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FuncionarioModel funcionariomodel = db.Funcionarios.Find(id);
            if (funcionariomodel == null)
            {
                return HttpNotFound();
            }
            return View(funcionariomodel);
        }

        //
        // POST: /Funcionario/Funcionario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FuncionarioModel funcionariomodel = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionariomodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}