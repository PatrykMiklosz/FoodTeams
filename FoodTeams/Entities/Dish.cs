namespace FoodTeams.Entities
{
    public class Dish
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Extras { get; set; }
        public decimal Price { get; set; }
        public long OrderId { get; set; }
        public long UserId { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
