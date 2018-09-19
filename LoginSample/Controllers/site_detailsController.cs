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
    public class site_detailsController : Controller
    {
        private designdbEntities db = new designdbEntities();

        // GET: site_details
        public ActionResult Index()
        {
            return View(db.site_details.ToList());
        }

        // GET: site_details/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            site_detail site_details = db.site_details.Find(id);
            if (site_details == null)
            {
                return HttpNotFound();
            }
            return View(site_details);
        }

        // GET: site_details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: site_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Site_Name,Builder,Street_Road,Area,City,State,Pin_Code,Lat,Lon,Contact_Person_Name,Contact_Person_Email,Contact_Person_Mobile,Admin_Email,Admin_Mobile,Status,Comments")] site_detail site_details, [Bind(Include = "Logo")] HttpPostedFileBase Logo)
        {
            site_details.SiD = Guid.NewGuid().ToString();
            if (Logo != null)
            {
                byte[] img_buf = new byte[Logo.ContentLength];
                Logo.InputStream.Read(img_buf, 0, img_buf.Length);
                var base64 = Convert.ToBase64String(img_buf);
                site_details.Logo = base64;
            }
            if (ModelState.IsValid)
            {
                db.site_details.Add(site_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(site_details);
        }

        // GET: site_details/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            site_detail site_details = db.site_details.Find(id);
            if (site_details == null)
            {
                return HttpNotFound();
            }
            return View(site_details);
        }

        // POST: site_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiD,Site_Name,Builder,Logo,Street_Road,Area,City,State,Pin_Code,Lat,Lon,Contact_Person_Name,Contact_Person_Email,Contact_Person_Mobile,Admin_Email,Admin_Mobile,Status,Comments")] site_detail site_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(site_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(site_details);
        }

        // GET: site_details/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            site_detail site_details = db.site_details.Find(id);
            if (site_details == null)
            {
                return HttpNotFound();
            }
            return View(site_details);
        }

        // POST: site_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            site_detail site_details = db.site_details.Find(id);
            db.site_details.Remove(site_details);
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