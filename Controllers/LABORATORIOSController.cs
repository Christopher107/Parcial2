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
    public class LABORATORIOSController : Controller
    {
        private parcial2Entities db = new parcial2Entities();

        // GET: LABORATORIOS
        public ActionResult Index()
        {
            return PartialView(db.LABORATORIOS.ToList());
        }

        // GET: LABORATORIOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LABORATORIOS lABORATORIOS = db.LABORATORIOS.Find(id);
            if (lABORATORIOS == null)
            {
                return HttpNotFound();
            }
            return View(lABORATORIOS);
        }

        // GET: LABORATORIOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LABORATORIOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LabId,LabNombre,LabMail,LabDireccion")] LABORATORIOS lABORATORIOS)
        {
            if (ModelState.IsValid)
            {
                db.LABORATORIOS.Add(lABORATORIOS);
                db.SaveChanges();
                return RedirectToAction("Create","RECEPCIONs");
            }

            return PartialView(lABORATORIOS);
        }

        // GET: LABORATORIOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LABORATORIOS lABORATORIOS = db.LABORATORIOS.Find(id);
            if (lABORATORIOS == null)
            {
                return HttpNotFound();
            }
            return View(lABORATORIOS);
        }

        // POST: LABORATORIOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LabId,LabNombre,LabMail,LabDireccion")] LABORATORIOS lABORATORIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lABORATORIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lABORATORIOS);
        }

        // GET: LABORATORIOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LABORATORIOS lABORATORIOS = db.LABORATORIOS.Find(id);
            if (lABORATORIOS == null)
            {
                return HttpNotFound();
            }
            return View(lABORATORIOS);
        }

        // POST: LABORATORIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LABORATORIOS lABORATORIOS = db.LABORATORIOS.Find(id);
            db.LABORATORIOS.Remove(lABORATORIOS);
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
