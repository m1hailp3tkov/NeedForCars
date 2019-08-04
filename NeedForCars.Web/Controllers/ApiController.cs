using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.ViewModels.UserCars.DTOs;

namespace NeedForCars.Web.Controllers
{
    public class ApiController : Controller
    {
        private readonly IMakesService makesService;
        private readonly IModelsService modelsService;
        private readonly IGenerationsService generationsService;
        private readonly ICarsService carsService;

        public ApiController(IMakesService makesService, IModelsService modelsService, IGenerationsService generationsService, ICarsService carsService)
        {
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.generationsService = generationsService;
            this.carsService = carsService;
        }

        public JsonResult FetchMakes()
        {
            var makes = makesService.GetAll()
                .To<MakeDTO>()
                .OrderBy(x => x.Name);

            return Json(makes);
        }

        public JsonResult FetchModels(int id)
        {
            var models = modelsService.GetAllForMake(id)
                .To<ModelDTO>()
                .OrderBy(x => x.Name);

            return Json(models);
        }

        public JsonResult FetchGenerations(int id)
        {
            var generations = generationsService.GetAllForModel(id)
                .To<GenerationDTO>()
                .OrderBy(x => x.Name);

            return Json(generations);
        }

        public JsonResult FetchCars(int id)
        {
            var cars = carsService.GetAllForGeneration(id)
                .To<CarDTO>()
                .OrderBy(x => x.EngineMaxHP)
                .ThenBy(x => x.DisplayText);

            return Json(cars);
        }
    }
}