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
    public class TestGroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestGroups
        public ActionResult GetTestGroupList()
        {
            return View(db.TestGroups.ToList());
        }



        // GET: TestGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestGroupId,GroupName")] TestGroup testGroup)
        {
            if (ModelState.IsValid)
            {
                db.TestGroups.Add(testGroup);
                db.SaveChanges();
                return RedirectToAction("GetTestGroupList", "TestGroups");
            }

            return View(testGroup);
        }

        // GET: TestGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestGroup testGroup = db.TestGroups.Find(id);
            if (testGroup == null)
            {
                return HttpNotFound();
            }
            return View(testGroup);
        }

        // POST: TestGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestGroupId,GroupName")] TestGroup testGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetTestGroupList", "TestGroups");
            }
            return View(testGroup);
        }

        // GET: TestGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestGroup testGroup = db.TestGroups.Find(id);
            if (testGroup == null)
            {
                return HttpNotFound();
            }
            return View(testGroup);
        }

        // POST: TestGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestGroup testGroup = db.TestGroups.Find(id);
            db.TestGroups.Remove(testGroup);
            db.SaveChanges();
            return RedirectToAction("GetTestGroupList", "TestGroups");
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
