namespace FoodTeams.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string ObjectId { get; set; }
        public string DomainId { get; set; }
        public long OrganizationId { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
