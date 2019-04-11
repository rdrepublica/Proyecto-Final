using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HumanResources.Models;

namespace HumanResources.Controllers
{
    public class SALIDA_EMPLEADOSController : Controller
    {
        private HumanResourcesModel db = new HumanResourcesModel();

        // GET: SALIDA_EMPLEADOS
        public ActionResult Index(String search)
        {
            var employee = from e in db.SALIDA_EMPLEADOS.ToList()
                           select e;

            if ((!String.IsNullOrEmpty(search)))
            {
                DateTime newFecha = DateTime.Parse(search);

                employee = employee.Where(s => s.FECHA_SALIDA.Equals(newFecha));
            }
            employee = employee.OrderBy(s => s.FECHA_SALIDA);
            return View(employee);
            return View(db.SALIDA_EMPLEADOS.ToList());
        }

        // GET: SALIDA_EMPLEADOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALIDA_EMPLEADOS sALIDA_EMPLEADOS = db.SALIDA_EMPLEADOS.Find(id);
            if (sALIDA_EMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(sALIDA_EMPLEADOS);
        }

        // GET: SALIDA_EMPLEADOS/Create
        public ActionResult Create()
        {
            var empleado = db.EMPLEADOS.ToList();
            var listaEmpleados = new SelectList(empleado, "NOMBRE", "NOMBRE");
            ViewBag.Empleados = listaEmpleados;
            return View();
        }

        // POST: SALIDA_EMPLEADOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EMPLEADO,TIPO_SALIDA,MOTIVO,FECHA_SALIDA")] SALIDA_EMPLEADOS sALIDA_EMPLEADOS)
        {
            var x = sALIDA_EMPLEADOS.EMPLEADO;
            var q = (from a in db.EMPLEADOS where a.NOMBRE == x select a).First();
            q.STATUS_EMP = "Inactivo";
            db.SaveChanges();

            db.SaveChanges();
            if (ModelState.IsValid)
            {
                db.SALIDA_EMPLEADOS.Add(sALIDA_EMPLEADOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(sALIDA_EMPLEADOS);
        }

        // GET: SALIDA_EMPLEADOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALIDA_EMPLEADOS sALIDA_EMPLEADOS = db.SALIDA_EMPLEADOS.Find(id);
            if (sALIDA_EMPLEADOS == null)
            {
                return HttpNotFound();
            }       
            return View(sALIDA_EMPLEADOS);
        }

        // POST: SALIDA_EMPLEADOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EMPLEADO,TIPO_SALIDA,MOTIVO,FECHA_SALIDA")] SALIDA_EMPLEADOS sALIDA_EMPLEADOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALIDA_EMPLEADOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALIDA_EMPLEADOS);
        }

        // GET: SALIDA_EMPLEADOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALIDA_EMPLEADOS sALIDA_EMPLEADOS = db.SALIDA_EMPLEADOS.Find(id);
            if (sALIDA_EMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(sALIDA_EMPLEADOS);
        }

        // POST: SALIDA_EMPLEADOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALIDA_EMPLEADOS sALIDA_EMPLEADOS = db.SALIDA_EMPLEADOS.Find(id);
            db.SALIDA_EMPLEADOS.Remove(sALIDA_EMPLEADOS);
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
