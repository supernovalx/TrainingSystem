using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingSystem.Models;

namespace TrainingSystem.Controllers
{
    public class CoursesController : Controller
    {
        private TrainDbEntities db = new TrainDbEntities();

        
        public ActionResult Index(string SearchString)
        {
            List<Course> courses = db.Courses.Include(c => c.Category).ToList();

            if (!string.IsNullOrEmpty(SearchString))
                courses = courses.Where(c => c.Name.ToLower().Contains(SearchString.ToLower())).ToList();

            if (Authorizer.CheckRole("Trainer", Session))
            {
                string uid = Session["username"].ToString();
                User user = db.Users.FirstOrDefault(u => u.UserID == uid);
                courses = user.Topics.Select(t => t.Course).Distinct().ToList();
            }
            return View(courses.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        
        public ActionResult Create()
        {
            if (Authorizer.CheckRole("TrainingStaff", Session))
            {
                ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
                return View();
            }
            else
                return View("AccessDenied");

        }

        
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Name,Description,ImageFile,CategoryID")] Course course)
        {
            if (ModelState.IsValid)
            {
                string filename = new Random().Next(31287489).ToString() + course.ImageFile.FileName;
                course.ImageFile.SaveAs(@"C:\Users\hoang\source\repos\TrainingSystem\TrainingSystem\Content\Images\" + filename);
                course.Image = filename;
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", course.CategoryID);
            return View(course);
        }

        
        public ActionResult Edit(int? id)
        {
            if (Authorizer.CheckRole("TrainingStaff", Session))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", course.CategoryID);
                return View(course);
            }
            else
                return View("AccessDenied");
        }

        
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Name,Description,ImageFile,CategoryID")] Course course)
        {
            if (ModelState.IsValid)
            {
                string filename = new Random().Next(31287489).ToString() + course.ImageFile.FileName;
                course.ImageFile.SaveAs(@"C:\Users\hoang\source\repos\TrainingSystem\TrainingSystem\Content\Images\" + filename);
                course.Image = filename;
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", course.CategoryID);
            return View(course);
        }

        
        public ActionResult Delete(int? id)
        {
            if (Authorizer.CheckRole("TrainingStaff", Session))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return HttpNotFound();
                }
                return View(course);
            }
            else
                return View("AccessDenied");

        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
