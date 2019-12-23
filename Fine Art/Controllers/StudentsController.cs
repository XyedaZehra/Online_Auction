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
    public class StudentsController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Students
        public ActionResult Index()
        {
            if(Session["admin"] != null)
            {
    var students = db.Students.Include(s => s.Role).Include(s => s.Award).Include(s => s.Student_Academic_Record);
            return View(students.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.RId = new SelectList(db.Roles, "RId", "Name");
            ViewBag.S_Id = new SelectList(db.Awards, "S_Id", "Award_Title");
            ViewBag.S_Id = new SelectList(db.Student_Academic_Records, "S_Id", "remarks");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "S_Id,Name,Email,Age,Phone_Number,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.RId = 4;
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RId = new SelectList(db.Roles, "RId", "Name", student.RId);
            ViewBag.S_Id = new SelectList(db.Awards, "S_Id", "Award_Title", student.S_Id);
            ViewBag.S_Id = new SelectList(db.Student_Academic_Records, "S_Id", "remarks", student.S_Id);
            return RedirectToAction("Index", "Home");
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.RId = new SelectList(db.Roles, "RId", "Name", student.RId);
            ViewBag.S_Id = new SelectList(db.Awards, "S_Id", "Award_Title", student.S_Id);
            ViewBag.S_Id = new SelectList(db.Student_Academic_Records, "S_Id", "remarks", student.S_Id);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "S_Id,Name,Email,Age,Phone_Number,Address,RId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RId = new SelectList(db.Roles, "RId", "Name", student.RId);
            ViewBag.S_Id = new SelectList(db.Awards, "S_Id", "Award_Title", student.S_Id);
            ViewBag.S_Id = new SelectList(db.Student_Academic_Records, "S_Id", "remarks", student.S_Id);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
