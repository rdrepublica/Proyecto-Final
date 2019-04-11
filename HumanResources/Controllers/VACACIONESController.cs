using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HumanResources.Models;

namespace HumanResources.Controllers
{
    public class VACACIONESController : Controller
    {
        private HumanResourcesModel db = new HumanResourcesModel();

        // GET: VACACIONES
        public ActionResult Index()
        {
            return View(db.VACACIONES.ToList());
        }

        // GET: VACACIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACACIONE vACACIONE = db.VACACIONES.Find(id);
            if (vACACIONE == null)
            {
                return HttpNotFound();
            }
            return View(vACACIONE);
        }

        // GET: VACACIONES/Create
        public ActionResult Create()
        {
            var empleado = db.EMPLEADOS.ToList();
            var listaEmpleados = new SelectList(empleado, "NOMBRE", "NOMBRE");
            ViewBag.Empleados = listaEmpleados;
            return View();
        }

        // POST: VACACIONES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EMPLEADO,FECHA_INICIO,FECHA_FIN,ANO,COMENTARIOS")] VACACIONE vACACIONE)
        {
            if (ModelState.IsValid)
            {
                db.VACACIONES.Add(vACACIONE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vACACIONE);
        }

        // GET: VACACIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACACIONE vACACIONE = db.VACACIONES.Find(id);
            if (vACACIONE == null)
            {
                return HttpNotFound();
            }
            return View(vACACIONE);
        }

        // POST: VACACIONES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EMPLEADO,FECHA_INICIO,FECHA_FIN,ANO,COMENTARIOS")] VACACIONE vACACIONE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vACACIONE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vACACIONE);
        }

        // GET: VACACIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACACIONE vACACIONE = db.VACACIONES.Find(id);
            if (vACACIONE == null)
            {
                return HttpNotFound();
            }
            return View(vACACIONE);
        }

        // POST: VACACIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VACACIONE vACACIONE = db.VACACIONES.Find(id);
            db.VACACIONES.Remove(vACACIONE);
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
