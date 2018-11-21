using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Parcial2.Models;

namespace Parcial2.Controllers
{
    public class INT_CLIENTESController : Controller
    {
        private parcial2Entities db = new parcial2Entities();

        // GET: INT_CLIENTES
        public ActionResult Index()
        {
            return PartialView(db.INT_CLIENTES.ToList());
        }

        // GET: INT_CLIENTES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INT_CLIENTES iNT_CLIENTES = db.INT_CLIENTES.Find(id);
            if (iNT_CLIENTES == null)
            {
                return HttpNotFound();
            }
            return View(iNT_CLIENTES);
        }

        // GET: INT_CLIENTES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: INT_CLIENTES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CliRut,CliNombre,CliDireccion,CliGiro,CliFonos")] INT_CLIENTES iNT_CLIENTES)
        {
            if (ModelState.IsValid)
            {
                db.INT_CLIENTES.Add(iNT_CLIENTES);
                db.SaveChanges();
                return RedirectToAction("Create","LABORATORIOS");
            }

            return PartialView(iNT_CLIENTES);
        }

        // GET: INT_CLIENTES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INT_CLIENTES iNT_CLIENTES = db.INT_CLIENTES.Find(id);
            if (iNT_CLIENTES == null)
            {
                return HttpNotFound();
            }
            return View(iNT_CLIENTES);
        }

        // POST: INT_CLIENTES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CliRut,CliNombre,CliDireccion,CliGiro,CliFonos")] INT_CLIENTES iNT_CLIENTES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNT_CLIENTES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iNT_CLIENTES);
        }

        // GET: INT_CLIENTES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INT_CLIENTES iNT_CLIENTES = db.INT_CLIENTES.Find(id);
            if (iNT_CLIENTES == null)
            {
                return HttpNotFound();
            }
            return View(iNT_CLIENTES);
        }

        // POST: INT_CLIENTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INT_CLIENTES iNT_CLIENTES = db.INT_CLIENTES.Find(id);
            db.INT_CLIENTES.Remove(iNT_CLIENTES);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
