using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Web.Areas.Administrator.ViewModels.Makes;
using NeedForCars.Web.Common;
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
                    Id = x.Id,
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
            var make = new Make
            {
                Name = createMakeModel.Name,
                Description = createMakeModel.Description
            };

            this.makesService.Add(make);

            var imagePath = string.Format(GlobalConstants.MAKE_LOGO_PATH_TEMPLATE, make.Id);
            this.imagesService.UploadImage(createMakeModel.Logo, imagePath);

            return this.Redirect("/Administrator/Makes");
        }

        public IActionResult Edit(string id)
        {
            var make = makesService.GetById(id);
            if (make == null)
            {
                return BadRequest();
            }

            //TODO : Automapper
            var model = new EditMakeModel
            {
                Id = id,
                Name = make.Name,
                Description = make.Description
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditMakeModel editMakeModel)
        {
            var id = (string)Url.ActionContext.RouteData.Values["id"];

            if (!this.imagesService.IsValidImage(editMakeModel.NewLogo) && editMakeModel.NewLogo != null)
            {
                this.ModelState.AddModelError(nameof(editMakeModel.NewLogo), "Image is not in valid format");
            }

            if (!ModelState.IsValid)
            {
                return this.Edit(id);
            }

            var make = makesService
                .GetById(id);

            make.Name = editMakeModel.Name;
            make.Description = editMakeModel.Description;

            makesService.Update(make);

            if (editMakeModel.NewLogo != null)
            {
                var imagePath = string.Format(GlobalConstants.MAKE_LOGO_PATH_TEMPLATE, id);
                this.imagesService.UploadImage(editMakeModel.NewLogo, imagePath);
            }

             return this.Redirect("/Administrator/Makes");
        }
    }
}

//TODO Async controllers