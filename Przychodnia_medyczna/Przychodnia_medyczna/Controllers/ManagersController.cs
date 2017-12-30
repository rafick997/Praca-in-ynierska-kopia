using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Przychodnia_medyczna.Models;

namespace Przychodnia_medyczna.Controllers
{
    public class ManagersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Managers
        [Authorize(Roles = "Manager")]
        public ActionResult GetPatientsList(string searchBy, string search, int? page)
        {
            if (searchBy == "PESEL")
                return View(db.Patients.Where(p => p.PESEL.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 3));
            else
                return View(db.Patients.Where(p=>p.ApplicationUser.UserName.StartsWith(search)||search == null).ToList().ToPagedList(page ?? 1, 3));
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public ActionResult AddTestResult(string TestResultId)
        {
            ViewBag.TestResultId = TestResultId;
            return View();
        }
        [Authorize(Roles = "Manager")]
        public ActionResult CreateTestResult(string patientPesel)
        {
            // IEnumerable<SelectListItem> managers = db.Managers.Select( b => new SelectListItem { Value = b.ManagerId, Text = b.Name});
            //ViewData["Managers"] = managers;
            return View();
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
