using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingSystem.Models;

namespace TrainingSystem.Controllers
{
    public class AdministratorController : Controller
    {
        private TrainDbEntities db = new TrainDbEntities();

        // GET: Administrator
        public ActionResult ChangePassword()
        {
            if (Authorizer.CheckRole("Administrator", Session))
            {
                return View();
            }
            else
                return View("AccessDenied");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(string oldPassword, string newPassword, string confirmNewPassword)
        {
            //ModelState.AddModelError("",$"awdawd{oldPassword}{newPassword}{confirmNewPassword}");
            if(Session["username"] != null)
            {
                string username = Session["username"].ToString();
                User user = db.Users.FirstOrDefault(u => u.UserID == username);
                if (user != null)
                {
                    if (user.Password == oldPassword)
                    {
                        if (newPassword == confirmNewPassword)
                        {
                            user.Password = newPassword;
                            db.Entry(user).State = EntityState.Modified;
                            db.SaveChanges();

                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "New password and comfirm password does not match");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Old password does not match");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "User not found!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please login first!");
            }
            return View();
        }
    }
}