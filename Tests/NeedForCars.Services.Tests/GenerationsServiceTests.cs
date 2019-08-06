using Microsoft.EntityFrameworkCore;
using NeedForCars.Data;
using NeedForCars.Models;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NeedForCars.Services.Tests
{
    public class GenerationsServiceTests
    {
        [Fact]
        public async Task AddAsyncShouldCreateGeneration()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("CreateGenerationDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);

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

            var generation = new Generation
            {
                ModelId = model.Id,
                BodyType = Models.Enums.BodyType.Convertible,
                Name = "Name",
                Seats = 5,
                Description = "Desc"
            };

            await generationsService.AddAsync(generation);
            var result = await context.Generations.CountAsync();

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteGeneration()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("DeleteGenerationDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);

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

            var generation = new Generation
            {
                ModelId = model.Id,
                BodyType = Models.Enums.BodyType.Convertible,
                Name = "Name",
                Seats = 5,
                Description = "Desc"
            };
            await context.Generations.AddAsync(generation);
            await context.SaveChangesAsync();

            await generationsService.DeleteAsync(generation);
            var result = await context.Generations.CountAsync();

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("Generation", true)]
        [InlineData("nonexistent", false)]
        public async Task ExistsShouldReturnCorrectValue(string generationName, bool expected)
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("ExistsGenerationDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);

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

            var generation = new Generation
            {
                ModelId = model.Id,
                BodyType = Models.Enums.BodyType.Convertible,
                Name = "Generation",
                Seats = 5,
                Description = "Desc"
            };
            await context.Generations.AddAsync(generation);
            await context.SaveChangesAsync();

            var result = generationsService.Exists(model.Id, generationName);
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetAllForModelShouldReturnAllGenerationsForModel()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("GetAllForModelGenerationDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);

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

            var generation1 = new Generation
            {
                ModelId = model.Id,
                BodyType = Models.Enums.BodyType.Convertible,
                Name = "Name",
                Seats = 5,
                Description = "Desc"
            };
            var generation2 = new Generation
            {
                ModelId = model.Id,
                BodyType = Models.Enums.BodyType.Convertible,
                Name = "Name2",
                Seats = 5,
                Description = "Desc"
            };
            await context.Generations.AddAsync(generation1);
            await context.Generations.AddAsync(generation2);
            await context.SaveChangesAsync();

            var result = generationsService.GetAllForModel(model.Id).Count();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetByIdShouldReturnCorrectGeneration()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("GetByIdGenerationDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);

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

            var generation = new Generation
            {
                ModelId = model.Id,
                BodyType = Models.Enums.BodyType.Convertible,
                Name = "Name",
                Seats = 5,
                Description = "Desc"
            };
            await context.Generations.AddAsync(generation);
            await context.SaveChangesAsync();

            var result = generationsService.GetById(generation.Id);

            Assert.Equal("Name", result.Name);
        }

        [Fact]
        public async Task GetRelatedEntitiesCountShouldReturnCorrectValues()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
               .UseInMemoryDatabase("RelatedEntitiesDb_generations")
               .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);

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

            generationsService.GetRelatedEntitiesCount(generation, out int cars, out int userCars);

            Assert.True(cars == 1 && userCars == 1);
        }

        [Fact]
        public async Task UpdateAsyncShouldCorrectlyUpdateGeneration()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("UpdateGenerationDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);

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

            var generation = new Generation
            {
                ModelId = model.Id,
                BodyType = Models.Enums.BodyType.Convertible,
                Name = "Name",
                Seats = 5,
                Description = "Desc"
            };
            await context.Generations.AddAsync(generation);
            await context.SaveChangesAsync();

            generation.Name = "updated";
            await generationsService.UpdateAsync(generation);

            var result = context.Generations.FirstAsync()
                .Result;

            Assert.Equal("updated", result.Name);
        }
    }
}
