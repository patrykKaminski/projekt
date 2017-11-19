using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;
using WebApplication8.Repository;
using WebApplication8.Service;

namespace WebApplication8.Controllers
{
    public class ContactFormsController : Controller
    {
        private EmailService _emailService;

        private ContactFormRepository _ContactRepository;

        public ContactFormsController()
        {
            _emailService = new Service.EmailService();
            _ContactRepository = new ContactFormRepository();
        }

        

        // GET: ContactForms
        public ActionResult Index()
        {
            return View(_ContactRepository.GetWhere(x => x.Id>0));
        }

        // GET: ContactForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = _ContactRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
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
                _ContactRepository.Create(contactForm);
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
            ContactForm contactForm = _ContactRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
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
            ContactForm contactForm = _ContactRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _ContactRepository.Delete(contactForm);

            return RedirectToAction("Index");
        }

        
    }
}
