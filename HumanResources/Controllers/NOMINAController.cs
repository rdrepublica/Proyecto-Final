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
    public class NOMINAController : Controller
    {
        private HumanResourcesModel db = new HumanResourcesModel();

        // GET: NOMINA
        public ActionResult Index(String searching, String find)
        {
            
            if (searching != null)
            {
                if (find == "ANO")
                {
                    return View(db.NOMINAs.Where(x => x.ANO.ToString().Equals(searching)).ToList());
                }
                else if (find == "MES")
                {
                    return View(db.NOMINAs.Where(x => x.MES.ToString().Equals(searching)).ToList());
                }
                return View();

            }
            else
            {
                return View(db.NOMINAs.ToList());
            }
            return View(db.NOMINAs.Where(x => x.ANO.ToString().Equals(searching)).ToList());
        }

        // GET: NOMINA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINAs.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // GET: NOMINA/Create
        public ActionResult Create()
        {
            ViewBag.TotalSalario = db.EMPLEADOS.Sum(a => a.SALARIO);
            var total = ViewBag.TotalSalario;
            
            return View();
        }

        // POST: NOMINA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ANO,MES,MONTO_TOTAL")] NOMINA nOMINA)
        {
            if (ModelState.IsValid)
            {
                db.NOMINAs.Add(nOMINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nOMINA);
        }

        // GET: NOMINA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINAs.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // POST: NOMINA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ANO,MES,MONTO_TOTAL")] NOMINA nOMINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOMINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nOMINA);
        }

        // GET: NOMINA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINAs.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // POST: NOMINA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NOMINA nOMINA = db.NOMINAs.Find(id);
            db.NOMINAs.Remove(nOMINA);
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
