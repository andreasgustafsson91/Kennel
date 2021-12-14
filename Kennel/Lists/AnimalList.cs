using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel
{
    public class AnimalList : IAnimalList
    {
        public List<IAnimal> animals { get; set; }

        public AnimalList()
        {
            animals = new();
        }
    }
}
