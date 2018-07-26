using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validation.Web.Models;

namespace Validation.Web.Controllers
{
    public class UsersController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View("Index");
        }

        // Add the following Controller Actions

        // GET: User/Register
        // Return the empty registration view
        public ActionResult Login()
        {
            return View("Index");
        }

        // POST: User/Register
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            // Let's validate the model before proceeding
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            return RedirectToAction("Confirmation", "Users");
        }

        // POST: User/Register
        // Validate the model and redirect to confirmation (if successful) or return the 
        // registration view (if validation fails)        

        // GET: User/Login
        // Return the empty login view

        // POST: User/Login  
        // Validate the model and redirect to login (if successful) or return the 
        // login view (if validation fails)

        public ActionResult Register()
        {
            return View("Register");
        }

        // POST: User/Register
        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {
            // Let's validate the model before proceeding
            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }

            return RedirectToAction("Confirmation", "Users");
        }

        // GET: User/Confirmation
        // Return the confirmation view
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}