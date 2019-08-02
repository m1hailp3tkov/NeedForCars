﻿using System;
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

namespace NeedForCars.Web.Controllers
{
    public class UserCarsController : BaseController
    {
        private readonly UserManager<NeedForCarsUser> userManager;
        private readonly ICarsService carsService;
        private readonly IUserCarsService userCarsService;
        private readonly IImagesService imagesService;

        public UserCarsController(UserManager<NeedForCarsUser> userManager,
            ICarsService carsService, IUserCarsService userCarsService, IImagesService imagesService)
        {
            this.userManager = userManager;
            this.carsService = carsService;
            this.userCarsService = userCarsService;
            this.imagesService = imagesService;
        }

        public IActionResult All()
        {
            var userId = userManager.GetUserId(this.User);
            var userCars = this.userCarsService
                .GetAllForUser(userId);

            var viewModel = userCars.To<DisplayUserCarModel>();

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCarModel createUserCarModel)
        {
            createUserCarModel.OwnerId = userManager.GetUserId(this.User);

            var car = this.carsService.GetById(createUserCarModel.CarId);
            if (car == null)
            {
                return this.BadRequest();
            }

            var validDateTime = DateTime.TryParse($"{createUserCarModel.ProductionDateYear}/{createUserCarModel.ProductionDateMonth}/01", out DateTime dateTime);
            if(!validDateTime)
            {
                return this.BadRequest();
            }

            if (createUserCarModel.Photos == null)
            {
                this.ModelState.AddModelError(nameof(createUserCarModel.Photos),
                    GlobalConstants.IMAGE_REQUIRED);
            }

            ValidatePhotos(createUserCarModel);
            ValidateProductionDate(createUserCarModel, car);

            if (!this.ModelState.IsValid)
            {
                return this.View(createUserCarModel);
            }


            var userCar = Mapper.Map<UserCar>(createUserCarModel);
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
            var userId = userManager.GetUserId(this.User);
            var userCar = this.userCarsService.GetById(editUserCarModel.Id);
            var car = this.carsService.GetById(editUserCarModel.CarId);
            var validDateTime = DateTime.TryParse($"{editUserCarModel.ProductionDateYear}/{editUserCarModel.ProductionDateMonth}/01", out DateTime dateTime);

            if (userCar.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            if (!validDateTime)
            {
                return this.BadRequest();
            }

            ValidatePhotos(editUserCarModel);

            ValidateProductionDate(editUserCarModel, car);

            if (!this.ModelState.IsValid)
            {
                return this.View(editUserCarModel);
            }

            if (car == null || userCar == null)
            {
                return this.BadRequest();
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

        private void ValidatePhotos(CreateUserCarModel model)
        {
            if (model.Photos != null
                && !imagesService.IsValidImageCollection(model.Photos))
            {
                this.ModelState.AddModelError(nameof(model.Photos),
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