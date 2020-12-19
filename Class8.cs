using System;

class Factorial
{
    // Это рекурсивный метод.
    public int FactR(int n)
    {
        int result;
        if (n == 1) return 1;
        result = FactR(n - 1) * n;
        Console.WriteLine(result);
        return result;
    }
    // Это итерационный метод.
    public int FactI(int n)
    {
        int t, result;
        result = 1;
        for (t = 1; t <= n; t++)
        {
            result *= t;
            Console.WriteLine(result);
        }
        return result;
    }
}

class RevStr
{
    // Вывести символьную строку в обратном порядке.

    public void DisplayRev(string str)
    {
        if (str.Length > 0)
            DisplayRev(str.Substring(1, str.Length - 1));
        else
            return;
        Console.Write(str[0]);
    }
}
class Recursion
{
    static void test()
    {
        
        Factorial f = new Factorial();
        Console.WriteLine("Факториалы, рассчитанные рекурсивным методом.");
        Console.WriteLine("Факториал числа 5 равен " + f.FactR(5));
        Console.WriteLine();

        Console.WriteLine("Факториалы, рассчитанные итерационным методом.");
        Console.WriteLine("Факториал числа 5 равен " + f.FactI(5));
        Console.WriteLine();

        string s = "Это тест";
        RevStr rsOb = new RevStr();
        Console.WriteLine("Исходная строка: " + s);
        Console.Write("Перевернутая строка: ");
        rsOb.DisplayRev(s);
        
    }
}