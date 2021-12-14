using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel
{
    public class CustomerList : ICustomerList
    {
        public List<IPerson> customers { get; set; }

        public CustomerList()
        {
            customers = new()
            {
                new Person { Name = "Sven", Email = "Svenne@mail.com" },
                new Person { Name = "Kurt", Email = "Kurtan@mail.com" },
                new Person { Name = "Hans", Email = "Hasse@mail.com" },
                new Person { Name = "Muhammed", Email = "Musse@mail.com" }
            };
        }
    }
}
