// класс object
#pragma warning disable 659

using System;

class A
{
    public int a;
    public A(int i)
    {
        a = i;
    }

    public override bool Equals(object obj)
    {
        return this.a == ((A) obj).a;
    }
    

}


class B
{
    int a;
    public B(int i)
    {
        a = i;
    }

}

class C
{
   static void test()
    {
        A ob1 = new A(5);
        A ob2 = new A(5);
        B ob3 = new B(10);


        Console.WriteLine(Equals(ob1, ob2) ? "ob1 = ob2" : "ob1 != ob2");
        // метод Equals переопределён, теперь он возвращает true, если равны поля у объектов, а не если они ссылаются на один и тот же объект
        Console.WriteLine(ReferenceEquals(ob1, ob2) ? "ref ob1 = ref ob2" : "ref ob1 != ref ob2");
        // метод ReferenceEquals переопределить нельзя, поэтому с помощью него можно наверняка проверить равенство объектов
        Console.WriteLine("{0}, {1}", ob1.GetHashCode(), ob2.GetHashCode());
        Console.WriteLine("{0}, {1}", ob1.GetType(), ob3.GetType());
        Console.WriteLine("{0}, {1}", ob1.ToString(), ob3.ToString());
    }
}

// Использовать класс object для создания массива "обобщенного" типа.
class GenericDemo
{
    static void test()
    {
        object[] ga = new object[10];
        // Сохранить целые значения.
        for (int i = 0; i < 3; i++)
            ga[i] = i;
        // Сохранить значения типа double.
        for (int i = 3; i < 6; i++)
            ga[i] = (double)i / 2;
        // Сохранить две строки, а также значения типа bool и char.
        ga[6] = "Привет";
        ga[7] = true;
        ga[8] = 'X';
        ga[9] = "Конец";
        for (int i = 0; i < ga.Length; i++)
            Console.WriteLine("ga[" + i + "]: " + ga[i] + " ");
    }
}