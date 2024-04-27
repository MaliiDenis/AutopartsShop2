using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Motora.Application;
using Motora.Database;
using Motora.Domain.Models;

namespace Motora.Web.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Login()
        {
            // Redirect user if already logged in
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        
        public ActionResult Register()
        {
            // Redirect user if already logged in
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = AuthenticateUser(username, password);
            if (user != null)
            {
                SetUpAuthenticationTicket(user);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            if (!IsUsernameAvailable(username))
            {
                ViewBag.Error = "User already exists";
                return View();
            }

            var user = RegisterNewUser(username, password);
            SetUpAuthenticationTicket(user);
            return RedirectToAction("Index", "Home");
        }

        private bool IsUsernameAvailable(string username)
        {
            return _context.Customers.FirstOrDefault(u => u.Username == username) == null;
        }

        private Customer RegisterNewUser(string username, string password)
        {
            string salt = HashingService.CreateSalt();
            string passwordHash = HashingService.HashPassword(password, salt);

            var newUser = new Customer
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = salt,
                Role = "User"
            };

            _context.Customers.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }

        private Customer AuthenticateUser(string username, string password)
        {
            var user = _context.Customers.FirstOrDefault(u => u.Username == username);
            if (user != null && HashingService.VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return user;
            }
            return null;
        }

        private void SetUpAuthenticationTicket(Customer user)
        {
            var authTicket = new FormsAuthenticationTicket(
                1, // version
                user.Username,
                DateTime.Now,
                DateTime.Now.AddMinutes(20), // expire
                true, // persistent
                user.Role, // user roles
                "/");

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(authCookie);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "")
            {
                Expires = DateTime.Now.AddYears(-1)
            };
            HttpContext.Response.Cookies.Add(authCookie);
            return RedirectToAction("Login", "Account");
        }
    }
}