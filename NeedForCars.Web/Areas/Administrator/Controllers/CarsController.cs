using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Models.Owned;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Areas.Administrator.ViewModels.Cars;
using NeedForCars.Web.Common;

namespace NeedForCars.Web.Areas.Administrator.Controllers
{
    public class CarsController : AdministratorController
    {
        private readonly ICarsService carsService;
        private readonly IEnginesService enginesService;
        private readonly IGenerationsService generationsService;
        private readonly IImagesService imagesService;

        public CarsController(ICarsService carsService, IEnginesService enginesService, 
            IGenerationsService generationsService, IImagesService imagesService)
        {
            this.carsService = carsService;
            this.enginesService = enginesService;
            this.generationsService = generationsService;
            this.imagesService = imagesService;
        }

        public IActionResult All(int id)
        {
            var generation = generationsService.GetById(id);
            if (generation == null)
            {
                return this.BadRequest();
            }

            SetUpViewBag(generation);

            var viewModel = generation.Cars
                .AsQueryable()
                .To<DisplayCarModel>()
                .OrderBy(x => x.BeginningOfProductionYear)
                .ThenBy(x => x.Engine.MaxHP)
                .ThenBy(x => x.Engine.Name);

            return View(viewModel);
        }

        public IActionResult Create(int id)
        {
            var generation = generationsService.GetById(id);
            if (generation == null)
            {
                return this.BadRequest();
            }

            SetUpViewBag(generation);

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarModel createCarModel, int id)
        {
            var generation = generationsService.GetById(id);
            var engine = enginesService.GetById(createCarModel.EngineId);

            if (generation == null)
            {
                return this.BadRequest();
            }

            var car = Mapper.Map<Car>(createCarModel);
            car.GenerationId = id;

            if (this.carsService.Exists(car))
            {
                this.ModelState.AddModelError("", GlobalConstants.CAR_ALREADY_EXISTS);
            }

            ValidateTireInfo(createCarModel.TireInfo);

            if (!this.ModelState.IsValid)
            {
                SetUpViewBag(generation);
                return this.View();
            }

            await carsService.AddAsync(car);

            return this.RedirectToAction(nameof(All), new { id });
        }

        public IActionResult Edit(int id)
        {
            var car = carsService.GetById(id);
            if (car == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<EditCarModel>(car);

            SetUpViewBag(car.Generation);

            this.ViewBag.Engine = $"{car.Engine.Name} ({car.Engine.MaxHP} HP)";

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarModel editCarModel, int id)
        {
            var car = carsService.GetById(editCarModel.Id);
            var engine = enginesService.GetById(editCarModel.EngineId);
            var generation = generationsService.GetById(editCarModel.GenerationId);

            if (generation == null || engine == null || car == null)
            {
                return this.BadRequest();
            }

            bool isChanged =
                   car.EngineId != editCarModel.EngineId
                || car.GenerationId != editCarModel.GenerationId
                || car.Transmission != editCarModel.Transmission
                || car.DriveWheel != editCarModel.DriveWheel
                || car.BeginningOfProductionYear != editCarModel.BeginningOfProductionYear
                || car.BeginningOfProductionMonth != editCarModel.BeginningOfProductionMonth
                || car.EndOfProductionYear != editCarModel.EndOfProductionYear
                || car.EndOfProductionMonth != editCarModel.EndOfProductionMonth;

            Mapper.Map(editCarModel, car);

            if (isChanged && carsService.Exists(car))
            {
                this.ModelState.AddModelError("", GlobalConstants.CAR_ALREADY_EXISTS);
            }

            ValidateTireInfo(editCarModel.TireInfo);

            if (!this.ModelState.IsValid)
            {
                SetUpViewBag(generation);
                this.ViewBag.Engine = $"{car.Engine.Name} ({car.Engine.MaxHP} HP)";
                return this.View();
            }

            await carsService.UpdateAsync(car);

            return this.RedirectToAction(nameof(All), new { car.Id });
        }

        public IActionResult Delete(int id)
        {
            var car = this.carsService.GetById(id);
            if(car == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<DeleteCarModel>(car);

            this.carsService.GetRelatedEntitiesCount(car, out int userCarsCount);
            viewModel.UserCarsCount = userCarsCount;

            SetUpViewBag(car.Generation);
            this.ViewBag.Engine = $"{car.Engine.Name} ({car.Engine.MaxHP} HP)";

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCarModel deleteCarModel)
        {
            var car = this.carsService.GetById(deleteCarModel.Id);

            await this.carsService.DeleteAsync(car);

            return this.RedirectToAction(nameof(All), new { Id = car.GenerationId });
        }

        private void SetUpViewBag(Generation generation)
        {
            this.ViewBag.Make = generation.Model.Make.Name;
            this.ViewBag.Model = generation.Model.Name;
            this.ViewBag.Generation = generation.Name;
            this.ViewBag.GenerationId = generation.Id;
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