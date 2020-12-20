using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    // Класс PhoneList способен управлять любым видом списка телефонных номеров.
    // при условии, что он является производным от класса PhoneNumber.
    class PhoneList<T> where T : PhoneNumber
    {
        T[] phList;
        int position;
        int maxCapacity;

        public PhoneList(int maxCapacity)
        {
            this.maxCapacity = maxCapacity;
            phList = new T[maxCapacity];
            position = 0;
        }

        // Добавить элемент в список.
        public void Add(T newEntry)
        {
            Validate.IsTrue(HasPlace, "Нет места.");
            Validate.IsNotNull(newEntry);

            phList[position] = newEntry;
            position++;
        }

        public bool HasPlace =>
           position < maxCapacity;

        public int Count => 
            position;

        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < position; i++)
            {
                if (match(phList[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindIndexByName(string name)
        {
            return FindIndex(arrayValue => arrayValue.Name == name);
        }

        public bool RemoveContact(string name)
        {
            int index = FindIndexByName(name);
            if (index == -1)
            {
                return false;
            }

            position--;
            for (int i = index; i < position; i++)
            {
                phList[i] = phList[i + 1];
            }
            return true;
        }
    }
}
