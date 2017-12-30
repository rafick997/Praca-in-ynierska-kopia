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
    public class LaboratoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Laboratories
        public ActionResult Index()
        {
            return View(db.Laboratories.ToList());
        }

        // GET: Laboratories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratory laboratory = db.Laboratories.Find(id);
            if (laboratory == null)
            {
                return HttpNotFound();
            }
            return View(laboratory);
        }

        // GET: Laboratories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Laboratories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LaboratoryId,LabolatoryName,Street,ZipCode,City,Country")] Laboratory laboratory)
        {
            if (ModelState.IsValid)
            {
                db.Laboratories.Add(laboratory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(laboratory);
        }

        // GET: Laboratories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratory laboratory = db.Laboratories.Find(id);
            if (laboratory == null)
            {
                return HttpNotFound();
            }
            return View(laboratory);
        }

        // POST: Laboratories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LaboratoryId,LabolatoryName,Street,ZipCode,City,Country")] Laboratory laboratory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laboratory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(laboratory);
        }

        // GET: Laboratories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratory laboratory = db.Laboratories.Find(id);
            if (laboratory == null)
            {
                return HttpNotFound();
            }
            return View(laboratory);
        }

        // POST: Laboratories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Laboratory laboratory = db.Laboratories.Find(id);
            db.Laboratories.Remove(laboratory);
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
