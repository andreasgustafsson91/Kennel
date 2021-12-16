using Kennel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennel.Services
{
    public interface IKennelService
    {

    }
    public class KennelService : IKennelService
    {
        private readonly ICustomerService _customerService;
        private readonly IAnimalService _animalService;
        private Models.Kennel _kennel = new Models.Kennel();

        public KennelService(ICustomerService customerService, IAnimalService animalService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _animalService = animalService ?? throw new ArgumentNullException(nameof(animalService));

            _kennel = new Models.Kennel()
            {
                Id = 1, 
                Name = "Ante's kennel"
            };
        }

        public void RegisterCustomer(Customer customer)
        {
            _kennel.Customers.Add(customer);
        }

        public void RegisterAnimal(Animal animal)
        {
            _kennel.Animals.Add(animal);
        }
    }
}
