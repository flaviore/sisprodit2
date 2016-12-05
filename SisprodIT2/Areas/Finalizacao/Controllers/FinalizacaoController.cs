using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Finalizacao.Models;
using SisprodIT2.Map;

namespace SisprodIT2.Areas.Finalizacao.Controllers
{
    [Authorize]
    [SessionExpire]
    public class FinalizacaoController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Finalizacao/Finalizacao/

        public ActionResult Index()
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            return View(db.Finalizacoes.ToList().OrderBy(x => x.Descricao));
        }

        //
        // GET: /Finalizacao/Finalizacao/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            FinalizacaoModel finalizacaomodel = db.Finalizacoes.Find(id);
            if (finalizacaomodel == null)
            {
                return HttpNotFound();
            }
            return View(finalizacaomodel);
        }

        //
        // GET: /Finalizacao/Finalizacao/Create

        public ActionResult Create()
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            return View();
        }

        //
        // POST: /Finalizacao/Finalizacao/Create

        [HttpPost]
        public ActionResult Create(FinalizacaoModel finalizacaomodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            if (ModelState.IsValid)
            {
                db.Finalizacoes.Add(finalizacaomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(finalizacaomodel);
        }

        //
        // GET: /Finalizacao/Finalizacao/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            FinalizacaoModel finalizacaomodel = db.Finalizacoes.Find(id);
            if (finalizacaomodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            return View(finalizacaomodel);
        }

        //
        // POST: /Finalizacao/Finalizacao/Edit/5

        [HttpPost]
        public ActionResult Edit(FinalizacaoModel finalizacaomodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            if (ModelState.IsValid)
            {
                db.Entry(finalizacaomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(finalizacaomodel);
        }

        //
        // GET: /Finalizacao/Finalizacao/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            FinalizacaoModel finalizacaomodel = db.Finalizacoes.Find(id);
            if (finalizacaomodel == null)
            {
                return HttpNotFound();
            }
            return View(finalizacaomodel);
        }

        //
        // POST: /Finalizacao/Finalizacao/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            FinalizacaoModel finalizacaomodel = db.Finalizacoes.Find(id);
            db.Finalizacoes.Remove(finalizacaomodel);
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