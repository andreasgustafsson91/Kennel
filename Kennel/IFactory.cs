namespace Kennel
{
    public interface IFactory
    {
        IAnimal CreateAnimal();
        IPerson CreatePerson();
    }
}