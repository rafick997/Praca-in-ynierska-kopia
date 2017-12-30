using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Przychodnia_medyczna.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using PagedList.Mvc;
using System.Collections.Generic;
using System.Data.Entity;

namespace Przychodnia_medyczna.Controllers
{

    public class SuperAdminsController : AccountController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Home()
        {
            return View();
        }


        [Authorize(Roles = "SuperAdmin")]
        public ActionResult GetPatients(int? page)
        {
            List<Patient> patients = new List<Patient>();
            return View(db.Patients.ToList().ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult GetManagers()
        {
            List<Manager> managers = new List<Manager>();
            managers = db.Managers.ToList();

            return View(managers);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult RegisterPatient()
        {
            return View();
        }
        public RoleManager<IdentityRole> RoleManager { get; set; }

        private ApplicationUserManager userManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult> RegisterPatient(PatientRegisterModel model)
        {

            IdentityResult result = null;
            if (ModelState.IsValid)
            {
                Address address = new Address
                {
                    Street = model.Address.Street,
                    ZipCode = model.Address.ZipCode,
                    City = model.Address.City,
                    Country = model.Address.Country,
                    Id = model.Id


                };
                Patient patient = new Patient
                {

                    Name = model.Name,
                    LastName = model.LastName,
                    PatientId = model.Id,
                    PESEL = model.PESEL


                };
                try
                {
                    var user = new ApplicationUser() { Id = model.Id, Email = model.Email, UserName = model.Email, PhoneNumber = model.ContactNumber };

                    result = await userManager.CreateAsync(user, model.Password);
                }
                catch (Exception ex)
                {
                    throw;
                }
                if (result.Succeeded)
                {
                    userManager.AddToRole(patient.PatientId, model.Role);

                    db.Patients.Add(patient);
                    db.Addresses.Add(address);
                    db.SaveChanges();
                    RedirectToAction("GetPatients", "SuperAdmins");

                }
                else
                {
                    ViewBag.msg = "Problem was accured while addind new patient";
                    return View();
                }

            }
            return RedirectToAction("GetPatients", "SuperAdmins");
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public ActionResult RegisterManager()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult> RegisterManager(ManagerRegisterModel model)
        {
            IdentityResult result = null;
            if (ModelState.IsValid)
            {
                Manager manager = new Manager
                {

                    ManagerId = model.ManagerId
                };
                try
                {
                    var user = new ApplicationUser() { Id = model.ManagerId, Email = model.Email, UserName = model.Email, PhoneNumber = model.ContactNumber };

                    result = await userManager.CreateAsync(user, model.Password);
                }
                catch (Exception ex)
                {
                    throw;
                }
                if (result.Succeeded)
                {
                    userManager.AddToRole(manager.ManagerId, model.Role);
                    db.Managers.Add(manager);
                    db.SaveChanges();
                    RedirectToAction("GetManagers", "SuperAdmins");
                }
                else
                {
                    ViewBag.msg = "Problem was accured while addind new patient";
                    return View();
                }

            }
            return RedirectToAction("GetManagers", "SuperAdmins");
        }

        // GET: Laboratories
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult LaboratotyIndex()
        {
            return View(db.Laboratories.ToList());
        }

        [Authorize(Roles = "SuperAdmin")]
        //LaboratoryDetails
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Laboratory laboratory = db.Laboratories.Find(id);
            if (laboratory == null)
            {
                return HttpNotFound();
            }
            return View(laboratory);
        }
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
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
        [Authorize(Roles = "SuperAdmin")]
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
