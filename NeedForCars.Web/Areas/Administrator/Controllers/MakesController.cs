using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Areas.Administrator.ViewModels.Makes;
using NeedForCars.Web.Common;
using System.Collections.Generic;
using System.Linq;

namespace NeedForCars.Web.Areas.Administrator.Controllers
{
    public class MakesController : AdministratorController
    {
        private readonly IMakesService makesService;
        private readonly IImagesService imagesService;

        public MakesController(IMakesService makesService, IImagesService imagesService)
        {
            this.makesService = makesService;
            this.imagesService = imagesService;
        }

        public IActionResult All()
        {
            var allMakes = makesService.GetAll();

            var makes = allMakes.To<DisplayMakeModel>();

            return this.View(makes);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateMakeModel createMakeModel)
        {
            if (this.makesService.Exists(createMakeModel.Name))
            {
                this.ModelState.AddModelError(nameof(createMakeModel.Name), "Make already exists");
            }
            if (!this.imagesService.IsValidImage(createMakeModel.Logo))
            {
                this.ModelState.AddModelError(nameof(createMakeModel.Logo), "Image is not in valid format");
            }
            if (!ModelState.IsValid)
            {
                return this.Create();
            }

            //TODO: Use automapper
            var make = Mapper.Map<Make>(createMakeModel);
            this.makesService.Add(make);

            var imagePath = string.Format(GlobalConstants.MAKE_LOGO_PATH_TEMPLATE, make.Id);
            this.imagesService.UploadImage(createMakeModel.Logo, imagePath);

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Edit(string id)
        {
            var make = makesService.GetById(id);
            if (make == null)
            {
                return BadRequest();
            }

            //TODO : Automapper
            var viewModel = Mapper.Map<EditMakeModel>(make);

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditMakeModel editMakeModel, string id)
        {
            var make = makesService.GetById(id);
            if(make == null)
            {
                return this.BadRequest();
            }

            if (!this.imagesService.IsValidImage(editMakeModel.NewLogo) && editMakeModel.NewLogo != null)
            {
                this.ModelState.AddModelError(nameof(editMakeModel.NewLogo), "Image is not in valid format");
            }
            if (!ModelState.IsValid)
            {
                return this.Edit(id);
            }
            
            make.Name = editMakeModel.Name;
            make.Description = editMakeModel.Description;

            makesService.Update(make);

            if (editMakeModel.NewLogo != null)
            {
                var imagePath = string.Format(GlobalConstants.MAKE_LOGO_PATH_TEMPLATE, id);
                this.imagesService.UploadImage(editMakeModel.NewLogo, imagePath);
            }

            return this.RedirectToAction(nameof(All));
        }
    }
}

//TODO Async controllers