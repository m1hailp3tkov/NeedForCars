using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class ModelEngines
    {
        [Required]
        public int ModelId { get; set; }
        public Model Model { get; set; }

        [Required]
        public int EngineId { get; set; }
        public Engine Engine { get; set; }
    }
}
