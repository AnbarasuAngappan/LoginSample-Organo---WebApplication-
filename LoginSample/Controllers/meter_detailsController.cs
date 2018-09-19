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
    public class meter_detailsController : Controller
    {
        private designdbEntities db = new designdbEntities();

        // GET: meter_details
        public ActionResult Index(String id)
        {
            IQueryable<meter_detail> meter_details;
            if (id == null)
            {
                 meter_details = db.meter_details.Include(m => m.house_details).Include(m => m.meter_master).Include(m => m.site_details).Include(m => m.utility_tarrif_master);
            }
            else
            {
                meter_details = db.meter_details.Where(m => m.HiD == id);
            }
           
            return View(meter_details.ToList());
        }

        public PartialViewResult Partial(String id)
        {
            IQueryable<meter_detail> meter_details;
            if (id == null)
            {
                meter_details = db.meter_details.Include(m => m.house_details).Include(m => m.meter_master).Include(m => m.site_details).Include(m => m.utility_tarrif_master);
            }
            else
            {
                meter_details = db.meter_details.Where(m => m.HiD == id);
            }
            return PartialView(meter_details.ToList());
        }

        // GET: meter_details/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meter_detail meter_details = db.meter_details.Find(id);
            if (meter_details == null)
            {
                return HttpNotFound();
            }
            return View(meter_details);
        }

        // GET: meter_details/Create
        public ActionResult Create()
        {
            var meter = db.meter_masters.ToList().Select(s => new { MMiD = s.MMiD, Manufacturer = $"{s.Manufacturer} - {s.Model} - {s.Table_1.Name}" });
            ViewBag.MMiD = new SelectList(meter, "MMiD", "Manufacturer");
            ViewBag.UiD = new SelectList(db.utility_tarrif_masters, "UiD", "Utility_Provider_Name");
            LoadSites(null);
            return View();
        }

        public JsonResult GetHouseNo(string id)
        {
            var houses = db.house_details.Where((d) => d.SiD == id).AsEnumerable().Select((s) => new { HiD = s.HiD, House_No = s.House_No });
            return Json(houses, JsonRequestBehavior.AllowGet);

        }

        private void LoadSites(string selectedHiD)
        {
            ViewBag.HiD = new SelectList(string.Empty, "HiD", "House_No");
            if (selectedHiD == null)
                ViewBag.SiD = new SelectList(db.site_details, "SiD", "Site_Name");
            else
            {
                var house = db.house_details.Where((d) => d.HiD == selectedHiD).FirstOrDefault();
                if (house != null)
                {
                    ViewBag.SiD = new SelectList(db.site_details, "SiD", "Site_Name", house.SiD);
                    ViewBag.HiD = new SelectList(db.house_details.Where((s) => s.SiD == house.SiD), "HiD", "House_No", selectedHiD);
                }
            }
        }

        // POST: meter_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HiD,SiD,MBUS_Device_ID,IP_Address,Port,MMiD,UiD,Status")] meter_detail meter_details)
        {
            meter_details.MiD = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {
                db.meter_details.Add(meter_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var meter = db.meter_masters.ToList().Select(s => new { MMiD = s.MMiD, Manufacturer = $"{s.Manufacturer} - {s.Model} - {s.Table_1.Name}" });
            //ViewBag.HiD = new SelectList(db.house_details, "HiD", "House_No", meter_details.HiD);
            ViewBag.MMiD = new SelectList(meter, "MMiD", "Manufacturer", meter_details.MMiD);
            //ViewBag.SiD = new SelectList(db.site_details, "SiD", "Site_Name", meter_details.SiD);
            ViewBag.UiD = new SelectList(db.utility_tarrif_masters, "UiD", "Utility_Provider_Name", meter_details.UiD);
            LoadSites(meter_details.HiD);
            return View(meter_details);
        }

        // GET: meter_details/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meter_detail meter_details = db.meter_details.Find(id);
            if (meter_details == null)
            {
                return HttpNotFound();
            }
           
            var meter = db.meter_masters.ToList().Select(s => new { MMiD = s.MMiD, Manufacturer = $"{s.Manufacturer} - {s.Model} - {s.Table_1.Name}" });
            ViewBag.HiD = new SelectList(db.house_details, "HiD", "SiD", meter_details.HiD);
            ViewBag.MMiD = new SelectList(meter, "MMiD", "Manufacturer", meter_details.MMiD);
            ViewBag.SiD = new SelectList(db.site_details, "SiD", "Site_Name", meter_details.SiD);
            ViewBag.UiD = new SelectList(db.utility_tarrif_masters, "UiD", "Utility_Provider_Name", meter_details.UiD);
            LoadSites(meter_details.HiD);
            return View(meter_details);
        }

        // POST: meter_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MiD,HiD,SiD,MBUS_Device_ID,MMiD,UiD,IP_Address,Port,Status,Error_Code,Error_Msg")] meter_detail meter_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meter_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var meter = db.meter_masters.ToList().Select(s => new { MMiD = s.MMiD, Manufacturer = $"{s.Manufacturer} - {s.Model} - {s.Table_1.Name}" });
            //ViewBag.HiD = new SelectList(db.house_details, "HiD", "SiD", meter_details.HiD);
            ViewBag.MMiD = new SelectList(meter, "MMiD", "Manufacturer", meter_details.MMiD);
            //ViewBag.SiD = new SelectList(db.site_details, "SiD", "Site_Name", meter_details.SiD);
            ViewBag.UiD = new SelectList(db.utility_tarrif_masters, "UiD", "Utility_Provider_Name", meter_details.UiD);
            LoadSites(meter_details.HiD);
            return View(meter_details);
        }

        // GET: meter_details/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meter_detail meter_details = db.meter_details.Find(id);
            if (meter_details == null)
            {
                return HttpNotFound();
            }
            return View(meter_details);
        }

        // POST: meter_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            meter_detail meter_details = db.meter_details.Find(id);
            db.meter_details.Remove(meter_details);
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