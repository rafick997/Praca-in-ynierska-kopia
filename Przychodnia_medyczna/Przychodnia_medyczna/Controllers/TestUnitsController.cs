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
    public class TestUnitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestUnits
        public ActionResult GetTestUnitList()
        {
            return View(db.TestUnits.ToList());
        }


        // GET: TestUnits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnitId,UnitName")] TestUnit testUnit)
        {
            if (ModelState.IsValid)
            {
                db.TestUnits.Add(testUnit);
                db.SaveChanges();
                return RedirectToAction("GetTestUnitList", "TestUnits");
            }

            return View(testUnit);
        }

        // GET: TestUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestUnit testUnit = db.TestUnits.Find(id);
            if (testUnit == null)
            {
                return HttpNotFound();
            }
            return View(testUnit);
        }

        // POST: TestUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnitId,UnitName")] TestUnit testUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetTestUnitList", "TestUnits");
            }
            return View(testUnit);
        }

        // GET: TestUnits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestUnit testUnit = db.TestUnits.Find(id);
            if (testUnit == null)
            {
                return HttpNotFound();
            }
            return View(testUnit);
        }

        // POST: TestUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestUnit testUnit = db.TestUnits.Find(id);
            db.TestUnits.Remove(testUnit);
            db.SaveChanges();
            return RedirectToAction("GetTestUnitList", "TestUnits");
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
