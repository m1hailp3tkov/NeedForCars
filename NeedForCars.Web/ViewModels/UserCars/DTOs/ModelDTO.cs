using NeedForCars.Models;
using NeedForCars.Services.Mapping;

namespace NeedForCars.Web.ViewModels.UserCars.DTOs
{
    public class ModelDTO : IMapFrom<Model>
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public string Name { get; set; }
    }
}
