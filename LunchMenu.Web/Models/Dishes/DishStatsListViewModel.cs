namespace LunchMenu.Web.Models.Dishes
{
    public class DishStatsListViewModel
    {
        public List<DishStatsViewModel> Dishes { get; set; }
        public int TotalOrders { get; set; }
    }
    public class DishStatsViewModel
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int TotalOrders { get; set; }
    }
}
