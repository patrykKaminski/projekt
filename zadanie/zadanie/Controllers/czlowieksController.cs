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
    public class czlowieksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: czlowieks
        public ActionResult Index()
        {
            return View(db.czlowiekDB.ToList());
        }

        // GET: czlowieks/Details/5
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

        // POST: czlowieks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,wiek,waga,wzrost")] czlowiek czlowiek)
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

        // POST: czlowieks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,wiek,waga,wzrost")] czlowiek czlowiek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(czlowiek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(czlowiek);
        }

        // GET: czlowieks/Delete/5
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

        // POST: czlowieks/Delete/5
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
