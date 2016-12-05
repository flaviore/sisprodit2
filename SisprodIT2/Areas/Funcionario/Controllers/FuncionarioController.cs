using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Funcionario.Models;
using SisprodIT2.Map;
using SisprodIT2.Areas.Telefone.Models;
using SisprodIT2.Areas.Email.Models;

namespace SisprodIT2.Areas.Funcionario.Controllers
{
    [Authorize]
    [SessionExpire]
    public class FuncionarioController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Funcionario/Funcionario/

        public ActionResult Index()
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            var funcionarios = db.Funcionarios.Include(f => f.Setor).Include(f => f.Perfil);
            return View(funcionarios.ToList());
        }

        //
        // GET: /Funcionario/Funcionario/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            FuncionarioModel funcionariomodel = db.Funcionarios.Find(id);
            funcionariomodel.Setor = db.Setores.Find(funcionariomodel.SetorModelId);
            funcionariomodel.Perfil = db.Perfis.Find(funcionariomodel.PerfilModelId);

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
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            ViewBag.SetorModelId = new SelectList(db.Setores, "SetorModelId", "Nome");
            ViewBag.PerfilModelId = new SelectList(db.Perfis, "PerfilModelId", "Descricao");
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            return View();
        }

        //
        // POST: /Funcionario/Funcionario/Create

        [HttpPost]
        public ActionResult Create(FuncionarioModel funcionariomodel, FormCollection form)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }

            string[] _ddd = form["ddd[]"].Split(',');
            string[] _telefones = form["telefone[]"].Split(',');
            string[] _email = form["email[]"].Split(',');

            if (ModelState.IsValid)
            {
                if (_ddd.Count() == _telefones.Count())
                {
                    for (int i = 0; i < _telefones.Count(); i++)
                    {
                        TelefoneModel telefone = new TelefoneModel();
                        telefone.DDD = int.Parse(_ddd[i]);
                        telefone.Telefone = int.Parse(_telefones[i]);

                        telefone.Ativo = true;
                        telefone.DataCadastro = DateTime.Now;
                        telefone.DataAtualizacao = DateTime.Now;
                        telefone.FuncionarioAtualizadorId = funcionariomodel.FuncionarioModelId;

                        funcionariomodel.TelefoneLista.Add(telefone);
                    }
                }

                for (int i = 0; i < _email.Count(); i++)
                {
                    EmailModel email = new EmailModel();
                    email.Email = _email[i];

                    email.Ativo = true;
                    email.DataCadastro = DateTime.Now;
                    email.DataAtualizacao = DateTime.Now;
                    email.FuncionarioAtualizadorId = funcionariomodel.FuncionarioModelId;

                    funcionariomodel.EmailLista.Add(email);
                }


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
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }

            FuncionarioModel funcionariomodel = db.Funcionarios.Find(id);

            if (funcionariomodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.SetorModelId = new SelectList(db.Setores, "SetorModelId", "Nome", funcionariomodel.SetorModelId);
            ViewBag.PerfilModelId = new SelectList(db.Perfis, "PerfilModelId", "Descricao", funcionariomodel.PerfilModelId);
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];

            funcionariomodel.TelefoneLista = db.Telefones.ToList<TelefoneModel>().Where(x => x.FuncionarioModelId == funcionariomodel.FuncionarioModelId).ToList();
            funcionariomodel.EmailLista = db.Emails.ToList<EmailModel>().Where(x => x.FuncionarioModelId == funcionariomodel.FuncionarioModelId).ToList();

            return View(funcionariomodel);
        }

        //
        // POST: /Funcionario/Funcionario/Edit/5

        [HttpPost]
        public ActionResult Edit(FuncionarioModel funcionariomodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }

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

        ////
        //// GET: /Funcionario/Funcionario/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    FuncionarioModel funcionariomodel = db.Funcionarios.Find(id);
        //    if (funcionariomodel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(funcionariomodel);
        //}

        ////
        //// POST: /Funcionario/Funcionario/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    FuncionarioModel funcionariomodel = db.Funcionarios.Find(id);
        //    db.Funcionarios.Remove(funcionariomodel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}