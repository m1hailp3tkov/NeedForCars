using NeedForCars.Models;
using System.Collections;
using System.Collections.Generic;

namespace NeedForCars.Services.Contracts
{
    public interface IMakesService
    {
        void Add(Make make);

        bool Exists(Make make);

        ICollection<Make> GetAll();
    }
}
