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

        
        public ActionResult Index(string SearchString)
        {
            if (Authorizer.CheckRole("TrainingStaff", Session))
            {
                List<User> trainees = db.Users.Where(u => u.Role == "Trainee").ToList();

                if (!string.IsNullOrEmpty(SearchString))
                    trainees = trainees.Where(c => ToSearchString(c).Contains(SearchString.ToLower())).ToList();

                return View(trainees);
            }
            else
                return View("AccessDenied");
        }

        private string ToSearchString(User u)
        {
            return $"{u.Name} {u.ProgrammingLanguage} {u.TOEIC} {u.Phone} {u.UserID} {u.Location}".ToLower();
        }
        
        public ActionResult Details(string id)
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

        public ActionResult AssignCourse(string id)
        {
            if (Authorizer.CheckRole("TrainingStaff", Session))
            {
                ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name");
                ViewBag.TraineeID = id;
                return View();
            }
            else
                return View("AccessDenied");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignCourse(string traineeID, int courseID)
        {
            Course course = db.Courses.FirstOrDefault(t => t.CourseID == courseID);
            User user = db.Users.FirstOrDefault(u => u.UserID == traineeID);
            course.Users.Add(user);
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Trainee/Details/" + traineeID);
        }

        public ActionResult RemoveAssignCourse(string traineeID, int courseID)
        {
            Course course = db.Courses.FirstOrDefault(t => t.CourseID == courseID);
            User user = db.Users.FirstOrDefault(u => u.UserID == traineeID);
            course.Users.Remove(user);
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Trainee/Details/" + traineeID);
        }

        
        public ActionResult Create()
        {
            if (Authorizer.CheckRole("TrainingStaff", Session))
            {
                return View();
            }
            else
                return View("AccessDenied");
        }

        
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Name,Email,DOB,Education,ProgrammingLanguage,TOEIC,Experience,Department,Location,Phone")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "Trainee";
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        
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

        
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Name,Email,DOB,Education,ProgrammingLanguage,TOEIC,Experience,Department,Location,Phone")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "Trainee";
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        
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
