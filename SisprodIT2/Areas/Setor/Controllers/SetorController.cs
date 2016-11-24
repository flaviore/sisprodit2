using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Setor.Models;
using SisprodIT2.Map;

namespace SisprodIT2.Areas.Setor.Controllers
{
    [Authorize]
    [SessionExpire]
    public class SetorController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Setor/Setor/

        public ActionResult Index()
        {
            return View(db.Setores.ToList());
        }

        //
        // GET: /Setor/Setor/Details/5

        public ActionResult Details(int id = 0)
        {
            SetorModel setormodel = db.Setores.Find(id);
            if (setormodel == null)
            {
                return HttpNotFound();
            }
            return View(setormodel);
        }

        //
        // GET: /Setor/Setor/Create

        public ActionResult Create()
        {
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            return View();
        }

        //
        // POST: /Setor/Setor/Create

        [HttpPost]
        public ActionResult Create(SetorModel setormodel)
        {
            if (ModelState.IsValid)
            {
                db.Setores.Add(setormodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setormodel);
        }

        //
        // GET: /Setor/Setor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            SetorModel setormodel = db.Setores.Find(id);
            if (setormodel == null)
            {
                return HttpNotFound();
            }
            return View(setormodel);
        }

        //
        // POST: /Setor/Setor/Edit/5

        [HttpPost]
        public ActionResult Edit(SetorModel setormodel, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setormodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                
                ModelState.AddModelError("error", "Erro!!");

                //return View(setormodel);
            }
            
            return View(setormodel);
        }

        //
        // GET: /Setor/Setor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SetorModel setormodel = db.Setores.Find(id);
            
            if (setormodel == null)
            {
                return HttpNotFound();
            }
            return View(setormodel);
        }

        //
        // POST: /Setor/Setor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SetorModel setormodel = db.Setores.Find(id);
            db.Setores.Remove(setormodel);
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