using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
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

        public IActionResult Index()
        {
            //TODO : Automapper
            var makes = makesService
                .GetAll()
                .Select(x => new DisplayMakeModel
                {
                    Name = x.Name,
                    Description = x.Description
                });

            return this.View(makes);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateMakeModel model)
        {
            if (this.makesService.Exists(model.Name))
            {
                this.ModelState.AddModelError(nameof(model.Name), "Make already exists");
            }

            if (!this.imagesService.IsValidImage(model.Logo))
            {
                this.ModelState.AddModelError(nameof(model.Logo), "Image is not in valid format");
            }

            if (!ModelState.IsValid)
            {
                return this.Create();
            }

            //TODO: Use automapper
            var make = new Make
            {
                Name = model.Name,
                Description = model.Description
            };

            this.makesService.Add(make);

            var imagePath = string.Format(GlobalConstants.MAKE_PATH_TEMPLATE, model.Name);
            this.imagesService.UploadImage(model.Logo, imagePath);

            return this.Redirect("/Administrator/Makes");
        }

        public IActionResult Edit(string id)
        {
            var make = makesService.GetById(id);
            if (make == null)
            {
                ViewData["Error"] = $"A make with the id {id} does not exist";
                return this.View();
            }




            return this.Index();
        }
    }
}