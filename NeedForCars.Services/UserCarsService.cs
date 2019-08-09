using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;

namespace NeedForCars.Services
{
    public class UserCarsService : IUserCarsService
    {
        private readonly NeedForCarsDbContext context;

        public UserCarsService(NeedForCarsDbContext context)
        {
            this.context = context;
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
                .Include(x => x.Owner)
                .Include(x => x.Car)
                .ThenInclude(x => x.Generation)
                .ThenInclude(x => x.Model)
                .ThenInclude(x => x.Make)
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

        public IQueryable<UserCar> GetAllPublic()
        {
            var userCars = this.context
                .UserCars
                .Where(x => x.IsPublic);

            return userCars;
        }

        public IQueryable<UserCar> GetAllForSale()
        {
            var userCars = this.context.UserCars
                .Where(x => x.ForSale);

            return userCars;
        }
    }
}
