using System.Collections.Generic;

namespace FoodTeams.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }
        public string RestaurantName { get; set; }
        public string MenuLink { get; set; }
        public decimal MinPrice { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal FreeDeliveryPrice { get; set; }
        public long BLIKNumber { get; set; }

        public  virtual IEnumerable<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
