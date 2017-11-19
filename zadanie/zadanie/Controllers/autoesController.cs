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
    public class autoesController : Controller
    {
        private ContactFormRepositoryAuto _ContactFormRepositoryAuto;
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return View(_ContactFormRepositoryAuto.GetWhere(x => x.id > 0));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auto auto = _ContactFormRepositoryAuto.GetWhere(x => x.id == id.Value).FirstOrDefault();
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( auto auto)
        {
            if (ModelState.IsValid)
            {
                db.autoDB.Add(auto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auto);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auto auto = db.autoDB.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auto);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auto auto = db.autoDB.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            auto auto = db.autoDB.Find(id);
            db.autoDB.Remove(auto);
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
