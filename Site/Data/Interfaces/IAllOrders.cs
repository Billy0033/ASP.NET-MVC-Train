using Site.Data.Models;

namespace Site.Data.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order);
    }
}
