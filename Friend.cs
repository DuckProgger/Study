using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    // Класс для телефонных номеров друзей.
    class Friend : PhoneNumber
    {
        public Friend(string name, string number, bool isWorkNumber) : base(name, number)
        {
            IsWorkNumber = isWorkNumber;
        }
        public bool IsWorkNumber { get; set; }
    }
}
