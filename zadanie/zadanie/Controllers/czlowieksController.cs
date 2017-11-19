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
    public class czlowieksController : Controller
    {
        private ContactFormRepositoryCzlowiek _ContactFormRepositoryCzlowiek;
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return View(db.czlowiekDB.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            czlowiek czlowiek = db.czlowiekDB.Find(id);
            if (czlowiek == null)
            {
                return HttpNotFound();
            }
            return View(czlowiek);
        }

        // GET: czlowieks/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(czlowiek czlowiek)
        {
            if (ModelState.IsValid)
            {
                db.czlowiekDB.Add(czlowiek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(czlowiek);
        }

        // GET: czlowieks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            czlowiek czlowiek = db.czlowiekDB.Find(id);
            if (czlowiek == null)
            {
                return HttpNotFound();
            }
            return View(czlowiek);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( czlowiek czlowiek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(czlowiek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(czlowiek);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            czlowiek czlowiek = db.czlowiekDB.Find(id);
            if (czlowiek == null)
            {
                return HttpNotFound();
            }
            return View(czlowiek);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            czlowiek czlowiek = db.czlowiekDB.Find(id);
            db.czlowiekDB.Remove(czlowiek);
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
