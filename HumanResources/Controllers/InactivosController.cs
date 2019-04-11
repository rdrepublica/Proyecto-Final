using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResources.Models;

namespace HumanResources.Controllers
{
    public class InactivosController : Controller
    {
        private HumanResourcesModel db = new HumanResourcesModel();
        // GET: Inactivos
        public ActionResult Index(String searching, String find)
        {
            String valor = "Inactivo";
            if (searching != null)
            {
                if (find == "NOMBRE")
                {
                    return View(db.EMPLEADOS.Where(x => x.STATUS_EMP.Equals(valor) & x.NOMBRE.Contains(searching) || valor == null).ToList());
                }
                else if (find == "DEPARTAMENTO")
                {
                    return View(db.EMPLEADOS.Where(x => x.STATUS_EMP.Equals(valor) & x.DEPARTAMENTO.Contains(searching) || valor == null).ToList());
                }
                return View();

            }
            else
            {
                return View(db.EMPLEADOS.Where(x => x.STATUS_EMP.Equals(valor) || valor == null).ToList());
            }

        }
    }
}