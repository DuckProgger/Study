using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    // Специальное исключение, генерируемое в том случае,
    // если имя или номер телефона не найдены.
    class NotFoundException : Exception
    {
        public NotFoundException() : base() { }
    }
    class EmptyFieldException : Exception
    {
        public EmptyFieldException() : base() { }
    }

    class EmptyListException : Exception
    {
        public EmptyListException() : base() { }
    }

    class UncorrectCommandException : Exception
    {
        public UncorrectCommandException() : base() { }
    }
}
