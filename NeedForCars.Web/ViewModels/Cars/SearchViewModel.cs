using NeedForCars.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.Cars
{
    public class SearchViewModel
    {
        public int? MakeId { get; set; }

        public int? ModelId { get; set; }

        public int? GenerationId { get; set; }

        public int? CarId { get; set; }

        public int? MileageFrom { get; set; }

        public int? MileageTo { get; set; }

        public int? PriceFrom { get; set; }

        public int? PriceTo { get; set; }

        public Currency Currency { get; set; }

        public int? YearOfProductionFrom { get; set; }

        public int? YearOfProductionTo { get; set; }

        public FuelType? FuelType { get; set; }

        public int? MinHP { get; set; }

        public int? MaxHP { get; set; }

        public Transmission? Transmission { get; set; }

        public AlternativeFuel? AlternativeFuel { get; set; }

        public DriveWheel? DriveWheel { get; set; }

        public Ordering Ordering { get; set; }

        public OrderingType OrderingType { get; set; }
    }

    public enum Ordering
    {
        Latest = 1,
        Price = 2,
        Mileage = 3,
        ProductionDate = 4
    }

    public enum OrderingType
    {
        Ascending = 1,
        Descending = 2
    }
}
