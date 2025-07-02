using System.ComponentModel.DataAnnotations;
using LunchMenu.Service.DTOs.Dish;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LunchMenu.Web.Models.Order
{
    public class CreateOrderViewModel
    {
        public DateTime OrderDate { get; set; }

        public int? SelectedAppetizerId { get; set; }
        public int? SelectedMainCourseId { get; set; }
        public int? SelectedDessertId { get; set; }

        public List<DishInfo> Appetizers { get; set; } = new();
        public List<DishInfo> MainCourses { get; set; } = new();
        public List<DishInfo> Desserts { get; set; } = new();
    }
}
