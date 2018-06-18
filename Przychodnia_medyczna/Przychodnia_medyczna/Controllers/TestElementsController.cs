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
    public class TestElementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestElements
        public ActionResult GetTestElementList()
        {
            var testElements = db.TestElements.Include(t => t.TestGroup).Include(t => t.TestUnit);
            return View(testElements.ToList());
        }

        // GET: TestElements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestElement testElement = db.TestElements.Find(id);
            if (testElement == null)
            {
                return HttpNotFound();
            }
            return View(testElement);
        }

        // GET: TestElements/Create
        public ActionResult Create()
        {
            ViewBag.TestGroupId = new SelectList(db.TestGroups, "TestGroupId", "GroupName");
            ViewBag.UnitId = new SelectList(db.TestUnits, "UnitId", "UnitName");
            return View();
        }

        // POST: TestElements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestElementId,TestGroupId,UnitId,MinValue,MaxValue")] TestElement testElement)
        {
            if (ModelState.IsValid)
            {
                db.TestElements.Add(testElement);
                db.SaveChanges();
                return RedirectToAction("GetTestElementList","TestElements");
            }

            ViewBag.TestGroupId = new SelectList(db.TestGroups, "TestGroupId", "GroupName", testElement.TestGroupId);
            ViewBag.UnitId = new SelectList(db.TestUnits, "UnitId", "UnitName", testElement.UnitId);
            return View(testElement);
        }

        // GET: TestElements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestElement testElement = db.TestElements.Find(id);
            if (testElement == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestGroupId = new SelectList(db.TestGroups, "TestGroupId", "GroupName", testElement.TestGroupId);
            ViewBag.UnitId = new SelectList(db.TestUnits, "UnitId", "UnitName", testElement.UnitId);
            return View(testElement);
        }

        // POST: TestElements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestElementId,TestGroupId,UnitId,MinValue,MaxValue")] TestElement testElement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testElement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetTestElementList", "TestElements");
            }
            ViewBag.TestGroupId = new SelectList(db.TestGroups, "TestGroupId", "GroupName", testElement.TestGroupId);
            ViewBag.UnitId = new SelectList(db.TestUnits, "UnitId", "UnitName", testElement.UnitId);
            return View(testElement);
        }

        // GET: TestElements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestElement testElement = db.TestElements.Find(id);
            if (testElement == null)
            {
                return HttpNotFound();
            }
            return View(testElement);
        }

        // POST: TestElements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestElement testElement = db.TestElements.Find(id);
            db.TestElements.Remove(testElement);
            db.SaveChanges();
            return RedirectToAction("GetTestElementList", "TestElements");
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
