using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Categoria.Models;
using SisprodIT2.Map;

namespace SisprodIT2.Areas.Categoria.Controllers
{
    [Authorize]
    [SessionExpire]
    public class CategoriaController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Categoria/Categoria/

        public ActionResult Index()
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            return View(db.Categorias.ToList().OrderBy(x => x.Descricao));
        }

        //
        // GET: /Categoria/Categoria/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            CategoriaModel categoriamodel = db.Categorias.Find(id);
            if (categoriamodel == null)
            {
                return HttpNotFound();
            }
            return View(categoriamodel);
        }

        //
        // GET: /Categoria/Categoria/Create

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
        // POST: /Categoria/Categoria/Create

        [HttpPost]
        public ActionResult Create(CategoriaModel categoriamodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            if (ModelState.IsValid)
            {
                db.Categorias.Add(categoriamodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriamodel);
        }

        //
        // GET: /Categoria/Categoria/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            CategoriaModel categoriamodel = db.Categorias.Find(id);
            if (categoriamodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            return View(categoriamodel);
        }

        //
        // POST: /Categoria/Categoria/Edit/5

        [HttpPost]
        public ActionResult Edit(CategoriaModel categoriamodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            if (ModelState.IsValid)
            {
                db.Entry(categoriamodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriamodel);
        }

        //
        // GET: /Categoria/Categoria/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            CategoriaModel categoriamodel = db.Categorias.Find(id);
            if (categoriamodel == null)
            {
                return HttpNotFound();
            }
            return View(categoriamodel);
        }

        //
        // POST: /Categoria/Categoria/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            CategoriaModel categoriamodel = db.Categorias.Find(id);
            db.Categorias.Remove(categoriamodel);
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