using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingSystem.Models;

namespace TrainingSystem.Controllers
{
    public class TrainingStaffController : Controller
    {
        private TrainDbEntities db = new TrainDbEntities();

        
        public ActionResult Index()
        {
            if (Authorizer.CheckRole("Administrator", Session))
            {
                return View(db.Users.Where(u => u.Role == "TrainingStaff").ToList());
            }
            else
                return View("AccessDenied");
        }

        
        public ActionResult Details(string id)
        {
            if (Authorizer.CheckRole("Administrator", Session))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
                return View("AccessDenied");
        }

        
        public ActionResult Create()
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
        public ActionResult Create([Bind(Include = "UserID,Password,Name,Email,DOB")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "TrainingStaff";
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        
        public ActionResult Edit(string id)
        {
            if (Authorizer.CheckRole("Administrator", Session))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
                return View("AccessDenied");

        }

        
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Password,Name,Email,DOB")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "TrainingStaff";
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        
        public ActionResult Delete(string id)
        {
            if (Authorizer.CheckRole("Administrator", Session))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
                return View("AccessDenied");

        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
