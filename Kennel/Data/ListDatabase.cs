using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennel
{
    public class ListDatabase : IListDatabase
    {
        public List<IAnimal> animals { get; set; }
        public List<IPerson> customers { get; set; }

        public ListDatabase()
        {
            customers = new()
            {
                new Person
                {
                    Name = "Sven",
                    Email = "Svenne@mail.com"
                },
                new Person
                {
                    Name = "Kurt",
                    Email = "Kurtan@mail.com"
                },
                new Person
                {
                    Name = "Hans",
                    Email = "Hasse@mail.com"
                },
                new Person
                {
                    Name = "Muhammed",
                    Email = "Musse@mail.com"
                }
            };
            animals = new()
            {
                new Animal
                {
                    Name = "Hugo",
                    Owner = new Person
                    {
                        Name = "Sven",
                        Email = "Svenne@mail.com"
                    }
                },
                new Animal
                {
                    Name = "Bilbo",
                    Owner = new Person
                    {
                        Name = "Kurt",
                        Email = "Kurtan@mail.com"
                    }
                },
                new Animal
                {
                    Name = "Yoda",
                    Owner = new Person
                    {
                        Name = "Muhammed",
                        Email = "Musse@mail.com"
                    }
                },
                new Animal
                {
                    Name = "Kraken",
                    Owner = new Person
                    {
                        Name = "Hans",
                        Email = "Hasse@mail.com"
                    }
                }
            };
        }
    }
}
