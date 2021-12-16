using System.Collections.Generic;

namespace Kennel.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Animal> Animals { get; set; } = new List<Animal>();
    }
}
