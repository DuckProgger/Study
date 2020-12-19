// Интерфейсы

using System;

public interface ISeries
{
    int GetNext(); // возвратить следующее по порядку число
    void Reset(); // перезапустить
    void SetStart(int х); // задать начальное значение
}

class ByTwos : ISeries
{
    int start;
    int val;
    public ByTwos()
    {
        start = 0;
        val = 0;
    }
    public int GetNext()
    {
        val += 2;
        return val;
    }
    public void Reset()
    {
        val = start;
    }
    public void SetStart(int x)
    {
        start = x;
        val = start;
    }
    // Метод, не указанный в интерфейсе ISeries.
    public int GetPrevious()
    {
        return val -= 2;
    }
}

class Primes : ISeries
{
    public int count
    {
        get
        {
            return c;
        }
        private set
        {
            c = value;
        }
    }
    int start, val, c;
    public Primes()
    {
        start = 2;
        val = 2;
    }
    public int GetNext()
    {
        int i, j;
        bool isprime;
        val++;
        for (i = val; i < 1000000; i++)
        {
            isprime = true;
            for (j = 2; j <= Math.Sqrt(i); j++)
            {
                Console.Write("{0} - {1}\n", i , j);
                c++;
                if ((i % j) == 0)
                {
                    isprime = false;
                    break;
                }
            }
            if (isprime)
            {
                val = i;
                break;
            }
        }
        return val;
    }
    public void Reset()
    {
        val = start;
    }
    public void SetStart(int x)
    {
        start = x;
        val = start;
    }
}

class SeriesDemo
{

    static void test()
    {
        ByTwos ob = new ByTwos();
        for (int i = 0; i < 5; i++)
            Console.WriteLine("Следующее число равно " + ob.GetNext());
        Console.WriteLine("\nСбросить");
        ob.Reset();
        for (int i = 0; i < 5; i++)
            Console.WriteLine("Следующее число равно " + ob.GetPrevious());
        Console.WriteLine("\nНачать с числа 100");
        ob.SetStart(100);
        for (int i = 0; i < 5; i++)
            Console.WriteLine("Следующее число равно " + ob.GetNext());
        Console.WriteLine();

        Primes ob2 = new Primes();
        for (int i = 0; i < 5000; i++)
            Console.WriteLine("Следующее число равно " + ob2.GetNext());
        Console.WriteLine("Кол-во итераций: {0}\n", ob2.count);
        Console.WriteLine("\nСбросить");
        ob.Reset();
        ob.SetStart(100);
        for (int i = 0; i < 5; i++)
            Console.WriteLine("Следующее число равно " + ob.GetNext());
    }
}

// Воспользоваться явной реализацией для устранения неоднозначности.
interface IMyIF_A
{
    int Meth(int x);
}
interface IMyIF_B
{
    int Meth(int x);
}
// Оба интерфейса реализуются в классе MyClass.
class MyClassIF : IMyIF_A, IMyIF_B
{
    // Реализовать оба метода Meth() явно.
    int IMyIF_A.Meth(int x)
    {
        return x + x;
    }
    int IMyIF_B.Meth(int x)
    {
        return x * x;
    }
    // Вызывать метод Meth() по интерфейсной ссылке.
    public int MethA(int x)
    {
        IMyIF_A a_ob = this;
        return a_ob.Meth(x); // вызов интерфейсного метода IMyIF_A
    }
    public int MethB(int x)
    {
        IMyIF_B b_ob = this;
        return b_ob.Meth(x); // вызов интерфейсного метода IMyIF_B
    }
}
class FQIFNames
{
    static void test()
    {
        MyClassIF ob = new MyClassIF();
        Console.Write("Вызов метода IMyIF_A.Meth(): ");
        Console.WriteLine(ob.MethA(3));
        Console.Write("Вызов метода IMyIF_B.Meth(): ");
        Console.WriteLine(ob.MethB(3));
    }
}

