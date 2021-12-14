using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel
{
    public class CreatePerson : ICreatePerson
    {
        IPerson Person;


        public CreatePerson(IPerson person)
        {
            Person = person;

        }

        public IPerson Create()
        {
            return Person;
        }
    }
}
