using System;

namespace Study
{
    // Продемонстрировать наложение ограничений на базовый класс.
    internal class Handler
    {
        private static void Main() {
            new Handler().Run();
        }


        // Следующий код вполне допустим, поскольку
        // класс Friend наследует от класса PhoneNumber.
        private readonly PhoneList<PhoneNumber> phoneNumbers = new PhoneList<PhoneNumber>(2);


        public void Run() {
            while (true) {
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
                try {
                    switch (cmd) {
                        case '1':
                            AddContact();
                            break;

                        case '2':
                            DeleteContact();
                            break;

                        case '3':
                            ShowContact();
                            break;

                        case '4':
                            ChangeContactName();
                            break;

                        case '5':
                            ChangeContactPhone();
                            break;
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
                catch (Exception ex) {
                    WriteLine();
                    WriteLine("ОШИБКА: " + ex.Message);
                    WriteLine();
                }
            }
        }

        

        private void DeleteContact() {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Validate.IsNotEmpty(name, "Не введено имя.");

            if (phoneNumbers.RemoveContact(name)) {
                WriteLine("Удалено.");
            }
            else {
                WriteLine("Контакт не найден.");
            }
        }

        private void AddContact() {
            Validate.IsTrue(phoneNumbers.HasPlace, "Нет свободного места.");

            WriteLine("Тип контакта:");
            WriteLine("1 - Друзья");
            WriteLine("2 - Коллеги");
            char c = Console.ReadKey().KeyChar;
            WriteLine();
            switch (c) {
                case '1':
                    phoneNumbers.Add(CreatePhoneNumber(typeof(Friend)));
                    break;

                case '2':
                    phoneNumbers.Add(CreatePhoneNumber(typeof(Colleague)));
                    break;

                default:
                    throw CreateUncorrectCommandException();
            }
        }

        private void ChangeContactName() {
            Write("Введите имя: ");
            string name = Console.ReadLine();
            Validate.IsNotEmpty(name, "Не введено имя.");

            int index = phoneNumbers.FindIndexByName(name);
            Validate.IsTrue(index != -1, "Имя не найдено.");

            Write("Введите новое имя: ");
            string newName = Console.ReadLine();
            Validate.IsNotEmpty(newName, "Не введено новое имя.");

            phoneNumbers[index].Name = newName;
            WriteLine("Имя изменено.");
        }

        private void changecontactphone() {
            write("введите имя: ");
            string name = console.readline();
            validate.isnotempty(name, "не введено имя.");

            int index = phonenumbers.findindexbyname(name);
            validate.istrue(index != -1, "имя не найдено.");

            write("введите новый номер телефона: ");
            string newnumber = console.readline();
            validate.isnotempty(newnumber, "не введён номер телефона.");

            phonenumbers[index].number = newnumber;
            writeline("номер изменён.");
        }

        private void ShowContact() {
            Write("Введите имя: ");
            string name = Console.ReadLine();
            Validate.IsNotEmpty(name, "Не введено имя.");

            int index = phoneNumbers.FindIndexByName(name);
            Validate.IsTrue(index != -1, "Имя не найдено.");

            WriteNumberInfo(phoneNumbers[index]);
        }



        private PhoneNumber CreatePhoneNumber(Type phoneNumberType) {
            if (phoneNumberType == typeof(PhoneNumber)) {
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите номер: ");
                string number = Console.ReadLine();
                Validate.IsTrue(!ContainsLetters(number), "Номер содержит буквы.");
                return new PhoneNumber(number, name);
            } else if (phoneNumberType == typeof(Friend)) {
                PhoneNumber phoneNumber = CreatePhoneNumber(typeof(PhoneNumber));
                Console.Write("Рабочий? (+/-): ");
                bool isWorkNumber = Console.ReadKey().KeyChar == '+';
                return new Friend(phoneNumber.Number, phoneNumber.Name, isWorkNumber);
            } else if (phoneNumberType == typeof(Colleague)) {
                PhoneNumber phoneNumber = CreatePhoneNumber(typeof(PhoneNumber));
                Console.Write("E-Mail: ");
                string eMail = Console.ReadLine();
                return new Colleague(phoneNumber.Number, phoneNumber.Name, eMail);
            }

            throw new NotImplementedException();
        }

        private void WriteNumberInfo(PhoneNumber phoneNumber) {
            if (phoneNumber is Friend friend) {
                if (!friend.IsWorkNumber) {
                    WriteLine("Телефон: " + friend.Number);
                } else {
                    WriteLine("Рабочий телефон: " + friend.Number);
                }
            } else if (phoneNumber is Colleague colleague) {
                WriteLine("Телефон: " + colleague.Number);
                WriteLine("E-Mail: " + colleague.EMail);
            } else {
                throw new NotImplementedException();
            }
        }


        private void Write(string message = "") {
            //string pad = new string(' ', level * 4);
            Console.Write(message);
        }
        private void WriteLine(string message = "") {
            //string pad = new string(' ', level * 4);
            Console.WriteLine(message);
        }

        private Exception CreateUncorrectCommandException() {
            return new Exception("Введена неверная команда.");
        }

        private bool ContainsLetters(string value) {
            foreach (char c in value) {
                if (char.IsLetter(c)) {
                    return true;
                }
            }
            return false;
        }

    }
}

