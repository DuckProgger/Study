// Простой пример применения делегата.
using System;

// Объявить тип делегата.
delegate string StrMod(string str);

class DelegateTest
{
    // Заменить пробелы дефисами.
    static string ReplaceSpaces(string s)
    {
        Console.WriteLine("Замена пробелов дефисами.");
        return s.Replace(' ', '-');
    }
    // Удалить пробелы.
    static string RemoveSpaces(string s)
    {
        string temp = "";
        int i;
        Console.WriteLine("Удаление пробелов.");
        for (i = 0; i < s.Length; i++)
            if (s[i] != ' ') temp += s[i];
        return temp;
    }
    // Обратить строку.
    static string Reverse(string s)
    {
        string temp = "";
        int i;
        Console.WriteLine("Обращение строки.");
        for (i = s.Length - 1; i >= 0; i--)
            temp += s[i];
        return temp;
    }
    static void test()
    {
        // Сконструировать делегат.
        StrMod strOp = ReplaceSpaces;
        string str;
        // Вызвать методы с помощью делегата.
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

// Делегаты могут ссылаться и на методы экземпляра.
class StringOps
{
    // Заменить пробелы дефисами.
    public string ReplaceSpaces(string s)
    {
        Console.WriteLine("Замена пробелов дефисами.");
        return s.Replace(' ', '-');
    }
    // Удалить пробелы.
    public string RemoveSpaces(string s)
    {
        string temp = "";
        int i;
        Console.WriteLine("Удаление пробелов.");
        for (i = 0; i < s.Length; i++)
            if (s[i] != ' ') temp += s[i];
        return temp;
    }
    // Обратить строку.
    public string Reverse(string s)
    {
        string temp = "";
        int i, j;
        Console.WriteLine("Обращение строки.");
        for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
            temp += s[i];
        return temp;
    }
}
class DelegateTest2
{
    static void test()
    {
        StringOps so = new StringOps(); // создать экземпляр
                                        // объекта класса StringOps
                                        // Инициализировать делегат.
        StrMod strOp = so.ReplaceSpaces;
        string str;
        // Вызвать методы с помощью делегатов.
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();
        strOp = so.RemoveSpaces;
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();
        strOp = so.Reverse;
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
    }
}

// Продемонстрировать групповую адресацию.
// Объявить тип делегата.
delegate void StrMod2(ref string str);

class MultiCastDemo
{
    // Заменить пробелы дефисами.
    static void ReplaceSpaces(ref string s)
    {
        Console.WriteLine("Замена пробелов дефисами.");
        s = s.Replace(' ', '-');
    }
    // Удалить пробелы.
    static void RemoveSpaces(ref string s)
    {
        string temp = "";
        int i;
        Console.WriteLine("Удаление пробелов.");
        for (i = 0; i < s.Length; i++)
            if (s[i] != ' ') temp += s[i];
        s = temp;
    }
    // Обратить строку.
    static void Reverse(ref string s)
    {
        string temp = "";
        int i, j;
        Console.WriteLine("Обращение строки.");
        for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
            temp += s[i];
        s = temp;
    }
    static void test()
    {
        // Сконструировать делегаты.
        StrMod2 strOp;
        StrMod2 replaceSp = ReplaceSpaces;
        StrMod2 removeSp = RemoveSpaces;
        StrMod2 reverseStr = Reverse;
        string str = "Это простой тест.";
        // Организовать групповую адресацию.
        strOp = replaceSp;
        strOp += reverseStr;
        // Обратиться к делегату с групповой адресацией.
        strOp(ref str);
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();
        // Удалить метод замены пробелов и добавить метод удаления пробелов.
        strOp -= replaceSp;
        strOp += removeSp;
        str = "Это простой тест."; // восстановить исходную строку
                                   // Обратиться к делегату с групповой адресацией.
        strOp(ref str);
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();
    }
}

class X2
{
    public int Val;
}
// Класс Y, производный от класса X.
class Y2 : X2 { }

// Этот делегат возвращает объект класса X и
// принимает объект класса Y в качестве аргумента.
delegate X2 ChangeIt(Y2 obj);

class CoContraVariance
{
    // Этот метод возвращает объект класса X и
    // имеет объект класса X в качестве параметра.
    static X2 IncrA(X2 obj)
    {
        X2 temp = new X2();
        temp.Val = obj.Val + 1;
        return temp;
    }
    // Этот метод возвращает объект класса Y и
    // имеет объект класса Y в качестве параметра.
    static Y2 IncrB(Y2 obj)
    {
        Y2 temp = new Y2();
        temp.Val = obj.Val + 1;
        return temp;
    }
    static void test()
    {
        Y2 Yob = new Y2();
        // В данном случае параметром метода IncrA является объект класса X,
        // а параметром делегата ChangeIt — объект класса Y. Но благодаря
        // контравариантности следующая строка кода вполне допустима.
        ChangeIt change = IncrA;
        X2 Xob = change(Yob);
        Console.WriteLine("Xob: " + Xob.Val);
        // В этом случае возвращаемым типом метода IncrB служит объект класса Y,
        // а возвращаемым типом делегата ChangeIt — объект класса X. Но благодаря
        // ковариантности следующая строка кода оказывается вполне допустимой.
        change = IncrB;
        Yob = (Y2)change(Yob);
        Console.WriteLine("Yob: " + Yob.Val);
    }
}


// Анонимный метод
// Объявить тип делегата.
delegate void CountIt();
class AnonMethDemo
{
    static void test()
    {
        // Далее следует код для подсчета чисел, передаваемый делегату
        // в качестве анонимного метода.
        CountIt count = delegate {
            // Этот кодовый блок передается делегату.
            for (int i = 0; i <= 5; i++)
                Console.WriteLine(i);
        }; // обратите внимание на точку с запятой
        count();
    }
}

// Анонимный метод, принимающий аргумент.
delegate void CountIt2(int end);
class AnonMethDemo2
{
    static void test()
    {
        // Здесь конечное значение для подсчета передается анонимному методу.
        CountIt2 count = delegate (int end) {
            for (int i = 0; i <= end; i++)
                Console.WriteLine(i);
        };
        count(3);
        Console.WriteLine();
        count(5);
    }
}

// Этот делегат возвращает значение.
delegate int CountIt3(int end);
class AnonMethDemo3
{
    static void test()
    {
        int result;
        // Здесь конечное значение для подсчета перелается анонимному методу.
        // А возвращается сумма подсчитанных чисел.
        CountIt3 count = delegate (int end) {
            int sum = 0;
            for (int i = 0; i <= end; i++)
            {
                Console.WriteLine(i);
                sum += i;
            }
            return sum; // возвратить значение из анонимного метода
        };
        result = count(3);
        Console.WriteLine("Сумма 3 равна " + result);
        Console.WriteLine();
        result = count(5);
        Console.WriteLine("Сумма 5 равна " + result);
    }
}

// Захваченная переменная
// Этот делегат возвращает значение типа int и принимает аргумент типа int.
delegate int CountIt4(int end);
class VarCapture
{
    static CountIt4 Counter()
    {
        int sum = 0;
        // Здесь подсчитанная сумма сохраняется в переменной sum.
        CountIt4 ctObj = delegate (int end) 
        {
            for (int i = 0; i <= end; i++)
            {
                Console.WriteLine(i);
                sum += i;
            }
            return sum;
        };
        return ctObj;
    }
    static void test()
    {
        // Получить результат подсчета.
        CountIt4 count = Counter();
        int result;
        result = count(3);
        Console.WriteLine("Сумма 3 равна " + result);
        Console.WriteLine();
        result = count(5);
        Console.WriteLine("Сумма 5 равна " + result);
    }
}

