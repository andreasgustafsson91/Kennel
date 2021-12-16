using System.Collections.Generic;

namespace Kennel
{
    public interface IListDatabase
    {
        List<IAnimal> animals { get; set; }
        List<IPerson> customers { get; set; }
    }
}