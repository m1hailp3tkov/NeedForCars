using NeedForCars.Models;

namespace NeedForCars.Services.Contracts
{
    public interface ICarsService
    {
        void Add(Car car);

        bool Exists(Car car, string generationName);

        Car GetById(string id);

        void Update(Car car);
    }
}
