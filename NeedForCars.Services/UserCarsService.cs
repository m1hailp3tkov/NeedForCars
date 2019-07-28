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

        public void Delete(UserCar userCar)
        {
            if (userCar == null) return;
        }

        public async Task<IQueryable<UserCar>> GetAllForUser(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            return user.UserCars.AsQueryable();
        }

        public UserCar GetById(string id)
        {
            return this.context.UserCars
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(UserCar userCar)
        {
            this.context.Update(userCar);

            await this.context.SaveChangesAsync();
        }
    }
}
