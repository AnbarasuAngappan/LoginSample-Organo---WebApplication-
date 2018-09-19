using LoginSample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LoginSample.Controllers
{
    public class utility_tarrif_masterController : Controller
    {
        private designdbEntities db = new designdbEntities();
        private SelectList list;

        // GET: utility_tarrif_master
        public ActionResult Index()
        {
            return View(db.utility_tarrif_masters.ToList());
        }

        // GET: utility_tarrif_master/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utility_tarrif_master utility_tarrif_master = db.utility_tarrif_masters.Find(id);
            if (utility_tarrif_master == null)
            {
                return HttpNotFound();
            }
            return View(utility_tarrif_master);
        }

        // GET: utility_tarrif_master/Create
        public ActionResult Create()
        {
            list = new SelectList(new[] { "Electricity", "LPG", "Water", "Solar", "Genset" });
            ViewBag.Utility_Type = list;
            return View();
        }

        // POST: utility_tarrif_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "Utility_Provider_Name,Utility_Type,City,State,Tarrif_Master,Charge_Back")] utility_tarrif_master utility_tarrif_master*/ UnitViewModel model)
        {
            model.Tarrif.UiD = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {
                
                utility_tarrif_master u = new utility_tarrif_master();
                u.UiD = model.Tarrif.UiD;
                u.Utility_Provider_Name = model.Tarrif.Utility_Provider_Name;
                u.Utility_Type = model.Tarrif.Utility_Type;
                db.utility_tarrif_masters.Add(u);
                db.SaveChanges();

                foreach (var opt in model.Options)
                {
                    var newOption = new Unit();
                    newOption.Startunit = opt.Startunit ;
                    newOption.Endunit =  opt.Endunit ;
                    newOption.Price =  opt.Price ;
                    db.Units.Add(newOption);
                    db.SaveChanges();
                  
                }
                return RedirectToAction("Index");
            }
            ViewBag.Utility_Type = list;
            return View(model);
        }

        // GET: utility_tarrif_master/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utility_tarrif_master utility_tarrif_master = db.utility_tarrif_masters.Find(id);
            if (utility_tarrif_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.Utility_Type = list;
            return View(utility_tarrif_master);
        }

        // POST: utility_tarrif_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UiD,Utility_Provider_Name,Utility_Type,City,State,Tarrif_Master,Charge_Back")] utility_tarrif_master utility_tarrif_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utility_tarrif_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Utility_Type = list;
            return View(utility_tarrif_master);
        }

        // GET: utility_tarrif_master/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utility_tarrif_master utility_tarrif_master = db.utility_tarrif_masters.Find(id);
            if (utility_tarrif_master == null)
            {
                return HttpNotFound();
            }
            return View(utility_tarrif_master);
        }

        // POST: utility_tarrif_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            utility_tarrif_master utility_tarrif_master = db.utility_tarrif_masters.Find(id);
            db.utility_tarrif_masters.Remove(utility_tarrif_master);
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