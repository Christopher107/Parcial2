using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Parcial2.Models;

namespace Parcial2.Controllers
{

    public class RECEPCIONsController : Controller
    {
        private parcial2Entities db = new parcial2Entities();

        // GET: RECEPCIONs
        public ActionResult Index()
        {
            var rECEPCION = db.RECEPCION.Include(r => r.INT_CLIENTES).Include(r => r.LABORATORIOS);
            return PartialView(rECEPCION.ToList());
        }

        // GET: RECEPCIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPCION rECEPCION = db.RECEPCION.Find(id);
            if (rECEPCION == null)
            {
                return HttpNotFound();
            }
            return View(rECEPCION);
        }

        // GET: RECEPCIONs/Create
        public ActionResult Create()
        {
            ViewBag.CliRut = new SelectList(db.INT_CLIENTES, "CliRut", "CliNombre");
            ViewBag.LabId = new SelectList(db.LABORATORIOS, "LabId", "LabNombre");
            return View();
        }

        // POST: RECEPCIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecId,CliRut,LabId,RecFolio,RecFechaRecepcion,RecFechaEntrega,RecLocalidad,RecCantidadMuestras")] RECEPCION rECEPCION)
        {
            if (ModelState.IsValid)
            {
                db.RECEPCION.Add(rECEPCION);
                db.SaveChanges();
                return RedirectToAction("Index","RECEPCIONs");
            }

            ViewBag.CliRut = new SelectList(db.INT_CLIENTES, "CliRut", "CliNombre", rECEPCION.CliRut);
            ViewBag.LabId = new SelectList(db.LABORATORIOS, "LabId", "LabNombre", rECEPCION.LabId);
            return PartialView(rECEPCION);
        }

        public RECEPCIONsController(DateTime RecFechaRecepcion, DateTime RecFechaEntrega)
        {
            DateTime RecFechaRecepcion = Convert.ToDateTime(RecFechaRecepcion, new CultureInfo("es-ES"));
            RecFechaRecepcion = RecFechaRecepcion.AddDays(2);
            string resultado = RecFechaRecepcion.ToString("ddMMyyyy");
        }

        // GET: RECEPCIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPCION rECEPCION = db.RECEPCION.Find(id);
            if (rECEPCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.CliRut = new SelectList(db.INT_CLIENTES, "CliRut", "CliNombre", rECEPCION.CliRut);
            ViewBag.LabId = new SelectList(db.LABORATORIOS, "LabId", "LabNombre", rECEPCION.LabId);
            return View(rECEPCION);
        }

        // POST: RECEPCIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecId,CliRut,LabId,RecFolio,RecFechaRecepcion,RecFechaEntrega,RecLocalidad,RecCantidadMuestras")] RECEPCION rECEPCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rECEPCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CliRut = new SelectList(db.INT_CLIENTES, "CliRut", "CliNombre", rECEPCION.CliRut);
            ViewBag.LabId = new SelectList(db.LABORATORIOS, "LabId", "LabNombre", rECEPCION.LabId);
            return View(rECEPCION);
        }

        // GET: RECEPCIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPCION rECEPCION = db.RECEPCION.Find(id);
            if (rECEPCION == null)
            {
                return HttpNotFound();
            }
            return View(rECEPCION);
        }

        // POST: RECEPCIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RECEPCION rECEPCION = db.RECEPCION.Find(id);
            db.RECEPCION.Remove(rECEPCION);
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
