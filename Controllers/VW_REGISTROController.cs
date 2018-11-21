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
    public class VW_REGISTROController : Controller
    {
        private parcial2Entities db = new parcial2Entities();

        // GET: VW_REGISTRO
        public ActionResult Index()
        {
            return View(db.VW_REGISTRO.ToList());
        }

        // GET: VW_REGISTRO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_REGISTRO vW_REGISTRO = db.VW_REGISTRO.Find(id);
            if (vW_REGISTRO == null)
            {
                return HttpNotFound();
            }
            return View(vW_REGISTRO);
        }

        // GET: VW_REGISTRO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VW_REGISTRO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FOLIO,FECHA_DE_RECEPCION,FECHA_DE_ENTREGA,RUT_DEL_CLIENTE,NOMBRE_DEL_LABORATORIO,CANTIDAD_DE_MUESTRAS")] VW_REGISTRO vW_REGISTRO)
        {
            if (ModelState.IsValid)
            {
                db.VW_REGISTRO.Add(vW_REGISTRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vW_REGISTRO);
        }

        // GET: VW_REGISTRO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_REGISTRO vW_REGISTRO = db.VW_REGISTRO.Find(id);
            if (vW_REGISTRO == null)
            {
                return HttpNotFound();
            }
            return View(vW_REGISTRO);
        }

        // POST: VW_REGISTRO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FOLIO,FECHA_DE_RECEPCION,FECHA_DE_ENTREGA,RUT_DEL_CLIENTE,NOMBRE_DEL_LABORATORIO,CANTIDAD_DE_MUESTRAS")] VW_REGISTRO vW_REGISTRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vW_REGISTRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vW_REGISTRO);
        }

        // GET: VW_REGISTRO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VW_REGISTRO vW_REGISTRO = db.VW_REGISTRO.Find(id);
            if (vW_REGISTRO == null)
            {
                return HttpNotFound();
            }
            return View(vW_REGISTRO);
        }

        // POST: VW_REGISTRO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VW_REGISTRO vW_REGISTRO = db.VW_REGISTRO.Find(id);
            db.VW_REGISTRO.Remove(vW_REGISTRO);
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
