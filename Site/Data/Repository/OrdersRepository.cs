using Site.Data.Interfaces;
using Site.Data.Models;

namespace Site.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContent appDbContent;
        private readonly ShopCar shopCar;

        public OrdersRepository(AppDbContent appDbContent, ShopCar shopCar)
        {
            this.appDbContent = appDbContent;
            this.shopCar = shopCar;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDbContent.Order.Add(order);

            var items = shopCar.listShopItems;

            foreach (var el in items) {
                var orderDetail = new OrderDetail
                {
                    carID = el.car.id,
                    orderID = order.id,
                    Price = el.car.price
                };
                appDbContent.OrderDetail.Add(orderDetail);
            }
            appDbContent.SaveChanges();
        }
    }
}
