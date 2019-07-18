using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models.Owned
{
    public class FuelConsumption
    {
        [Range(typeof(decimal), "0.1", "100")]
        public decimal? Urban { get; set; }

        [Range(typeof(decimal), "0.1", "100")]
        public decimal? ExtraUrban { get; set; }

        [Range(typeof(decimal), "0.1", "100")]
        public decimal? Combined { get; set; }
    }
}
