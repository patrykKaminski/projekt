using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using zadanie.Models;

namespace zadanie.Controllers
{
    public class rowersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: rowers
        public ActionResult Index()
        {
            return View(db.rowerDB.ToList());
        }

        // GET: rowers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rower rower = db.rowerDB.Find(id);
            if (rower == null)
            {
                return HttpNotFound();
            }
            return View(rower);
        }

        // GET: rowers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,marka,iloscBiegow,rozmiarRamy")] rower rower)
        {
            if (ModelState.IsValid)
            {
                db.rowerDB.Add(rower);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rower);
        }

        // GET: rowers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rower rower = db.rowerDB.Find(id);
            if (rower == null)
            {
                return HttpNotFound();
            }
            return View(rower);
        }

        // POST: rowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,marka,iloscBiegow,rozmiarRamy")] rower rower)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rower).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rower);
        }

        // GET: rowers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rower rower = db.rowerDB.Find(id);
            if (rower == null)
            {
                return HttpNotFound();
            }
            return View(rower);
        }

        // POST: rowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rower rower = db.rowerDB.Find(id);
            db.rowerDB.Remove(rower);
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
