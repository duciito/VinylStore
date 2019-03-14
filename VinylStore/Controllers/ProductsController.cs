using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VinylStore.Entities;
using VinylStore.Filters;
using VinylStore.Repositories;
using VinylStore.ViewModels.Products;

namespace VinylStore.Controllers
{
    [AuthorizationFilter]
    public class ProductsController : Controller
    {
        // GET: Products
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(new GenresRepository().GetAll());
        }

        public ActionResult Edit(int? id)
        {
            ProductsRepository productsRepo = new ProductsRepository();
            GenresRepository genresRepo = new GenresRepository();
            Product item = id == null ? new Product() : productsRepo.GetById(id.Value);

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.GenreId = item.GenreId;
            model.Artist = item.Artist;
            model.Title = item.Title;
            model.Genres = new SelectList
            (
                genresRepo.GetAll(),
                "Id",
                "Name",
                model.GenreId
            );
            model.Price = item.Price;
            model.VinylImgPath = item.VinylImgPath;
            model.OnSale = item.OnSale;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            GenresRepository genresRepo = new GenresRepository();
            if (!ModelState.IsValid)
            {
                model.Genres = new SelectList
            (
                genresRepo.GetAll(),
                "Id",
                "Name",
                model.GenreId
            );
                return View(model);
            }

            ProductsRepository repo = new ProductsRepository();
            Product item = new Product();

            item.Id = model.Id;
            item.GenreId = model.GenreId;
            item.Artist = model.Artist;
            item.Title = model.Title;
            item.Price = (decimal)model.Price;
            item.VinylImgPath = model.VinylImgPath;
            item.OnSale = model.OnSale;

            if (item.Id > 0)
                repo.Update(item);
            else
                repo.Insert(item);

            return RedirectToAction("Index", "Products");
        }

        public ActionResult Delete(int id)
        {
            ProductsRepository repo = new ProductsRepository();
            Product item = repo.GetById(id);
            repo.Delete(item);

            return RedirectToAction("Index", "Products");
        }
    }
}