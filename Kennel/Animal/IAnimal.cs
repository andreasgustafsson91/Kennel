namespace Kennel
{
    public interface IAnimal : IKennelLogic
    {
        string Name { get; set; }
        IPerson Owner { get; set; }
    }
}