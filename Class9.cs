using System;
class Cons
{
    public static int alpha;
    public int beta;

    // Конструктор экземпляра.
    public Cons()
    {
        beta = 100;
        Console.WriteLine("В конструкторе экземпляра.");
    }

    // Статический конструктор.
    static Cons()
    {
        alpha = 99;
        Console.WriteLine("В статическом конструкторе.");
    }
}
class ConsDemo
{
    static void test()
    {
        Cons ob = new Cons();
        Console.WriteLine("Cons.alpha: " + Cons.alpha);
        Console.WriteLine("ob.beta: " + ob.beta);
    }
}