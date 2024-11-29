namespace Site.Data.Models
{
    public class Car
    {
        public int id { get; set; } //id - машины 

        public string name { get; set; } // название машины

        public string shortDescription { get; set; } // короткое описание машины

        public string longDescription { get; set; } //длинное описание машины

        public string img { get; set; } // url адрес - путь к картинке

        public ushort price { get; set; } //переменная для цены, цена не может быть отрицательная

        public bool isFavorite { get; set; } //актуальность, если true, то отображаем на главной станице, если нет, то не отображаем

        public bool availabel { get; set; } //если товар на складе, то какое количество осталось на складе

        public int categoryID { get; set; }
        //присвоение товара к определнной категории, укажем id категории - например электрокар - 1, обычный авто - 2 и передаем эту категорию в Category

        public virtual Category Category { get; set; }// Сохдаем объект со всеми значениями, которые имеются в Category



    }
}
