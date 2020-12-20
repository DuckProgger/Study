using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    public static class Validate
    {
        public static void IsTrue(bool condition, string message = "")
        {
            if (!condition)
            {
                throw new Exception(message);
            }
        }

        public static void IsNotNull(object value, string message = "")
        {
            IsTrue(value != null, message);
        }

        public static void IsNotEmpty(string value, string message = "")
        {
            IsTrue(!string.IsNullOrEmpty(value), message);
        }
    }
}
