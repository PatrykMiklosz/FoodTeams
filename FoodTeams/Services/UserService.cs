using FoodTeams.Entities;
using System.Linq;

namespace FoodTeams.Services

{
    public class UserService
    {
		private readonly FoodTeamsDbContext dbContext;

		public UserService(FoodTeamsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

        public User GetUserByEmail(string email)
		{
			var user = dbContext.Users.Where(u=>u.Email==email).FirstOrDefault();
			return user;
		}

		public string GetUserEmailByUserId(long id)
		{
			var user = dbContext.Users.FirstOrDefault(u => u.Id == id);
			return user.Email;
		}
    }
}
