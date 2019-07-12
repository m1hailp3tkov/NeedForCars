using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Web.Areas.Administrator.ViewModels.Models;
using System.Linq;

namespace NeedForCars.Web.Areas.Administrator.Controllers
{
    public class ModelsController : AdministratorController
    {
        private readonly IModelsService modelsService;

        public ModelsController(IModelsService modelsService)
        {
            this.modelsService = modelsService;
        }

        public IActionResult Index(string makeId)
        {
            var viewModel = modelsService
                .GetAllForMake(makeId)
                .Select(x => new DisplayModelModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                });
                
            return this.View(viewModel);
        }

        public IActionResult Create(string makeId)
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateModelModel createModelModel)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View();
            }

            var makeId = (string)Url.ActionContext.RouteData.Values["id"];

            var model = new Model
            {
                Name = createModelModel.Name,
                Description = createModelModel.Description
            };

            modelsService.AddModelToMake(makeId, model);

            return this.Redirect($"/Administrator/Models/?makeId={makeId}");
            // TODO: fix redirects with some proper routes?
        }
    }
}