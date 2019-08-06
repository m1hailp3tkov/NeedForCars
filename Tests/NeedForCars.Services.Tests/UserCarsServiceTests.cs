using Microsoft.EntityFrameworkCore;
using NeedForCars.Data;
using NeedForCars.Models;
using System.Threading.Tasks;
using Xunit;

namespace NeedForCars.Services.Tests
{
    public class UserCarsServiceTests
    {
        [Fact]
        public async Task AddAsyncShouldCreateUserCar()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("CreateUserCarDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var userCarsService = new UserCarsService(context);

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
            await context.SaveChangesAsync();

            var userCar = new UserCar
            {
                OwnerId = user.Id,
                CarId = car.Id,
                Color = "color",
                ProductionDateYear = 2000,
                ProductionDateMonth = 1,
                Mileage = 0
            };

            await userCarsService.AddAsync(userCar);

            var result = await context.UserCars.CountAsync();

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task GetByIdShouldReturnCorrectCar()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("GetByIdUserCarDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var userCarsService = new UserCarsService(context);

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
            await context.SaveChangesAsync();

            var userCar = new UserCar
            {
                Description = "123",
                OwnerId = user.Id,
                CarId = car.Id,
                Color = "color",
                ProductionDateYear = 2000,
                ProductionDateMonth = 1,
                Mileage = 0
            };

            await context.UserCars.AddAsync(userCar);
            await context.SaveChangesAsync();

            var result = userCarsService.GetById(userCar.Id);

            Assert.Equal("123", result.Description);
        }

        [Fact]
        public async Task GetAllForUserShouldReturnCorrectUserCars()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("GetAllForUserUserCarDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var userCarsService = new UserCarsService(context);

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
            await context.SaveChangesAsync();

            var userCar1 = new UserCar
            {
                Description = "123",
                OwnerId = user.Id,
                CarId = car.Id,
                Color = "color",
                ProductionDateYear = 2000,
                ProductionDateMonth = 1,
                Mileage = 0
            };

            var userCar2 = new UserCar
            {
                Description = "12345",
                OwnerId = user.Id,
                CarId = car.Id,
                Color = "color",
                ProductionDateYear = 2002,
                ProductionDateMonth = 1,
                Mileage = 0
            };

            await context.UserCars.AddAsync(userCar1);
            await context.UserCars.AddAsync(userCar2);
            await context.SaveChangesAsync();

            var result = await userCarsService.GetAllForUser(user.Id).CountAsync();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task UpdateAsyncShouldUpdateUserCar()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("UpdateUserCarDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var userCarsService = new UserCarsService(context);

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
            await context.SaveChangesAsync();

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

            userCar.ProductionDateYear = 2002;

            await userCarsService.UpdateAsync(userCar);

            var result = await context.UserCars.FirstAsync();

            Assert.Equal(2002, result.ProductionDateYear);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteUserCar()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("DeleteUserCarDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var userCarsService = new UserCarsService(context);

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
            await context.SaveChangesAsync();

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

            await userCarsService.DeleteAsync(userCar);

            var result = await context.UserCars.CountAsync();

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task GetAllPublicShouldOnlyReturnPublicUserCars()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("GetAllPublicUserCarDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var userCarsService = new UserCarsService(context);

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
            await context.SaveChangesAsync();

            var userCar1 = new UserCar
            {
                OwnerId = user.Id,
                CarId = car.Id,
                Color = "color",
                ProductionDateYear = 2000,
                ProductionDateMonth = 1,
                Mileage = 0,
                IsPublic = true
            };
            var userCar2 = new UserCar
            {
                OwnerId = user.Id,
                CarId = car.Id,
                Color = "color",
                ProductionDateYear = 2000,
                ProductionDateMonth = 1,
                Mileage = 0,
                IsPublic = false
            };

            await context.UserCars.AddAsync(userCar1);
            await context.UserCars.AddAsync(userCar2);
            await context.SaveChangesAsync();

            var result = await userCarsService.GetAllPublic().CountAsync();

            Assert.Equal(1, result);
        }
    }
}
