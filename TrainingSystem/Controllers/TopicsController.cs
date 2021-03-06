﻿using System;
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
    public class TopicsController : Controller
    {
        private TrainDbEntities db = new TrainDbEntities();

        
        public ActionResult Index()
        {
            return View(db.Topics.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        
        public ActionResult Create()
        {
            if (Authorizer.CheckRole("TrainingStaff", Session))
            {
                ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name");
                return View();
            }
            else
                return View("AccessDenied");  
        }

        
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopicID,Name,Description,CourseID")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topic);
        }

        
        public ActionResult Edit(int? id)
        {
            if (Authorizer.CheckRole("TrainingStaff", Session))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Topic topic = db.Topics.Find(id);
                if (topic == null)
                {
                    return HttpNotFound();
                }
                return View(topic);
            }
            else
                return View("AccessDenied");
            
        }

        
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TopicID,Name,Description")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        
        public ActionResult Delete(int? id)
        {
            if (Authorizer.CheckRole("TrainingStaff", Session))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Topic topic = db.Topics.Find(id);
                if (topic == null)
                {
                    return HttpNotFound();
                }
                return View(topic);
            }
            else
                return View("AccessDenied");
            
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
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
