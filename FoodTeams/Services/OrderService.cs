using FoodTeams.Entities;

namespace FoodTeams.Services
{
    public class OrderService
    {
        public readonly FoodTeamsDbContext dbContext;
        public Order Order { get; set; }

        public OrderService(FoodTeamsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateOrder(Order order)
        {
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            Order = dbContext.Orders.FirstOrDefault(x => x.Id == order.Id);
        }

        public void CompleteOrder(long id)
		{
            var order = dbContext.Orders.FirstOrDefault(x => x.Id == id);  
            order.IsActive = false;
            dbContext.SaveChanges();
		}

        public void GetOrder(long id)
        {
           Order = dbContext.Orders.FirstOrDefault(x => x.Id == id);
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
        }

        public void UpdateOrder(string restaurantName, string menuLink, decimal minPrice, decimal deliveryPrice, decimal freeDeliveryPrice, long blikNumber)
        {
            Order.RestaurantName = restaurantName;
            Order.MenuLink = menuLink;
            Order.MinPrice = minPrice;
            Order.DeliveryPrice = deliveryPrice;
            Order.FreeDeliveryPrice = freeDeliveryPrice;
            Order.BLIKNumber = blikNumber;
            Order.CreateDate = DateTime.Now;
            Order.IsActive = true;
            dbContext.SaveChanges();
        }

        public int OrdersCount(bool status)
        {
            return dbContext.Orders.Where(x=>x.IsActive==status).Count();
        }

        public decimal GetReceipt(Order order)
        {
            decimal receipt = 0;
            foreach(var dish in Order.Dishes)
            {
                receipt += dish.Price;
            }
            return receipt;
        }

        public decimal GetMinimalOrderPrice(Order order)
		{
            decimal orderCost = 0;
            foreach (var dish in order.Dishes)
            {
                orderCost += dish.Price;
            }
            if(orderCost-order.MinPrice>=0)
			{
                return 0;
			}
            return order.MinPrice-orderCost;
        }

        public decimal GetFreeDeliveryOrderPrice(Order order)
		{
            decimal orderCost = 0;
            foreach (var dish in order.Dishes)
            {
                orderCost += dish.Price;
            }
            if (orderCost - order.FreeDeliveryPrice >= 0)
            {
                return 0;
            }
            return order.FreeDeliveryPrice-orderCost;
        }

        public decimal GetOrderCost(Order order)
		{
            decimal cost = 0;
            foreach (var dish in order.Dishes)
            {
                cost += dish.Price;
            }
            if(GetFreeDeliveryOrderPrice(order) == 0)
			{
                return cost;
			}
            return cost + order.DeliveryPrice;
        }

        public IEnumerable<Order> GetOrdersByStatus(bool status)
        {
            return dbContext.Orders.Where(o => o.IsActive == status).OrderByDescending(o => o.Id);
        }
    }
}
