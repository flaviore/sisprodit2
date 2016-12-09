using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Chamado.Models;
using SisprodIT2.Map;
using SisprodIT2.Areas.Comentario.Models;

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
            var chamados = db.Chamados.Include(c => c.FuncionarioCriador).Include(c => c.FuncionarioResponsavel).Include(c => c.Categoria).Include(c => c.Finalizacao);
            return View(chamados.ToList());
        }

        //
        // GET: /Chamado/Chamado/Details/5

        public ActionResult Details(int id = 0)
        {
            ChamadoModel chamadomodel = db.Chamados.Find(id);
            chamadomodel.Categoria = db.Categorias.Find(chamadomodel.CategoriaModelId);
            chamadomodel.FuncionarioCriador = db.Funcionarios.Find(chamadomodel.FuncionarioCriadorId);
            chamadomodel.FuncionarioResponsavel = db.Funcionarios.Find(chamadomodel.FuncionarioResponsavelId);
            chamadomodel.FuncionarioAtualizador = db.Funcionarios.Find(chamadomodel.FuncionarioAtualizadorId);
            chamadomodel.Finalizacao = db.Finalizacoes.Find(chamadomodel.FinalizacaoModelId);
            chamadomodel.ComentarioLista = db.Comentarios.ToList<ComentarioModel>().Where(x => x.ChamadoModelId == chamadomodel.ChamadoModelId).ToList();
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
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            ViewBag.FuncionarioCriadorId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome");
            //ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome");
            ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios.Where(b => new[] { "Administrador", "Gerente", "Agente" }.Contains(b.Perfil.Descricao)), "FuncionarioModelId", "Nome");
            ViewBag.CategoriaModelId = new SelectList(db.Categorias, "CategoriaModelId", "Descricao");
            ViewBag.FinalizacaoModelId = new SelectList(db.Finalizacoes, "FinalizacaoModelId", "Descricao");
            ViewBag.Revisao = 1;
            ViewBag.Status = "Pendente";
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

            ViewBag.FuncionarioCriadorId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioCriadorId);
            //ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioResponsavelId);
            ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios.Where(b => new[] { "Administrador", "Gerente", "Agente" }.Contains(b.Perfil.Descricao)), "FuncionarioModelId", "Nome");
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
            ViewBag.Revisao = chamadomodel.Revisao;
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            ViewBag.FuncionarioCriadorId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioCriadorId);
            //ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioResponsavelId);
            ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios.Where(b => new[] { "Administrador", "Gerente", "Agente" }.Contains(b.Perfil.Descricao)), "FuncionarioModelId", "Nome", chamadomodel.FuncionarioResponsavelId);
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
                chamadomodel.Revisao = chamadomodel.Revisao + 1;
                chamadomodel.Status = "Atribuido";
                db.Entry(chamadomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home", new { Area = "" });
            }

            ViewBag.Revisao = chamadomodel.Revisao;
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            ViewBag.FuncionarioCriadorId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioCriadorId);
            //ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioResponsavelId);
            ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios.Where(b => new[] { "Administrador", "Gerente", "Agente" }.Contains(b.Perfil.Descricao)), "FuncionarioModelId", "Nome", chamadomodel.FuncionarioResponsavelId);
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

        public ActionResult Close(int id = 0)
        {
            var chamadomodel = db.Chamados.Find(id);
            if (chamadomodel == null)
            {
                return HttpNotFound();
            }

            chamadomodel.Categoria = db.Categorias.Find(chamadomodel.CategoriaModelId);
            chamadomodel.FuncionarioCriador = db.Funcionarios.Find(chamadomodel.FuncionarioCriadorId);
            chamadomodel.FuncionarioResponsavel = db.Funcionarios.Find(chamadomodel.FuncionarioResponsavelId);
            chamadomodel.FuncionarioAtualizador = db.Funcionarios.Find(chamadomodel.FuncionarioAtualizadorId);

            ViewBag.Revisao = chamadomodel.Revisao;
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            ViewBag.FuncionarioCriadorId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioCriadorId);
            //ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioResponsavelId);
            ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios.Where(b => new[] { "Administrador", "Gerente", "Agente" }.Contains(b.Perfil.Descricao)), "FuncionarioModelId", "Nome", chamadomodel.FuncionarioResponsavelId);
            ViewBag.CategoriaModelId = new SelectList(db.Categorias, "CategoriaModelId", "Descricao", chamadomodel.CategoriaModelId);
            ViewBag.FinalizacaoModelId = new SelectList(db.Finalizacoes, "FinalizacaoModelId", "Descricao", chamadomodel.FinalizacaoModelId);
            return View(chamadomodel);
        }


        [HttpPost, ActionName("Close")]
        public ActionResult CloseConfirmed(ChamadoModel chamadomodel)
        {


            if (ModelState.IsValid)
            {
                chamadomodel.Categoria = db.Categorias.Find(chamadomodel.CategoriaModelId);
                chamadomodel.FuncionarioCriador = db.Funcionarios.Find(chamadomodel.FuncionarioCriadorId);
                chamadomodel.FuncionarioResponsavel = db.Funcionarios.Find(chamadomodel.FuncionarioResponsavelId);
                chamadomodel.FuncionarioAtualizador = db.Funcionarios.Find(chamadomodel.FuncionarioAtualizadorId);

                chamadomodel.Revisao = chamadomodel.Revisao + 1;
                chamadomodel.Status = "Fechado";
                db.Entry(chamadomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home", new { Area = "" });
            }

            ViewBag.Revisao = chamadomodel.Revisao;
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            ViewBag.FuncionarioCriadorId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioCriadorId);
            //ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", chamadomodel.FuncionarioResponsavelId);
            ViewBag.FuncionarioResponsavelId = new SelectList(db.Funcionarios.Where(b => new[] { "Administrador", "Gerente", "Agente" }.Contains(b.Perfil.Descricao)), "FuncionarioModelId", "Nome", chamadomodel.FuncionarioResponsavelId);
            ViewBag.CategoriaModelId = new SelectList(db.Categorias, "CategoriaModelId", "Descricao", chamadomodel.CategoriaModelId);
            ViewBag.FinalizacaoModelId = new SelectList(db.Finalizacoes, "FinalizacaoModelId", "Descricao", chamadomodel.FinalizacaoModelId);
            return View(chamadomodel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}