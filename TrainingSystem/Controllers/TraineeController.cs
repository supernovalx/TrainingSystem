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
    public class TraineeController : Controller
    {
        private TrainDbEntities db = new TrainDbEntities();

        // GET: Trainee
        public ActionResult Index()
        {
            return View(db.Users.Where(u => u.Role == "Trainee").ToList());
        }

        // GET: Trainee/Details/5
        public ActionResult Details(string id)
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

        // GET: Trainee/Create
        public ActionResult Create()
        {
            if (Authorizer.CheckRole("TrainingStaff", Session))
            {
                return View();
            }
            else
                return View("AccessDenied");  
        }

        // POST: Trainee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Password,Role,Name,Email,DOB,Education,ProgrammingLanguage,TOEIC,Experience,Department,Location,Type,Phone,Workplace")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Trainee/Edit/5
        public ActionResult Edit(string id)
        {
            if (Authorizer.CheckRole("TrainingStaff", Session))
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

        // POST: Trainee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Password,Role,Name,Email,DOB,Education,ProgrammingLanguage,TOEIC,Experience,Department,Location,Type,Phone,Workplace")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Trainee/Delete/5
        public ActionResult Delete(string id)
        {
            if (Authorizer.CheckRole("TrainingStaff", Session))
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

        // POST: Trainee/Delete/5
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
