using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Colleague : PhoneNumber
    {
        public Colleague(string name, string number, string eMail) : base(name, number)
        {
            EMail = eMail;
        }

        public string EMail { get; set; }
    }
}
