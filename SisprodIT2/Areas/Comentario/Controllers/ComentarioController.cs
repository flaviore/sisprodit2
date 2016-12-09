using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Comentario.Models;
using SisprodIT2.Map;

namespace SisprodIT2.Areas.Comentario.Controllers
{
    public class ComentarioController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Comentario/Comentario/

        public ActionResult Index()
        {
            var comentarios = db.Comentarios.Include(c => c.Chamado).Include(c => c.FuncionarioAtualizador);
            return View(comentarios.ToList());
        }

        //
        // GET: /Comentario/Comentario/Details/5

        public ActionResult Details(int id = 0)
        {
            ComentarioModel comentariomodel = db.Comentarios.Find(id);
            if (comentariomodel == null)
            {
                return HttpNotFound();
            }
            return View(comentariomodel);
        }

        //
        // GET: /Comentario/Comentario/Create

        public ActionResult Create(int id = 0)
        {
            //ViewBag.ChamadoModelId = new SelectList(db.Chamados, "ChamadoModelId", "Titulo");
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            ViewBag.ChamadoModelId = id;
            ViewBag.ChamadoTitulo = db.Chamados.Find(id).Titulo;
            ViewBag.FuncionarioAtualizadorId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome");
            return View();
        }

        //
        // POST: /Comentario/Comentario/Create

        [HttpPost]
        public ActionResult Create(ComentarioModel comentariomodel)
        {
            if (ModelState.IsValid)
            {
                db.Comentarios.Add(comentariomodel);
                db.SaveChanges();
                return RedirectToAction("Details", "Chamado",  new { Area = "Chamado", id = comentariomodel.ChamadoModelId});
            }
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            ViewBag.ChamadoModelId = new SelectList(db.Chamados, "ChamadoModelId", "Titulo", comentariomodel.ChamadoModelId);
            ViewBag.FuncionarioAtualizadorId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", comentariomodel.FuncionarioAtualizadorId);
            return View(comentariomodel);
        }

        //
        // GET: /Comentario/Comentario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ComentarioModel comentariomodel = db.Comentarios.Find(id);
            if (comentariomodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            //ViewBag.ChamadoModelId = new SelectList(db.Chamados, "ChamadoModelId", "Titulo", comentariomodel.ChamadoModelId);
            
            ViewBag.FuncionarioAtualizadorId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", comentariomodel.FuncionarioAtualizadorId);
            return View(comentariomodel);
        }

        //
        // POST: /Comentario/Comentario/Edit/5

        [HttpPost]
        public ActionResult Edit(ComentarioModel comentariomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentariomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Chamado", new { Area = "Chamado", id = comentariomodel.ChamadoModelId });
            }
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            ViewBag.ChamadoModelId = new SelectList(db.Chamados, "ChamadoModelId", "Titulo", comentariomodel.ChamadoModelId);
            ViewBag.FuncionarioAtualizadorId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", comentariomodel.FuncionarioAtualizadorId);
            return View(comentariomodel);
        }

        //
        // GET: /Comentario/Comentario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ComentarioModel comentariomodel = db.Comentarios.Find(id);
            
            if (comentariomodel == null)
            {
                return HttpNotFound();
            }
            comentariomodel.FuncionarioAtualizador = db.Funcionarios.Find(comentariomodel.FuncionarioAtualizadorId);
            return View(comentariomodel);
        }

        //
        // POST: /Comentario/Comentario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ComentarioModel comentariomodel = db.Comentarios.Find(id);
            db.Comentarios.Remove(comentariomodel);
            db.SaveChanges();
            return RedirectToAction("Details", "Chamado", new { Area = "Chamado", id = comentariomodel.ChamadoModelId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}