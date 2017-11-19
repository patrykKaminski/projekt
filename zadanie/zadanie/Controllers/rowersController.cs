using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using zadanie.Models;
using zadanie.Repository;

namespace zadanie.Controllers
{
    public class rowersController : Controller
    {
        private ContactFormRepositoryRower _ContactFormRepositoryRower;
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return View(db.rowerDB.ToList());
        }

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

        public ActionResult Create()
        {
            return View();
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(rower rower)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rower).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rower);
        }

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
