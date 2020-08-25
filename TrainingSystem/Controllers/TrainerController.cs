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
    public class TrainerController : Controller
    {
        private TrainDbEntities db = new TrainDbEntities();

        // GET: Trainer
        public ActionResult Index()
        {
            if (Authorizer.CheckRole("Administrator,TrainingStaff", Session))
            {
                return View(db.Users.Where(u => u.Role == "Trainer").ToList());
            }
            else
                return View("AccessDenied");
        }

        // GET: Trainer/Details/5
        public ActionResult Details(string id)
        {
            if (Authorizer.CheckRole("Administrator,TrainingStaff", Session))
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

        // GET: Trainer/Create
        public ActionResult Create()
        {
            if (Authorizer.CheckRole("TrainingStaff,Administrator", Session))
            {
                return View();
            }
            else
                return View("AccessDenied");
        }

        // POST: Trainer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Password,Name,Email,DOB,Type,Phone,Workplace")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "Trainer";
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult AssignTopic(string id)
        {
            if (Authorizer.CheckRole("TrainingStaff,Administrator", Session))
            {
                ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "Name");
                ViewBag.TrainerID = id;
                return View();
            }
            else
                return View("AccessDenied");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignTopic(string trainerID, int topicID)
        {
            Topic topic = db.Topics.FirstOrDefault(t => t.TopicID == topicID);
            User user = db.Users.FirstOrDefault(u => u.UserID == trainerID);
            topic.Users.Add(user);
            db.Entry(topic).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Trainer/Details/" + trainerID);
        }

        public ActionResult RemoveAssignTopic(string trainerID, int topicID)
        {
            Topic topic = db.Topics.FirstOrDefault(t => t.TopicID == topicID);
            User user = db.Users.FirstOrDefault(u => u.UserID == trainerID);
            topic.Users.Remove(user);
            db.Entry(topic).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Trainer/Details/" + trainerID);
        }

        public ActionResult UpdateProfile()
        {
            if (Authorizer.CheckRole("Trainer", Session))
            {
                string id = Session["username"].ToString();
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

        // POST: Trainer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfile([Bind(Include = "UserID,Password,Name,Email,DOB,Type,Phone,Workplace")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "Trainer";
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(string id)
        {
            if (Authorizer.CheckRole("TrainingStaff,Administrator", Session))
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

        // POST: Trainer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Password,Name,Email,DOB,Type,Phone,Workplace")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "Trainer";
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Trainer/Delete/5
        public ActionResult Delete(string id)
        {
            if (Authorizer.CheckRole("TrainingStaff,Administrator", Session))
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

        // POST: Trainer/Delete/5
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
