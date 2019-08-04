using NeedForCars.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface IUserCarsService
    {
        Task AddAsync(UserCar userCar);

        UserCar GetById(string id);

        Task UpdateAsync(UserCar userCar);

        IQueryable<UserCar> GetAllForUser(string userId);

        Task DeleteAsync(UserCar userCar);

        Task DeleteAllForUser(string userId);

        IQueryable<UserCar> GetAllPublic();
    }
}
