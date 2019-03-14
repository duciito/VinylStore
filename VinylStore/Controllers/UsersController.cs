using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VinylStore.Entities;
using VinylStore.Filters;
using VinylStore.Repositories;
using VinylStore.ViewModels.Users;

namespace VinylStore.Controllers
{
    [AuthorizationFilter]
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            UsersRepository repo = new UsersRepository();
            User item = id == null ? new User() : repo.GetById(id.Value);

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Username = item.Username;
            model.Password = item.Password;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            UsersRepository repo = new UsersRepository();
            User item = new User();

            item.Id = model.Id;
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            if (item.Id > 0)
                repo.Update(item);
            else
                repo.Insert(item);

            return RedirectToAction("AdminPanel", "Account");
        }

        public ActionResult Delete(int id)
        {
            UsersRepository repo = new UsersRepository();

            User item = repo.GetById(id);
            repo.Delete(item);

            return RedirectToAction("AdminPanel", "Account");
        }
    }
}