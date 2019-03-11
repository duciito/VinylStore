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

            if (repo.GetById(id) == null)
            {
                return new HttpNotFoundResult("There is no such product!");
            }

            if (Session[$"cart{((User)Session["loggedUser"]).Id}"] == null)
            {
                Dictionary<int, int> cart = new Dictionary<int, int>();
                cart.Add(id, 1);
                Session[$"cart{((User)Session["loggedUser"]).Id}"] = cart;
            }
            else
            {
                Dictionary<int, int> cart = (Dictionary<int, int>)Session[$"cart{((User)Session["loggedUser"]).Id}"];
                
                if (cart.ContainsKey(id))
                {
                    cart[id]++;
                }
                else
                {
                    cart.Add(id, 1);
                }
                Session[$"cart{((User)Session["loggedUser"]).Id}"] = cart;
            }

            return RedirectToAction("Index", "Products");
        }

        public ActionResult RemoveByOne(int id)
        {
            if (Session[$"cart{((User)Session["loggedUser"]).Id}"] == null)
            {
                return new HttpNotFoundResult("You haven't added anything to the cart yet!");
            }

            Dictionary<int, int> cart = (Dictionary<int, int>)Session[$"cart{((User)Session["loggedUser"]).Id}"];

            if (cart.ContainsKey(id) && cart[id] > 1)
            {
                cart[id]--;
            }
            else if (cart.ContainsKey(id) && cart[id] == 1)
            {
                return RedirectToAction("Remove", new { id = id });
            }
            Session[$"cart{((User)Session["loggedUser"]).Id}"] = cart;

            return RedirectToAction("Index", "Account");
        }

        public ActionResult Remove(int id)
        {
            if (Session[$"cart{((User)Session["loggedUser"]).Id}"] == null)
            {
                return new HttpNotFoundResult("You haven't added anything to the cart yet!");
            }

            Dictionary<int, int> cart = (Dictionary<int, int>)Session[$"cart{((User)Session["loggedUser"]).Id}"];

            if (cart.ContainsKey(id))
            {
                cart.Remove(id);
            }
            Session[$"cart{((User)Session["loggedUser"]).Id}"] = cart;

            return RedirectToAction("Index", "Account");
        }
    }
}