using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;

namespace NeedForCars.Services
{
    public class UserCarsService : IUserCarsService
    {
        private readonly NeedForCarsDbContext context;
        private readonly UserManager<NeedForCarsUser> userManager;

        public UserCarsService(NeedForCarsDbContext context, UserManager<NeedForCarsUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task AddAsync(UserCar userCar)
        {
            if (userCar == null) return;

            await this.context.UserCars.AddAsync(userCar);
            await this.context.SaveChangesAsync();
        }

        public UserCar GetById(string id)
        {
            return this.context.UserCars
                .FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<UserCar> GetAllForUser(string userId)
        {
            var userCars = this.context
                .UserCars
                .Where(x => x.OwnerId == userId)
                .AsQueryable();

            return userCars;
        }

        public async Task UpdateAsync(UserCar userCar)
        {
            this.context.Update(userCar);

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserCar userCar)
        {
            if (userCar == null) return;

            this.context.Remove(userCar);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAllForUser(string userId)
        {
            var userCars = this.context
                .UserCars
                .Where(x => x.OwnerId == userId);

            this.context.UserCars
                .RemoveRange(userCars);

            await this.context.SaveChangesAsync();
        }
    }
}
