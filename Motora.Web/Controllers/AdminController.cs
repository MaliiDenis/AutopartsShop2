using System.Linq;
using System.Web.Mvc;
using Motora.Database;

namespace Motora.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/Feedbacks
        public ActionResult Feedbacks()
        {
            var feedbacks = _context.Feedbacks.ToList();
            return View(feedbacks);
        }

        // POST: Admin/DeleteFeedback/5
        [HttpPost]
        public ActionResult DeleteFeedback(int id)
        {
            var feedback = _context.Feedbacks.Find(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                _context.SaveChanges();
                return RedirectToAction("Feedbacks");
            }

            return HttpNotFound();
        }
    }
}
