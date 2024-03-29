﻿using Microsoft.AspNetCore.Http;
using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Generations
{
    public class CreateGenerationModel : IMapTo<Generation>
    {
        [Required(ErrorMessage = GlobalConstants.IMAGE_REQUIRED)]
        [Display(Name = "Photos")]
        public IEnumerable<IFormFile> FormImages { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = GlobalConstants.GENERATION_NAME_LENGTH, MinimumLength = 1)]
        [RegularExpression(GlobalConstants.GENERATION_NAME_REGEX, ErrorMessage = GlobalConstants.GENERATION_NAME_INVALID)]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(BodyType), ErrorMessage = GlobalConstants.GENERATION_BODYTYPE_INVALID)]
        [Display(Name = "Body Type")]
        public BodyType BodyType { get; set; }

        [Range(1, 8, ErrorMessage = GlobalConstants.GENERATION_SEATS_INVALID)]
        public int? Seats { get; set; }

        public string Description { get; set; }
    }
}
