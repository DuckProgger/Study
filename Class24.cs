// Применить два одиночных лямбда-выражения.
using System;

// Объявить делегат, принимающий аргумент типа int и
// возвращающий результат типа int.
delegate int Incr(int v);

// Объявить делегат, принимающий аргумент типа int и
// возвращающий результат типа bool.
delegate bool IsEven(int v);

class SimpleLambdaDemo
{
    static void test()
    {
        // Создать делегат Incr, ссылающийся на лямбда-выражение.
        // увеличивающее свой параметр на 2.
        Incr incr = count => count + 2;
        // А теперь использовать лямбда-выражение incr.
        Console.WriteLine("Использование лямбда-выражения incr: ");
        int x = -10;
        while (x <= 0)
        {
            Console.Write(x + " ");
            x = incr(x); // увеличить значение x на 2
        }
        Console.WriteLine("\n");
        // Создать экземпляр делегата IsEven, ссылающийся на лямбда-выражение,
        // возвращающее логическое значение true, если его параметр имеет четное
        // значение, а иначе — логическое значение false.
        IsEven isEven = n => n % 2 == 0;
        // А теперь использовать лямбда-выражение isEven.
        Console.WriteLine("Использование лямбда-выражения isEven: ");
        for (int i = 1; i <= 10; i++)
            if (isEven(i)) Console.WriteLine(i + " четное.");
    }
}

// Блочное лямбда-выражение

// Делегат IntOp принимает один аргумент типа int
// и возвращает результат типа int.
delegate int IntOp(int end);

class StatementLambdaDemo
{
    static void test()
    {
        // Блочное лямбда-выражение возвращает факториал
        // передаваемого ему значения.
        IntOp fact = n => {
            int r = 1;
            for (int i = 1; i <= n; i++)
                r = i * r;
            return r;
        };
        Console.WriteLine("Факториал 3 равен " + fact(3));
        Console.WriteLine("Факториал 5 равен " + fact(5));
    }
}

// Первый пример применения делегатов, переделанный с
// целью использовать блочные лямбда-выражения.
// Объявить тип делегата.
delegate string StrMod3(string s);
class UseStatementLambdas
{
    static void test()
    {
        // Создать делегаты, ссылающиеся на лямбда- выражения,
        // выполняющие различные операции с символьными строками.
        // Заменить пробелы дефисами.
        StrMod3 ReplaceSpaces = s => {
            Console.WriteLine("Замена пробелов дефисами.");
            return s.Replace(' ', '-');
        };
        // Удалить пробелы.
        StrMod3 RemoveSpaces = s => {
            string temp = "";
            int i;
            Console.WriteLine("Удаление пробелов.");
            for (i = 0; i < s.Length; i++)
                if (s[i] != ' ') temp += s[i];
            return temp;
        };
        // Обратить строку.
        StrMod3 Reverse = s => {
            string temp = "";
            int i, j;
            Console.WriteLine("Обращение строки.");
            for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
                temp += s[i];
            return temp;
        };
        string str;
        // Обратиться к лямбда-выражениям с помощью делегатов.
        StrMod3 strOp = ReplaceSpaces;
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();
        strOp = RemoveSpaces;
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();
        strOp = Reverse;
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
    }
}

// Применить Callback метод
namespace UsingCallback
{
    class Callback
    {
        public delegate double OperationHandle(double value);
        static void test()
        {
            double value;
            value = ValueOperation(5.0, val => val * val); // добавление обработчика с помощью лямбда-выражения
            value = ValueOperation(10.0, Sum); // добавление обработчика с помощью стороннего метода
        }

        static double Sum(double val)
        {
            return val + val;
        }

        static double ValueOperation(double value, OperationHandle handle) // здесь в качестве первого аргумета выступает число,
                                                                           // над которым будет совершён неизвестый методу ряд действий,
                                                                           // который содержится в передаваемом вторым аргументом делегате
        {
            if (handle == null)
            {
                throw new NotImplementedException("Отсутствуют обработчики");
            }
            double result = handle(value);
            Console.WriteLine(result);
            return result;
        }
    }
}
