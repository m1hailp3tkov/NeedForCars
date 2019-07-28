namespace NeedForCars.Models.Contracts
{
    public interface IIdentifiable<T>
    {
        T Id { get; set; }
    }
}