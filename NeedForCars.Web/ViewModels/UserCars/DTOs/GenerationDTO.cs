using NeedForCars.Models;
using NeedForCars.Services.Mapping;

namespace NeedForCars.Web.ViewModels.UserCars.DTOs
{
    public class GenerationDTO : IMapFrom<Generation>
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public string Name { get; set; }
    }
}
