using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fine_Art.Models;

namespace Fine_Art.Controllers
{
    public class ExhibitionsController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Exhibitions
        public ActionResult Index()
        {
           // var exhibitions = db.Exhibitions.Include(e => e.E_Id).Include(e => e.Student);
            return View(db.Exhibitions.ToList());
        }

        // GET: Exhibitions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            return View(exhibition);
        }

        // GET: Exhibitions/Create
        public ActionResult Create()
        {
            ViewBag.E_Id = new SelectList(db.Events, "E_Id", "Event_Detail");
            ViewBag.S_Id = new SelectList(db.Students, "S_Id", "Name");
            return View();
        }

        // POST: Exhibitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Painting_Pic,Painting_Detail,Price,Status,E_Id,S_Id")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                db.Exhibitions.Add(exhibition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.E_Id = new SelectList(db.Events, "E_Id", "Event_Detail", exhibition.E_Id);
            ViewBag.S_Id = new SelectList(db.Students, "S_Id", "Name", exhibition.S_Id);
            return View(exhibition);
        }

        // GET: Exhibitions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            ViewBag.E_Id = new SelectList(db.Events, "E_Id", "Event_Detail", exhibition.E_Id);
            ViewBag.S_Id = new SelectList(db.Students, "S_Id", "Name", exhibition.S_Id);
            return View(exhibition);
        }

        // POST: Exhibitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Painting_Pic,Painting_Detail,Price,Status,E_Id,S_Id")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exhibition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.E_Id = new SelectList(db.Events, "E_Id", "Event_Detail", exhibition.E_Id);
            ViewBag.S_Id = new SelectList(db.Students, "S_Id", "Name", exhibition.S_Id);
            return View(exhibition);
        }

        // GET: Exhibitions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            return View(exhibition);
        }

        // POST: Exhibitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Exhibition exhibition = db.Exhibitions.Find(id);
            db.Exhibitions.Remove(exhibition);
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
