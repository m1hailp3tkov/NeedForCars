using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Models.Owned;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Areas.Administrator.ViewModels.Cars;

namespace NeedForCars.Web.Areas.Administrator.Controllers
{
    public class CarsController : AdministratorController
    {
        private readonly ICarsService carsService;
        private readonly IEnginesService enginesService;
        private readonly IGenerationsService generationsService;

        public CarsController(ICarsService carsService, IEnginesService enginesService, IGenerationsService generationsService)
        {
            this.carsService = carsService;
            this.enginesService = enginesService;
            this.generationsService = generationsService;
        }

        public IActionResult All(string id)
        {
            var generation = generationsService.GetById(id);
            if (generation == null)
            {
                return this.BadRequest();
            }

            this.ViewBag.Make = generation.Model.Make.Name;
            this.ViewBag.Model = generation.Model.Name;
            this.ViewBag.Generation = generation.Name;
            this.ViewBag.GenerationId = generation.Id;

            var viewModel = generation.Cars
                .AsQueryable()
                .To<DisplayCarModel>();

            return View(viewModel);
        }

        public IActionResult Create(string id)
        {
            var generation = generationsService.GetById(id);
            if (generation == null)
            {
                return this.BadRequest();
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCarModel createCarModel, string id)
        {
            var generation = generationsService.GetById(id);
            var engine = enginesService.GetById(createCarModel.EngineId);

            if (generation == null || engine == null)
            {
                return this.BadRequest();
            }
            //TODO: extract First car Year to global constants
            //TODO: extract model error messages to global constants
            if (createCarModel.BeginningOfProduction.Year < 1886)
            {
                this.ModelState.AddModelError(nameof(createCarModel.BeginningOfProduction), "Cars didn't exist back then.");
            }
            if (createCarModel.EndOfProduction > DateTime.UtcNow || createCarModel.EndOfProduction < createCarModel.BeginningOfProduction)
            {
                this.ModelState.AddModelError(nameof(createCarModel.EndOfProduction),
                    "Invalid date.");
            }

            var car = Mapper.Map<Car>(createCarModel);
            car.GenerationId = id;

            if (this.carsService.Exists(car))
            {
                this.ModelState.AddModelError("", "A car like that already exists");
            }

            ValidateTireInfo(createCarModel.TireInfo);

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.carsService.Add(car);

            return this.RedirectToAction(nameof(All), new { id });
        }

        public IActionResult Details(string id)
        {
            var car = carsService.GetById(id);
            if (car == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<CarDetailsModel>(car);
            return this.View(viewModel);
        }

        public IActionResult Edit(string id)
        {
            var car = carsService.GetById(id);
            if (car == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<EditCarModel>(car);

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCarModel editCarModel)
        {
            var car = carsService.GetById(editCarModel.Id);
            var engine = enginesService.GetById(editCarModel.EngineId);
            var generation = generationsService.GetById(editCarModel.GenerationId);

            if (generation == null || engine == null || car == null)
            {
                return this.BadRequest();
            }
            if (editCarModel.BeginningOfProduction.Year < 1886)
            {
                this.ModelState.AddModelError(nameof(editCarModel.BeginningOfProduction), "Cars didn't exist back then.");
            }
            if (editCarModel.EndOfProduction > DateTime.UtcNow || editCarModel.EndOfProduction<editCarModel.BeginningOfProduction)
            {
                this.ModelState.AddModelError(nameof(editCarModel.EndOfProduction),
                    "Invalid date.");
            }

            bool isChanged =
                   car.EngineId != editCarModel.EngineId
                || car.GenerationId != editCarModel.GenerationId
                || car.Transmission != editCarModel.Transmission
                || car.DriveWheel != editCarModel.DriveWheel
                || car.BeginningOfProduction != editCarModel.BeginningOfProduction
                || car.EndOfProduction != editCarModel.EndOfProduction;

            Mapper.Map(editCarModel, car);

            if (isChanged && carsService.Exists(car))
            {
                this.ModelState.AddModelError("", "A car like that already exists");
            }

            ValidateTireInfo(editCarModel.TireInfo);
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            carsService.Update(car);

            this.TempData.Clear();
            return this.RedirectToAction(nameof(Details), new { car.Id });
        }

        private void ValidateTireInfo(TireInfo tireInfo)
        {
            if (tireInfo.WheelDiameter == 0 &&
                   tireInfo.AspectRatio == 0 &&
                   tireInfo.TireWidth == 0)
            {
                this.ModelState.Remove($"{typeof(TireInfo).Name}.{nameof(tireInfo.WheelDiameter)}");
                this.ModelState.Remove($"{typeof(TireInfo).Name}.{nameof(tireInfo.AspectRatio)}");
                this.ModelState.Remove($"{typeof(TireInfo).Name}.{nameof(tireInfo.TireWidth)}");
            }
        }
    }
}