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
    public class LICENCIAController : Controller
    {
        private HumanResourcesModel db = new HumanResourcesModel();

        // GET: LICENCIA
        public ActionResult Index()
        {
            return View(db.LICENCIAS.ToList());
        }

        // GET: LICENCIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICENCIA lICENCIA = db.LICENCIAS.Find(id);
            if (lICENCIA == null)
            {
                return HttpNotFound();
            }
            return View(lICENCIA);
        }

        // GET: LICENCIA/Create
        public ActionResult Create()
        {
            var empleado = db.EMPLEADOS.ToList();
            var listaEmpleados = new SelectList(empleado, "NOMBRE", "NOMBRE");
            ViewBag.Empleados = listaEmpleados;
            return View();
        }

        // POST: LICENCIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EMPLEADO,FECHA_INICIO,FECHA_FIN,MOTIVO,COMENTARIOS")] LICENCIA lICENCIA)
        {
            if (ModelState.IsValid)
            {
                db.LICENCIAS.Add(lICENCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lICENCIA);
        }

        // GET: LICENCIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICENCIA lICENCIA = db.LICENCIAS.Find(id);
            if (lICENCIA == null)
            {
                return HttpNotFound();
            }
            return View(lICENCIA);
        }

        // POST: LICENCIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EMPLEADO,FECHA_INICIO,FECHA_FIN,MOTIVO,COMENTARIOS")] LICENCIA lICENCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lICENCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lICENCIA);
        }

        // GET: LICENCIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICENCIA lICENCIA = db.LICENCIAS.Find(id);
            if (lICENCIA == null)
            {
                return HttpNotFound();
            }
            return View(lICENCIA);
        }

        // POST: LICENCIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LICENCIA lICENCIA = db.LICENCIAS.Find(id);
            db.LICENCIAS.Remove(lICENCIA);
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
