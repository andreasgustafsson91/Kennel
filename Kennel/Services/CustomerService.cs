using Kennel.Models;
using System.Collections.Generic;

namespace Kennel.Services
{
    public interface ICustomerService
    {
        Customer Create(int id, string name, string email, List<Animal> animals);
        IEnumerable<Customer> GetAll();
        Customer GetByEmail(string email);
        Customer GetById(int id);

    }
    public class CustomerService
    {
        private readonly List<Customer> _customerList = new List<Customer>();

        public CustomerService()
        {
            _customerList.AddRange(new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Jack",
                    Email = "jack@mail.se",
                    //Animals = new List<Animal>
                    //{
                    //    new Animal
                    //    {
                    //        Id = 1,
                    //        Name = "Gizmo",
                    //        HasCheckedIn = true,
                    //        Species = "Cat",
                    //        OwnerId = 1,
                    //        Treatments = new List<Treatment>()
                    //    }
                    //}
                },
                new Customer
                {
                    Id = 2,
                    Name = "Ante",
                    Email = "ante@mail.se",
                    //Animals = new List<Animal>
                    //{
                    //    new Animal
                    //    {
                    //        Id = 2,
                    //        Name = "Linnea",
                    //        HasCheckedIn = true,
                    //        Species = "Dog",
                    //        OwnerId = 1,
                    //        Treatments = new List<Treatment>()
                    //    }
                    //}
                }
            });
        }

        public Customer Create(int id, string name, string email, List<Animal> animals)
        {
            var newCustomer = new Customer
            {
                Animals = animals,
                Email = email,
                Name = name,
                Id = id
            };

            _customerList.Add(newCustomer);

            return newCustomer;
        }

        public IEnumerable<Customer> GetAll() => _customerList;
        public Customer GetById(int id) => _customerList.Find(x => x.Id == id);
        public Customer GetByEmail(string email) => _customerList.Find(x => x.Email == email);
    }
}
