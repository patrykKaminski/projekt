using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class KontaktModelsController : Controller
    {
        private Models.AppContext db = new Models.AppContext();

        // GET: KontaktModels
        public ActionResult Index()
        {
            return View(db.KontaktModels.ToList());
        }

        // GET: KontaktModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KontaktModel kontaktModel = db.KontaktModels.Find(id);
            if (kontaktModel == null)
            {
                return HttpNotFound();
            }
            return View(kontaktModel);
        }

        // GET: KontaktModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KontaktModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Temat,Treść")] KontaktModel kontaktModel)
        {
            if (ModelState.IsValid)
            {
                db.KontaktModels.Add(kontaktModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kontaktModel);
        }

        // GET: KontaktModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KontaktModel kontaktModel = db.KontaktModels.Find(id);
            if (kontaktModel == null)
            {
                return HttpNotFound();
            }
            return View(kontaktModel);
        }

        // POST: KontaktModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Temat,Treść")] KontaktModel kontaktModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kontaktModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kontaktModel);
        }

        // GET: KontaktModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KontaktModel kontaktModel = db.KontaktModels.Find(id);
            if (kontaktModel == null)
            {
                return HttpNotFound();
            }
            return View(kontaktModel);
        }

        // POST: KontaktModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KontaktModel kontaktModel = db.KontaktModels.Find(id);
            db.KontaktModels.Remove(kontaktModel);
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
