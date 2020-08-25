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

        // GET: TrainingStaff
        public ActionResult Index()
        {
            if (Authorizer.CheckRole("Administrator", Session))
            {
                return View(db.Users.Where(u => u.Role == "TrainingStaff").ToList());
            }
            else
                return View("AccessDenied");
        }

        // GET: TrainingStaff/Details/5
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

        // GET: TrainingStaff/Create
        public ActionResult Create()
        {
            if (Authorizer.CheckRole("Administrator", Session))
            {
                return View();
            }
            else
                return View("AccessDenied");

        }

        // POST: TrainingStaff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: TrainingStaff/Edit/5
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

        // POST: TrainingStaff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: TrainingStaff/Delete/5
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

        // POST: TrainingStaff/Delete/5
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
