using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VinylStore.Entities;
using VinylStore.Filters;
using VinylStore.Repositories;
using VinylStore.ViewModels.Account;

namespace VinylStore.Controllers
{
    public class AccountController : Controller
    {
        [AuthenticationFilter]
        public ActionResult Index()
        {
            IndexVM model = new IndexVM();
            if (Session[$"cart{((User)Session["loggedUser"]).Id}"] == null)
            {
                model.CartProducts = null;
            }
            else
            {
                model.CartProducts = (Dictionary<Product, int>)Session[$"cart{((User)Session["loggedUser"]).Id}"];
            }

            OrdersRepository ordersRepo = new OrdersRepository();
            int userId = ((User)Session["loggedUser"]).Id;
            model.Orders = ordersRepo.GetAll(o => o.UserId == userId, includes: o => o.OrderItems);
            
            return View(model);
        }

        // GET: /Account/Register
        public ActionResult Register()
        {
            if (Session["loggedUser"] != null)
                return RedirectToAction("Index", "Home");

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
            if (Session["loggedUser"] != null)
                return RedirectToAction("Index", "Home");

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