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
    public class PERMISOController : Controller
    {
        private HumanResourcesModel db = new HumanResourcesModel();

        // GET: PERMISO
        public ActionResult Index(String searching)
        {
            return View(db.PERMISOS.Where(x => x.EMPLEADO.Contains(searching) | searching == null).ToList());
        }

        // GET: PERMISO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERMISO pERMISO = db.PERMISOS.Find(id);
            if (pERMISO == null)
            {
                return HttpNotFound();
            }
            return View(pERMISO);
        }

        // GET: PERMISO/Create
        public ActionResult Create()
        {
            var empleado = db.EMPLEADOS.ToList();
            var listaEmpleados = new SelectList(empleado, "NOMBRE", "NOMBRE");
            ViewBag.Empleados = listaEmpleados;
            return View();
        }

        // POST: PERMISO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EMPLEADO,FECHA_INICIO,FECHA_FIN,COMENTARIOS")] PERMISO pERMISO)
        {
            if (ModelState.IsValid)
            {
                db.PERMISOS.Add(pERMISO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pERMISO);
        }

        // GET: PERMISO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERMISO pERMISO = db.PERMISOS.Find(id);
            if (pERMISO == null)
            {
                return HttpNotFound();
            }
            return View(pERMISO);
        }

        // POST: PERMISO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EMPLEADO,FECHA_INICIO,FECHA_FIN,COMENTARIOS")] PERMISO pERMISO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERMISO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pERMISO);
        }

        // GET: PERMISO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERMISO pERMISO = db.PERMISOS.Find(id);
            if (pERMISO == null)
            {
                return HttpNotFound();
            }
            return View(pERMISO);
        }

        // POST: PERMISO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERMISO pERMISO = db.PERMISOS.Find(id);
            db.PERMISOS.Remove(pERMISO);
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
