using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingSystem.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            Session["username"] = null;
            Session["role"] = null;
            Session["name"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}