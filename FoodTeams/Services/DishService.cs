using FoodTeams.Entities;
using FoodTeams.Services;

namespace FoodTeams.Services
{
    public class DishService
    {
        private readonly FoodTeamsDbContext dbContext;
        private readonly OrderService orderService;
        public Dish dish = new Dish();

        public DishService(FoodTeamsDbContext dbContext, OrderService orderService)
        {
            this.dbContext = dbContext;
            this.orderService = orderService;
        }

        public Dish GetDishById(long id)
        {
            return dbContext.Dishes.FirstOrDefault(x => x.Id == id);
        }

        public void CreateDish(long id, string description, string extras, decimal price, long userId)
        {
            var dish = new Dish
            {
                OrderId = id,
                Description = description,
                Extras = extras,
                Price = price,
                UserId = userId
            };
            dbContext.Add(dish);
            dbContext.SaveChanges();
        }

        public void DeleteDish(long id)
        {
            dbContext.Remove(GetDishById(id));
            dbContext.SaveChanges();
        }

        public void EditDish(long dishId, string description, string extras, decimal price, long userId)
        {
            GetDishById(dishId).Description=description;
            GetDishById(dishId).Extras = extras;
            GetDishById(dishId).Price = price;
            GetDishById(dishId).UserId = userId;
            dbContext.SaveChanges();
        }

        public IEnumerable<Dish> GetOrderDishes(long id)
        {
            var order = dbContext.Orders.FirstOrDefault(o => o.Id == id);
            return dbContext.Dishes.Where(d => d.OrderId == id);
        }
    }
}
