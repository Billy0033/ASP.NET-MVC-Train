using Site.Data.Models;

namespace Site.Data
{
    public class DBObjects
    {
        public static void Initial(AppDbContent content)
        {
            //AppDbContent content;
            //using (var scope = app.ApplicationServices.CreateScope())
            //{
            //    content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
            //}

            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any())
            {
                content.Car.AddRange(
                    new Car
                    {
                        name = "Tesla Model S",
                        shortDescription = "пятидверный электромобиль производства американской компании Tesla.",
                        longDescription = "пятидверный электромобиль производства американской компании Tesla. Прототип был впервые показан на Франкфуртском автосалоне в 2009 году; поставки электромобиля в США начались в июне 2012 года",
                        img = "https://media.ed.edmunds-media.com/tesla/model-s/2024/oem/2024_tesla_model-s_sedan_plaid_fq_oem_1_1600.jpg",
                        price = 45000,
                        isFavorite = true,
                        availabel = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        name = "BMW M5",
                        shortDescription = "Автомобили M BMW 5 серии впечатляющим образом сочетают в себе фирменную спортивность BMW M с комфортом и элегантностью седана бизнес-класса. ",
                        longDescription = "Познакомьтесь с тремя уникальными автомобилями BMW M с яркими характерами. Быстрейший в истории, новый BMW M5 CS с двигателем мощностью в 635 л.с. (467 кВт) и разгоном до 100 км/ч за рекордные 3 секунды. ",
                        img = "https://repost.uz/storage/uploads/55-1685413670-avto11-post-material.jpeg",
                        price = 50000,
                        isFavorite = true,
                        availabel = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        name = "Mercedes-Benz C 180 AMG",
                        shortDescription = "Совершенная динамика, отточенная управляемость, беспрецедентная безопасность — новый Mercedes C-180 в кузове W205 знает, чего Вы хотите от городского автомобиля. Его яркая внешность обращает на себя внимание с первого же взгляда, и возникает непреодолимое желание сесть за руль и испытать седан в деле.",
                        longDescription = "Мотор работает в паре с 9-ступенчатым «автоматом» 9G-TRONIC. Максимальная скорость седана 225 км/ч. До «сотни» с нуля автомобиль разгонится за 8,3 с. При таких впечатляющих характеристиках средний расход топлива удивительно небольшой: 6,5–6,2 л/100 км.",
                        img = "https://www.auto-plus.tn/assets/modules/newcars/mercedes-benz/classe-c/couverture/mercedes-benz-classe-c.jpg",
                        price = 55000,
                        isFavorite = true,
                        availabel = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        name = "BYD",
                        shortDescription = "китайский конгломерат, включающий в себя производителя автомобилей BYD Auto и производителя аккумуляторов и электроники BYD Electronic",
                        longDescription = "Базируется в Шэньчжэне (Китай). В списке крупнейших публичных компаний мира Forbes Global 2000 за 2022 год BYD заняла 580-е место.",
                        img = "https://avtoremont.uz/d/byd-e2-white.jpg",
                        price = 55000,
                        isFavorite = true,
                        availabel = true,
                        Category = Categories["Электромобили"]
                    }


                    );
            }
            content.SaveChanges();

        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null) { 
                    var list = new Category[] {
                         new Category{ categoryName = "Электромобили", description = "Современный вид транспорта."},
                         new Category{ categoryName = "Классические автомобили", description = "Машины с двигателем внутреннего сгорания"}

                    };
                    category = new Dictionary<string, Category>();
                    foreach(Category element in list)
                    {
                        category.Add(element.categoryName, element);

                    }
                }
                return category;

            }
        }
        
    }
}
