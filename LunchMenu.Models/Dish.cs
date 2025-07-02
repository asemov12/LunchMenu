using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Models
{
    public class Dish
    {
        public int DishId { get; set; }

        [Required(ErrorMessage = "Dish name is required")]
        [StringLength(100, ErrorMessage = "Dish name is too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Dish type is required")]
        [RegularExpression("^(appetizer|main|dessert)$", ErrorMessage = "Dish type must be 'appetizer', 'main', or 'dessert'")]
        public string Type { get; set; }
    }
}
