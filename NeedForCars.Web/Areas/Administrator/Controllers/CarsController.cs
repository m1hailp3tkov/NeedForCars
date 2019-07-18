using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
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
            if(generation==null)
            {
                return this.BadRequest();
            }

            /*this.ViewBag.Make = generation.Model.Make.Name;
            this.ViewBag.Model.*/
            return View();
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

            if(generation == null)
            {
                return this.BadRequest();
            }
            if (engine == null)
            {
                this.ModelState.AddModelError(nameof(createCarModel.EngineId), "Engine with this Id does not exist.");
            }
            //TODO: extract First car Year to global constants
            //TODO: extract model error messages to global constants
            if (createCarModel.BeginningOfProduction.Year < 1886)
            {
                this.ModelState.AddModelError(nameof(createCarModel.BeginningOfProduction), "Cars didn't exist back then.");
            }
            if(createCarModel.EndOfProduction > DateTime.UtcNow)
            {
                this.ModelState.AddModelError(nameof(createCarModel.EndOfProduction),
                    "We do not not support cars from the future.");
            }
            if(!this.ModelState.IsValid)
            {
                return this.View();
            }

            var car = Mapper.Map<Car>(createCarModel);
            car.GenerationId = id;

            this.carsService.Add(car);

            return this.RedirectToAction(nameof(All), new { id });
        }
    }
}