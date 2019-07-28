using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Areas.Administrator.ViewModels.Models;
using NeedForCars.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult All(int id)
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

        public IActionResult Create(int id)
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
        public async Task<IActionResult> Create(CreateModelModel createModelModel, int id)
        {
            var make = makesService.GetById(id);
            if (make == null)
            {
                return this.BadRequest();
            }
            if(modelsService.Exists(id,createModelModel.Name))
            {
                this.ModelState.AddModelError(nameof(createModelModel.Name), GlobalConstants.MODEL_ALREADY_EXISTS);
            }
            if(!this.ModelState.IsValid)
            {
                return this.View(createModelModel);
            }

            var model = Mapper.Map<Model>(createModelModel);
            model.MakeId = id;

            await modelsService.AddAsync(model);

            return this.RedirectToAction(nameof(All), new { id });
        }

        public IActionResult Edit(int id)
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
        public async Task<IActionResult> Edit(EditModelModel editModelModel)
        {
            var model = modelsService.GetById(editModelModel.Id);
            if(model == null)
            {
                return this.BadRequest();
            }
            if(modelsService.Exists(model.MakeId, editModelModel.Name) && editModelModel.Name != model.Name)
            {
                this.ModelState.AddModelError(nameof(editModelModel.Name), GlobalConstants.MODEL_ALREADY_EXISTS);
            }
            if (!ModelState.IsValid)
            {
                return this.View(editModelModel);
            }

            model = Mapper.Map(editModelModel, model);

            await modelsService.UpdateAsync(model);

            return this.RedirectToAction(nameof(All), new { Id = model.MakeId});
        }
    }
}
