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
    public class meter_masterController : Controller
    {
        private designdbEntities db = new designdbEntities();
        
        // GET: meter_master
        public ActionResult Index()
        {
            var meter_master = db.meter_masters.Include(s => s.Table_1).Include(s => s.ProtocolType).Include(s => s.Register).Include(s => s.Table_2);
            return View(db.meter_masters.ToList());
        }

        // GET: meter_master/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meter_master meter_master = db.meter_masters.Find(id);
            if (meter_master == null)
            {
                return HttpNotFound();
            }
            return View(meter_master);
        }

        // GET: meter_master/Create
        public ActionResult Create()
        {
             ViewBag.PiD = new SelectList(db.ProtocolTypes, "Id","Name");
             ViewBag.TiD = new SelectList(db.Table_1, "Id", "Name");
             ViewBag.RiD = new SelectList(db.Registers, "Id", "Name");
             ViewBag.IiD = new SelectList(db.Table_2, "Id", "Name");
            return View();
        }

        // POST: meter_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PiD,RiD,TiD,IiD,Manufacturer,Protocol,Type,Model,Address")] meter_master meter_master)
        {
            meter_master.MMiD = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {
                db.meter_masters.Add(meter_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PiD = new SelectList(db.ProtocolTypes, "Id", "Name",meter_master.PiD);
            ViewBag.TiD = new SelectList(db.Table_1, "Id", "Name",meter_master.TiD);
            ViewBag.RiD = new SelectList(db.Registers, "Id", "Name",meter_master.RiD);
            ViewBag.IiD = new SelectList(db.Table_2, "Id", "Name", meter_master.IiD);

            return View(meter_master);
        }

        // GET: meter_master/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meter_master meter_master = db.meter_masters.Find(id);
            if (meter_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.PiD = new SelectList(db.ProtocolTypes, "Id", "Name", meter_master.PiD);
            ViewBag.TiD = new SelectList(db.Table_1, "Id", "Name", meter_master.TiD);
            ViewBag.RiD = new SelectList(db.Registers, "Id", "Name", meter_master.RiD);
            ViewBag.IiD = new SelectList(db.Table_2, "Id", "Name", meter_master.IiD);
            return View(meter_master);
        }

        // POST: meter_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PiD,RiD,TiD,IiD,MMiD,Manufacturer,Model,Type,Protocol,Register_Type,Address")] meter_master meter_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meter_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PiD = new SelectList(db.ProtocolTypes, "Id", "Name", meter_master.PiD);
            ViewBag.TiD = new SelectList(db.Table_1, "Id", "Name", meter_master.TiD);
            ViewBag.RiD = new SelectList(db.Registers, "Id", "Name", meter_master.RiD);
            ViewBag.IiD = new SelectList(db.Table_2, "Id", "Name", meter_master.IiD);
            return View(meter_master);
        }

        // GET: meter_master/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meter_master meter_master = db.meter_masters.Find(id);
            if (meter_master == null)
            {
                return HttpNotFound();
            }
            return View(meter_master);
        }

        // POST: meter_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            meter_master meter_master = db.meter_masters.Find(id);
            db.meter_masters.Remove(meter_master);
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