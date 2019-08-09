using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.ViewModels.Cars;
using NeedForCars.Web.ViewModels.UserCars;
using X.PagedList;

namespace NeedForCars.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly IUserCarsService userCarsService;

        public CarsController(IUserCarsService userCarsService)
        {
            this.userCarsService = userCarsService;
        }

        public IActionResult Browse(int? page, SearchViewModel searchViewModel)
        {
            var filteredCars = GetUserCarsFiltered(searchViewModel);

            var orderedCars = OrderUserCars(filteredCars, searchViewModel);

            int pageNumber = (page ?? 1);

            var viewModel = orderedCars
                .To<DisplayUserCarModel>()
                .ToPagedList(pageNumber, 10);

            return View(viewModel);
        }

        public IActionResult Details(string id)
        {
            var userCar = userCarsService.GetById(id);

            if(!userCar.IsPublic)
            {
                return this.Forbid();
            }

            var viewModel = Mapper.Map<CarDetailsViewModel>(userCar);

            return this.View(viewModel);
        }

        public IActionResult Search()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel searchViewModel)
        {
            return this.RedirectToAction(nameof(Browse), searchViewModel);
        }

        private IQueryable<UserCar> GetUserCarsFiltered(SearchViewModel model)
        {
            var userCars = this.userCarsService.GetAllForSale();

            if (model.MakeId != null) userCars = userCars.Where(x => x.Car.Generation.Model.MakeId == model.MakeId);

            if (model.ModelId != null) userCars = userCars.Where(x => x.Car.Generation.ModelId == model.ModelId);

            if (model.GenerationId != null) userCars = userCars.Where(x => x.Car.GenerationId == model.GenerationId);

            if (model.CarId != null) userCars = userCars.Where(x => x.CarId == model.CarId);

            if (model.MileageFrom != null) userCars = userCars.Where(x => x.Mileage >= model.MileageFrom);
            if (model.MileageTo != null) userCars = userCars.Where(x => x.Mileage <= model.MileageTo);

            if (model.PriceFrom != null) userCars = userCars.Where(x => x.Price >= model.PriceFrom);
            if (model.PriceTo != null) userCars = userCars.Where(x => x.Price <= model.PriceTo);
            if (model.Currency != null) userCars = userCars.Where(x => x.Currency == model.Currency);

            if (model.YearOfProductionFrom != null) userCars = userCars.Where(x => x.ProductionDateYear >= model.YearOfProductionFrom);
            if (model.YearOfProductionTo != null) userCars = userCars.Where(x => x.ProductionDateYear <= model.YearOfProductionTo);

            if (model.FuelType != null) userCars = userCars.Where(x => x.Car.Engine.FuelType == model.FuelType);

            if (model.MinHP != null) userCars = userCars.Where(x => x.CustomMaxHP >= model.MinHP || x.Car.Engine.MaxHP >= model.MinHP);
            if (model.MaxHP != null) userCars = userCars.Where(x => x.CustomMaxHP <= model.MaxHP || x.Car.Engine.MaxHP <= model.MaxHP);

            if (model.Transmission != null) userCars = userCars.Where(x => x.Car.Transmission == model.Transmission);

            if (model.AlternativeFuel != null) userCars = userCars.Where(x => x.AlternativeFuel == model.AlternativeFuel);

            if (model.DriveWheel != null) userCars = userCars.Where(x => x.Car.DriveWheel == model.DriveWheel);

            return userCars;
        }

        private IQueryable<UserCar> OrderUserCars(IQueryable<UserCar> userCars, SearchViewModel model)
        {
            switch (model.Ordering)
            {
                case Ordering.Latest:
                    if (model.OrderingType == OrderingType.Ascending)
                        userCars = userCars.OrderBy(x => x.CreatedOn);
                    else
                        userCars = userCars.OrderByDescending(x => x.CreatedOn);
                    break;

                case Ordering.Mileage:
                    if (model.OrderingType == OrderingType.Ascending)
                        userCars = userCars.OrderBy(x => x.Mileage);
                    else
                        userCars = userCars.OrderByDescending(x => x.Mileage);
                    break;

                case Ordering.Price:
                    if (model.OrderingType == OrderingType.Ascending)
                        userCars = userCars.OrderBy(x => x.Price);
                    else
                        userCars = userCars.OrderByDescending(x => x.Price);
                    break;

                case Ordering.Production:
                    if (model.OrderingType == OrderingType.Ascending)
                        userCars = userCars.OrderBy(x => new DateTime(x.ProductionDateYear, x.ProductionDateMonth, 1));
                    else
                        userCars = userCars.OrderByDescending(x => new DateTime(x.ProductionDateYear, x.ProductionDateMonth, 1));
                    break;
            }

            return userCars;
        }
    }
}