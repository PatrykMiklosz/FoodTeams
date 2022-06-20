using FoodTeams.Entities;

namespace FoodTeams.Services
{
    public class OrderService
    {
        private readonly FoodTeamsDbContext dbContext;
        public List<Order> Orders { get; set; }
        public Order Order { get; set; }
        public long NewOrderId { get; set; }

        public OrderService(FoodTeamsDbContext dbContext)
        {
            this.dbContext = dbContext;
            Orders = dbContext.Orders.ToList();
        }

        public void CreateOrder(Order order)
        {
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            NewOrderId = order.Id;
            Order = dbContext.Orders.FirstOrDefault(x => x.Id == NewOrderId);
        }
    }
}
