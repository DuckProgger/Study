using System;

class RefSwap
{
    int a, b;

    public RefSwap(int i, int j)
    {
        a = i;
        b = j;
    }

    public void Show()
    {
        Console.WriteLine("a: {0}, b: {1}", a, b);
    }

    public void Swap(ref RefSwap a, ref RefSwap b)
    {
        RefSwap t;
        t = a;
        a = b;
        b = t;
    }
}
    
class RefTest
{
    static void test()
    {
        RefSwap x = new RefSwap(1, 3);
        RefSwap y = new RefSwap(2, 5);

        Console.WriteLine("x:");
        x.Show();
        Console.WriteLine("y:");
        y.Show();

        y.Swap(ref x, ref y);

        Console.WriteLine("После замены:");
        Console.WriteLine("x:");
        x.Show();
        Console.WriteLine("y:");
        y.Show();
    }
}