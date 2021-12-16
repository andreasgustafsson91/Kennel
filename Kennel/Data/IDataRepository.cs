using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennel
{
    public interface IDataRepository
    {
        List<IPerson> GetAllPerson();
        void SavePerson(IPerson person);
        void SaveAnimal(IAnimal animal);
        List<IAnimal> GetAllAnimal();
    }
}
