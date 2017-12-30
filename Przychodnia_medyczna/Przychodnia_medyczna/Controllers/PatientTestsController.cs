using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Przychodnia_medyczna.Models;

namespace Przychodnia_medyczna.Controllers
{
    public class PatientTestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PatientTests
        public ActionResult Index()
        {
            db.TestGroups.Include(p => p.TestGroupId).ToList();
            return View(db.PatientTests.ToList());
        }

        // GET: PatientTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTest patientTest = db.PatientTests.Find(id);
            if (patientTest == null)
            {
                return HttpNotFound();
            }
            return View(patientTest);
        }

        // GET: PatientTests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestId,TestName")] PatientTest patientTest)
        {
            if (ModelState.IsValid)
            {
                db.PatientTests.Add(patientTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patientTest);
        }

        // GET: PatientTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTest patientTest = db.PatientTests.Find(id);
            if (patientTest == null)
            {
                return HttpNotFound();
            }
            return View(patientTest);
        }

        // POST: PatientTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestId,TestName")] PatientTest patientTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientTest);
        }

        // GET: PatientTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTest patientTest = db.PatientTests.Find(id);
            if (patientTest == null)
            {
                return HttpNotFound();
            }
            return View(patientTest);
        }

        // POST: PatientTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientTest patientTest = db.PatientTests.Find(id);
            db.PatientTests.Remove(patientTest);
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
