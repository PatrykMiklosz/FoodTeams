using FoodTeams.Entities;

namespace FoodTeams.Services
{
    public class OrderService
    {
        private readonly FoodTeamsDbContext dbContext;
        public List<Order> Orders { get; set; }
        public Order Order { get; set; }
        public long NewOrderId { get; set; }
        public int ActiveOrders { get; set; }
        public int OrderHistory { get; set; }

        public OrderService(FoodTeamsDbContext dbContext)
        {
            this.dbContext = dbContext;
            Orders = dbContext.Orders.ToList();
        }

        public void CreateOrder(Order order)
        {
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            Orders.Add(order);
            NewOrderId = order.Id;
            Order = dbContext.Orders.FirstOrDefault(x => x.Id == NewOrderId);
        }

        public void CompleteOrder(long id)
		{
            var order = dbContext.Orders.FirstOrDefault(x => x.Id == id);  
            order.IsActive = false;
            dbContext.SaveChanges();
		}

        public void GetOrder(long id)
        {
            this.Order = dbContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void RestoreOrder(long id)
        {
            var order = dbContext.Orders.FirstOrDefault(x => x.Id == id);
            order.IsActive = true;
            dbContext.SaveChanges();
        }

        public void DeleteOrder(long id)
        {
            var order = dbContext.Orders.FirstOrDefault(x => x.Id == id);
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();
            Orders.Remove(order);
        }

        public void EditOrder(long id)
        {
            var order = dbContext.Orders.FirstOrDefault(x => x.Id == id);
            Order = order;
        }

        public void UpdateOrder(Order order)
        {
            Order.RestaurantName = order.RestaurantName;
            Order.MenuLink = order.MenuLink;
            Order.MinPrice = order.MinPrice;
            Order.DeliveryPrice = order.DeliveryPrice;
            Order.FreeDeliveryPrice = order.FreeDeliveryPrice;
            Order.BLIKNumber = order.BLIKNumber;
            Order.CreateDate = DateTime.Now;
            Order.IsActive = true;
            dbContext.SaveChanges();
        }

        public int ActiveOrdersCount()
        {
            return dbContext.Orders.Where(x=>x.IsActive==true).Count();
        }

        public int OrdersCount()
        {
            return dbContext.Orders.Where(x => x.IsActive == false).Count();
        }
    }
}
