using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models.Owned
{
    public class FuelConsumption
    {
        [Range(typeof(decimal), "0.1M", "100M")]
        public decimal? Urban { get; set; }

        [Range(typeof(decimal), "0.1M", "100M")]
        public decimal? ExtraUrban { get; set; }

        [Range(typeof(decimal), "0.1M", "100M")]
        public decimal? Combined { get; set; }
    }
}
