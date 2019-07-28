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
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCarModel createUserCarModel)
        {
            createUserCarModel.OwnerId = userManager.GetUserId(this.User);

            var car = this.carsService.GetById(createUserCarModel.CarId);
            if(car == null)
            {
                return this.BadRequest();
            }
            if(!imagesService.IsValidImageCollection(createUserCarModel.Photos))
            {
                this.ModelState.AddModelError(nameof(createUserCarModel.Photos),
                        GlobalConstants.IMAGE_COLLECTION_INVALID);
            }
            if(createUserCarModel.ProductionDate < car.BeginningOfProduction
               || createUserCarModel.ProductionDate > car.EndOfProduction)
            {
                this.ModelState.AddModelError(nameof(createUserCarModel.ProductionDate),
                    string.Format
                    (GlobalConstants.USERCAR_PRODUCTIONDATE_INVALID,
                        car.BeginningOfProduction.ToShortDateString(),
                        car.EndOfProduction.ToShortDateString()));
            }

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
    }
}