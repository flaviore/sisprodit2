using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Chamado.Models;
using SisprodIT2.Map;

namespace SisprodIT2.Areas.Chamado.Controllers
{
    [Authorize]
    [SessionExpire]
    public class ChamadoController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Chamado/Chamado/

        public ActionResult Index()
        {
            var chamados = db.Chamados.Include(c => c.FuncionarioCriador).Include(c => c.Categoria).Include(c => c.Finalizacao);
            
            return View(chamados.ToList().OrderByDescending(x => x.DataAtualizacao));
        }

        //
        // GET: /Chamado/Chamado/Details/5

        public ActionResult Details(int id = 0)
        {
            ChamadoModel chamadomodel = db.Chamados.Find(id);
            if (chamadomodel == null)
            {
                return HttpNotFound();
            }
            return View(chamadomodel);
        }

        //
        // GET: /Chamado/Chamado/Create

        public ActionResult Create()
        {
            ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome");
            ViewBag.CategoriaModelId = new SelectList(db.Categorias.OrderBy(x => x.Descricao), "CategoriaModelId", "Descricao");
            //ViewBag.FinalizacaoModelId = new SelectList(db.Finalizacoes, "FinalizacaoModelId", "Descricao");
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            ViewBag.FinalizacaoModelId = db.Finalizacoes.Min(x => x.FinalizacaoModelId);
            return View();
        }

        //
        // POST: /Chamado/Chamado/Create

        [HttpPost]
        public ActionResult Create(ChamadoModel chamadomodel)
        {
            if (ModelState.IsValid)
            {
                db.Chamados.Add(chamadomodel);
                db.SaveChanges();
                return RedirectToAction("Index", "Home", new { Area = "" });
            }

            ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioResponsavelId);
            ViewBag.CategoriaModelId = new SelectList(db.Categorias, "CategoriaModelId", "Descricao", chamadomodel.CategoriaModelId);
            ViewBag.FinalizacaoModelId = new SelectList(db.Finalizacoes, "FinalizacaoModelId", "Descricao", chamadomodel.FinalizacaoModelId);
            return View(chamadomodel);
        }

        //
        // GET: /Chamado/Chamado/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ChamadoModel chamadomodel = db.Chamados.Find(id);
            if (chamadomodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioResponsavelId);
            ViewBag.CategoriaModelId = new SelectList(db.Categorias, "CategoriaModelId", "Descricao", chamadomodel.CategoriaModelId);
            ViewBag.FinalizacaoModelId = new SelectList(db.Finalizacoes, "FinalizacaoModelId", "Descricao", chamadomodel.FinalizacaoModelId);
            return View(chamadomodel);
        }

        //
        // POST: /Chamado/Chamado/Edit/5

        [HttpPost]
        public ActionResult Edit(ChamadoModel chamadomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamadomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioResponsavelId);
            ViewBag.CategoriaModelId = new SelectList(db.Categorias, "CategoriaModelId", "Descricao", chamadomodel.CategoriaModelId);
            ViewBag.FinalizacaoModelId = new SelectList(db.Finalizacoes, "FinalizacaoModelId", "Descricao", chamadomodel.FinalizacaoModelId);
            return View(chamadomodel);
        }

        //
        // GET: /Chamado/Chamado/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ChamadoModel chamadomodel = db.Chamados.Find(id);
            if (chamadomodel == null)
            {
                return HttpNotFound();
            }
            return View(chamadomodel);
        }

        //
        // POST: /Chamado/Chamado/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ChamadoModel chamadomodel = db.Chamados.Find(id);
            db.Chamados.Remove(chamadomodel);
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