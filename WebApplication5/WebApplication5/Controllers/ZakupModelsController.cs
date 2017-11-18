using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ZakupModelsController : Controller
    {
        private Models.AppContext db = new Models.AppContext();

        // GET: ZakupModels
        public ActionResult Index()
        {
            return View(db.zakupDBmodels.ToList());
        }

        // GET: ZakupModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZakupModel zakupModel = db.zakupDBmodels.Find(id);
            if (zakupModel == null)
            {
                return HttpNotFound();
            }
            return View(zakupModel);
        }

        // GET: ZakupModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZakupModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ZakupModel zakupModel)
        {
            if (ModelState.IsValid)
            {
                zakupModel.CzasModyfikacji = DateTime.Now;
                zakupModel.CzasDodania = DateTime.Now;
                db.zakupDBmodels.Add(zakupModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zakupModel);
        }

        // GET: ZakupModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZakupModel zakupModel = db.zakupDBmodels.Find(id);
            if (zakupModel == null)
            {
                return HttpNotFound();
            }
            return View(zakupModel);
        }

        // POST: ZakupModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ZakupModel zakupModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zakupModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zakupModel);
        }

        // GET: ZakupModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZakupModel zakupModel = db.zakupDBmodels.Find(id);
            if (zakupModel == null)
            {
                return HttpNotFound();
            }
            return View(zakupModel);
        }

        // POST: ZakupModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZakupModel zakupModel = db.zakupDBmodels.Find(id);
            db.zakupDBmodels.Remove(zakupModel);
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
