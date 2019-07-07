using NeedForCars.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Generation : IIdentifiable
    {
        public Generation()
        {
            this.Cars = new HashSet<Car>();
        }

        public string Id { get; set; }

        [Required]
        public string ModelId { get; set; }
        public Model Model { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        //Nullables
        [StringLength(50)]
        [RegularExpression("@[A-Za-z 0-9(),]+")] //TODO: Extract generation name regex to globals
        public string Name { get; set; }

        public string Description { get; set; }
    }
}