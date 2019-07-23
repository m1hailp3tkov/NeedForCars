using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Services
{
    public class MakesService : IMakesService
    {
        private readonly NeedForCarsDbContext context;

        public MakesService(NeedForCarsDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Make make)
        {
            if (make == null) return;

            await this.context.Makes.AddAsync(make);
            await this.context.SaveChangesAsync();
        }

        public bool Exists(string makeName)
        {
            return this.context.Makes
                .Any(x => x.Name == makeName);
        }

        public IQueryable<Make> GetAll()
        {
            return this.context.Makes;
        }

        public Make GetById(string id)
        {
            return this.context
                .Makes
                .Include(x => x.Models)
                .FirstOrDefault(x => x.Id == id || x.Name == id);
        }

        public async Task UpdateAsync(Make make)
        {
            if (make == null) return;

            this.context.Makes.Update(make);

            await this.context.SaveChangesAsync();
        }
    }
}
