using System;
class MyClass2
{
    int a, b; // закрытые члены класса
              // Создать фабрику для класса MyClass2.
    static public MyClass2 Factory(int i, int j)
    {
        MyClass2 t = new MyClass2();
        t.a = i;
        t.b = j;
        return t; // возвратить объект
    }
    public void Show()
    {
        Console.WriteLine("а и b: " + a + " " + b);
    }
}
class MakeObjects
{
    static public void test()
    {
        int i, j;
        // Сформировать объекты, используя фабрику класса.
        for (i = 0, j = 10; i < 10; i++, j--)
        {
            MyClass2 anotherOb = MyClass2.Factory(i, j); // создать объект
            anotherOb.Show();
        }
        Console.WriteLine();
    }
}