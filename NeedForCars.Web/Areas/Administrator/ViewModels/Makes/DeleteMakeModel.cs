namespace NeedForCars.Web.Areas.Administrator.ViewModels.Makes
{
    public class DeleteMakeModel : DisplayMakeModel
    {
        public int ModelsCount { get; set; }

        public int GenerationsCount { get; set; }

        public int CarsCount { get; set; }

        public int UserCarsCount { get; set; }
    }
}
