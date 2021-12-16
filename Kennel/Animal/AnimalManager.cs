using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennel
{
    public class AnimalManager : IAnimalManager
    {
        IFactory Factory;
        IDataRepository DataRepository;
        IAnimal Animal;

        public AnimalManager(IFactory factory, IDataRepository dataRepository, IAnimal animal)
        {
            Factory = factory;
            DataRepository = dataRepository;
            Animal = animal;
        }

        public void Register()
        {
            var animal = Factory.CreateAnimal();
            var customers = DataRepository.GetAllPerson();
            Console.WriteLine($"\nEnter {Animal.TypeOfAnimal}s name: ");
            animal.Name = Console.ReadLine();

            if (string.IsNullOrEmpty(animal.Name))
            {
                Console.WriteLine("Invalid input");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"\nSelect owner to {animal.Name}: ");
            
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine($"{i} {customers[i].Name}");
            }
            Console.WriteLine("Enter input below: \n");
            int ownerIndex = Convert.ToInt32(Console.ReadLine());
            if ((customers.Count - 1) < ownerIndex)
            {
                return;
            }
            else
            {
                animal.Owner = customers[ownerIndex];
                DataRepository.SaveAnimal(animal);
                Console.WriteLine($"\n{animal.Name} saved with {animal.Owner.Name} as owner. \n\nPress any button to continue...");
                Console.ReadLine();
            }
        }
        public void ListAnimals()
        {
            var animals = DataRepository.GetAllAnimal();
            Console.WriteLine($"---{Animal.TypeOfAnimal}s Registered---\n");
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i}");
                Console.WriteLine($"{Animal.TypeOfAnimal}            {animals[i].Name}");
                Console.WriteLine($"Owner:         {animals[i].Owner.Name}");
                Console.WriteLine($"Checked-In?    {animals[i].isCheckedIn}");
                Console.WriteLine($"Trimmed Claws? {animals[i].isClawsTrimmed}");
                Console.WriteLine($"Washed?        {animals[i].isWashed}\n");
            }
            Console.WriteLine("Press any button to continue...");
            Console.ReadLine();
        }
        public void CheckInAnimal()
        {
            var animals = DataRepository.GetAllAnimal();
            Console.WriteLine($"Choose {Animal.TypeOfAnimal} to Check-In: \n");
            for (int i = 0; i < animals.Count; i++)
            {
                if (!animals[i].isCheckedIn)
                {
                    Console.WriteLine($"{i}. {animals[i].Name}");
                }
            }
            Console.WriteLine("\nEnter input: ");
            try //förlåt.
            {
                int checkInAnimal = Convert.ToInt32(Console.ReadLine());
                animals[checkInAnimal].isCheckedIn = true;
                Console.WriteLine($"\n{animals[checkInAnimal].Name} is Checked-In.\n");
                Console.WriteLine("Press any button to continue...");
                Console.ReadLine();
                
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input... \nPress any button to go back");
                Console.ReadLine();
            }
        }
        public void CheckOutAnimal()
        {
            var animals = DataRepository.GetAllAnimal();
            Console.WriteLine($"Choose {Animal.TypeOfAnimal} to Check-out: \n");
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].isCheckedIn)
                {
                    Console.WriteLine($"{i}. {animals[i].Name}");
                }
            }
            Console.WriteLine("\nEnter input: ");
            int checkInAnimal = Convert.ToInt32(Console.ReadLine());
            try
            {
                animals[checkInAnimal].isCheckedIn = false;
                Console.WriteLine($"\n{animals[checkInAnimal].Name} is Checked-Out.\n");
                Console.WriteLine("Press any button to see receipt...");
                Console.ReadLine();
                Animal.PrintReceipt(animals[checkInAnimal]);
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid input... \nPress any button to go back");
                Console.ReadLine();
            }
        }
        public void ListCheckedInAnimalsWithOwners()
        {
            var animals = DataRepository.GetAllAnimal();
            Console.WriteLine($"All Checked-In {Animal.TypeOfAnimal}s with Owners\n");
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].isCheckedIn == true)
                {
                    Console.WriteLine($"{Animal.TypeOfAnimal}:    {animals[i].Name}");
                    Console.WriteLine($"Owner:  {animals[i].Owner.Name}\n");
                }
            }
            Console.WriteLine("Press any button to continue...");
            Console.ReadLine();
        }
        public void ExtraServices()
        {
            var animals = DataRepository.GetAllAnimal();
            Console.WriteLine($"Pick the extra service for your {Animal.TypeOfAnimal}: \n");
            Console.WriteLine("1. Wash");
            Console.WriteLine("2. Pedicure\n");
            Console.WriteLine("Enter input:");
            string extraServiceOption = Console.ReadLine();
            if (extraServiceOption == "1")
            {
                Console.WriteLine($"Registered {Animal.TypeOfAnimal}s: \n");
                for (int i = 0; i < animals.Count; i++)
                {
                    Console.WriteLine($"{i}. {animals[i].Name}");
                }
                Console.WriteLine("\nApply Wash to: ");
                int applyWash = Convert.ToInt32(Console.ReadLine());
                animals[applyWash].isWashed = true;
                Console.WriteLine($"\nWash applied to {animals[applyWash].Name}\n");
                Console.WriteLine("Press any button continue...");
                Console.ReadLine();

            }
            if (extraServiceOption == "2")
            {
                Console.WriteLine($"Registered {Animal.TypeOfAnimal}s: \n");
                for (int i = 0; i < animals.Count; i++)
                {
                    Console.WriteLine($"{i}. {animals[i].Name}");
                }
                Console.WriteLine("\nApply Pedicure to: ");
                int applyPedicure = Convert.ToInt32(Console.ReadLine());
                animals[applyPedicure].isClawsTrimmed = true;
                Console.WriteLine($"\nPedicure applied to {animals[applyPedicure].Name}\n");
                Console.WriteLine("Press any button continue...");
                Console.ReadLine();
            }
        }
    }
}
