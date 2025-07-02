using LunchMenu.Service.DTOs.Report;
using System.ComponentModel.DataAnnotations;

namespace LunchMenu.Web.Models.Reports
{
    public class DailyStatsViewModel
    {
        [Required(ErrorMessage = "Please select a date")]
        [DataType(DataType.Date)]
        public DateTime? SelectedDate { get; set; }

        public DateTime? Date { get; set; }
        public int TotalOrders { get; set; }
        public int TotalDishes { get; set; }
        public int TotalUniqueCustomers { get; set; }

        public List<DailyDishStatViewModel> Dishes { get; set; } = new();
    }
}
