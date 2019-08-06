using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using NeedForCars.Data;
using NeedForCars.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NeedForCars.Services.Tests
{
    public class ModelsServiceTests
    {
        [Fact]
        public async Task AddAsyncShouldCreateModel()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("CreateModelDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);

            var make = new Make
            {
                Name = "Make",
                Description = "Desc"
            };

            await context.Makes.AddAsync(make);
            await context.SaveChangesAsync();

            var model = new Model
            {
                MakeId = make.Id,
                Name = "Model"
            };

            await modelsService.AddAsync(model);
            await context.SaveChangesAsync();

            var result = context.Models.Count();

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteModel()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("DeleteModelDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);

            var make = new Make
            {
                Name = "Make",
                Description = "Desc"
            };

            await context.Makes.AddAsync(make);
            await context.SaveChangesAsync();

            var model = new Model
            {
                MakeId = make.Id,
                Name = "Model"
            };

            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();

            await modelsService.DeleteAsync(model);
            await context.SaveChangesAsync();

            var result = await context.Models.CountAsync();

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("Model1", true)]
        [InlineData("nonexistent", false)]
        public async Task ExistsShouldReturnCorrectValue(string modelName, bool expected)
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
               .UseInMemoryDatabase("ModelExistsDb")
               .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);

            var make = new Make
            {
                Name = "Make",
                Description = "Desc"
            };

            await context.Makes.AddAsync(make);
            await context.SaveChangesAsync();

            var model = new Model
            {
                Name = "Model1",
                Description = "Desc",
                MakeId = make.Id
            };

            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();

            var result = modelsService.Exists(make.Id, modelName);

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetAllForMakeShouldReturnAllModelsForMake()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
               .UseInMemoryDatabase("ModelGetAllDb")
               .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);

            var make = new Make
            {
                Name = "Make",
                Description = "Desc"
            };

            await context.Makes.AddAsync(make);
            await context.SaveChangesAsync();

            var model1 = new Model
            {
                Name = "Model1",
                Description = "Desc",
                MakeId = make.Id
            };
            var model2 = new Model
            {
                Name = "Model2",
                Description = "Desc",
                MakeId = make.Id
            };

            await context.Models.AddAsync(model1);
            await context.Models.AddAsync(model2);
            await context.SaveChangesAsync();

            var result = modelsService.GetAllForMake(make.Id).Count();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetByIdShouldReturnCorrectModel()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
               .UseInMemoryDatabase("ModelGetByIdDb")
               .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);

            var make = new Make
            {
                Name = "Make",
                Description = "Desc"
            };

            await context.Makes.AddAsync(make);
            await context.SaveChangesAsync();

            var model1 = new Model
            {
                Name = "Model1",
                Description = "Desc",
                MakeId = make.Id
            };

            await context.Models.AddAsync(model1);
            await context.SaveChangesAsync();

            var result = modelsService.GetById(model1.Id);

            Assert.Equal("Model1", result.Name);
        }

        [Fact]
        public async Task GetRelatedEntitiesCountShouldReturnCorrectValues()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
               .UseInMemoryDatabase("RelatedEntitiesDb_models")
               .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);

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

            modelsService.GetRelatedEntitiesCount(model, out int generations, out int cars, out int userCars);

            Assert.True(generations == 1 && cars == 1 && userCars == 1);
        }

        [Fact]
        public async Task UpdateAsyncCorrectlyUpdatesEntity()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("UpdateModelDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);

            var make = new Make
            {
                Name = "Make",
                Description = "Desc"
            };
            await context.Makes.AddAsync(make);
            await context.SaveChangesAsync();

            var model = new Model
            {
                Name = "Model1",
                Description = "Desc",
                MakeId = make.Id
            };
            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();

            model.Name = "newName";

            await modelsService.UpdateAsync(model);
            await context.SaveChangesAsync();

            var result = context.Models
                .FirstAsync().Result
                .Name;

            Assert.Equal("newName", result);
        }
    }
}
