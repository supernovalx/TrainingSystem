using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingSystem.Models;

namespace TrainingSystem.Controllers
{
    public class LoginController : Controller
    {
        private TrainDbEntities db = new TrainDbEntities();
        
        public ActionResult Index()
        {
            if (Session["username"] != null)
                return RedirectToAction();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.UserID == username && u.Password == password);
            if (user != null)
            {
                Session["username"] = username;
                Session["role"] = user.Role;
                Session["name"] = user.Name;
                return RedirectToAction();
            }

            return View();
        }

        private ActionResult RedirectToAction()
        {
            string role = Session["role"].ToString();
            if (role == "Administrator")
                return RedirectToAction("Index", "TrainingStaff");
            else if (role == "TrainingStaff")
                return RedirectToAction("Index", "Trainer");
            else if (role == "Trainer")
                return RedirectToAction("UpdateProfile", "Trainer");
            else
                return RedirectToAction("Index", "Login");

        }
    }
}