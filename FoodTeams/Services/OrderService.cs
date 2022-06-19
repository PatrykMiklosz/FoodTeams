using FoodTeams.Entities;

namespace FoodTeams.Services
{
    public class OrderService
    {
        private readonly FoodTeamsDbContext dbcontext;
        public List<Order> Orders { get; set; }
        public Order Order { get; set; }
        public long NewOrderId { get; set; }

        public OrderService(FoodTeamsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
            Orders = dbcontext.Orders.ToList();
        }

        public void CreateOrder(Order order)
        {   
            dbcontext.Orders.Add(order);
            dbcontext.SaveChanges();
            NewOrderId = order.Id;

        }

    }
}
