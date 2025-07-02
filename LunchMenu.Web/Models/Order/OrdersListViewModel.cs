namespace LunchMenu.Web.Models.Order
{
    public class OrdersListViewModel
    {
        public List<OrderViewModel> orders;
        public int totalCount;
    }

    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
