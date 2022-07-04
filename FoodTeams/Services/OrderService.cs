using FoodTeams.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodTeams.Services
{
    public class OrderService
    {
        public readonly FoodTeamsDbContext dbContext;

        public OrderService(FoodTeamsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateOrder(Order order)
        {
            order.CreateDate = DateTime.Now;
            order.IsActive = true;
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }

        public void CompleteOrder(long id)
		{
            var order = GetOrderById(id);  
            order.IsActive = false;
            dbContext.SaveChanges();
		}

        public Order GetOrderById(long id)
        {
           return dbContext.Orders.Include(o => o.Dishes).FirstOrDefault(o => o.Id == id);
        }

        public Order GetOrderByDishId(long id)
		{
            var dish = dbContext.Dishes.FirstOrDefault(d => d.Id == id);
            var order = dbContext.Orders.Where(o => o.Dishes.Contains(dish)).FirstOrDefault();
            return order;
		}

        public void RestoreOrder(long id)
        {
            var order = GetOrderById(id);
            order.IsActive = true;
            dbContext.SaveChanges();
        }

        public void DeleteOrder(long id)
        {
            var order = GetOrderById(id);
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();
        }

        public void UpdateOrder(long id, string restaurantName, string menuLink, decimal minPrice, decimal deliveryPrice, decimal freeDeliveryPrice, long blikNumber)
        {
            var order = GetOrderById(id);
            order.RestaurantName = restaurantName;
            order.MenuLink = menuLink;
            order.MinPrice = minPrice;
            order.DeliveryPrice = deliveryPrice;
            order.FreeDeliveryPrice = freeDeliveryPrice;
            order.BLIKNumber = blikNumber;
            order.CreateDate = DateTime.Now;
            order.IsActive = true;
            dbContext.SaveChanges();
        }

        public int OrdersCount(bool status)
        {
            return dbContext.Orders.Where(x=>x.IsActive==status).Count();
        }

        public decimal GetReceipt(Order order)
        {
            decimal receipt = 0;
            foreach(var dish in order.Dishes)
            {
                receipt += dish.Price;
            }
            if (GetFreeDeliveryOrderPrice(order) == 0)
            {
                return receipt;
            }
            else receipt += order.DeliveryPrice;
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
