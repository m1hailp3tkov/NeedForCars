using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NeedForCars.Services.Mapping;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Web.Areas.Administrator.ViewModels.Engines;

namespace NeedForCars.Web.Areas.Administrator.Controllers
{
    public class EnginesController : AdministratorController
    {
        private readonly IEnginesService enginesService;

        public EnginesController(IEnginesService enginesService)
        {
            this.enginesService = enginesService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction(nameof(All));
        }

        public IActionResult All()
        {
            var model = enginesService.All()
                .To<DisplayEngineModel>()
                .ToList();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var engine = enginesService.GetById(id);
            if (engine == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<EngineDetailsModel>(engine);

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEngineModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var engine = Mapper.Map<Engine>(viewModel);

            await enginesService.AddAsync(engine);

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var engine = enginesService.GetById(id);
            if (engine == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<EditEngineModel>(engine);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEngineModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var engine = Mapper.Map<Engine>(viewModel);

            await this.enginesService.UpdateAsync(engine);

            return this.RedirectToAction(nameof(Details), new { id = engine.Id });
        }

        public IActionResult Delete(int id)
        {
            var engine = this.enginesService.GetById(id);
            if (engine == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<DeleteEngineModel>(engine);
            this.enginesService.GetRelatedEntitiesCount(engine, out int cars, out int userCars);

            viewModel.CarsCount = cars;
            viewModel.UserCarsCount = userCars;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteEngineModel deleteEngineModel)
        {
            var engine = enginesService.GetById(deleteEngineModel.Id);
            
            await this.enginesService.DeleteAsync(engine);

            return this.RedirectToAction(nameof(All));
        }
    }
}