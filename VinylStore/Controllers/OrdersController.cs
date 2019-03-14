using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VinylStore.Entities;
using VinylStore.Filters;
using VinylStore.Repositories;
using VinylStore.ViewModels.Orders;

namespace VinylStore.Controllers
{
    [AuthenticationFilter]
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult MakeOrder()
        {
            if (Session[$"cart{((User)Session["loggedUser"]).Id}"] == null)
            {
                return new HttpNotFoundResult("You haven't added anything to the cart yet!");
            }

            Dictionary<Product, int> cartProducts = (Dictionary<Product, int>)Session[$"cart{((User)Session["loggedUser"]).Id}"];
            Order order = new Order();
            OrdersRepository ordersRepo = new OrdersRepository();

            order.OrderDate = DateTime.Now;
            order.UserId = ((User)Session["loggedUser"]).Id;
            order.IsApproved = false;
            order.OrderItems = new List<OrderItem>();

            foreach (KeyValuePair<Product, int> cartItem in cartProducts)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.OrderId = order.Id;
                orderItem.ProductId = cartItem.Key.Id;
                orderItem.Quantity = cartItem.Value;
                orderItem.UnitPrice = cartItem.Key.Price;
                order.OrderItems.Add(orderItem);
            }

            ordersRepo.Insert(order);
            Session[$"cart{((User)Session["loggedUser"]).Id}"] = null;

            return RedirectToAction("Index", "Account");
        }
        
        public ActionResult Details(int id)
        {
            OrdersRepository ordersRepo = new OrdersRepository();
            Order order = ordersRepo.GetById(id);
            int loggedUserId = ((User)Session["loggedUser"]).Id;

            if (order == null)
            {
                return new HttpNotFoundResult("There is no such order!");
            }

            if (order.UserId != loggedUserId && loggedUserId != 1)
            {
                return new HttpUnauthorizedResult("You can't view other users' orders!");
            }

            DetailsVM model = new DetailsVM();
            model.OrderId = order.Id;
            model.OrderDate = order.OrderDate;
            model.IsApproved = order.IsApproved;
            model.OrderProducts = new Dictionary<Product, int>();

            foreach(OrderItem orderItem in order.OrderItems)
            {
                model.OrderProducts.Add(orderItem.Product, orderItem.Quantity);
                model.TotalPrice += orderItem.UnitPrice * orderItem.Quantity;
            }

            return View(model);
        }

        [AuthorizationFilter]
        public ActionResult Approve(int id)
        {
            OrdersRepository ordersRepo = new OrdersRepository();
            Order order = ordersRepo.GetById(id);

            order.IsApproved = true;
            ordersRepo.Update(order);

            return RedirectToAction("AdminPanel", "Account");
        }

        public ActionResult Delete(int id)
        {
            OrdersRepository ordersRepo = new OrdersRepository();
            Order order = ordersRepo.GetById(id);
            int loggedUserId = ((User)Session["loggedUser"]).Id;

            ordersRepo.Delete(order);

            return RedirectToAction(loggedUserId == 1 ? "AdminPanel" : "Index", "Account");
        }
    }
}