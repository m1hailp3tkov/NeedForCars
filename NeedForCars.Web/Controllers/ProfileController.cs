using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.ViewModels.Profile;
using NeedForCars.Web.ViewModels.UserCars;
using X.PagedList;

namespace NeedForCars.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<NeedForCarsUser> userManager;
        private readonly IUserCarsService userCarsService;

        public ProfileController(UserManager<NeedForCarsUser> userManager, IUserCarsService userCarsService)
        {
            this.userManager = userManager;
            this.userCarsService = userCarsService;
        }

        public async Task<IActionResult> Index(string userName, int? page)
        {
            var user = await this.userManager.FindByNameAsync(userName);
            if(user == null)
            {
                return this.BadRequest();
            }

            var userInfoModel = Mapper.Map<UserInfoModel>(user);

            int pageNumber = (page ?? 1);

            userInfoModel.DisplayUserCars = userCarsService.GetAllPublic()
                .Where(x => x.OwnerId == user.Id)
                .To<DisplayUserCarModel>()
                .ToPagedList(pageNumber, 10);

            return View(userInfoModel);
        }
    }
}