using Site.Data.Models;

namespace Site.ViewModels
{
    public class CarsViewListModel
    {
        public IEnumerable<Car> allCars { get; set; }

        public string currCategory { get; set; }
    }
}

