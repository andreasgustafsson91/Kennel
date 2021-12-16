using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennel
{
    public class PersonManager : IPersonManager
    {
        IFactory Factory;
        IDataRepository DataRepository;

        public PersonManager(IFactory factory, IDataRepository dataRepository)
        {
            Factory = factory;
            DataRepository = dataRepository;
        }

        public void Register()
        {
            var person = Factory.CreatePerson();
            Console.WriteLine("\nEnter your name: ");
            person.Name = Console.ReadLine();
            Console.WriteLine("\nEnter your email: ");
            person.Email = Console.ReadLine();
            DataRepository.SavePerson(person);
            Console.WriteLine($"\n{person.Name} saved. \n\nPress any button to continue...");
            Console.ReadLine();
        }

        public void ListCustomers()
        {
            var customers = DataRepository.GetAllPerson();
            Console.WriteLine("---Customers Registered---\n");
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine($"{i}");
                Console.WriteLine($"Customer:  {customers[i].Name}");
                Console.WriteLine($"Email:     {customers[i].Email}\n");
            }
            Console.WriteLine("\nPress any button to continue...");
            Console.ReadLine();
        }
    }
}
