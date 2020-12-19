// Наследование, многоуровневая иерархия классов

using System;
class TwoDShape
{
    double pri_width;
    double pri_height;
    // Конструктор, используемый по умолчанию.
    public TwoDShape()
    {
        Width = Height = 0.0;
    }
    // Конструктор для класса TwoDShape.
    public TwoDShape(double w, double h)
    {
        Width = w;
        Height = h;
    }
    // Сконструировать объект равной ширины и высоты.
    public TwoDShape(double x)
    {
        Width = Height = x;
    }
    // Создать копию объекта
    public TwoDShape(TwoDShape ob)
    {
        Width = ob.Width;
        Height = ob.Height;
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
    public void ShowDim()
    {
        Console.WriteLine("Ширина и высота равны " +
        Width + " и " + Height);
    }
}
// Класс для треугольников, производный от класса TwoDShape.
class Triangle : TwoDShape
{
    string Style; // закрытый член класса
    /* Конструктор, используемый по умолчанию.
    Автоматически вызывает конструктор, доступный по
    умолчанию в классе TwoDShape. */
    public Triangle()
    {
        Style = "null";
    }
    // Конструктор.
    public Triangle(string s, double w, double h) : base(w, h)
    {
        Style = s;
    }
    // Сконструировать равнобедренный треугольник.
    public Triangle(double x) : base(x)
    {
        Style = "равнобедренный";
    }

    // Создать копию объекта
    public Triangle(Triangle ob) : base(ob)
    {
        Style = ob.Style;
    }

    // Возвратить площадь треугольника.
    public double Area()
    {
        return Width * Height / 2;
    }
    // Показать тип треугольника.
    public void ShowStyle()
    {
        Console.WriteLine("Треугольник " + Style);
    }
}
// Расширить класс Triangle.
class ColorTriangle : Triangle
{
    string color;
    public ColorTriangle(string c, string s, double w, double h) : base(s, w, h)
    {
        color = c;
    }

    public ColorTriangle(string c, double x) : base(x)
    {
        color = c;
    }
    // Показать цвет треугольника.
    public void ShowColor()
    {
        Console.WriteLine("Цвет " + color);
    }
}
class Shapes
{
    static void test()
    {
        ColorTriangle t1 = new ColorTriangle("синий", "прямоугольный", 8.0, 12.0);
        ColorTriangle t2 = new ColorTriangle("красный", "равнобедренный", 2.0, 2.0);
        ColorTriangle t3 = new ColorTriangle("зелёный", 3.0);
        Triangle t4 = new Triangle("кривой", 10.0, 15.0);


        Console.WriteLine("Сведения об объекте t1: ");
        t1.ShowStyle();
        t1.ShowDim();
        t1.ShowColor();
        Console.WriteLine("Площадь равна " + t1.Area());
        Console.WriteLine();
        Console.WriteLine("Сведения об объекте t2: ");
        t2.ShowStyle();
        t2.ShowDim();
        t2.ShowColor();
        Console.WriteLine("Площадь равна " + t2.Area());
        Console.WriteLine();
        Console.WriteLine("Сведения об объекте t3: ");
        t3.ShowStyle();
        t3.ShowDim();
        t3.ShowColor();
        Console.WriteLine();
        Console.WriteLine("Сведения об объекте t4: ");
        t4.ShowStyle();
        t4.ShowDim();

        // Создать экземпляр, где в качестве параметра задаётся объект
        Triangle t5 = new Triangle(t3); // в качестве параметра можно задать объект любого производного класса (Triangle, ColorTriangle)
        Console.WriteLine();
        Console.WriteLine("Сведения об объекте t5: ");
        t5.ShowStyle();
        t5.ShowDim();

    }
}