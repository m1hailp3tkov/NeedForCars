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
                this.ModelState["Name"]
                    .Errors
                    .Add("Make already exists");

                return this.Create();
            }

            this.makesService.Add(make);

            //TODO: Validation for image format (possibly in service?)
            var imagePath = string.Format(GlobalConstants.MAKE_PATH_TEMPLATE, model.Name);
            this.imagesService.UploadImage(model.Logo, imagePath);

            return this.Index();
        }
    }
}