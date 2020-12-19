// Простой пример применения свойства.
using System;
class SimpProp
{
    int prop; // поле, управляемое свойством МуРrор
    public SimpProp() { prop = 0; }
    /* Это свойство обеспечивает доступ к закрытой переменной экземпляра prop.
    Оно допускает присваивание только положительных значений. */
    public int MyProp
    {
        get
        {
            return prop;
        }
        set
        {
            if (value >= 0) prop = value;
        }
    }
}

// Применить инициализаторы объектов в свойствах.
class SimpProp2
{
    // Теперь это свойства.
    public int Count { get; set; }
    public string Str { get; set; }
}

// Продемонстрировать применение свойства.
class PropertyDemo
{
    static void test()
    {
        SimpProp ob = new SimpProp();
        Console.WriteLine("Первоначальное значение ob.МуРrор: " + ob.MyProp);
        ob.MyProp = 100; // присвоить значение
        Console.WriteLine("Текущее значение ob.МуРrор: " + ob.MyProp);
        // Переменной prop нельзя присвоить отрицательное значение.
        Console.WriteLine("Попытка присвоить значение " +
        "-10 свойству ob.МуРrор");
        ob.MyProp = -10;
        Console.WriteLine("Текущее значение ob.МуРrор: " + ob.MyProp);

        Console.WriteLine();
        // Сконструировать объект типа MyClass с помощью инициализаторов объектов.
        SimpProp2 obj = new SimpProp2 { Count = 100, Str = "Тестирование" };
        Console.WriteLine(obj.Count + " " + obj.Str);
    }
}