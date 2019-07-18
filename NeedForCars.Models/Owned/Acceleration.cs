using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models.Owned
{
    public class Acceleration
    {
        [Range(typeof(decimal), "1", "100")]
        public decimal? _0_100 { get; set; }

        [Range(typeof(decimal), "1", "100")]
        public decimal? _0_200 { get; set; }

        [Range(typeof(decimal), "1", "100")]
        public decimal? _0_300 { get; set; }
    }
}
