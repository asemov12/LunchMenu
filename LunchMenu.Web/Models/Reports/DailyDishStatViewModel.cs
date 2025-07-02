using LunchMenu.Service.DTOs.Report;
using System.ComponentModel.DataAnnotations;

namespace LunchMenu.Web.Models.Reports
{
    public class DailyDishStatViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int TimesOrdered { get; set; }
        public List<string> CustomerNames { get; set; } = new();
    }
}
