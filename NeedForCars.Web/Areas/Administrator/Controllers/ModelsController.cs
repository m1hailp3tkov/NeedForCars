using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
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
            //id is MAKE ID
            var make = makesService.GetById(id);
            if(make == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<IEnumerable<DisplayModelModel>>(make.Models);

            this.ViewBag.MakeName = make.Name;

            return this.View(viewModel);
        }

        public IActionResult Create(string id)
        {
            //ID IS MAKE ID
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
            
            if(!this.ModelState.IsValid)
            {
                return this.View(createModelModel);
            }

            var model = Mapper.Map<Model>(createModelModel);

            modelsService.AddModelToMake(id, model);

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
        public IActionResult Edit(EditModelModel editModelModel, string id)
        {
            var model = modelsService.GetById(id);
            if(model == null)
            {
                return this.BadRequest();
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
