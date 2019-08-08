using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Areas.Administrator.ViewModels.Makes;
using NeedForCars.Web.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return this.RedirectToAction(nameof(All));
        }

        public IActionResult All()
        {
            var allMakes = makesService.GetAll();

            var makes = allMakes.To<DisplayMakeModel>()
                .OrderBy(x => x.Name);

            return this.View(makes);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMakeModel createMakeModel)
        {
            if (this.makesService.Exists(createMakeModel.Name))
            {
                this.ModelState.AddModelError(nameof(createMakeModel.Name), GlobalConstants.MAKE_ALREADY_EXISTS);
            }
            if (!this.imagesService.IsValidImage(createMakeModel.Logo))
            {
                this.ModelState.AddModelError(nameof(createMakeModel.Logo), GlobalConstants.IMAGE_INVALID);
            }
            if (!ModelState.IsValid)
            {
                return this.View(createMakeModel);
            }

            var make = Mapper.Map<Make>(createMakeModel);
            await this.makesService.AddAsync(make);

            var imagePath = string.Format(GlobalConstants.MAKE_LOGO_PATH_TEMPLATE, make.Id);
            await this.imagesService.UploadImageAsync(createMakeModel.Logo, imagePath);

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var make = makesService.GetById(id);
            if (make == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<EditMakeModel>(make);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMakeModel editMakeModel)
        {
            var make = makesService.GetById(editMakeModel.Id);
            if (make == null)
            {
                return this.BadRequest();
            }

            if (this.makesService.Exists(editMakeModel.Name) && editMakeModel.Name != make.Name)
            {
                this.ModelState.AddModelError(nameof(editMakeModel.Name), GlobalConstants.MAKE_ALREADY_EXISTS);
            }
            if (!this.imagesService.IsValidImage(editMakeModel.NewLogo) && editMakeModel.NewLogo != null)
            {
                this.ModelState.AddModelError(nameof(editMakeModel.NewLogo), GlobalConstants.IMAGE_INVALID);
            }
            if (!ModelState.IsValid)
            {
                return this.Edit(editMakeModel.Id);
            }

            make = Mapper.Map(editMakeModel, make);

            await makesService.UpdateAsync(make);

            if (editMakeModel.NewLogo != null)
            {
                var imagePath = string.Format(GlobalConstants.MAKE_LOGO_PATH_TEMPLATE, editMakeModel.Id);
                await this.imagesService.UploadImageAsync(editMakeModel.NewLogo, imagePath);
            }

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            var make = this.makesService.GetById(id);

            if (make == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<DeleteMakeModel>(make);
            makesService.GetRelatedEntitiesCount(make, out int models, out int generations, out int cars, out int userCars);

            viewModel.ModelsCount = models;
            viewModel.GenerationsCount = generations;
            viewModel.CarsCount = cars;
            viewModel.UserCarsCount = userCars;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteMakeModel deleteMakeModel)
        {
            var make = makesService.GetById(deleteMakeModel.Id);

            await this.makesService.DeleteAsync(make);
            var path = string.Format(GlobalConstants.MAKE_LOGO_PATH_TEMPLATE, make.Id);
            this.imagesService.TryDeleteImage(path);

            return this.RedirectToAction(nameof(All));
        }
    }
}