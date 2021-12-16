using System.Collections.Generic;

namespace Kennel.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public bool HasCheckedIn { get; set; }
        public Customer Owner { get; set; } = new Customer();
        public int OwnerId { get; set; }
        public List<Treatment> Treatments { get; set; } = new List<Treatment>();


        //public bool isCheckedIn { get; set; }
        //public bool isWashed { get; set; }
        //public bool isClawsTrimmed { get; set; }
        //public int Price { get; set; }

        //public int CalculatePrice()
        //{
        //    return Price;
        //}
    }
}
