using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.ViewModels;
using NeedForCars.Web.ViewModels.UserCars;
using X.PagedList;

namespace NeedForCars.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserCarsService userCarsService;

        public HomeController(IUserCarsService userCarsService)
        {
            this.userCarsService = userCarsService;
        }

        public IActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            var viewModel = userCarsService.GetAllPublic()
                .OrderByDescending(x => x.CreatedOn)
                .To<DisplayUserCarModel>()
                .ToPagedList(pageNumber, 10);

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
