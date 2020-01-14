using MVC_CRUD_DiplomadoUASD_AJAX_II.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD_DiplomadoUASD_AJAX_II.Controllers
{
    public class HomeController : Controller
    {
        EmpleadoDB empleadoDB = new EmpleadoDB();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            var lista = empleadoDB.ListAll();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Empleado empleado)
        {
            return Json(empleadoDB.Add(empleado), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            var empleado = empleadoDB.ListAll().Find(e => e.EmpleadoID.Equals(id));
            return Json(empleado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Empleado empleado)
        {
            return Json(empleadoDB.Update(empleado), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            return Json(empleadoDB.Delete(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}