using Kennel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kennel
{
    public class MainMenu : IMainMenu
    {
        private readonly ICustomerService _customerService;
        private readonly IAnimalService _animalService;
        private readonly IKennelService _kennelService;
        public string menuOption { get; set; }
        public bool IsRunning { get; set; }

        public MainMenu(ICustomerService customerService, IAnimalService animalService, IKennelService kennelService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _animalService = animalService ?? throw new ArgumentNullException(nameof(animalService));
            _kennelService = kennelService ?? throw new ArgumentNullException(nameof(kennelService));
        }

        public void Menu()
        {
            IsRunning = true;
            do
            {
                ShowMenu();
            }
            while (IsRunning == true);
        }


        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("---Menu---");
            Console.WriteLine("1. Register Customer");
            Console.WriteLine("2. Register Animal");
            Console.WriteLine("3. View Registered Customers");
            Console.WriteLine("4. View Registered Animals");
            Console.WriteLine("5. Check-In Animal");
            Console.WriteLine("6. Check-Out Animal");
            Console.WriteLine("7. View Checked-in Animals with Owners");
            Console.WriteLine("8. Add Extra Services");
            Console.WriteLine("9. Exit Application");
            Console.WriteLine("Enter option: \n");

            menuOption = Console.ReadLine();
            if (menuOption == "1")
            {
                Console.WriteLine("\nEnter your name: ");
                var name = Console.ReadLine();
                Console.WriteLine("\nEnter your email: ");
                var email = Console.ReadLine();
                var customer = _customerService.Create(348, name, email, new List<Models.Animal>());
                Console.WriteLine($"\n{customer.Name} saved. \n\nPress any button to continue...");
                Console.ReadLine();
            }
            if (menuOption == "2")
            {
                Console.WriteLine("\nEnter animal name: ");

                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadLine();
                    return;
                }

                var animal = _animalService.Create(123, name, false, new Models.Customer(), "Cat");

                Console.WriteLine($"\nSelect owner to {animal.Name}: ");
                var customers = _customerService.GetAll();
                foreach(var customer in customers)
                {
                    Console.WriteLine($"Id: {customer.Id}, Name: {customer.Name}");
                }

                Console.WriteLine("Enter input below: \n");
                int animalOwnerId = Convert.ToInt32(Console.ReadLine());

                if (!customers.Any(x => x.Id == animalOwnerId))
                    return;
                else
                {
                    animal.Owner = _customerService.GetById(animalOwnerId);
                    _animalService.Update(animal);
                    Console.WriteLine($"\n{animal.Name} saved with {animal.Owner.Name} as owner. \n\nPress any button to continue...");
                    Console.ReadLine();
                }

            }
            if (menuOption == "3")
            {
                Console.WriteLine("---Customer Register---\n");
                for (int i = 0; i < CustomerList.customers.Count; i++)
                {
                    Console.WriteLine($"Customer {i}: {CustomerList.customers[i].Name}");
                    Console.WriteLine($"Email: {CustomerList.customers[i].Email}\n");
                }
                Console.WriteLine("\nPress any button to continue...");
                Console.ReadLine();
            }
            if (menuOption == "4")
            {
                Console.WriteLine("---Animal Registered---\n");
                for (int i = 0; i < AnimalList.animals.Count; i++)
                {
                    Console.WriteLine($"Animal {i}: {AnimalList.animals[i].Name}");
                    Console.WriteLine($"Owner: {AnimalList.animals[i].Owner.Name}");
                    Console.WriteLine($"Checked-In? {AnimalList.animals[i].isCheckedIn}");
                    Console.WriteLine($"Washed? {AnimalList.animals[i].isWashed}\n");
                }
                Console.WriteLine("Press any button to continue...");
                Console.ReadLine();
            }
            if (menuOption == "5")
            {
                Console.WriteLine("Choose animal to Check-In: \n");
                for (int i = 0; i < AnimalList.animals.Count; i++)
                {
                    if (!AnimalList.animals[i].isCheckedIn)
                    {
                        Console.WriteLine($"{i}. {AnimalList.animals[i].Name}");
                    }

                }
                Console.WriteLine("\nEnter input: ");
                try //förlåt.
                {
                    int checkInAnimal = Convert.ToInt32(Console.ReadLine());
                    AnimalList.animals[checkInAnimal].isCheckedIn = true;
                    Console.WriteLine($"\n{AnimalList.animals[checkInAnimal].Name} is Checked-In.\n");
                    Console.WriteLine("Press any button to continue...");
                    Console.ReadLine();
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid input... \nPress any button to go back");
                    Console.ReadLine();
                }


            }
            if (menuOption == "6")
            {
                Console.WriteLine("Choose animal to Check-out: \n");
                for (int i = 0; i < AnimalList.animals.Count; i++)
                {
                    if (AnimalList.animals[i].isCheckedIn)
                    {
                        Console.WriteLine($"{i}. {AnimalList.animals[i].Name}");
                    }
                }
                Console.WriteLine("\nEnter input: ");
                int checkInAnimal = Convert.ToInt32(Console.ReadLine());
                try
                {
                    AnimalList.animals[checkInAnimal].isCheckedIn = false;
                    Console.WriteLine($"\n{AnimalList.animals[checkInAnimal].Name} is Checked-Out.\n");
                    Console.WriteLine("Press any button to continue...");
                    Console.ReadLine();
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid input... \nPress any button to go back");
                    Console.ReadLine();
                }

            }
            if (menuOption == "7")
            {
                Console.WriteLine("All Checked-In Animals with Owners\n");
                for (int i = 0; i < AnimalList.animals.Count; i++)
                {
                    if (AnimalList.animals[i].isCheckedIn == true)
                    {
                        Console.WriteLine($"Animal: {AnimalList.animals[i].Name}");
                        Console.WriteLine($"Owner: {AnimalList.animals[i].Owner.Name}\n");
                    }
                }
                Console.WriteLine("Press any button to continue...");
                Console.ReadLine();
            }
            if (menuOption == "8")
            {
                Console.WriteLine("Pick the extra service for your animal: \n");
                Console.WriteLine("1. Wash");
                Console.WriteLine("2. Pedicure\n");
                Console.WriteLine("Enter input:");
                string extraServiceOption = Console.ReadLine();
                if (extraServiceOption == "1")
                {
                    Console.WriteLine("Registered Animals: \n");
                    for (int i = 0; i < AnimalList.animals.Count; i++)
                    {
                        Console.WriteLine($"{i}. {AnimalList.animals[i].Name}");
                    }
                    Console.WriteLine("Apply Wash to: ");
                    int applyWash = Convert.ToInt32(Console.ReadLine());
                    AnimalList.animals[applyWash].isWashed = true;
                    Console.WriteLine($"Wash applied to {AnimalList.animals[applyWash].Name}");
                    Console.WriteLine("Press any button continue...");
                    Console.ReadLine();

                }
                if (extraServiceOption == "2")
                {
                    Console.WriteLine("Registered Animals: \n");
                    for (int i = 0; i < AnimalList.animals.Count; i++)
                    {
                        Console.WriteLine($"{i}. {AnimalList.animals[i].Name}");
                    }
                    Console.WriteLine("Apply Pedicure to: ");
                    int applyWash = Convert.ToInt32(Console.ReadLine());
                    AnimalList.animals[applyWash].isWashed = true;
                    Console.WriteLine($"Wash applied to {AnimalList.animals[applyWash].Name}");
                    Console.WriteLine("Press any button continue...");
                    Console.ReadLine();
                }
            }
            if (menuOption == "9")
            {
                IsRunning = false;
            }


            else
            {
                Console.WriteLine("");
            }
        }



    }
}
