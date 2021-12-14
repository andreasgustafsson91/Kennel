using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel
{
    public class MainMenu : IMainMenu
    {
        ICustomerList CustomerList;
        IAnimalList AnimalList;
        IPerson Person;
        IFactory Factory;
        public string menuOption { get; set; }
        public bool IsRunning { get; set; }

        public MainMenu(IPerson person, ICustomerList customerList, IFactory factory, IAnimalList animalList)
        {
            Person = person;
            CustomerList = customerList;
            AnimalList = animalList;
            Factory = factory;
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
                var person = Factory.CreatePerson();
                Console.WriteLine("\nEnter your name: ");
                person.Name = Console.ReadLine();
                Console.WriteLine("\nEnter your email: ");
                person.Email = Console.ReadLine();
                CustomerList.customers.Add(person);
                Console.WriteLine($"\n{person.Name} saved. \n\nPress any button to continue...");
                Console.ReadLine();
            }
            if (menuOption == "2")
            {
                var animal = Factory.CreateAnimal();
                    Console.WriteLine("\nEnter animal name: ");
                
                animal.Name = Console.ReadLine();
                if (string.IsNullOrEmpty(animal.Name))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadLine();
                    return;
                }

                    Console.WriteLine($"\nSelect owner to {animal.Name}: ");
                for (int i = 0; i < CustomerList.customers.Count; i++)
                {
                    Console.WriteLine($"{i} {CustomerList.customers[i].Name}");
                }
                    Console.WriteLine("Enter input below: \n");
                int AnimalOwner = Convert.ToInt32(Console.ReadLine());
                if ((CustomerList.customers.Count - 1) < AnimalOwner)
                {

                    return;
                }
                else
                {
                    animal.Owner = CustomerList.customers[AnimalOwner];
                    AnimalList.animals.Add(animal);
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
                    if(!AnimalList.animals[i].isCheckedIn)
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
                if(extraServiceOption == "1")
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
