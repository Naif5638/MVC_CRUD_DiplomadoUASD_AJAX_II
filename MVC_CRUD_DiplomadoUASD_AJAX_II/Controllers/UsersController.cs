using MVC_CRUD_DiplomadoUASD_AJAX_II.Models;
using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD_DiplomadoUASD_AJAX_II.Controllers
{
    public class UsersController : Controller
    {
        EmpleadoDB empleadoDB = new EmpleadoDB();
        SessionData session = new SessionData();
        
        public ActionResult Index()
        {
            var listUser = empleadoDB.Users();
            return View(listUser);
        }

        public ActionResult Details(int userId)
        {
            var user = empleadoDB.User(userId);
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            var user = empleadoDB.User(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(Users user)
        {
            if(user != null)
            {
                int i = empleadoDB.UpdateUser(user);
                if (i != 0)
                {
                    ModelState.AddModelError(string.Empty, "Datos enviados no estan correctos..");
                    return View(user);
                }
            }
            return View("Index");
        }

        // GET: Users
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                if (userLogin.Login())
                {
                    session.setSession("userName", userLogin.User.UserName);
                    ViewBag.User = session.getSession("userName");
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña no validos");
                    return View(userLogin);
                }
            }
            else
                return View(userLogin);
        }

        [HttpPost]
        public ActionResult SignUp(Users user)
        {
            if (user != null)
            {
                int i = empleadoDB.InsertUser(user);
                if (i != 0)
                {
                    return View("Index");
                }
            }
            else
            {
                return View(user);
            }
            
            return View("Login");
        }

    }
}