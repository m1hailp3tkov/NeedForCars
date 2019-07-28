using NeedForCars.Models.Contracts;
using NeedForCars.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Generation : IIdentifiable<int>
    {
        public Generation()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        public int ModelId { get; set; }
        public Model Model { get; set; }

        //Body/physical data
        [Required]
        public BodyType BodyType { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        //Nullables
        [Range(1, 8)]
        public int? Seats { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}