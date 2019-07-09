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
            if(!ModelState.IsValid)
            {
                return this.Create();
            }

            //TODO: Use automapper
            var make = new Make
            {
                Name = model.Name,
                Description = model.Description
            };

            if(this.makesService.Exists(make))
            {
                this.ModelState[nameof(model.Name)]
                    .Errors
                    .Add("Make already exists");

                return this.Create();
            }

            if(!this.imagesService.IsValidImage(model.Logo))
            {
                this.ModelState[nameof(model.Logo)]
                    .Errors
                    .Add("Image is not in valid format");

                return this.Create();
            }

            this.makesService.Add(make);

            var imagePath = string.Format(GlobalConstants.MAKE_PATH_TEMPLATE, model.Name);
            this.imagesService.UploadImage(model.Logo, imagePath);

            return this.Redirect("/Administrator/Makes");
        }
    }
}