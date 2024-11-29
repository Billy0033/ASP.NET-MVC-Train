using Microsoft.EntityFrameworkCore;

namespace Site.Data.Models
{
    public class ShopCar
    {

        private readonly AppDbContent appDbContent;

        public ShopCar(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public string shopCarId { get; set; }

        public List<ShopCarItem> listShopItems { get; set; }

        public static ShopCar GetCar(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContent>();
            string shopCarId = session.GetString("CarId") ?? Guid.NewGuid().ToString();

            session.SetString("CarId", shopCarId);

            return new ShopCar(context) { shopCarId = shopCarId };

        }

        public void AddToCar(Car car)
        {
            this.appDbContent.ShopCarItem.Add(new ShopCarItem { 
                shopCarId = shopCarId,
                car = car,
                price = car.price 
            });

            appDbContent.SaveChanges();

        }

        public List<ShopCarItem> getShopItems()
        {
            return appDbContent.ShopCarItem.Where(c => c.shopCarId == shopCarId).Include(s => s.car).ToList();
        }
    }
}
