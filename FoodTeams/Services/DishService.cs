using FoodTeams.Entities;
using FoodTeams.Services;

namespace FoodTeams.Services
{
    public class DishService
    {
        private readonly FoodTeamsDbContext dbContext;
        private readonly OrderService orderService;
        public IEnumerable<Dish> dishes = new List<Dish>();

        public DishService(FoodTeamsDbContext dbContext, OrderService orderService)
        {
            this.dbContext = dbContext;
            this.orderService = orderService;
        }
        public void GetDishes(long id)
        {
            var dishes = dbContext.Dishes.ToList().Where(x => x.OrderId == id);
            this.dishes = dishes;
            orderService.Order = dbContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void CreateDish(long id, string description, string extras, decimal price, long userId)
        {
            var dish = new Dish();
            dish.OrderId = id;
            dish.Description = description;
            dish.Extras = extras;
            dish.Price = price;
            dish.UserId = userId;
            dbContext.Add(dish);
            dbContext.SaveChanges();
        }
    }
}
