using NeedForCars.Models;
using System.Linq;

namespace NeedForCars.Services.Contracts
{
    public interface IMakesService
    {
        void Add(Make make);

        bool Exists(string makeName);

        IQueryable<Make> GetAll();

        Make GetById(string id);

        void Update(Make make);
    }
}
