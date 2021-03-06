﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisprodIT2.Areas.Perfil.Models;
using SisprodIT2.Map;

namespace SisprodIT2.Areas.Perfil.Controllers
{
    [Authorize]
    [SessionExpire]
    public class PerfilController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Perfil/Perfil/

        public ActionResult Index()
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            return View(db.Perfis.ToList());
        }

        //
        // GET: /Perfil/Perfil/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            PerfilModel perfilmodel = db.Perfis.Find(id);
            if (perfilmodel == null)
            {
                return HttpNotFound();
            }
            return View(perfilmodel);
        }

        //
        // GET: /Perfil/Perfil/Create

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
        // POST: /Perfil/Perfil/Create

        [HttpPost]
        public ActionResult Create(PerfilModel perfilmodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            if (ModelState.IsValid)
            {
                db.Perfis.Add(perfilmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfilmodel);
        }

        //
        // GET: /Perfil/Perfil/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            ViewBag.FuncionarioModelId = Session["FuncionarioModelId"];
            PerfilModel perfilmodel = db.Perfis.Find(id);
            if (perfilmodel == null)
            {
                return HttpNotFound();
            }
            return View(perfilmodel);
        }

        //
        // POST: /Perfil/Perfil/Edit/5

        [HttpPost]
        public ActionResult Edit(PerfilModel perfilmodel)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            if (ModelState.IsValid)
            {
                db.Entry(perfilmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfilmodel);
        }

        //
        // GET: /Perfil/Perfil/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            PerfilModel perfilmodel = db.Perfis.Find(id);

            if (perfilmodel == null)
            {
                return HttpNotFound();
            }
            return View(perfilmodel);
        }

        //
        // POST: /Perfil/Perfil/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Session["Perfil"].ToString().Equals("Administrador"))
            {
                return RedirectToAction("SemPermissao", "Home", new { area = "" });
            }
            PerfilModel perfilmodel = db.Perfis.Find(id);
            db.Perfis.Remove(perfilmodel);
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