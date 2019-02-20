using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseLab.Models;

namespace DatabaseLab.Controllers
{
    public class ProspectsController : Controller
    {
        private ProspectsDBContext db = new ProspectsDBContext();

        // GET: Prospects
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Prospects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prospects prospects = db.Users.Find(id);
            if (prospects == null)
            {
                return HttpNotFound();
            }
            return View(prospects);
        }

        // GET: Prospects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prospects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Pos,Avg")] Prospects prospects)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(prospects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prospects);
        }

        // GET: Prospects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prospects prospects = db.Users.Find(id);
            if (prospects == null)
            {
                return HttpNotFound();
            }
            return View(prospects);
        }

        // POST: Prospects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Pos,Avg")] Prospects prospects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prospects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prospects);
        }

        // GET: Prospects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prospects prospects = db.Users.Find(id);
            if (prospects == null)
            {
                return HttpNotFound();
            }
            return View(prospects);
        }

        // POST: Prospects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prospects prospects = db.Users.Find(id);
            db.Users.Remove(prospects);
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
