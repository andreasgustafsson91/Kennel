using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel
{
    public class MainMenu : IMainMenu
    {
        IPersonManager PersonManager;
        IAnimalManager AnimalManager;
        IAnimal Animal;

        public string menuOption { get; set; }
        public bool IsRunning { get; set; }

        public MainMenu(IPersonManager personManager, IAnimalManager animalManager, IAnimal animal)
        {
            PersonManager = personManager;
            AnimalManager = animalManager;
            Animal = animal;
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
            Console.WriteLine($"2. Register {Animal.TypeOfAnimal}");
            Console.WriteLine("3. View Registered Customers");
            Console.WriteLine($"4. View Registered {Animal.TypeOfAnimal}s");
            Console.WriteLine($"5. Check-In {Animal.TypeOfAnimal}");
            Console.WriteLine($"6. Check-Out {Animal.TypeOfAnimal}");
            Console.WriteLine($"7. View Checked-in {Animal.TypeOfAnimal}s with Owners");
            Console.WriteLine("8. Add Extra Services");
            Console.WriteLine("9. Exit Application");
            Console.WriteLine("Enter option: \n");

            menuOption = Console.ReadLine();
            if (menuOption == "1")
            {
                PersonManager.Register();
            }
            if (menuOption == "2")
            {
                AnimalManager.Register();
            }
            if (menuOption == "3")
            {
                PersonManager.ListCustomers();
            }
            if (menuOption == "4")
            {
                AnimalManager.ListAnimals();
            }
            if (menuOption == "5")
            {
                AnimalManager.CheckInAnimal();   
            }
            if (menuOption == "6")
            {
                AnimalManager.CheckOutAnimal();
            }
            if (menuOption == "7")
            {
                AnimalManager.ListCheckedInAnimalsWithOwners();
            }
            if (menuOption == "8")
            {
                AnimalManager.ExtraServices();
            }
            if (menuOption == "9")
            {
                IsRunning = false;
                /*Environment.Exit(0);*/

            }
            else
            {
                Console.WriteLine("");
            }
        }



    }
}
