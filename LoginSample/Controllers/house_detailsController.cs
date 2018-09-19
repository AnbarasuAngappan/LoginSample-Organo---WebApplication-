using LoginSample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LoginSample.Controllers
{
    public class house_detailsController : Controller
    {
        private designdbEntities db = new designdbEntities();

        // GET: house_details
        public ActionResult Index()
        {
            var house_details = db.house_details.Include(h => h.site_details);
            return View(house_details.ToList());
        }

        // GET: house_details/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            house_detail house_details = db.house_details.Find(id);
            if (house_details == null)
            {
                return HttpNotFound();
            }
            return View(house_details);
        }

        // GET: house_details/Create
        public ActionResult Create()
        {
            ViewBag.SiD = new SelectList(db.site_details, "SiD", "Site_Name");
            return View();
        }

        // POST: house_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiD,House_No,Owner_Name,Owner_Mobile,Owner_Email,Tenant_Name,Tenant_Email,Tenant_Mobile,Maintainance_Notes")] house_detail house_details)
        {
            house_details.HiD = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {
                db.house_details.Add(house_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SiD = new SelectList(db.site_details, "SiD", "Site_Name", house_details.SiD);
            return View(house_details);
        }

        // GET: house_details/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            house_detail house_details = db.house_details.Find(id);
            if (house_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.SiD = new SelectList(db.site_details, "SiD", "Site_Name", house_details.SiD);
            return View(house_details);
        }

        // POST: house_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HiD,SiD,House_No,Owner_Name,Owner_Mobile,Owner_Email,Tenant_Name,Tenant_Email,Tenant_Mobile,Maintainance_Notes")] house_detail house_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SiD = new SelectList(db.site_details, "SiD", "Site_Name", house_details.SiD);
            return View(house_details);
        }

        // GET: house_details/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            house_detail house_details = db.house_details.Find(id);
            if (house_details == null)
            {
                return HttpNotFound();
            }
            return View(house_details);
        }

        // POST: house_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            house_detail house_details = db.house_details.Find(id);
            db.house_details.Remove(house_details);
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