using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Colleague : PhoneNumber
    {
        public Colleague(string name, string number, bool isWorkNumber) : base(name, number)
        {
            IsWorkNumber = isWorkNumber;
        }
        public bool IsWorkNumber { get; private set; }
        // ...
    }
}
