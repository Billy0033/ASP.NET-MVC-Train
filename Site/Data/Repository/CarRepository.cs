using Microsoft.EntityFrameworkCore;
using Site.Data.Interfaces;
using Site.Data.Models;

namespace Site.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDbContent appDbContent;

        public CarRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<Car> Cars => appDbContent.Car.Include(c => c.Category);

        public IEnumerable<Car> getFavCars => appDbContent.Car.Where(p => p.isFavorite).Include(c => c.Category);

        public Car getObjectCar(int carId) => appDbContent.Car.FirstOrDefault(p => p.id == carId);
    }
}
