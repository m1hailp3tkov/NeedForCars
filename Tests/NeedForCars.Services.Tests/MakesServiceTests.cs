using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using NeedForCars.Data;
using NeedForCars.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NeedForCars.Services.Tests
{
    public class MakesServiceTests
    {
        private Make make1 = new Make
        {
            Name = "Make1",
            Description = "Desc"
        };
        private Make make2 = new Make
        {
            Name = "Make2",
            Description = "Desc"
        };

        [Fact]
        public async Task AddAsyncShouldCreateMake()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("CreateMakeDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);

            await makesService.AddAsync(make1);

            var makesCount = await context.Makes.CountAsync();

            Assert.Equal(1, makesCount);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteMake()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("DeleteMakeDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);

            await context.Makes.AddAsync(make1);
            await context.Makes.AddAsync(make2);

            await makesService.DeleteAsync(make1);

            var makesCount = await context.Makes.CountAsync();

            Assert.Equal(1, makesCount);
        }

        [Theory]
        [InlineData("Make1", true)]
        [InlineData("nonexistent", false)]
        public async Task ExistsShouldReturnCorrectValue(string makeName, bool expected)
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
               .UseInMemoryDatabase("ExistsDb")
               .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);

            await context.Makes.AddAsync(make1);
            await context.Makes.AddAsync(make2);
            await context.SaveChangesAsync();

            var result = makesService.Exists(makeName);

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetAllShouldReturnAllMakes()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
               .UseInMemoryDatabase("GetAllDb")
               .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);

            await context.Makes.AddAsync(make1);
            await context.Makes.AddAsync(make2);
            await context.SaveChangesAsync();

            var result = await makesService.GetAll().CountAsync();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetByIdShouldReturnCorrectMake()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
               .UseInMemoryDatabase("GetByIdDb")
               .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);

            await context.Makes.AddAsync(make1);
            await context.SaveChangesAsync();

            var result = makesService.GetById(make1.Id);

            Assert.Equal(make1.Name, result.Name);
        }

        [Fact]
        public async Task GetRelatedEntitiesCountShouldReturnCorrectValues()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
               .UseInMemoryDatabase("RelatedEntitiesDb_makes")
               .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);

            await context.Makes.AddAsync(make1);

            var model = new Model
            {
                MakeId = make1.Id,
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

            makesService.GetRelatedEntitiesCount(make1, out int models, out int generations, out int cars, out int userCars);

            Assert.True(models == 1 && generations == 1 && cars == 1 && userCars == 1);
        }

        [Fact]
        public async Task UpdateAsyncCorrectlyUpdatesEntity()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("CreateMakeDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);

            await context.Makes.AddAsync(make1);
            await context.SaveChangesAsync();

            var make = make1;
            make.Name = "newName";

            await makesService.UpdateAsync(make);
            await context.SaveChangesAsync();

            var result = context.Makes
                .FirstAsync().Result
                .Name;

            Assert.Equal("newName", result);
        }
    }
}
