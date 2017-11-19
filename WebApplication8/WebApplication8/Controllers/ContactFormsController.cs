using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;
using WebApplication8.Service;

namespace WebApplication8.Controllers
{
    public class ContactFormsController : Controller
    {
        private EmailService _emailService;

        public ContactFormsController()
        {
            _emailService = new Service.EmailService();
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactForms
        public ActionResult Index()
        {
            return View(db.ContactForms.ToList());
        }

        // GET: ContactForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = db.ContactForms.Find(id);
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                db.ContactForms.Add(contactForm);
                db.SaveChanges();
                var message = _emailService.CreateMailMessage(contactForm);
                _emailService.SendEmail(message);
                return RedirectToAction("Index");
            }

            return View(contactForm);
        }

       
        // GET: ContactForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = db.ContactForms.Find(id);
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // POST: ContactForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactForm contactForm = db.ContactForms.Find(id);
            db.ContactForms.Remove(contactForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
