using Microsoft.AspNetCore.Mvc;
using Site.Data.Interfaces;
using Site.Data.Models;
using Site.ViewModels;
using System.Diagnostics;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCar _shopCar;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }

        public ViewResult Index() {
            var homeCars = new HomeViewModel
            {
                favCars = _carRep.getFavCars
            };
            return View(homeCars);
        }


    }
}
