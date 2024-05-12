using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Motora.Database;
using Motora.Domain.Models;

namespace Motora.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        
        [HttpPost]
        public ActionResult Contact(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();
                ViewBag.Message = "Thank you for your feedback!";
            }
            return View(feedback);
        }

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult Why()
        {
            return View();
        }
    }
}