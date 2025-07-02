namespace LunchMenu.Web.Models.Reports
{
    public class PopularDishesViewModel
    {
        public int TotalOrders { get; set; }
        public int TotalDishes { get; set; }
        public List<PopularDishViewModel> Dishes { get; set; } = new();
    }
}
