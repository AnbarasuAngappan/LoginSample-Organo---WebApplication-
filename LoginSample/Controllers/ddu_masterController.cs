using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginSample;
using LoginSample.Models;

namespace LoginSample.Controllers
{
    public class ddu_masterController : Controller
    {
        private designdbEntities db = new designdbEntities();

        // GET: ddu_master
        public ActionResult Index()
        {
            return View(db.ddu_masters.ToList());
        }

        // GET: ddu_master/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ddu_master ddu_master = db.ddu_masters.Find(id);
            if (ddu_master == null)
            {
                return HttpNotFound();
            }
            return View(ddu_master);
        }

        // GET: ddu_master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ddu_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Manufacturer,Model")] ddu_master ddu_master)
        {
            ddu_master.DDUMiD = Guid.NewGuid().ToString();

            if (ModelState.IsValid)
            {
                db.ddu_masters.Add(ddu_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ddu_master);
        }

        // GET: ddu_master/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ddu_master ddu_master = db.ddu_masters.Find(id);
            if (ddu_master == null)
            {
                return HttpNotFound();
            }
            return View(ddu_master);
        }

        // POST: ddu_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DDUMiD,Manufacturer,Model")] ddu_master ddu_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ddu_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ddu_master);
        }

        // GET: ddu_master/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ddu_master ddu_master = db.ddu_masters.Find(id);
            if (ddu_master == null)
            {
                return HttpNotFound();
            }
            return View(ddu_master);
        }

        // POST: ddu_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ddu_master ddu_master = db.ddu_masters.Find(id);
            db.ddu_masters.Remove(ddu_master);
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
