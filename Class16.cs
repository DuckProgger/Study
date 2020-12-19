using System;

abstract class Figure
{

    public double Edge
    { get; set; }

    public double Radius
    { get; set; }

    public abstract double Area();

}

class Circle : Figure
{
    public Circle(double R)
    {
        Radius = R;
    }

    public override double Area()
    {
        double area = 3.14 * Radius * Radius;
        Console.WriteLine("Площадь:" + area);
        return area;
    }

    public void Show()
    {
        Console.WriteLine("Радиус:" + Radius);
    }

}

class Square : Figure
{
    public Square(double E)
    {
        Edge = E;
    }

    public override double Area()
    {
        double area = Edge * Edge;
        Console.WriteLine("Площадь:" + area);
        return area;
    }

}

class Why
{
    static void test()
    {
        Figure[] figures = new Figure[3];
        figures[0] = new Circle(6.3);
        figures[1] = new Circle(8.4);
        figures[2] = new Square(9.1);

        for (int i = 0; i < figures.Length; i++)
        {
            figures[i].Area();
        }
        /* а как же мне вызвать метод Show из класса Circle при таком подходе?
        объект figures ссылается на класс Figure, который не содержит в себе
        этот метод, но этот метод мне нужен только в классе Circle, поэтому
        в базовом классе мне его объявлять не хочется. Так каким же образом мне его вызвать?
        */
    }
}