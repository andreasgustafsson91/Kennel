using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel
{
    public class Animal : IAnimal
    {
        public string Name { get; set; }
        public IPerson Owner { get; set; }
        public string TypeOfAnimal { get; set; }

        public bool isCheckedIn { get; set; }
        public bool isWashed { get; set; }
        public bool isClawsTrimmed { get; set; }
        public int InitialPrice { get; set; }
        public int WashPrice { get; set; }
        public int PedicurePrice { get; set; }

        public Animal()
        {
            InitialPrice = 500;
            WashPrice = 500;
            PedicurePrice = 300;
            TypeOfAnimal = "Dog";
        }

        public int CalculatePrice(IAnimal animal)
        {
            int Total = 0;
            Total += InitialPrice;
            if (animal.isClawsTrimmed)
            {
                Total += PedicurePrice;
            }
            if (animal.isWashed)
            {
                Total += WashPrice;
            }
            //moms är för ekonomer.
            return Total;
        }
        public void PrintReceipt(IAnimal animal)
        {
            Console.WriteLine($"We hope your {TypeOfAnimal} has enjoyed his stay.\n" +
                $"Here is your receipt.\n");
            Console.WriteLine($"Initial cost: {InitialPrice} kr");
            if (animal.isWashed)
            {
                Console.WriteLine($"Wash         {WashPrice} kr");
            }
            if (animal.isClawsTrimmed)
            {
                Console.WriteLine($"Pedicure     {PedicurePrice} kr");
            }
            Console.WriteLine($"Your total is {CalculatePrice(animal)} kr\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
