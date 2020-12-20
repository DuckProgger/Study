using System;

namespace Study
{
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

