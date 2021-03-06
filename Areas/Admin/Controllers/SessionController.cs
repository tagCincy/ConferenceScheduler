﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConferenceScheduler.Models;
using ConferenceScheduler.Models.DAL;

namespace ConferenceScheduler.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SessionController : Controller
    {
        private ConferenceContext db = new ConferenceContext();

        //
        // GET: /Admin/Session/

        public ActionResult Index()
        {
            return View(db.Sessions.ToList());
        }

        //
        // GET: /Admin/Session/Details/5

        public ActionResult Details(int id = 0)
        {
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        //
        // GET: /Admin/Session/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Session/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Session session)
        {
            if (ModelState.IsValid)
            {
                db.Sessions.Add(session);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(session);
        }

        //
        // GET: /Admin/Session/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        //
        // POST: /Admin/Session/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Session session)
        {
            if (ModelState.IsValid)
            {
                db.Entry(session).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(session);
        }

        //
        // GET: /Admin/Session/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        //
        // POST: /Admin/Session/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Session session = db.Sessions.Find(id);
            db.Sessions.Remove(session);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}