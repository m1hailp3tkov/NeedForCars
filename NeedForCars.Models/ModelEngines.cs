using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class ModelEngines
    {
        [Required]
        public string ModelId { get; set; }
        public Model Model { get; set; }

        [Required]
        public string EngineId { get; set; }
        public Engine Engine { get; set; }
    }
}
