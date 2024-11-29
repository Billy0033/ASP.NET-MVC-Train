namespace Site.Data.Models
{
    public class ShopCarItem
    {
        public int id { get; set; }
        public Car car { get; set; }
        public int price { get; set; }
        public string shopCarId { get; set; }

    }
}
