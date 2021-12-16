using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennel
{
    public interface IKennelLogic
    {
        public bool isCheckedIn { get; set; }
        public bool isWashed { get; set; }
        public bool isClawsTrimmed { get; set; }
        public int InitialPrice { get; set; }
        public int WashPrice { get; set; }
        public int PedicurePrice { get; set; }

        int CalculatePrice(IAnimal animal);
        void PrintReceipt(IAnimal animal);
    }
}
