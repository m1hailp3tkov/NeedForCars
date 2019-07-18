using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Areas.Administrator.ViewModels.Generations;
using System.Collections.Generic;
using System.Linq;

namespace NeedForCars.Web.Areas.Administrator.Controllers
{
    public class GenerationsController : AdministratorController
    {
        private readonly IGenerationsService generationsService;
        private readonly IModelsService modelsService;

        public GenerationsController(IGenerationsService generationsService , IModelsService modelsService)
        {
            this.generationsService = generationsService;
            this.modelsService = modelsService;
        }

        public IActionResult All(string id)
        {
            var model = this.modelsService.GetById(id);
            if(model == null)
            {
                return this.BadRequest();
            }

            var viewModel = model.Generations
                .AsQueryable()
                .To<DisplayGenerationModel>();

            this.ViewBag.Make = model.Make.Name;
            this.ViewBag.Model = model.Name;

            return this.View(viewModel);
        }

        public IActionResult Create(string id)
        {
            var model = modelsService.GetById(id);
            if (model == null)
            {
                return this.BadRequest();
            }

            this.ViewBag.Make = model.Make.Name;
            this.ViewBag.Model = model.Name;

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateGenerationModel createGenerationModel, string id)
        {
            var model = modelsService.GetById(id);
            if (model == null)
            {
                return this.BadRequest();
            }
            if(this.generationsService.Exists(id, createGenerationModel.Name))
            {
                this.ModelState.AddModelError(nameof(createGenerationModel.Name), "Generation already exists");
            }
            if (!this.ModelState.IsValid)
            {
                return this.View(createGenerationModel);
            }


            var generation = Mapper.Map<Generation>(createGenerationModel);
            generation.ModelId = id;

            generationsService.Add(generation);

            return this.RedirectToAction(nameof(All), new { id });
        }

        public IActionResult Edit(string id)
        {
            var generation = generationsService.GetById(id);
            if (generation == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<EditGenerationModel>(generation);

            this.ViewBag.Model = generation.Model.Name;
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditGenerationModel editGenerationModel)
        {
            var generation = generationsService.GetById(editGenerationModel.Id);
            if (generation == null)
            {
                return this.BadRequest();
            }
            if (this.generationsService.Exists(editGenerationModel.Id, editGenerationModel.Name))
            {
                this.ModelState.AddModelError(nameof(editGenerationModel.Name), "Generation already exists");
            }
            if (!ModelState.IsValid)
            {
                return this.View(editGenerationModel);
            }

            generation.Name = editGenerationModel.Name;
            generation.Description = editGenerationModel.Description;

            generationsService.Update(generation);

            return this.RedirectToAction(nameof(All), new { Id = generation.ModelId });
        }
    }
}
