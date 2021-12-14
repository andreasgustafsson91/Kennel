using System.Collections.Generic;

namespace Kennel
{
    public interface ICustomerList
    {
        List<IPerson> customers { get; set; }
    }
}