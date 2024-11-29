using Microsoft.AspNetCore.Mvc;
using Site.Data.Interfaces;
using Site.Data.Models;
using Site.Data.Repository;
using Site.ViewModels;

namespace Site.Controllers
{
    public class ShopCarController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCar _shopCar;

        public ShopCarController(IAllCars carRep, ShopCar shopCar)
        {
            _carRep = carRep;
            _shopCar = shopCar;
        }

        public ViewResult Index()
        {
            var items = _shopCar.getShopItems();
            _shopCar.listShopItems = items;

            var obj = new ShopCarViewModel
            {
                shopCar = _shopCar
            };

            return View(obj);

        }

        public RedirectToActionResult addToCar(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _shopCar.AddToCar(item);
            }
            return RedirectToAction("Index");
        }
    }
}
