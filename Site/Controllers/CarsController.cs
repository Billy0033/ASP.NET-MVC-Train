using Microsoft.AspNetCore.Mvc;
using Site.Data.Interfaces;
using Site.Data.Models;
using Site.ViewModels;
using System;

namespace Site.Controllers
{
    public class CarsController : Controller
    {

        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategoties;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _allCategoties = iCarsCat;
        }


        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category)) {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else
            {
                if(string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили")).OrderBy(i => i.id);
                } else if(string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Классические автомобили")).OrderBy(i => i.id);
                }

                currCategory = _category;
            }
            var carObj = new CarsViewListModel
            {
                allCars = cars,
                currCategory = currCategory,
            };


            //CarsViewListModel obj = new CarsViewListModel();
            //obj.allCars = _allCars.Cars;
            //obj.currCategory = "Автомобили";

            return View(carObj);
        }
        //public IActionResult List()
        //{
        //    var cars = _allCars.Cars;
        //    return View(cars);
        //}
    }
}
