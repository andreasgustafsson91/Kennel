using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel
{
    public class Animal : IAnimal
    {
        public string Name { get; set; }
        public IPerson Owner { get; set; }

        public bool isCheckedIn { get; set; }
        public bool isWashed { get; set; }
        public bool isClawsTrimmed { get; set; }
        public int Price { get; set; }

        public int CalculatePrice()
        {
            return Price;
        }
    }
}
