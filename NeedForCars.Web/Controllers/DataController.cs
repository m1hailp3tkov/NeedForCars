using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Areas.Administrator.ViewModels.Makes;
using NeedForCars.Web.Common;
using NeedForCars.Web.ViewModels.Data;

namespace NeedForCars.Web.Controllers
{
    public class DataController : Controller
    {
        private readonly IMakesService makesService;
        private readonly IModelsService modelsService;
        private readonly IGenerationsService generationsService;
        private readonly ICarsService carsService;
        private readonly IImagesService imagesService;

        public DataController(IMakesService makesService, IModelsService modelsService,
            IGenerationsService generationsService, ICarsService carsService, IImagesService imagesService)
        {
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.generationsService = generationsService;
            this.carsService = carsService;
            this.imagesService = imagesService;
        }

        public IActionResult Makes()
        {
            var viewModel = this.makesService.GetAll()
                .To<DisplayMakeModel>()
                .OrderBy(x => x.Name)
                .GroupBy(x => x.Name[0]);

            return this.View(viewModel);
        }

        public IActionResult Models(int id)
        {
            var models = this.modelsService
                .GetAllForMake(id)
                .OrderBy(x => x.Name)
                .To<DisplayModelWithImageModel>()
                .ToList();

            foreach (var model in models)
            {
                //TODO: Make this random for good looks
                var generation = generationsService.GetAllForModel(model.Id)
                    .FirstOrDefault();

                if (generation != null)
                {
                    model.ImageUrl = $"/images/generations/{generation.Id}/0.png";
                }
            }

            var viewModel = models.GroupBy(x => x.Name[0]);

            return this.View(viewModel);
        }

        public IActionResult Generations(int id)
        {
            var model = modelsService.GetById(id);
            if (model == null)
            {
                return this.BadRequest();
            }

            var generations = generationsService
                .GetAllForModel(id)
                .To<DisplayGenerationWithImageModel>()
                .ToList();

            foreach (var generation in generations)
            {
                var _gen = generationsService.GetById(generation.Id);

                generation.ProductionYearBegin = _gen
                    .Cars
                    .Min(x => x.BeginningOfProductionYear);

                generation.ProductionYearEnd = _gen.Cars
                    .Any(x => x.EndOfProductionYear == null) ?
                    null : _gen.Cars.Max(x => x.EndOfProductionYear);

                generation.CarsCount = _gen.Cars.Count();

                generation.ImageUrl = $"/images/generations/{generation.Id}/0.png";
            }

            return this.View(generations);
        }

        public IActionResult Cars(int id)
        {
            var generation = generationsService.GetById(id);

            if (generation == null)
            {
                return this.BadRequest();
            }

            var imageUrls = imagesService.GetImageUrls(GlobalConstants.GENERATION_PHOTO_PATH_TEMPLATE, id.ToString());

            var cars = carsService.GetAllForGeneration(id)
                .To<DisplayCarWithEngineModel>()
                .ToList();

            var viewModel = new DisplayCarsWithImagesModel
            {
                Cars = cars,
                ImageUrls = imageUrls
            };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var car = carsService.GetById(id);

            if(car == null)
            {
                return this.BadRequest();
            }

            var imageUrls = imagesService.GetImageUrls(GlobalConstants.GENERATION_PHOTO_PATH_TEMPLATE, car.GenerationId.ToString());

            var viewModel = new CarDetailsWithImagesModel
            {
                ImageUrls = imageUrls
            };

            Mapper.Map(car, viewModel);

            return this.View(viewModel);
        }
    }
}