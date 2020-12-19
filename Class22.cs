// Прочитать введенную с клавиатуры строку
// непосредственно из потока Console.In.
using System;
using System.IO;


class ReadChars2
{ 
    static void test()
    {
        string str;
        Console.WriteLine("Введите несколько символов.");
        str = Console.In.ReadLine(); // вызвать метод ReadLine() класса TextReader
        Console.WriteLine("Вы ввели: " + str);
    }
}


class ReadKeys
{
    static void test()
    {
        ConsoleKeyInfo keypress;
        Console.WriteLine("Введите несколько символов, а по окончании - <Q>.");
        do
        {
            keypress = Console.ReadKey(); // считать данные о нажатых клавишах
            Console.WriteLine(" Вы нажали клавишу: " + keypress.KeyChar);
            // Проверить нажатие модифицирующих клавиш.
            if ((ConsoleModifiers.Alt & keypress.Modifiers) != 0)
                Console.WriteLine("Нажата клавиша <Alt>. " + (int)keypress.Modifiers);
            if ((ConsoleModifiers.Control & keypress.Modifiers) != 0)
                Console.WriteLine("Нажата клавиша <Control>. " + (int)keypress.Modifiers);
            if ((ConsoleModifiers.Shift & keypress.Modifiers) != 0)
                Console.WriteLine("Нажата клавиша <Shift>. " + (int)keypress.Modifiers);
            if ((int)keypress.Modifiers != 0)
                Console.WriteLine((int)keypress.Modifiers);
        } while (keypress.KeyChar != 'Q');
    }

}

// Организовать вывод в потоки Console.Out и Console.Error.
class ErrOut
{
    static void test()
    {
        int a = 10, b = 0;
        int result;
        Console.Out.WriteLine("Деление на нуль приведет " + "к исключительной ситуации.");
        try
        {
            result = a / b; // сгенерировать исключение при попытке деления на нуль
        }
        catch (DivideByZeroException exc)
        {
            Console.Error.WriteLine(exc.Message); // поток типа Error можно переадресовать (например, для записи в файл, а не просто для вывода на экран)
        }
    }
}

// Отобразить содержимое текстового файла.
class ShowFile
{
    static void test()
    {
        Console.WriteLine("Введите полный путь к файлу");
        string str = Console.ReadLine();
        int i;
        FileStream fin = null;
        // Использовать один блок try для открытия файла и чтения из него
        try
        {
            fin = new FileStream(str, FileMode.Open);
            // Читать байты до конца файла.
            while ((i = fin.ReadByte()) != -1)
            {
               Console.Write((char)i);
            }
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
        }
        finally
        {
            if (fin != null) fin.Close();
        }
    }
}

// Записать данные в файл.
class WriteToFile
{
    static void test()
    {
        FileStream fout = null;
        /*
        try
        {
            // Открыть выходной файл.
            fout = new FileStream("C:\\test.txt", FileMode.Create, FileAccess.ReadWrite);
            // Записать весь английский алфавит в файл.
            for (char c = 'A'; c <= 'Z'; c++)
                fout.WriteByte((byte)c);
            int i = fout.ReadByte();
            Console.WriteLine(i);
        }
        catch (Exception exc)
        {
            Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
        }
        finally
        {
            if (fout != null) fout.Close();
        }*/

        try
        {
            // Открыть выходной файл.
            fout = new FileStream("test.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter foutWriter = new StreamWriter(fout);

            // Записать весь английский алфавит в файл.
            for (char c = 'A'; c <= 'Z'; c++)
            {
                foutWriter.Write(c);
            }

        }
        catch (Exception exc)
        {
            Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
        }
        finally
        {
            if (fout != null)
            {
                fout.Close();
            }
        }

    }
}

// Копировать файл.

class CopyFile
{
    static void test()
    {
        string strFrom, strTo;
        Console.WriteLine("Путь файла, который нужно скопировать:");
        strFrom = Console.ReadLine();
        Console.WriteLine("Путь файла, в который нужно скопировать:");
        strTo = Console.ReadLine();
        int i;
        FileStream fin = null;
        FileStream fout = null;

        try
        {
            // Открыть файлы.
            fin = new FileStream(strFrom, FileMode.Open);
            fout = new FileStream(strTo, FileMode.Create);
            // Скопировать файл.
            while ((i = fin.ReadByte()) != -1)
            {
                fout.WriteByte((byte)i);
            }
            Console.WriteLine("Копирование завершено!");

        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
        }
        finally
        {
            if (fin != null) fin.Close();
            if (fout != null) fout.Close();
        }
    }
}

// Простая сервисная программа ввода с клавиатуры и вывода на диск,
// демонстрирующая применение класса StreamWriter.
class KtoD
{
    static void test()
    {
        string str;
        FileStream fout;
        // Открыть сначала поток файлового ввода-вывода.
        try
        {
            fout = new FileStream("test.txt", FileMode.Create);
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка открытия файла:\n" + exc.Message);
            return;
        }
        // Заключить поток файлового ввода-вывода в оболочку класса StreamWriter.
        StreamWriter fstr_out = new StreamWriter(fout);
        try
        {
            Console.WriteLine("Введите текст, а по окончании — 'стоп'.");
            do
            {
                Console.Write(": ");
                str = Console.ReadLine();
                if (str != "стоп")
                {
                    str = str + "\r\n"; // добавить новую строку
                    fstr_out.Write(str);
                }
            } while (str != "стоп");
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
        }
        finally
        {
            fstr_out.Close();
        }
    }
}

// Открыть файл средствами класса StreamWriter.
class KtoDStreamWriter
{
    static void test()
    {
        string str;
        StreamWriter fstr_out = null;
        try
        {
            // Открыть файл, заключенный в оболочку класса StreamWriter.
            fstr_out = new StreamWriter("test.txt");
            Console.WriteLine("Введите текст, а по окончании — 'стоп'.");
            do
            {
                Console.Write(" : ");
                str = Console.ReadLine();
                if (str != "стоп")
                {
                    str = str + "\r\n"; // добавить новую строку
                    fstr_out.Write(str);
                }
            } while (str != "стоп");
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
        }
        finally
        {
            if (fstr_out != null) fstr_out.Close();
        }
    }
}

// Простая сервисная программа ввода с диска и вывода на экран,
// демонстрирующая применение класса StreamReader.
class DtoS
{
    static void test()
    {
        FileStream fin;
        try
        {
            fin = new FileStream("C:\\test2.txt", FileMode.Open);
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка открытия файла:\n" + exc.Message);
            return;
        }
        StreamReader fstr_in = new StreamReader(fin);
        try
        {
            while (!fstr_in.EndOfStream)
            {
                Console.WriteLine(fstr_in.ReadLine());            
            }
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
        }
        finally
        {
            fstr_in.Close();
        }
    }
}

// Переадресовать поток Console.Out.
class Redirect
{
    static void test()
    {
        StreamWriter log_out = null;
        try
        {
            log_out = new StreamWriter("C:\\logfile.txt");
            // Переадресовать стандартный вывод в файл logfile.txt.
            Console.SetOut(log_out);
            Console.WriteLine("Это начало файла журнала регистрации.");
            for (int i = 0; i < 10; i++) Console.WriteLine(i);
            Console.WriteLine("Это конец файла журнала регистрации.");
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка ввода-вывода\n" + exc.Message);
        }
        finally
        {
            log_out?.Close();
        }
    }
}

// Чтение потока из файла и вывод на консоль с помощью переадресации
class Redirect2
{
    static void test()
    {
        StreamReader log_in = null;
        try
        {
            log_in = new StreamReader("C:\\test.txt");
            Console.SetIn(log_in);
            while (!log_in.EndOfStream)
            {
                Console.Write((char)Console.Read());
            }
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ашипка" + exc.Message);
        }
        finally
        {
            log_in?.Close();
        }
    }
}

// Использование двоичного потока
class RWData
{
    static void test()
    {
        BinaryWriter dataOut;
        BinaryReader dataIn;
        int i = 10;
        double d = 1023.56;
        bool b = true;
        string str = "Это тест";
        // Открыть файл для вывода.
        try
        {
            dataOut = new
            BinaryWriter(new FileStream("C:\\testdata", FileMode.Create));
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка открытия файла:\n" + exc.Message);
            return;
        }
        // Записать данные в файл.
        try
        {
            Console.WriteLine("Запись " + i);
            dataOut.Write(i);
            Console.WriteLine("Запись " + d);
            dataOut.Write(d);
            Console.WriteLine("Запись " + b);
            dataOut.Write(b);           
            Console.WriteLine("Запись " + 12.2 * 7.4);
            dataOut.Write(12.2 * 7.4);
            Console.WriteLine("Запись " + str);
            dataOut.Write(str);
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
        }
        finally
        {
            dataOut.Close();
        }
        Console.WriteLine();
        // А теперь прочитать данные из файла.
        try
        {
            dataIn = new
            BinaryReader(new FileStream("C:\\testdata", FileMode.Open));
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка открытия файла:\n" + exc.Message);
            return;
        }
        try
        {
            i = dataIn.ReadInt32();
            Console.WriteLine("Чтение " + i);
            d = dataIn.ReadDouble();
            Console.WriteLine("Чтение " + d);
            b = dataIn.ReadBoolean();
            Console.WriteLine("Чтение " + b);
            d = dataIn.ReadDouble();
            Console.WriteLine("Чтение " + d);
            str = dataIn.ReadString();
            Console.WriteLine("Чтение " + str);
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
        }
        finally
        {
            dataIn.Close();
        }
    }
}

/* Использовать классы BinaryReader и BinaryWriter для
реализации простой программы учета товарных запасов. */
class Inventory
{
    static void test()
    {
        BinaryWriter dataOut;
        BinaryReader dataIn;
        string item; // наименование предмета
        int onhand; // имеющееся в наличии количество
        double cost; // цена
        try
        {
            dataOut = new
            BinaryWriter(new FileStream("inventory.dat", FileMode.Create));
        }
        catch (IOException exc)
        {
            Console.WriteLine("He удается открыть файл " +
            "товарных запасов для вывода");
            Console.WriteLine("Причина: " + exc.Message);
            return;
        }
        // Записать данные о товарных запасах в файл.
        try
        {
            dataOut.Write("Молотки");
            dataOut.Write(10);
            dataOut.Write(3.95);
            dataOut.Write("Отвертки");
            dataOut.Write(18);
            dataOut.Write(1.50);
            dataOut.Write("Плоскогубцы");
            dataOut.Write(5);
            dataOut.Write(4.95);
            dataOut.Write("Пилы");
            dataOut.Write(8);
            dataOut.Write(8.95);
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка записи в файл товарных запасов");
            Console.WriteLine("Причина: " + exc.Message);
        }
        finally
        {
            dataOut.Close();
        }
        Console.WriteLine();
        // А теперь открыть файл товарных запасов для чтения.
        try
        {
            dataIn = new
            BinaryReader(new FileStream("inventory.dat", FileMode.Open));
        }
        catch (IOException exc)
        {
            Console.WriteLine("He удается открыть файл " +
            "товарных запасов для ввода");
            Console.WriteLine("Причина: " + exc.Message);
            return;
        }
        // Найти предмет, введенный пользователем.
        Console.Write("Введите наименование для поиска: ");
        string what = Console.ReadLine();
        Console.WriteLine();
        try
        {
            for (; ; )
            {
                // Читать данные о предмете хранения.
                item = dataIn.ReadString();
                onhand = dataIn.ReadInt32();
                cost = dataIn.ReadDouble();
                // Проверить, совпадает ли он с запрашиваемым предметом.
                // Если совпадает, то отобразить сведения о нем.
                if (item.Equals(what, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(item + ": " + onhand + " штук в наличии. " +
                    "Цена: {0:C} за штуку", cost);
                    Console.WriteLine("Общая стоимость по наименованию <{0}>: {1:C}.",
                    item, cost * onhand);
                    break;
                }
            }
        }
        catch (EndOfStreamException)
        {
            Console.WriteLine("Предмет не найден.");
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка чтения из файла товарных запасов");
            Console.WriteLine("Причина: " + exc.Message);
        }
        finally
        {
            dataIn.Close();
        }
    }
}

// Продемонстрировать произвольный доступ к файлу.
class RandomAccessDemo
{
    static void test()
    {
        FileStream f = null;
        char ch;
        try
        {
            f = new FileStream("random.dat", FileMode.Create);
            // Записать английский алфавит в файл.
            for (int i = 0; i < 26; i++)
                f.WriteByte((byte)('A' + i));
            // А теперь считать отдельные буквы английского алфавита.
            f.Seek(0, SeekOrigin.Begin); // найти первый байт
            ch = (char)f.ReadByte();
            Console.WriteLine("Первая буква: " + ch);
            f.Seek(1, SeekOrigin.Begin); // найти второй байт
            ch = (char)f.ReadByte();
            Console.WriteLine("Вторая буква: " + ch);
            f.Seek(4, SeekOrigin.Begin); // найти пятый байт
            ch = (char)f.ReadByte();
            Console.WriteLine("Пятая буква: " + ch);
            Console.WriteLine();
            // А теперь прочитать буквы английского алфавита через одну.
            Console.WriteLine("Буквы алфавита через одну: ");
            for (int i = 0; i < 26; i += 2)
            {
                f.Seek(i, SeekOrigin.Begin); // найти i-й символ
                // удобней использовать метод Position (f.Position = i;)
                ch = (char)f.ReadByte();
                Console.Write(ch + " ");
            }
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка ввода-вывода\n" + exc.Message);
        }
        finally
        {
            if (f != null) f.Close();
        }
        Console.WriteLine();
    }
}

// Продемонстрировать применение класса MemoryStream.
class MemStrDemo
{
    static void test()
    {
        byte[] storage = new byte[255];
        // Создать запоминающий поток.
        MemoryStream memstrm = new MemoryStream(storage);
        // Заключить объект memstrm в оболочки классов
        // чтения и записи данных в потоки.
        StreamWriter memwtr = new StreamWriter(memstrm);
        StreamReader memrdr = new StreamReader(memstrm);
        try
        {
            // Записать данные в память, используя объект memwtr.
            for (int i = 0; i < 10; i++)
                memwtr.WriteLine("byte [" + i + "]: " + i);
            // Поставить в конце точку.
            memwtr.WriteLine(".");
            memwtr.Flush();
            Console.WriteLine("Чтение прямо из массива storage: ");
            // Отобразить содержимое массива storage непосредственно,
            foreach (char ch in storage)
            {
                if (ch == '.') break;
                Console.Write(ch);
            }
            Console.WriteLine("\nЧтение из потока с помощью объекта memrdr: ");
            // Читать из объекта memstrm средствами ввода данных из потока.
            memstrm.Seek(0, SeekOrigin.Begin); // установить указатель файла
                                               // в исходное положение
            string str;
            do
            {
                str = memrdr.ReadLine();
                if (str[0] == '.') break;
                Console.WriteLine(str);
            } while (str != null);
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка ввода-вывода\n" + exc.Message);
        }
        finally
        {
            // Освободить ресурсы считывающего и записывающего потоков.
            memwtr.Close();
            memrdr.Close();
        }
    }

    /*С помощью запоминающих потоков можно, например, организовать сложный вывод с предварительным накоплением
      данных в массиве до тех пор, пока они не понадобятся.*/
}

// Продемонстрировать применение классов StringReader и StringWriter.
// Это то же самое, что MemoryStream, только поток не байтовый, а строчный
class StrRdrWtrDemo
{
    static void test()
    {
        StringWriter strwtr = null;
        StringReader strrdr = null;
        try
        {
            // Создать объект класса StringWriter.
            strwtr = new StringWriter();
            // Вывести данные в записывающий поток типа StringWriter.
            for (int i = 0; i < 10; i++)
                strwtr.WriteLine("Значение i равно: " + i);
            // Создать объект класса StringReader.
            strrdr = new StringReader(strwtr.ToString());
            //А теперь ввести данные из считывающего потока типа StringReader.
            string str = strrdr.ReadLine();
            while (str != null)
            {
                str = strrdr.ReadLine();
                Console.WriteLine(str);
            }
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка ввода-вывода\n" + exc.Message);
        }
        finally
        {
            // Освободить ресурсы считывающего и записывающего потоков.
            if (strrdr != null) strrdr.Close();
            if (strwtr != null) strwtr.Close();
        }
    }
}

/* Скопировать файл, используя метод File.Copy().
Чтобы воспользоваться этой программой, укажите имя исходного и целевого
файлов. Например, чтобы скопировать файл FIRST.DAT в файл SECOND.DAT,
введите в командной строке следующее:
CopyFile FIRST.DAT SECOND.DAT
*/
class CopyFile2
{
    static void test()
    {
        string from = Console.ReadLine();
        string to = Console.ReadLine();
        // Копировать файлы.
        try
        {
            File.Copy(from, to, true);
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка копирования файла\n" + exc.Message);
        }
    }
}

// Применить методы Exists() и GetLastAccessTime().
class ExistsDemo
{
    static void test()
    {
        if (File.Exists("test.txt"))
        {
            Console.WriteLine("Файл существует. В последний раз он был доступен " + File.GetLastAccessTime("test.txt"));
            Console.WriteLine("Создан " + File.GetCreationTime("test.txt"));
            Console.WriteLine("Изменён " + File.GetLastWriteTime("test.txt"));
        }

        else
            Console.WriteLine("Файл не существует");
    }
}

// Эта программа усредняет ряд чисел, вводимых пользователем.
class AvgNums
{
    static void test()
    {
        string str;
        int n;
        double sum = 0.0;
        double avg, t;
        Console.Write("Сколько чисел вы собираетесь ввести: ");
        str = Console.ReadLine();
        try
        {
            n = Int32.Parse(str);
        }
        catch (FormatException exc)
        {
            Console.WriteLine(exc.Message);
            return;
        }
        catch (OverflowException exc)
        {
            Console.WriteLine(exc.Message);
            return;
        }
        Console.WriteLine("Введите " + n + " чисел.");
        for (int i = 0; i < n; i++)
        {
            Console.Write(": ");
            str = Console.ReadLine();
            try
            {
                t = Double.Parse(str);
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
                t = 0.0;
            }
            catch (OverflowException exc)
            {
                Console.WriteLine(exc.Message);
                t = 0;
            }
            sum += t;
        }
        avg = sum / n;
        Console.WriteLine("Среднее равно " + avg);
    }
}