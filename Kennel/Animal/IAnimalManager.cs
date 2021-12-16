namespace Kennel
{
    public interface IAnimalManager
    {
        void Register();
        void ListAnimals();
        void CheckInAnimal();
        void CheckOutAnimal();
        void ListCheckedInAnimalsWithOwners();
        void ExtraServices();
    }
}