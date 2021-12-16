using System.Collections.Generic;

namespace Kennel.Models
{
    public class Kennel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Treatment> Services { get; set; }

        public List<Animal> Animals { get; set; } = new List<Animal>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
