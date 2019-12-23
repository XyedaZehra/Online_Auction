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
    public class Student_Academic_RecordController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Student_Academic_Record
        public ActionResult Index()
        {
            var student_Academic_Records = db.Student_Academic_Records.Include(s => s.Competition).Include(s => s.Student);
            return View(student_Academic_Records.ToList());
        }

        // GET: Student_Academic_Record/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Academic_Record student_Academic_Record = db.Student_Academic_Records.Find(id);
            if (student_Academic_Record == null)
            {
                return HttpNotFound();
            }
            return View(student_Academic_Record);
        }

        // GET: Student_Academic_Record/Create
        public ActionResult Create()
        {
            ViewBag.C_Id = new SelectList(db.Competitions, "C_Id", "C_desc");
            ViewBag.S_Id = new SelectList(db.Students, "S_Id", "Name");
            return View();
        }

        // POST: Student_Academic_Record/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "S_Id,C_Id,remarks,createddate,Marks")] Student_Academic_Record student_Academic_Record)
        {
            if (ModelState.IsValid)
            {
                db.Student_Academic_Records.Add(student_Academic_Record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.C_Id = new SelectList(db.Competitions, "C_Id", "C_desc", student_Academic_Record.C_Id);
            ViewBag.S_Id = new SelectList(db.Students, "S_Id", "Name", student_Academic_Record.S_Id);
            return View(student_Academic_Record);
        }

        // GET: Student_Academic_Record/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Academic_Record student_Academic_Record = db.Student_Academic_Records.Find(id);
            if (student_Academic_Record == null)
            {
                return HttpNotFound();
            }
            ViewBag.C_Id = new SelectList(db.Competitions, "C_Id", "C_desc", student_Academic_Record.C_Id);
            ViewBag.S_Id = new SelectList(db.Students, "S_Id", "Name", student_Academic_Record.S_Id);
            return View(student_Academic_Record);
        }

        // POST: Student_Academic_Record/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "S_Id,C_Id,remarks,createddate,Marks")] Student_Academic_Record student_Academic_Record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Academic_Record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.C_Id = new SelectList(db.Competitions, "C_Id", "C_desc", student_Academic_Record.C_Id);
            ViewBag.S_Id = new SelectList(db.Students, "S_Id", "Name", student_Academic_Record.S_Id);
            return View(student_Academic_Record);
        }

        // GET: Student_Academic_Record/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Academic_Record student_Academic_Record = db.Student_Academic_Records.Find(id);
            if (student_Academic_Record == null)
            {
                return HttpNotFound();
            }
            return View(student_Academic_Record);
        }

        // POST: Student_Academic_Record/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Academic_Record student_Academic_Record = db.Student_Academic_Records.Find(id);
            db.Student_Academic_Records.Remove(student_Academic_Record);
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
