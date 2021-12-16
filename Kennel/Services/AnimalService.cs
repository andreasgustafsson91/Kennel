using Kennel.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kennel.Services
{
    public interface IAnimalService
    {
        Animal Create(int id, string name, bool hasCheckedIn, Customer customer, string species);
        Animal Update(Animal animal);
        void CheckIn(int id);
        void CheckOut(int id);
        IEnumerable<Animal> GetAll();
        Animal GetById(int id);

    }
    public class AnimalService : IAnimalService
    {
        private readonly List<Animal> _animalList = new List<Animal>();

        public AnimalService()
        {
            var customer1 = new Customer
            {
                Name = "Björn",
                Email = "bjorn@mail.se",
                Id = 123,
                Animals = new List<Animal>()
            };

            _animalList.AddRange(new List<Animal>
            {
                new Animal
            {
                Id = 1,
                Name = "Yoda",
                HasCheckedIn = false,
                //Owner = customer1,
                //OwnerId = customer1.Id,
                OwnerId = default(int),
                Species = "Dog",
                Treatments = new List<Treatment>()
            }
            });
        }

        public Animal Create(int id, string name, bool hasCheckedIn, Customer customer, string species)
        {
            var newAnimal = new Animal
            {
                Id = id,
                Name = name,
                HasCheckedIn = hasCheckedIn,
                Owner = customer,
                OwnerId = customer.Id,
                Species = species
                //Treatments = new List<Treatment>()
            };

            _animalList.Add(newAnimal);

            return newAnimal;
        }

        public Animal Update(Animal animal)
        {
           var updatedAnimal = _animalList.Where(x => x.Id == animal.Id)
                .Select(x =>
                {
                    x.OwnerId = animal.OwnerId;
                    x.Owner = animal.Owner;
                    x.Name = animal.Name;
                    x.Species = animal.Species;
                    return x;
                })
                .FirstOrDefault();

            return updatedAnimal;
        }

        public void CheckIn(int id)
        {
            _animalList.Single(x => x.Id == id).HasCheckedIn = true;
        }

        public void CheckOut(int id)
        {
            _animalList.Single(x => x.Id == id).HasCheckedIn = false;
        }

        public IEnumerable<Animal> GetAll() => _animalList;

        public Animal GetById(int id) => _animalList.Find(x => x.Id == id);
    }
}