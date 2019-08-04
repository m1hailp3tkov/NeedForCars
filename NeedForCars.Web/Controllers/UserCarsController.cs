using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Web.Common;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.ViewModels.UserCars;
using NeedForCars.Web.ViewModels.UserCars.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace NeedForCars.Web.Controllers
{
    public class UserCarsController : BaseController
    {
        private readonly UserManager<NeedForCarsUser> userManager;
        private readonly ICarsService carsService;
        private readonly IUserCarsService userCarsService;
        private readonly IImagesService imagesService;
        private readonly IMakesService makesService;
        private readonly IModelsService modelsService;
        private readonly IGenerationsService generationsService;

        public UserCarsController(UserManager<NeedForCarsUser> userManager,
            ICarsService carsService, IUserCarsService userCarsService, IImagesService imagesService, 
            IMakesService makesService, IModelsService modelsService, IGenerationsService generationsService)
        {
            this.userManager = userManager;
            this.carsService = carsService;
            this.userCarsService = userCarsService;
            this.imagesService = imagesService;
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.generationsService = generationsService;
        }

        public IActionResult All()
        {
            var userId = userManager.GetUserId(this.User);
            var userCars = this.userCarsService
                .GetAllForUser(userId);

            var viewModel = userCars.To<DisplayUserCarModel>();

            return this.View(viewModel);
        }

        public IActionResult Details(string id)
        {
            var userCar = this.userCarsService.GetById(id);

            if (userCar == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<DetailsUserCarModel>(userCar);

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateUserCarModel();

            var allMakes = this.makesService.GetAll().To<MakeDTO>();

            viewModel.MakeList = new SelectList(allMakes, nameof(MakeDTO.Id), nameof(MakeDTO.Name));

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCarModel createUserCarModel)
        {
            createUserCarModel.OwnerId = userManager.GetUserId(this.User);

            var car = this.carsService.GetById(createUserCarModel.SelectedCar.Value);
            var validDateTime = DateTime.TryParse($"{createUserCarModel.ProductionDateYear}/{createUserCarModel.ProductionDateMonth}/01", out DateTime dateTime);

            if (car == null || !validDateTime)
            {
                return this.BadRequest();
            }

            if (createUserCarModel.Photos == null)
            {
                this.ModelState.AddModelError(nameof(createUserCarModel.Photos),
                    GlobalConstants.IMAGE_REQUIRED);
            }

            ValidatePhotos(createUserCarModel.Photos, nameof(CreateUserCarModel.Photos));
            ValidateProductionDate(createUserCarModel, car);

            if (!this.ModelState.IsValid)
            {
                var makes = this.makesService
                    .GetAll()
                    .To<MakeDTO>();
                var models = this.modelsService
                    .GetAllForMake(createUserCarModel.SelectedMake.Value)
                    .To<ModelDTO>();
                var generations = this.generationsService
                    .GetAllForModel(createUserCarModel.SelectedModel.Value)
                    .To<GenerationDTO>();
                var cars = this.carsService
                    .GetAllForGeneration(createUserCarModel.SelectedGeneration.Value)
                    .To<CarDTO>();

                createUserCarModel.MakeList = new SelectList(makes, nameof(MakeDTO.Id), nameof(MakeDTO.Name));
                createUserCarModel.ModelList = new SelectList(models, nameof(ModelDTO.Id), nameof(ModelDTO.Name));
                createUserCarModel.GenerationList = new SelectList(generations, nameof(GenerationDTO.Id), nameof(GenerationDTO.Name));
                createUserCarModel.CarList = new SelectList(cars, nameof(CarDTO.Id), nameof(CarDTO.DisplayText));

                return this.View(createUserCarModel);
            }


            var userCar = Mapper.Map<UserCar>(createUserCarModel);
            userCar.CarId = car.Id;

            await this.userCarsService.AddAsync(userCar);

            await imagesService.UploadImagesAsync(createUserCarModel.Photos.ToList(),
                GlobalConstants.USERCAR_PHOTO_PATH_TEMPLATE, userCar.Id.ToString());

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Edit(string id)
        {
            var userCar = userCarsService.GetById(id);
            if (userCar == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<EditUserCarModel>(userCar);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserCarModel editUserCarModel)
        {
            //TODO: usercar edit
            var userId = userManager.GetUserId(this.User);
            var userCar = this.userCarsService.GetById(editUserCarModel.Id);

            if (userCar == null)
            {
                return this.BadRequest();
            }

            if (userCar.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            ValidatePhotos(editUserCarModel.Photos, nameof(EditUserCarModel.Photos));

            if (!this.ModelState.IsValid)
            {
                return this.View(editUserCarModel);
            }

            userCar = Mapper.Map(editUserCarModel, userCar);
            userCar.OwnerId = userId;

            await userCarsService.UpdateAsync(userCar);

            if (editUserCarModel.Photos != null)
            {
                var path = string.Format(GlobalConstants.USERCAR_PHOTO_PATH_TEMPLATE, editUserCarModel.Id, "0");

                this.imagesService.TryDeleteImagesFromDirectory(path);

                await this.imagesService.UploadImagesAsync(editUserCarModel.Photos.ToList(),
                    GlobalConstants.USERCAR_PHOTO_PATH_TEMPLATE, editUserCarModel.Id.ToString());
            }

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Delete(string id)
        {
            var userCar = userCarsService.GetById(id);
            if (userCar == null)
            {
                return this.BadRequest();
            }

            var viewModel = Mapper.Map<DeleteUserCarModel>(userCar);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteUserCarModel deleteUserCarModel)
        {
            var userCar = this.userCarsService.GetById(deleteUserCarModel.Id);
            var path = string.Format(GlobalConstants.USERCAR_PHOTO_PATH_TEMPLATE, deleteUserCarModel.Id, "0");

            this.imagesService.TryDeleteImagesFromDirectory(path);
            await this.userCarsService.DeleteAsync(userCar);

            return this.RedirectToAction(nameof(All));
        }

        private void ValidatePhotos(IEnumerable<IFormFile> photos, string errorModelKey)
        {
            if (photos != null
                && !imagesService.IsValidImageCollection(photos))
            {
                this.ModelState.AddModelError(errorModelKey,
                    GlobalConstants.IMAGE_COLLECTION_INVALID);
            }
        }

        private void ValidateProductionDate(CreateUserCarModel model, Car car)
        {
            if (car == null || model == null) return;

            var productionDate = new DateTime(model.ProductionDateYear, model.ProductionDateMonth, 1);
            var beginningOfProduction = new DateTime(car.BeginningOfProductionYear, car.BeginningOfProductionMonth, 1);
            DateTime endOfProduction;
            if (car.EndOfProductionYear != null && car.EndOfProductionMonth != null)
            {
                endOfProduction = DateTime.UtcNow;
            }
            else
            {
                endOfProduction = new DateTime((int)car.EndOfProductionYear, (int)car.EndOfProductionMonth, 1);
            }

            if (productionDate < beginningOfProduction
              || productionDate > endOfProduction)
            {
                this.ModelState.AddModelError(nameof(model.ProductionDateYear),
                    string.Format
                    (GlobalConstants.USERCAR_PRODUCTIONDATE_INVALID,
                        beginningOfProduction.ToString("MMMM yyyy"),
                        endOfProduction.ToString("MMMM yyyy")));
            }
        }
    }
}
