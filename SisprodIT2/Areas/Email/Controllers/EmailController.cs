using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Email.Models;
using SisprodIT2.Map;

namespace SisprodIT2.Areas.Email.Controllers
{
    [Authorize]
    public class EmailController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Email/Email/

        public ActionResult Index()
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            var emails = db.Emails.Include(e => e.Funcionario);
            return View(emails.ToList());
        }

        //
        // GET: /Email/Email/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            EmailModel emailmodel = db.Emails.Find(id);
            if (emailmodel == null)
            {
                return HttpNotFound();
            }
            return View(emailmodel);
        }

        //
        // GET: /Email/Email/Create

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
        // POST: /Email/Email/Create

        [HttpPost]
        public ActionResult Create(EmailModel emailmodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            if (ModelState.IsValid)
            {
                db.Emails.Add(emailmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioModelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", emailmodel.FuncionarioModelId);
            return View(emailmodel);
        }

        //
        // GET: /Email/Email/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            EmailModel emailmodel = db.Emails.Find(id);
            if (emailmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioModelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", emailmodel.FuncionarioModelId);
            return View(emailmodel);
        }

        //
        // POST: /Email/Email/Edit/5

        [HttpPost]
        public ActionResult Edit(EmailModel emailmodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            if (ModelState.IsValid)
            {
                db.Entry(emailmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioModelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", emailmodel.FuncionarioModelId);
            return View(emailmodel);
        }

        //
        // GET: /Email/Email/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            EmailModel emailmodel = db.Emails.Find(id);
            if (emailmodel == null)
            {
                return HttpNotFound();
            }
            return View(emailmodel);
        }

        //
        // POST: /Email/Email/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            EmailModel emailmodel = db.Emails.Find(id);
            db.Emails.Remove(emailmodel);
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