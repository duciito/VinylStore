using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VinylStore.Entities;
using VinylStore.Repositories;
using VinylStore.ViewModels.Account;

namespace VinylStore.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            UsersRepository repo = new UsersRepository();
            User registeredUser = repo.GetFirstOrDefault(i => i.Username == model.Username);

            if (registeredUser != null)
                ModelState.AddModelError("UsernameTaken", "Това име вече съществува!");

            if (!ModelState.IsValid)
                return View(model);

            User newUser = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Username = model.Username
            };

            repo.Insert(newUser);

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Login()
        {
            LoginVM model = new LoginVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            UsersRepository repo = new UsersRepository();
            Session["loggedUser"] = repo.GetFirstOrDefault(i => i.Username == model.Username && i.Password == model.Password);

            if (Session["loggedUser"] == null)
                ModelState.AddModelError("AuthenticationFailed", "Въвели сте грешни данни!");

            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["loggedUser"] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}