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
    public class TestTypes1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestTypes1
        public ActionResult Index()
        {
            var testTypes = db.TestTypes.Include(t => t.PatientTest);
            return View(testTypes.ToList());
        }

        // GET: TestTypes1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = db.TestTypes.Find(id);
            if (testType == null)
            {
                return HttpNotFound();
            }
            return View(testType);
        }

        // GET: TestTypes1/Create
        public ActionResult Create()
        {
            ViewBag.TestId = new SelectList(db.PatientTests, "TestId", "TestName");
            return View();
        }

        // POST: TestTypes1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestTypeId,TestId,Name")] TestType testType)
        {
            if (ModelState.IsValid)
            {
                db.TestTypes.Add(testType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TestId = new SelectList(db.PatientTests, "TestId", "TestName", testType.TestId);
            return View(testType);
        }

        // GET: TestTypes1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = db.TestTypes.Find(id);
            if (testType == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestId = new SelectList(db.PatientTests, "TestId", "TestName", testType.TestId);
            return View(testType);
        }

        // POST: TestTypes1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestTypeId,TestId,Name")] TestType testType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TestId = new SelectList(db.PatientTests, "TestId", "TestName", testType.TestId);
            return View(testType);
        }

        // GET: TestTypes1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = db.TestTypes.Find(id);
            if (testType == null)
            {
                return HttpNotFound();
            }
            return View(testType);
        }

        // POST: TestTypes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestType testType = db.TestTypes.Find(id);
            db.TestTypes.Remove(testType);
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
