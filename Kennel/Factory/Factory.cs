using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel
{
    public class Factory : IFactory
    {
        public IPerson CreatePerson()
        {
            return new Person();
        }

        public IAnimal CreateAnimal()
        {
            return new Animal();
        }
    }
}
