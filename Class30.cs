﻿// Простой пример обобщенного класса.
namespace c30_1
{
    using System;
    // В приведенном ниже классе Gen параметр типа Т заменяется
    // реальным типом данных при создании объекта типа Gen.
    class Gen<T>
    {
        T ob; // объявить переменную типа Т
              // Обратите внимание на то, что у этого конструктора имеется параметр типа Т.
        public Gen(T о)
        {
            ob = о;
        }
        // Возвратить переменную экземпляра ob, которая относится к типу Т.
        public T GetOb()
        {
            return ob;
        }
        // Показать тип Т.
        public void ShowType()
        {
            Console.WriteLine("К типу T относится " + typeof(T));
        }
    }
    // Продемонстрировать применение обобщенного класса.
    class GenericsDemo
    {
        static void test()
        {
            // Создать переменную ссылки на объект Gen типа int.
            Gen<int> iOb;
            // Создать объект типа Gen<int> и присвоить ссылку на него переменной iOb.
            iOb = new Gen<int>(102);
            // Показать тип данных, хранящихся в переменной iOb.
            iOb.ShowType();
            // Получить значение переменной iOb.
            int v = iOb.GetOb();
            Console.WriteLine("Значение: " + v);
            Console.WriteLine();
            // Создать объект типа Gen для строк.
            Gen<string> strOb = new Gen<string>("Обобщения повышают эффективность.");
            // Показать тип данных, хранящихся в переменной strOb.
            strOb.ShowType();
            // Получить значение переменной strOb.
            string str = strOb.GetOb();
            Console.WriteLine("Значение: " + str);
        }
    }
}

// Класс NonGen является полным функциональным аналогом класса Gen, но без обобщений.
namespace c30_2
{

    using System;
    class NonGen
    {
        object ob; // переменная ob теперь относится к типу object
                   // Передать конструктору ссылку на объект типа object.
        public NonGen(object о)
        {
            ob = о;
        }
        // Возвратить объект типа object.
        public object GetOb()
        {
            return ob;
        }
        // Показать тип переменной ob.
        public void ShowType()
        {
            Console.WriteLine("Тип переменной ob: " + ob.GetType());
        }
    }
    // Продемонстрировать применение необобщенного класса.
    class NonGenDemo
    {
        static void test()
        {
            NonGen iOb;
            // Создать объект класса NonGen.
            iOb = new NonGen(102);
            // Показать тип данных, хранящихся в переменной iOb.
            iOb.ShowType();
            // Получить значение переменной iOb.
            // На этот раз потребуется приведение типов.
            int v = (int)iOb.GetOb();
            Console.WriteLine("Значение: " + v);
            Console.WriteLine();
            // Создать еще один объект класса NonGen и
            // сохранить строку в переменной it.
            NonGen strOb = new NonGen("Тест на необобщенность");
            // Показать тип данных, хранящихся в переменной strOb.
            strOb.ShowType();
            // Получить значение переменной strOb.
            //Ив этом случае требуется приведение типов.
            String str = (string)strOb.GetOb();
            Console.WriteLine("Значение: " + str);
            // Этот код компилируется, но он принципиально неверный!
            iOb = strOb;
            // Следующая строка кода приводит к исключительной
            // ситуации во время выполнения.
            // v = (int) iOb.GetOb(); // Ошибка при выполнении!
        }
    }
}

// Простой обобщенный класс с двумя параметрами типа Т и V.
namespace c30_3
{
    using System;
    class TwoGen<T, V>
    {
        T ob1;
        V ob2;

        public TwoGen(T o1, V о2)
        {
            ob1 = o1;
            ob2 = о2;
        }

        public T getob1()
        {
            return ob1;
        }

        public V GetObj2()
        {
            return ob2;
        }

        // Показать типы Т и V.
        public void showTypes()
        {
            Console.WriteLine("К типу T относится " + typeof(T));
            Console.WriteLine("К типу V относится " + typeof(V));
        }
    }


    // Продемонстрировать применение обобщенного класса с двумя параметрами типа.
    class SimpGen
    {
        static void test()
        {
            TwoGen<int, string> tgObj = new TwoGen<int, string>(119, "Альфа Бета Гамма");
            // Показать типы.
            tgObj.showTypes();
            // Получить и вывести значения.
            int v = tgObj.getob1();
            Console.WriteLine("Значение: " + v);
            string str = tgObj.GetObj2();
            Console.WriteLine("Значение: " + str);
        }
    }
}

// Наложение ограничения на базовый класс.
namespace c30_4
{

    using System;
    class A
    {
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }
    // Класс В наследует класс А.
    class B : A { }
    // Класс С не наследует класс А.
    class С { }
    // В силу ограничения на базовый класс во всех аргументах типа,
    // передаваемых классу Test, должен присутствовать базовый класс А.
    class Test<T> where T : A
    {
        T obj;
        public Test(T о)
        {
            obj = о;
        }
        public void SayHello()
        {
            // Метод Hello() вызывается, поскольку он объявлен в базовом классе А.
            obj.Hello();
        }
    }
    class BaseClassConstraintDemo
    {
        static void test()
        {
            A a = new A();
            B b = new B();
            С с = new С();
            // Следующий код вполне допустим, поскольку класс А указан как базовый.
            Test<A> t1 = new Test<A>(a);
            t1.SayHello();
            // Следующий код вполне допустим, поскольку класс В наследует от класса А.
            Test<B> t2 = new Test<B>(b);
            t2.SayHello();
            // Следующий код недопустим, поскольку класс С не наследует от класса А.
            // Test<C> t3 = new Test<C>(c); // Ошибка!
            // t3.SayHello(); // Ошибка!
        }
    }
}

// Пример, демонстрирующий применение ограничения на базовый класс.
namespace c30_5
{

    using System;
    // Специальное исключение, генерируемое в том случае,
    // если имя или номер телефона не найдены.
    class NotFoundException : Exception
    {
        /* Реализовать все конструкторы класса Exception.
        Эти конструкторы выполняют вызов конструктора базового класса.
        Класс NotFoundException ничем не дополняет класс Exception и
        поэтому не требует никаких дополнительных действий. */
        public NotFoundException() : base() { }
        public NotFoundException(string str) : base(str) { }
        public NotFoundException(
        string str, Exception inner) : base(str, inner) { }
        protected NotFoundException(System.Runtime.Serialization.SerializationInfo si, System.Runtime.Serialization.StreamingContext sc) : base(si, sc) { }
    }
    // Базовый класс, в котором хранятся имя абонента и номер его телефона.
    class PhoneNumber
    {
        public PhoneNumber(string n, string num)
        {
            Name = n;
            Number = num;
        }
        public string Number { get; set; }
        public string Name { get; set; }
    }
    // Класс для телефонных номеров друзей.
    class Friend : PhoneNumber
    {
        public Friend(string n, string num, bool wk) : base(n, num)
        {
            IsWorkNumber = wk;
        }
        public bool IsWorkNumber { get; private set; }
        // ...
    }
    // Класс для телефонных номеров поставщиков.
    class Supplier : PhoneNumber
    {
        public Supplier(string n, string num) : base(n, num)
        { }
        // ...
    }
    // Этот класс не наследует от класса PhoneNumber.
    class EmailFriend
    {
        // ...
    }
    // Класс PhoneList способен управлять любым видом списка телефонных номеров.
    // при условии, что он является производным от класса PhoneNumber.
    class PhoneList<T> where T : PhoneNumber
    {
        T[] phList;
        int end;
        public PhoneList()
        {
            phList = new T[10];
            end = 0;
        }
        // Добавить элемент в список.
        public bool Add(T newEntry)
        {
            if (end == 10) return false;
            phList[end] = newEntry;
            end++;
            return true;
        }
        // Найти и возвратить сведения о телефоне по заданному имени.
        public T FindByName(string name)
        {
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
        // Найти и возвратить сведения о телефоне по заданному номеру.
        public T FindByNumber(string number)
        {
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
        // ...
    }
    // Продемонстрировать наложение ограничений на базовый класс.
    class UseBaseClassConstraint
    {
        static void test()
        {
            // Следующий код вполне допустим, поскольку
            // класс Friend наследует от класса PhoneNumber.
            PhoneList<Friend> plist = new PhoneList<Friend>();
            plist.Add(new Friend("Том", "555-1234", true));
            plist.Add(new Friend("Гари", "555-6756", true));
            plist.Add(new Friend("Матт", "555-9254", false));
            for (int i = 0; i < 10; i++)
            {
                if (!plist.Add(new Friend("user", "123", false)))
                {
                    Console.WriteLine("Нет места\n");
                    break;
                }
            }
            try
            {
                // Найти номер телефона по заданному имени друга.
                Friend frnd = plist.FindByName("Гари");
                Console.Write(frnd.Name + " " + frnd.Number);
                if (frnd.IsWorkNumber)
                    Console.WriteLine(" (рабочий)");
                else
                    Console.WriteLine();
            }
            catch (NotFoundException)
            {
                Console.WriteLine("He найдено");
            }
            Console.WriteLine();
            // Следующий код также допустим, поскольку
            // класс Supplier наследует от класса PhoneNumber.
            PhoneList<Supplier> plist2 = new PhoneList<Supplier>();
            plist2.Add(new Supplier("Фирма Global Hardware", "555-8834"));
            plist2.Add(new Supplier("Агентство Computer Warehouse", "555-9256"));
            plist2.Add(new Supplier("Компания NetworkCity", "555-2564"));
            try
            {
                // Найти наименование поставщика по заданному номеру телефона.
                Supplier sp = plist2.FindByNumber("555-2564");
                Console.WriteLine(sp.Name + " " + sp.Number);
            }
            catch (NotFoundException)
            {
                Console.WriteLine("He найдено");
            }
            // Следующее объявление недопустимо, поскольку
            // класс EmailFriend НЕ наследует от класса PhoneNumber.
            // PhoneList<EmailFriend> plist3 =
            // new PhoneList<EmailFriend>(); // Ошибка!
        }
    }
}

namespace c30_6
{

    using System;
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


    // Базовый класс, в котором хранятся имя абонента и номер его телефона.
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
    // Класс для телефонных номеров друзей.
    class Friend : PhoneNumber
    {
        public Friend(string name, string number, bool isWorkNumber) : base(name, number)
        {
            IsWorkNumber = isWorkNumber;
        }
        public bool IsWorkNumber { get; private set; }
        // ...
    }

    class Colleagues : PhoneNumber
    {
        public Colleagues(string n, string num, bool wk) : base(n, num)
        {
            IsWorkNumber = wk;
        }
        public bool IsWorkNumber { get; private set; }
        // ...
    }

    


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
            if(end == 0)
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

    // Продемонстрировать наложение ограничений на базовый класс.
    class UseBaseClassConstraint
    {
        static void Main()
        {
            // Следующий код вполне допустим, поскольку
            // класс Friend наследует от класса PhoneNumber.
            PhoneList<Friend> plist = new PhoneList<Friend>();

            while (true)
            {
                Console.WriteLine("Команды:");
                Console.WriteLine("1: добавить контакт");
                Console.WriteLine("2: удалить контакт");
                Console.WriteLine("3: показать контакт");
                Console.WriteLine("4: изменить имя контакта");
                Console.WriteLine("5: изменить номер контакта");
                Console.WriteLine("6: показать количество контактов");
                Console.WriteLine("ESC: выход");

                char cmd = Console.ReadKey().KeyChar;
                Console.WriteLine();
                try
                {
                    switch (cmd)
                    {
                        case '1':
                            if (!AddFriend(plist))
                            {
                                return;
                            }
                            break;
                        case '2':
                            Console.WriteLine("Введите имя контакта: ");
                            plist.RemoveContact(Console.ReadLine());
                            break;
                        case '3':
                            Console.WriteLine("Введите имя контакта: ");
                            Show(plist, Console.ReadLine());
                            break;
                        case '4':
                            Console.WriteLine("Введите имя контакта: ");
                            plist.RenameContact(Console.ReadLine());
                            break;
                        case '5':
                            Console.WriteLine("Введите имя контакта: ");
                            plist.ChangePhoneContact(Console.ReadLine());
                            break;
                        case '6':
                            plist.ShowCountContact();
                            break;
                        case (char)27:
                            return;
                        default:
                            Console.WriteLine("Неверная команда");
                            break;
                    }
                    Console.WriteLine();
                }
                catch (EmptyFieldException)
                {
                    Console.WriteLine("Пустое поле\n");
                }
                catch (EmptyListException)
                {
                    Console.WriteLine("Пустой список контактов\n");
                }
                catch (NotFoundException)
                {
                    Console.WriteLine("Контакт не найден\n");
                }
            }


        }


        static PhoneNumber CreatePhoneNumber(Type phoneNumberType)
        {
            if (phoneNumberType == typeof(PhoneNumber))
            {
                Console.Write("Введите номер: ");
                string number = Console.ReadLine();
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                return new PhoneNumber(number, name);
            }
            else if (phoneNumberType == typeof(Friend))
            {
                PhoneNumber phoneNumber = CreatePhoneNumber(typeof(PhoneNumber));
                Console.WriteLine("Рабочий? (+/-): ");
                bool isWorkNumber = Convert.ToBoolean(Console.ReadLine());
                return new Friend(phoneNumber.Number, phoneNumber.Name, isWorkNumber);
            }
            throw new NotImplementedException();
        }




        static bool AddFriend(PhoneList<Friend> list)
        {

            string name, phone;
            bool work;
            Console.Write("Имя: ");
            name = Console.ReadLine();
            if (name == "") throw new EmptyFieldException();
            Console.Write("Телефон: ");
            phone = Console.ReadLine();
            if (phone == "") throw new EmptyFieldException();
            Console.Write("Рабочий? (+/-) ");
            work = Console.ReadKey().KeyChar == '+';
            Console.WriteLine();
            Friend contact = new Friend(name, phone, work);
            if (!list.Add(contact))
            {
                Console.WriteLine("нет места");
                return false;
            }
            Console.Write("Контакт сохранён: " + contact.Name + " " + contact.Number);
            if (contact.IsWorkNumber)
            {
                Console.WriteLine(" рабочий");
            }
            else Console.WriteLine();
            return true;
        }

        static void Show(PhoneList<Friend> list, string name)
        {
            try
            {
                Friend contact = list.FindByName(name);
                Console.Write("Имя " + contact.Name + " Тел. " + contact.Number);
                if (contact.IsWorkNumber)
                {
                    Console.WriteLine(" (рабочий)");
                }
                else Console.WriteLine();
            }
            catch (NotFoundException)
            {
                throw new NotFoundException();
            }
        }
      
    }
}

