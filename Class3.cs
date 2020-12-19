using System;

class MyClass
{
    int alpha, beta;
    public MyClass(int i, int j)
    {
        alpha = i;
        beta = j;
    }

// Возвратить значение true, если параметр ob
// имеет те же значения, что и вызывающий объект.
    public bool SameAs(HisClass ob)
    {
        if ((ob.gamma == alpha) & (ob.teta == beta))
            return true;
        else return false;
    }
    // Сделать копию объекта ob.
    public void Copy(HisClass ob)
    {
        alpha = ob.gamma;
        beta = ob.teta;
    }
    public void Show()
    {
        Console.WriteLine("alpha: {0}, beta: {1}",
        alpha, beta);
    }
}

class HisClass
{
    public int gamma, teta;

    public HisClass(int i, int j)
    {
        gamma = i;
        teta = j;
    }

    public void Show()
    {
        Console.WriteLine("gamma: {0}, teta: {1}",
        gamma, teta);
    }
}


class PassOb
{
    static void test()
    {
        MyClass ob1 = new MyClass(4, 5);
        HisClass ob2 = new HisClass(6, 7);
        Console.Write("ob1: ");
        ob1.Show();
        Console.Write("ob2: ");
        ob2.Show();
        if (ob1.SameAs(ob2))
            Console.WriteLine("ob1 и ob2 имеют одинаковые значения.");
        else
            Console.WriteLine("ob1 и ob2 имеют разные значения.");
        Console.WriteLine();
        // А теперь сделать объект ob1 копией объекта ob2.
        ob1.Copy(ob2);
        Console.Write("оЫ после копирования: ");
        ob1.Show();
        if (ob1.SameAs(ob2))
            Console.WriteLine("ob1 и ob2 имеют одинаковые значения.");
        else
            Console.WriteLine("ob1 и ob2 имеют разные значения.");
    }
}
