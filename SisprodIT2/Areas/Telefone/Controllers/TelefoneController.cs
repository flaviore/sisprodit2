using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Telefone.Models;
using SisprodIT2.Map;

namespace SisprodIT2.Areas.Telefone.Controllers
{
    [Authorize]
    public class TelefoneController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Telefone/Telefone/

        public ActionResult Index()
        {
            var telefones = db.Telefones.Include(t => t.Funionario);
            return View(telefones.ToList());
        }

        //
        // GET: /Telefone/Telefone/Details/5

        public ActionResult Details(int id = 0)
        {
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
            ViewBag.FuncionarioModelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome");
            return View();
        }

        //
        // POST: /Telefone/Telefone/Create

        [HttpPost]
        public ActionResult Create(TelefoneModel telefonemodel)
        {
            if (ModelState.IsValid)
            {
                db.Telefones.Add(telefonemodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioModelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", telefonemodel.FuncionarioModelId);
            return View(telefonemodel);
        }

        //
        // GET: /Telefone/Telefone/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TelefoneModel telefonemodel = db.Telefones.Find(id);
            if (telefonemodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioModelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", telefonemodel.FuncionarioModelId);
            return View(telefonemodel);
        }

        //
        // POST: /Telefone/Telefone/Edit/5

        [HttpPost]
        public ActionResult Edit(TelefoneModel telefonemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefonemodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioModelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", telefonemodel.FuncionarioModelId);
            return View(telefonemodel);
        }

        //
        // GET: /Telefone/Telefone/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TelefoneModel telefonemodel = db.Telefones.Find(id);
            if (telefonemodel == null)
            {
                return HttpNotFound();
            }
            return View(telefonemodel);
        }

        //
        // POST: /Telefone/Telefone/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TelefoneModel telefonemodel = db.Telefones.Find(id);
            db.Telefones.Remove(telefonemodel);
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