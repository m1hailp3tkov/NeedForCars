using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Areas.Administrator.ViewModels.Generations;
using NeedForCars.Web.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.Areas.Administrator.Controllers
{
    public class GenerationsController : AdministratorController
    {
        private readonly IGenerationsService generationsService;
        private readonly IModelsService modelsService;
        private readonly IImagesService imagesService;

        public GenerationsController(IGenerationsService generationsService,
            IModelsService modelsService, IImagesService imagesService)
        {
            this.generationsService = generationsService;
            this.modelsService = modelsService;
            this.imagesService = imagesService;
        }

        public IActionResult All(int id)
        {
            var model = this.modelsService.GetById(id);
            if (model == null)
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

        public IActionResult Create(int id)
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
        public async Task<IActionResult> Create(CreateGenerationModel createGenerationModel, int id)
        {
            var model = modelsService.GetById(id);
            if (model == null)
            {
                return this.BadRequest();
            }
            if (this.generationsService.Exists(id, createGenerationModel.Name))
            {
                this.ModelState.AddModelError(nameof(createGenerationModel.Name),
                    GlobalConstants.GENERATION_ALREADY_EXISTS);
            }
            if (createGenerationModel.FormImages != null
                && !imagesService.IsValidImageCollection(createGenerationModel.FormImages))
            {
                this.ModelState.AddModelError(nameof(createGenerationModel.FormImages),
                    GlobalConstants.IMAGE_COLLECTION_INVALID);
            }
            if (!this.ModelState.IsValid)
            {
                return this.View(createGenerationModel);
            }

            var generation = Mapper.Map<Generation>(createGenerationModel);

            generation.ModelId = id;

            await this.generationsService.AddAsync(generation);

            await this.imagesService.UploadImagesAsync(createGenerationModel.FormImages.ToList(),
                GlobalConstants.GENERATION_PHOTO_PATH_TEMPLATE, generation.Id.ToString());

            return this.RedirectToAction(nameof(All), new { id });
        }

        public IActionResult Edit(int id)
        {
            var generation = generationsService.GetById(id);
            if (generation == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<EditGenerationModel>(generation);

            this.ViewBag.Make = generation.Model.Make.Name;
            this.ViewBag.Model = generation.Model.Name;
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditGenerationModel editGenerationModel)
        {
            var generation = generationsService.GetById(editGenerationModel.Id);
            if (generation == null)
            {
                return this.BadRequest();
            }
            if (this.generationsService.Exists(generation.ModelId, editGenerationModel.Name)
                && editGenerationModel.Name != generation.Name)
            {
                this.ModelState.AddModelError(nameof(editGenerationModel.Name),
                    GlobalConstants.GENERATION_ALREADY_EXISTS);
            }
            if (editGenerationModel.FormImages != null
                && !imagesService.IsValidImageCollection(editGenerationModel.FormImages))
            {
                this.ModelState.AddModelError(nameof(editGenerationModel.FormImages),
                    GlobalConstants.IMAGE_COLLECTION_INVALID);
            }
            if (!ModelState.IsValid)
            {
                return this.View(editGenerationModel);
            }

            if (editGenerationModel.FormImages != null)
            {
                var path = string.Format(GlobalConstants.GENERATION_PHOTO_PATH_TEMPLATE, generation.Id, "0");

                this.imagesService.TryDeleteImagesFromDirectory(path);

                await this.imagesService.UploadImagesAsync(editGenerationModel.FormImages.ToList(),
                    GlobalConstants.GENERATION_PHOTO_PATH_TEMPLATE, generation.Id.ToString());
            }

            generation = Mapper.Map(editGenerationModel, generation);

            await generationsService.UpdateAsync(generation);

            return this.RedirectToAction(nameof(All), new { Id = generation.ModelId });
        }

        public IActionResult Delete(int id)
        {
            var generation = generationsService.GetById(id);
            if (generation == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<DeleteGenerationModel>(generation);
            this.generationsService.GetRelatedEntitiesCount(generation, out int cars, out int userCars);

            viewModel.CarsCount = cars;
            viewModel.UserCarsCount = userCars;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteGenerationModel deleteGenerationModel)
        {
            var generation = generationsService.GetById(deleteGenerationModel.Id);
            var path = string.Format(GlobalConstants.GENERATION_PHOTO_PATH_TEMPLATE, deleteGenerationModel.Id, "0");

            this.imagesService.TryDeleteImagesFromDirectory(path);
            await this.generationsService.DeleteAsync(generation);

            return this.RedirectToAction(nameof(All), new { id = generation.ModelId });
        }
    }
}
