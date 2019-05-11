using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VinylStore.Entities;
using VinylStore.Filters;
using VinylStore.Repositories;

namespace VinylStore.Controllers
{
    [AuthenticationFilter]
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Add(int id)
        {
            ProductsRepository repo = new ProductsRepository();
            Product product = repo.GetById(id);

            if (product == null)
            {
                return new HttpNotFoundResult("There is no such product!");
            }

            Dictionary<Product, int> cart;
            if (Session["cart"] == null)
            {
                cart = new Dictionary<Product, int>();
                cart.Add(product, 1);
                Session["cart"] = cart;
            }
            else
            {
                cart = (Dictionary<Product, int>)Session["cart"];
                
                if (cart.ContainsKey(product))
                {
                    cart[product]++;
                }
                else
                {
                    cart.Add(product, 1);
                }
                Session["cart"] = cart;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult RemoveByOne(int id)
        {
            if (Session["cart"] == null)
            {
                return new HttpNotFoundResult("You haven't added anything to the cart yet!");
            }

            ProductsRepository repo = new ProductsRepository();
            Product product = repo.GetById(id);
            Dictionary<Product, int> cart = (Dictionary<Product, int>)Session["cart"];

            if (cart.ContainsKey(product) && cart[product] > 1)
            {
                cart[product]--;
            }
            else if (cart.ContainsKey(product) && cart[product] == 1)
            {
                return RedirectToAction("Remove", new { id = id });
            }
            Session["cart"] = cart;

            return RedirectToAction("Index", "Account");
        }

        public ActionResult Remove(int id)
        {
            if (Session["cart"] == null)
            {
                return new HttpNotFoundResult("You haven't added anything to the cart yet!");
            }

            ProductsRepository repo = new ProductsRepository();
            Product product = repo.GetById(id);
            Dictionary<Product, int> cart = (Dictionary<Product, int>)Session["cart"];

            if (cart.ContainsKey(product))
            {
                cart.Remove(product);
            }
            Session["cart"] = cart.Count == 0 ? null : cart;

            return RedirectToAction("Index", "Account");
        }
    }
}