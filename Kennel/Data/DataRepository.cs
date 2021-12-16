using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennel
{
    public class DataRepository : IDataRepository
    {
        IListDatabase ListDatabase;

        public DataRepository(IListDatabase listDatabase)
        {
            ListDatabase = listDatabase;
        }

        public List<IPerson> GetAllPerson()
        {
            return ListDatabase.customers.ToList();
        }
        public List<IAnimal> GetAllAnimal()
        {
            return ListDatabase.animals.ToList();
        }

        public void SavePerson(IPerson person)
        {
            ListDatabase.customers.Add(person);
        }

        public void SaveAnimal(IAnimal animal)
        {
            ListDatabase.animals.Add(animal);
        }
        
    }

    
}
