using Microsoft.AspNetCore.Http;
using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Generations
{
    public class EditGenerationModel : CreateGenerationModel, IMapFrom<Generation>
    {
        [Display(Name="Photos")]
        public new IEnumerable<IFormFile> FormImages { get; set; }

        public int Id { get; set; }
    }
}
