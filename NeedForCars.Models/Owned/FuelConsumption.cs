using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models.Owned
{
    public class FuelConsumption
    {
        [Range(typeof(decimal), "0.1", "100")]
        public decimal? Urban { get; set; }

        [Range(typeof(decimal), "0.1", "100")]
        [DisplayName("Extra Urban")]
        public decimal? ExtraUrban { get; set; }

        [Range(typeof(decimal), "0.1", "100")]
        public decimal? Combined { get; set; }
    }
}
