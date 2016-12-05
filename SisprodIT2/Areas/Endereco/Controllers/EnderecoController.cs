using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Endereco.Models;
using SisprodIT2.Map;

namespace SisprodIT2.Areas.Endereco.Controllers
{
    [Authorize]
    public class EnderecoController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Endereco/Endereco/

        public ActionResult Index()
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            var enderecos = db.Enderecos.Include(e => e.Funcionario);
            return View(enderecos.ToList());
        }

        //
        // GET: /Endereco/Endereco/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            EnderecoModel enderecomodel = db.Enderecos.Find(id);
            if (enderecomodel == null)
            {
                return HttpNotFound();
            }
            return View(enderecomodel);
        }

        //
        // GET: /Endereco/Endereco/Create

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
        // POST: /Endereco/Endereco/Create

        [HttpPost]
        public ActionResult Create(EnderecoModel enderecomodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            if (ModelState.IsValid)
            {
                db.Enderecos.Add(enderecomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioModelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", enderecomodel.FuncionarioModelId);
            return View(enderecomodel);
        }

        //
        // GET: /Endereco/Endereco/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            EnderecoModel enderecomodel = db.Enderecos.Find(id);
            if (enderecomodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioModelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", enderecomodel.FuncionarioModelId);
            return View(enderecomodel);
        }

        //
        // POST: /Endereco/Endereco/Edit/5

        [HttpPost]
        public ActionResult Edit(EnderecoModel enderecomodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            if (ModelState.IsValid)
            {
                db.Entry(enderecomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioModelId = new SelectList(db.Funcionarios, "FuncionarioModelId", "Nome", enderecomodel.FuncionarioModelId);
            return View(enderecomodel);
        }

        //
        // GET: /Endereco/Endereco/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            EnderecoModel enderecomodel = db.Enderecos.Find(id);
            if (enderecomodel == null)
            {
                return HttpNotFound();
            }
            return View(enderecomodel);
        }

        //
        // POST: /Endereco/Endereco/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            EnderecoModel enderecomodel = db.Enderecos.Find(id);
            db.Enderecos.Remove(enderecomodel);
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