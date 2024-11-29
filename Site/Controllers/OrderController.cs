using Microsoft.AspNetCore.Mvc;
using Site.Data.Models;
using Site.Data;
using Site.Data.Interfaces;

namespace Site.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCar shopCar;

        public OrderController(IAllOrders allOrders, ShopCar shopCar)
        {
            this.allOrders = allOrders;
            this.shopCar = shopCar;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCar.listShopItems = shopCar.getShopItems();

            if (shopCar.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары");
            }

            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
