using System;

namespace Study
{
    // Продемонстрировать наложение ограничений на базовый класс.
    class UseBaseClassConstraint
    {
        static void Main()
        {
            new UseBaseClassConstraint().Run();
        }


        // Следующий код вполне допустим, поскольку
        // класс Friend наследует от класса PhoneNumber.
        private PhoneList<PhoneNumber> phoneNumbers = new PhoneList<PhoneNumber>(2);


        public void Run()
        {
            while (true)
            {
                WriteLine("Команды:");
                WriteLine("1: добавить контакт");
                WriteLine("2: удалить контакт");
                WriteLine("3: показать контакт");
                WriteLine("4: изменить имя контакта");
                WriteLine("5: изменить номер контакта");
                WriteLine("6: показать количество контактов");
                WriteLine("ESC: выход");

                char cmd = Console.ReadKey().KeyChar;
                Console.WriteLine();
                try
                {
                    switch (cmd)
                    {
                        case '1':
                            AddContact();
                            break;

                        //case '2':
                        //    Console.WriteLine("Введите имя контакта: ");
                        //    plist.RemoveContact(Console.ReadLine());
                        //    break;
                        //case '3':
                        //    Console.WriteLine("Введите имя контакта: ");
                        //    Show(Console.ReadLine());
                        //    break;
                        //case '4':
                        //    Console.WriteLine("Введите имя контакта: ");
                        //    plist.RenameContact(Console.ReadLine());
                        //    break;
                        //case '5':
                        //    Console.WriteLine("Введите имя контакта: ");
                        //    plist.ChangePhoneContact(Console.ReadLine());
                        //    break;
                        //case '6':
                        //    plist.ShowCountContact();
                        //    break;
                        //case (char)27:
                        //    return;

                        default:
                            Console.WriteLine("Неверная команда");
                            break;
                    }
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    WriteLine();
                    WriteLine("ОШИБКА: " + ex.Message);
                    WriteLine();
                }
            }
        }

        private void AddContact()
        {
            Validate.IsTrue(phoneNumbers.HasPlace, "Нет свободного места.");

            WriteLine("Тип контакта:");
            WriteLine("1 - Друзья");
            WriteLine("2 - Коллеги");
            char c = Console.ReadKey().KeyChar;
            switch (c)
            {
                case '1':
                    WriteLine("");
                    phoneNumbers.Add(CreatePhoneNumber(typeof(Friend)));
                    break;

                case '2':
                    phoneNumbers.Add(CreatePhoneNumber(typeof(Colleague)));
                    break;

                default:
                    throw CreateUncorrectCommandException();
            }
        }

        private PhoneNumber CreatePhoneNumber(Type phoneNumberType)
        {
            if (phoneNumberType == typeof(PhoneNumber))
            {
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите номер: ");
                string number = Console.ReadLine();
                Validate.IsTrue(!ContainsLetters(number), "Номер содержит буквы.");
                return new PhoneNumber(number, name);
            }
            else if (phoneNumberType == typeof(Friend))
            {
                PhoneNumber phoneNumber = CreatePhoneNumber(typeof(PhoneNumber));
                Console.Write("Рабочий? (+/-): ");
                bool isWorkNumber = Console.ReadLine() == "+";
                return new Friend(phoneNumber.Number, phoneNumber.Name, isWorkNumber);
            }
            throw new NotImplementedException();
        }



        private void WriteLine(string message = "")
        {
            //string pad = new string(' ', level * 4);
            Console.WriteLine(message);
        }

        private Exception CreateUncorrectCommandException()
        {
            return new Exception("Введена неверная команда.");
        }

        private bool ContainsLetters(string value)
        {
            foreach (char c in value)
            {
                if (char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }

    }
}

