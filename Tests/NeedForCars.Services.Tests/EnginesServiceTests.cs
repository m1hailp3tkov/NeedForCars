using Microsoft.EntityFrameworkCore;
using NeedForCars.Data;
using NeedForCars.Models;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NeedForCars.Services.Tests
{
    public class EnginesServiceTests
    {
        [Fact]
        public async Task AllShouldReturnEnginesCorrectly()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("AllEnginesDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var enginesService = new EnginesService(context);

            var engine1 = new Engine
            {
                Name = "Name1",
                FuelType = Models.Enums.FuelType.Diesel,
                MaxHP = 100,
                Creator = "Creator"
            };
            await context.AddAsync(engine1);
            var engine2 = new Engine
            {
                Name = "Name2",
                FuelType = Models.Enums.FuelType.Diesel,
                MaxHP = 100,
                Creator = "Creator"
            };
            await context.AddAsync(engine2);
            await context.SaveChangesAsync();

            var result = enginesService.All().Count();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task AddAsyncShouldAddEngine()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("AddEngineDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var enginesService = new EnginesService(context);

            var engine = new Engine
            {
                Name = "Name1",
                FuelType = Models.Enums.FuelType.Diesel,
                MaxHP = 100,
                Creator = "Creator"
            };

            await enginesService.AddAsync(engine);

            var result = await context.Engines.CountAsync();

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteEngine()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("DeleteEngineDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var enginesService = new EnginesService(context);

            var engine = new Engine
            {
                Name = "Name1",
                FuelType = Models.Enums.FuelType.Diesel,
                MaxHP = 100,
                Creator = "Creator"
            };

            await context.Engines.AddAsync(engine);
            await context.SaveChangesAsync();

            await enginesService.DeleteAsync(engine);

            var result = await context.Engines.CountAsync();

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task GetByIdShouldReturnCorrectEngine()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("GetEngineByIdDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var enginesService = new EnginesService(context);

            var engine = new Engine
            {
                Name = "Name1",
                FuelType = Models.Enums.FuelType.Diesel,
                MaxHP = 100,
                Creator = "Creator"
            };

            await context.Engines.AddAsync(engine);
            await context.SaveChangesAsync();

            var result = enginesService.GetById(engine.Id);

            Assert.Equal(engine.Id, result.Id);
        }

        [Fact]
        public async Task UpdateAsyncShouldUpdateEngine()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("UpdateEngineDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var enginesService = new EnginesService(context);

            var engine = new Engine
            {
                Name = "Name1",
                FuelType = Models.Enums.FuelType.Diesel,
                MaxHP = 100,
                Creator = "Creator"
            };

            await context.Engines.AddAsync(engine);
            await context.SaveChangesAsync();

            engine.Name = "newName";
            await enginesService.UpdateAsync(engine);

            var result = context.Engines.FirstOrDefault().Name;

            Assert.Equal("newName", result);
        }

        [Fact]
        public async Task GetRelatedEntitiesCountShouldReturnCorrectValues()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
               .UseInMemoryDatabase("RelatedEntitiesDb_engines")
               .Options;

            var context = new NeedForCarsDbContext(options);

            var enginesService = new EnginesService(context);

            var make = new Make
            {
                Name = "Make",
                Description = "Desc"
            };
            await context.Makes.AddAsync(make);

            var model = new Model
            {
                MakeId = make.Id,
                Name = "Model1",
            };
            await context.Models.AddAsync(model);

            var generation = new Generation
            {
                ModelId = model.Id,
                Name = "Model1"
            };
            await context.Generations.AddAsync(generation);

            var engine = new Engine
            {
                Name = "engine",
                MaxHP = 100,
                FuelType = Models.Enums.FuelType.Diesel,
                Creator = "creator"
            };
            await context.Engines.AddAsync(engine);

            var car = new Car
            {
                GenerationId = generation.Id,
                EngineId = engine.Id,
                Transmission = Models.Enums.Transmission.Automatic,
                DriveWheel = Models.Enums.DriveWheel.AllWheelDrive,
                BeginningOfProductionYear = 2000,
                BeginningOfProductionMonth = 1
            };
            await context.Cars.AddAsync(car);

            var user = new NeedForCarsUser
            {
                Email = "email@mail.com",
                UserName = "username",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567890"
            };
            await context.Users.AddAsync(user);

            var userCar = new UserCar
            {
                OwnerId = user.Id,
                CarId = car.Id,
                Color = "color",
                ProductionDateYear = 2000,
                ProductionDateMonth = 1,
                Mileage = 0
            };
            await context.UserCars.AddAsync(userCar);

            await context.SaveChangesAsync();

            enginesService.GetRelatedEntitiesCount(engine, out int cars, out int userCars);

            Assert.True(cars == 1 && userCars == 1);
        }
    }
}
