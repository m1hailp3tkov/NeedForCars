using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Areas.Administrator.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForCars.Web.Areas.Administrator.Controllers
{
    public class ModelsController : AdministratorController
    {
        private readonly IModelsService modelsService;
        private readonly IMakesService makesService;

        public ModelsController(IModelsService modelsService , IMakesService makesService)
        {
            this.modelsService = modelsService;
            this.makesService = makesService;
        }

        public IActionResult All(string id)
        {
            var make = makesService.GetById(id);
            if(make == null)
            {
                return this.BadRequest();
            }

            var viewModel = make.Models
                .AsQueryable()
                .To<DisplayModelModel>();

            this.ViewBag.MakeName = make.Name;

            return this.View(viewModel);
        }

        public IActionResult Create(string id)
        {
            var make = makesService.GetById(id);
            if (make == null)
            {
                return this.BadRequest();
            }

            this.ViewBag.MakeName = make.Name;
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateModelModel createModelModel, string id)
        {
            var make = makesService.GetById(id);
            if (make == null)
            {
                return this.BadRequest();
            }
            if(modelsService.Exists(id,createModelModel.Name))
            {
                this.ModelState.AddModelError(nameof(createModelModel.Name), "Model already exists");
            }
            if(!this.ModelState.IsValid)
            {
                return this.View(createModelModel);
            }

            var model = Mapper.Map<Model>(createModelModel);
            model.MakeId = id;

            modelsService.Add(model);

            return this.RedirectToAction(nameof(All), new { id });
            // TODO? fix redirects with proper routes
        }

        public IActionResult Edit(string id)
        {
            var model = modelsService.GetById(id);
            if(model == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<EditModelModel>(model);

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditModelModel editModelModel)
        {
            var model = modelsService.GetById(editModelModel.Id);
            if(model == null)
            {
                return this.BadRequest();
            }
            if (modelsService.Exists(model.Make.Id, editModelModel.Name))
            {
                this.ModelState.AddModelError(nameof(editModelModel.Name), "Model already exists");
            }
            if (!ModelState.IsValid)
            {
                return this.View(editModelModel);
            }

            model.Name = editModelModel.Name;
            model.Description = editModelModel.Description;

            modelsService.Update(model);

            return this.RedirectToAction(nameof(All), new { Id = model.MakeId});
        }
    }
}
