using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Site.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Введите имя")]
        
        //[Required(ErrorMessage = "Длина имени не менее 5 символов")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию")]
        
        //[Required(ErrorMessage = "Длина фамилии не менее 5 символов")]
        public string Surname { get; set; }

        [Display(Name = "Введите номер телефона")]
        
        [DataType(DataType.PhoneNumber)]
        //[Required(ErrorMessage = "Длина телефона не менее 10 символов")]
        public string Phone { get; set; }

        [Display(Name = "Введите электронную почту")]
        
        //[Required(ErrorMessage = "Длина email не менее 10 символов")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }


    }
}
