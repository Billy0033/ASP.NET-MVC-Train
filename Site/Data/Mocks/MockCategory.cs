using Site.Data.Interfaces;
using Site.Data.Models;

namespace Site.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{ categoryName = "Электромобили", description = "Современный вид транспорта."},
                    new Category{ categoryName = "Классические автомобили", description = "Машины с двигателем внутреннего сгорания"}

                };
            }
        }
    }
}
