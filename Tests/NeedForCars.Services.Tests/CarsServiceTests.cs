using Microsoft.EntityFrameworkCore;
using NeedForCars.Data;
using NeedForCars.Models;
using System.Threading.Tasks;
using Xunit;

namespace NeedForCars.Services.Tests
{
    public class CarsServiceTests
    {
        [Fact]
        public async Task AddAsyncShouldCreateCar()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("CreateCarDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);
            var carsService = new CarsService(context, generationsService);

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

            var engine = new Engine
            {
                Name = "Name1",
                FuelType = Models.Enums.FuelType.Diesel,
                MaxHP = 100,
                Creator = "Creator"
            };

            await context.AddAsync(engine);
            await context.SaveChangesAsync();

            var car = new Car
            {
                GenerationId = generation.Id,
                EngineId = engine.Id,
                Transmission = Models.Enums.Transmission.Automatic,
                DriveWheel = Models.Enums.DriveWheel.AllWheelDrive,
                BeginningOfProductionYear = 2000,
                BeginningOfProductionMonth = 1
            };

            await carsService.AddAsync(car);

            var result = await context.Cars.CountAsync();

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task GetByIdShouldReturnCorrectCar()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("GetByIdCarDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);
            var carsService = new CarsService(context, generationsService);

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

            var engine = new Engine
            {
                Name = "Name1",
                FuelType = Models.Enums.FuelType.Diesel,
                MaxHP = 100,
                Creator = "Creator"
            };

            await context.Engines.AddAsync(engine);
            await context.SaveChangesAsync();

            var car = new Car
            {
                Name = "Name1",
                GenerationId = generation.Id,
                EngineId = engine.Id,
                Transmission = Models.Enums.Transmission.Automatic,
                DriveWheel = Models.Enums.DriveWheel.AllWheelDrive,
                BeginningOfProductionYear = 2000,
                BeginningOfProductionMonth = 1
            };

            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();

            var result = carsService.GetById(car.Id);

            Assert.Equal("Name1", result.Name);
        }

        [Fact]
        public async Task ExistsShouldReturnCorrectValue()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("ExistsCarDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);
            var carsService = new CarsService(context, generationsService);

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

            var engine = new Engine
            {
                Name = "Name1",
                FuelType = Models.Enums.FuelType.Diesel,
                MaxHP = 100,
                Creator = "Creator"
            };

            await context.Engines.AddAsync(engine);
            await context.SaveChangesAsync();

            var car = new Car
            {
                Name = "Name1",
                GenerationId = generation.Id,
                EngineId = engine.Id,
                Transmission = Models.Enums.Transmission.Automatic,
                DriveWheel = Models.Enums.DriveWheel.AllWheelDrive,
                BeginningOfProductionYear = 2000,
                BeginningOfProductionMonth = 1
            };
            var carThatExists = new Car
            {
                Name = "Name1",
                GenerationId = generation.Id,
                EngineId = engine.Id,
                Transmission = Models.Enums.Transmission.Automatic,
                DriveWheel = Models.Enums.DriveWheel.AllWheelDrive,
                BeginningOfProductionYear = 2000,
                BeginningOfProductionMonth = 1
            };
            var carThatDoesntExist = new Car
            {
                Name = "Name1",
                GenerationId = generation.Id,
                EngineId = engine.Id,
                Transmission = Models.Enums.Transmission.Manual,
                DriveWheel = Models.Enums.DriveWheel.AllWheelDrive,
                BeginningOfProductionYear = 2002,
                BeginningOfProductionMonth = 1
            };

            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();

            var carThatExistsValid = carsService.Exists(carThatExists);
            var carThatDoesntExistValid = !carsService.Exists(carThatDoesntExist);

            Assert.True(carThatExistsValid && carThatDoesntExistValid);
        }

        [Fact]
        public async Task UpdateAsyncShouldUpdateCar()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("UpdateCarDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);
            var carsService = new CarsService(context, generationsService);

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

            var engine = new Engine
            {
                Name = "Name1",
                FuelType = Models.Enums.FuelType.Diesel,
                MaxHP = 100,
                Creator = "Creator"
            };

            await context.AddAsync(engine);
            await context.SaveChangesAsync();

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
            await context.SaveChangesAsync();

            car.BeginningOfProductionYear = 2001;

            await carsService.UpdateAsync(car);

            var result = await context.Cars.FirstAsync();

            Assert.Equal(2001, result.BeginningOfProductionYear);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCar()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("DeleteCarDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);
            var carsService = new CarsService(context, generationsService);

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

            var engine = new Engine
            {
                Name = "Name1",
                FuelType = Models.Enums.FuelType.Diesel,
                MaxHP = 100,
                Creator = "Creator"
            };

            await context.AddAsync(engine);
            await context.SaveChangesAsync();

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
            await context.SaveChangesAsync();

            await carsService.DeleteAsync(car);

            var result = await context.Cars.CountAsync();

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task GetRelatedEntitiesCountShouldReturnCorrectValues()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
               .UseInMemoryDatabase("RelatedEntitiesDb_cars")
               .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);
            var carsService = new CarsService(context, generationsService);

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

            carsService.GetRelatedEntitiesCount(car, out int userCars);

            Assert.True(userCars == 1);
        }

        [Fact]
        public async Task GetAllForGenerationShouldReturnCorrectCars()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("GetAllCarsForGenerationDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var makesService = new MakesService(context);
            var modelsService = new ModelsService(context, makesService);
            var generationsService = new GenerationsService(context, modelsService);
            var carsService = new CarsService(context, generationsService);

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

            var engine = new Engine
            {
                Name = "Name1",
                FuelType = Models.Enums.FuelType.Diesel,
                MaxHP = 100,
                Creator = "Creator"
            };

            await context.AddAsync(engine);
            await context.SaveChangesAsync();

            var car1 = new Car
            {
                GenerationId = generation.Id,
                EngineId = engine.Id,
                Transmission = Models.Enums.Transmission.Automatic,
                DriveWheel = Models.Enums.DriveWheel.AllWheelDrive,
                BeginningOfProductionYear = 2000,
                BeginningOfProductionMonth = 1
            };
            var car2 = new Car
            {
                GenerationId = generation.Id,
                EngineId = engine.Id,
                Transmission = Models.Enums.Transmission.Manual,
                DriveWheel = Models.Enums.DriveWheel.AllWheelDrive,
                BeginningOfProductionYear = 1999,
                BeginningOfProductionMonth = 12
            };

            await context.Cars.AddAsync(car1);
            await context.Cars.AddAsync(car2);
            await context.SaveChangesAsync();

            var result = await carsService.GetAllForGeneration(generation.Id).CountAsync();

            Assert.Equal(2, result);
        }
    }
}
