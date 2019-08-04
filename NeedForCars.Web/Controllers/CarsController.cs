using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.ViewModels.UserCars;
using X.PagedList;

namespace NeedForCars.Web.Controllers
{
    public class CarsController : BaseController
    {
        private readonly IUserCarsService userCarsService;

        public CarsController(IUserCarsService userCarsService)
        {
            this.userCarsService = userCarsService;
        }

        public IActionResult Browse(int? page)
        {
            int pageNumber = (page ?? 1);

            var allCars = userCarsService
                .GetAllPublic()
                .To<DisplayUserCarModel>()
                .ToPagedList(pageNumber, 10);

            return View(allCars);
        }
    }
}