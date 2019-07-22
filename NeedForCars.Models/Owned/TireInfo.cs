using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models.Owned
{
    public class TireInfo
    {
        [Required]
        [Range(135, 315, ErrorMessage = "Invalid width")]
        public int TireWidth { get; set; }

        [Required]
        [Range(30, 80, ErrorMessage = "Invalid aspect ratio")]
        public int AspectRatio { get; set; }

        [Required]
        [Range(12, 22, ErrorMessage = "Invalid wheel diameter")]
        public int WheelDiameter { get; set; }
    }
}
