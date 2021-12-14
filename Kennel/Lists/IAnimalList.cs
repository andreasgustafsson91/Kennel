using System.Collections.Generic;

namespace Kennel
{
    public interface IAnimalList
    {
        List<IAnimal> animals { get; set; }
    }
}