using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    /// <summary>
    /// Базовый класс, в котором хранятся имя абонента и номер его телефона.
    /// </summary>
    class PhoneNumber
    {
        public PhoneNumber(string name, string number)
        {
            Name = name;
            Number = number;
        }

        public string Number { get; set; }
      
        public string Name { get; set; }
    }
}
