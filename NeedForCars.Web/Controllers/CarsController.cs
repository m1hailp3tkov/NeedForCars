using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Areas.Administrator.ViewModels.Makes;

namespace NeedForCars.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly IMakesService makesService;
        private readonly IModelsService modelsService;

        public CarsController(IMakesService makesService, IModelsService modelsService)
        {
            this.makesService = makesService;
            this.modelsService = modelsService;
        }

        public IActionResult Makes()
        {
            var viewModel = this.makesService.GetAll()
                .To<DisplayMakeModel>()
                .GroupBy(x => x.Name[0])
                .OrderBy(x => x.Key);

            return this.View(viewModel);
        }

        public IActionResult Models(int id)
        {
            throw new NotImplementedException();

        }
    }
}