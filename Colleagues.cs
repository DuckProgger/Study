using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Colleagues : PhoneNumber
    {
        public Colleagues(string n, string num, bool wk) : base(n, num)
        {
            IsWorkNumber = wk;
        }
        public bool IsWorkNumber { get; private set; }
        // ...
    }
}
