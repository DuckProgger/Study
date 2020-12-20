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
        int end;
        const int count = 2;
        public PhoneList()
        {
            phList = new T[count];
            end = 0;
        }
        // Добавить элемент в список.
        public bool Add(T newEntry)
        {
            if (end == count) return false;
            phList[end] = newEntry;
            end++;
            return true;
        }
        // Найти и возвратить сведения о телефоне по заданному имени.
        public T FindByName(string name)
        {
            if (end == 0)
            {
                throw new EmptyListException();
            }
            for (int i = 0; i < end; i++)
            {
                // Имя может использоваться, потому что его свойство Name
                // относится к членам класса PhoneNumber, который является
                // базовым по накладываемому ограничению.
                if (phList[i].Name == name)
                    return phList[i];
            }
            // Имя отсутствует в списке.
            throw new NotFoundException();
        }

        int FindByName2(string name)
        {
            if (end == 0)
            {
                throw new EmptyListException();
            }
            for (int i = 0; i < end; i++)
            {
                // Имя может использоваться, потому что его свойство Name
                // относится к членам класса PhoneNumber, который является
                // базовым по накладываемому ограничению.
                if (phList[i].Name == name)
                    return i;
            }
            // Имя отсутствует в списке.
            throw new NotFoundException();
        }
        // Найти и возвратить сведения о телефоне по заданному номеру.
        public T FindByNumber(string number)
        {
            if (end == 0)
            {
                throw new EmptyListException();
            }
            for (int i = 0; i < end; i++)
            {
                // Номер телефона также может использоваться, поскольку
                // его свойство Number относится к членам класса PhoneNumber,
                // который является базовым по накладываемому ограничению.
                if (phList[i].Number == number)
                    return phList[i];
            }
            // Номер телефона отсутствует в списке.
            throw new NotFoundException();
        }

        public void RemoveContact(string name)
        {
            try
            {
                int number = FindByName2(name);
                end--;
                for (int i = number; i < end; i++)
                {
                    phList[i] = phList[i + 1];
                }
            }
            catch (NotFoundException)
            {
                throw new NotFoundException();
            }
        }

        public void RenameContact(string name)
        {
            try
            {
                int number = FindByName2(name);
                Console.WriteLine("Новое имя: ");
                string newName = Console.ReadLine();
                phList[number].Name = newName;
            }
            catch (NotFoundException)
            {
                throw new NotFoundException();
            }
            catch (EmptyListException)
            {
                throw new EmptyListException();
            }
        }

        public void ChangePhoneContact(string name)
        {
            try
            {
                int number = FindByName2(name);
                Console.WriteLine("Новый номер: ");
                string newPhone = Console.ReadLine();
                phList[number].Number = newPhone;
            }
            catch (NotFoundException)
            {
                throw new NotFoundException();
            }
            catch (EmptyListException)
            {
                throw new EmptyListException();
            }
        }

        public void ShowCountContact()
        {
            Console.WriteLine("Количество контактов: " + end);
        }

    }
}
