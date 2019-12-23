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
    public class AdminsController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Admins
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {//var admins = db.Admins.Include(a => a.Role);
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            //ViewBag.RId = new SelectList(db.Roles, "RId", "Name");
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string txtName,string txtPassword)
        {
            if (ModelState.IsValid)
            {

                var q = db.Admins.Where(a => a.Email.Equals(txtName) && a.Password.Equals(txtPassword)).FirstOrDefault();
                var q1 = db.Students.Where(a => a.Email.Equals(txtName) && a.Password.Equals(txtPassword)).FirstOrDefault();
                if (q != null && q.Role.Name == "Admin")
                {
                    Session["admin"] = q.Role.Name;
                    return RedirectToAction("Index");
                }
                if (q1 != null && q1.Role.Name == "Manager")
                {
                    Session["manager"] = q.Role.Name;
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            else
            {
                return View();
            }
            }

            //ViewBag.RId = new SelectList(db.Roles, "RId", "Name", admin.RId);
            return View();
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            ViewBag.RId = new SelectList(db.Roles, "RId", "Name", admin.RId);
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,RId,Name,Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RId = new SelectList(db.Roles, "RId", "Name", admin.RId);
            return View(admin);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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
