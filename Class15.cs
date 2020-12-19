// Виртуальные методы

using System;
class Base
{
    public void Who()
    {
        Console.WriteLine("Метод Who() в классе Base");
    }
    // Создать виртуальный метод в базовом классе.
    public virtual void Who2()
    {
        Console.WriteLine("Метод Who2() в классе Base");
    }
}
class Derived1 : Base
{
    new public void Who()
    {
        Console.WriteLine("Метод Who() в классе Derivedl");
    }
    // Переопределить метод Who2() в производном классе.
    public override void Who2()
    {
        Console.WriteLine("Метод Who2() в классе Derivedl");
    }
}
class Derived2 : Base
{
    new public void Who()
    {
        Console.WriteLine("Метод Who() в классе Derived2");
    }
    // Вновь переопределить метод Who2() в еще одном производном классе.
    public override void Who2()
    {
        Console.WriteLine("Метод Who2() в классе Derived2");
    }
}
class OverrideDemo
{
    static void test()
    {
        Base baseOb = new Base();
        Derived1 dOb1 = new Derived1();
        Derived2 dOb2 = new Derived2();
        Base baseRef; // ссылка на базовый класс
        baseRef = baseOb;
        baseRef.Who();
        baseRef.Who2();
        Console.WriteLine();
        baseRef = dOb1;
        baseRef.Who();
        baseRef.Who2();
        Console.WriteLine();
        baseRef = dOb2;
        baseRef.Who();
        baseRef.Who2();

        /* таким образом мы выяснили, что вариант вызываемого метода при наличии нескольких методов в производных классах,
         * определенных с помощью сокрытия имён, определяется по ссылке на объект, а вариант метода при наличии нескольких виртуальных
         * методов определяется с помощью типа объекта
        */

        /* Если виртуальный метод не переопределяется, то
        используется его вариант из базового класса. */

        /* Если при наличии многоуровневой иерархии виртуальный метод не переопределяется
        в производном классе, то выполняется ближайший его вариант, обнаруживаемый
        вверх по иерархии
        */

    }
}

class TwoDShape2
{
    double pri_width;
    double pri_height;
    // Конструктор по умолчанию.
    public TwoDShape2()
    {
        Width = Height = 0.0;
        name = "null";
    }
    // Параметризированный конструктор.
    public TwoDShape2(double w, double h, string n)
    {
        Width = w;
        Height = h;
        name = n;
    }
    // Сконструировать объект равной ширины и высоты.
    public TwoDShape2(double x, string n)
    {
        Width = Height = x;
        name = n;
    }
    // Сконструировать копию объекта TwoDShape.
    public TwoDShape2(TwoDShape2 ob)
    {
        Width = ob.Width;
        Height = ob.Height;
        name = ob.name;
    }
    // Свойства ширины и высоты объекта.
    public double Width
    {
        get { return pri_width; }
        set { pri_width = value < 0 ? -value : value; }
    }
    public double Height
    {
        get { return pri_height; }
        set { pri_height = value < 0 ? -value : value; }
    }
    public string name { get; set; }
    public void ShowDim()
    {
        Console.WriteLine("Ширина и высота равны " +
        Width + " и " + Height);
    }
    public virtual double Area()
    {
        Console.WriteLine("Метод Area() должен быть переопределен");
        return 0.0;
    }
}
// Класс для треугольников, производный от класса TwoDShape.
class Triangle2 : TwoDShape2
{
    string Style;
    // Конструктор, используемый по умолчанию.
    public Triangle2()
    {
        Style = "null";
    }
    // Конструктор для класса Triangle.
    public Triangle2(string s, double w, double h) : base(w, h, "треугольник")
    {
        Style = s;
    }
    // Сконструировать равнобедренный треугольник,
    public Triangle2(double x) : base(x, "треугольник")
    {
        Style = "равнобедренный";
    }
    // Сконструировать копию объекта типа Triangle.
    public Triangle2(Triangle2 ob) : base(ob)
    {
        Style = ob.Style;
    }
    // Переопределить метод Area() для класса Triangle.
    public override double Area()
    {
        return Width * Height / 2;
    }
    // Показать тип треугольника.
    public void ShowStyle()
    {
        Console.WriteLine("Треугольник " + Style);
    }
}
// Класс для прямоугольников, производный от класса TwoDShape.
class Rectangle2 : TwoDShape2
{
    // Конструктор для класса Rectangle.
    public Rectangle2(double w, double h) : base(w, h, "прямоугольник")
    { }
    // Сконструировать квадрат.
    public Rectangle2(double x) : base(x, "прямоугольник")
    { }
    // Сконструировать копию объекта типа Rectangle.
    public Rectangle2(Rectangle2 ob) : base(ob) { }
    // Возвратить логическое значение true, если
    // прямоугольник окажется квадратом.
    public bool IsSquare()
    {
        if (Width == Height) return true;
        return false;
    }
    // Переопределить метод Area() для класса Rectangle.
    public override double Area()
    {
        return Width * Height;
    }
}
class DynShapes
{
    static void test()
    {
        TwoDShape2[] shapes = new TwoDShape2[5];
        shapes[0] = new Triangle2("прямоугольный", 8.0, 12.0);
        shapes[1] = new Rectangle2(10);
        shapes[2] = new Rectangle2(10, 4);
        shapes[3] = new Triangle2(7.0);
        shapes[4] = new TwoDShape2(10, 20, "общая форма");
        for (int i = 0; i < shapes.Length; i++)
        {
            Console.WriteLine("Объект — " + shapes[i].name);
            Console.WriteLine("Площадь равна " + shapes[i].Area());
            Console.WriteLine();
        }
    }


    // ВОПРОС: КАК ПРИ ТАКОЙ РЕАЛИЗАЦИИ ИСПОЛЬЗОВАТЬ МЕТОДЫ ВНУТРИ ПРОИЗВОДНЫХ КЛАССОВ?
    // НАПРИМЕР, МЕТОД ShowStyle ИЗ КЛАССА Triangle2 ВЫЗВАТЬ НЕТ ВОМОЖНОСТИ
    // СДЕЛАТЬ МЕТОД ТИПА static НЕ ИМЕЕТ СМЫСЛА, ТАК КАК ТОГДА И ПЕРЕМЕННАЯ Style ДОЛЖНА БЫТЬ static,
    // А ТОГДА ЭТА ПЕРЕМЕННАЯ БУДЕТА ОДНА ДЛЯ ВСЕХ ОБЪЕКТОВ

}