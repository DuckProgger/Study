// Пример перегрузки бинарных операторов.
using System;
// Класс для хранения трехмерных координат.
class ThreeD
{
    int x, y, z; // трехмерные координаты
    public ThreeD(int i = 0, int j = 0, int k = 0) { x = i; y = j; z = k; }
    // Перегрузить бинарный оператор +.
    public static ThreeD operator + (ThreeD op1, ThreeD op2)
    {
        ThreeD result = new ThreeD();
        /* Сложить координаты двух точек и возвратить результат. */
        result.x = op1.x + op2.x; // Эти операторы выполняют
        result.y = op1.y + op2.y; // целочисленное сложение,
        result.z = op1.z + op2.z; // сохраняя свое исходное назначение.
        return result;
    }
    // Перегрузить бинарный оператор -.
    public static ThreeD operator - (ThreeD op1, ThreeD op2)
    {
        ThreeD result = new ThreeD();
        /* Обратите внимание на порядок следования операндов:
        op1 — левый операнд, а ор2 — правый операнд. */
        result.x = op1.x - op2.x; // Эти операторы
        result.y = op1.y - op2.y; // выполняют целочисленное
        result.z = op1.z - op2.z; // вычитание
        return result;
    }

    // Перегрузить бинарный оператор *.
    public static ThreeD operator * (ThreeD op1, int op2)
    {
        ThreeD result = new ThreeD();
        result.x = op1.x * op2;
        result.y = op1.y * op2;
        result.z = op1.z * op2;
        return result;
    }

    // Перегрузить унарный оператор -.
    public static ThreeD operator - (ThreeD op)
    {
        ThreeD result = new ThreeD();
        result.x = -op.x;
        result.y = -op.y;
        result.z = -op.z;
        return result;
    }

    // Перегрузить унарный оператор ++.
    public static ThreeD operator ++(ThreeD op)
    {
        ThreeD result = new ThreeD();
        // Возвратить результат инкрементирования.
        result.x = op.x + 1;
        result.y = op.y + 1;
        result.z = op.z + 1;
        return result;
    }

    // Перегрузить оператор <.
    public static bool operator < (ThreeD op1, ThreeD op2)
    {
        if (Math.Sqrt(op1.x * op1.x + op1.y * op1.y + op1.z * op1.z) <
        Math.Sqrt(op2.x * op2.x + op2.y * op2.y + op2.z * op2.z))
            return true;
        else
            return false;
    }
    // Перегрузить оператор >.
    public static bool operator > (ThreeD op1, ThreeD op2)
    {
        if (Math.Sqrt(op1.x * op1.x + op1.y * op1.y + op1.z * op1.z) >
        Math.Sqrt(op2.x * op2.x + op2.y * op2.y + op2.z * op2.z))
            return true;
        else
            return false;
    }

    // Перегрузить оператор true.
    public static bool operator true(ThreeD op)
    {
        if ((op.x != 0) || (op.y != 0) || (op.z != 0))
            return true; // хотя бы одна координата не равна нулю
        else
            return false;
    }
    // Перегрузить оператор false.
    public static bool operator false(ThreeD op)
    {
        if ((op.x == 0) && (op.y == 0) && (op.z == 0))
            return true; // все координаты равны нулю
        else
            return false;
    }
    // Перегрузить унарный оператор --.
    public static ThreeD operator --(ThreeD op)
    {
        ThreeD result = new ThreeD();
        // Возвратить результат декрементирования.
        result.x = op.x - 1;
        result.y = op.y - 1;
        result.z = op.z - 1;
        return result;
    }

    // Перегрузить логический оператор |.
    public static bool operator |(ThreeD op1, ThreeD op2)
    {
        if (((op1.x != 0) || (op1.y != 0) || (op1.z != 0)) |
        ((op2.x != 0) || (op2.y != 0) || (op2.z != 0)))
            return true;
        else
            return false;
    }
    // Перегрузить логический оператор &.
    public static bool operator &(ThreeD op1, ThreeD op2)
    {
        if (((op1.x != 0) && (op1.y != 0) && (op1.z != 0)) &
        ((op2.x != 0) && (op2.y != 0) && (op2.z != 0)))
            return true;
        else
            return false;
    }
    // Перегрузить логический оператор !.
    public static bool operator !(ThreeD op)
    {
        if ((op.x != 0) || (op.y != 0) || (op.z != 0))
            return false;
        else return true;
    }

    // Неявное преобразование объекта типа ThreeD к типу int.
    public static implicit operator int(ThreeD op1)
    {
        return op1.x * op1.y * op1.z;
    }

    // Явное преобразование объекта типа ThreeD к типу double.
    public static explicit operator double (ThreeD op1)
    {
        return (double)op1.x * (double)op1.y * (double)op1.z;
    }

    // Вывести координаты X, Y, Z.
    public void Show()
    {
        Console.WriteLine(x + ", " + y + ", " + z);
    }
}
class ThreeDDemo
{
    static void test()
    {
        int i;
        double j;

        ThreeD a = new ThreeD(1, 2, 3);
        ThreeD b = new ThreeD(10, 10, 10);
        ThreeD c;
        Console.Write("Координаты точки a: ");
        a.Show();
        Console.WriteLine();
        Console.Write("Координаты точки b: ");
        b.Show();
        Console.WriteLine();
        c = a + b; // сложить координаты точек а и b
        Console.Write("Результат сложения а + b: ");
        c.Show();
        Console.WriteLine();
        c = a + b + c; // сложить координаты точек а, b и с
        Console.Write("Результат сложения а + b + с: ");
        c.Show();
        Console.WriteLine();
        c = c - a; // вычесть координаты точки а
        Console.Write("Результат вычитания с - а: ");
        c.Show();
        Console.WriteLine();
        c = c - b; // вычесть координаты точки b
        Console.Write("Результат вычитания с - b: ");
        c.Show();
        Console.WriteLine();
        c = a * 3;
        c.Show();
        c = -a; // присвоить точке с отрицательные координаты точки а
        Console.Write("Результат присваивания -а: ");
        c.Show();
        Console.WriteLine();
        c = a++; // присвоить точке с координаты точки а,
                 // а затем инкрементировать их
        Console.WriteLine("Если с = а++");
        Console.Write("то координаты точки с равны ");
        c.Show();
        Console.Write("а координаты точки а равны ");
        a.Show();
        // Установить исходные координаты (1,2,3) точки а
        a = new ThreeD(1, 2, 3);
        Console.Write("\nУстановка исходных координат точки а: ");
        a.Show();
        c = ++a; // инкрементировать координаты точки а,
                 // а затем присвоить их точке с
        Console.WriteLine("\nЕсли с = ++а");
        Console.Write("то координаты точки с равны ");
        c.Show();
        Console.Write("а координаты точки а равны ");
        a.Show();

        if (a > c) Console.WriteLine("а > c истинно");
        else if (a < c) Console.WriteLine("a < c истинно");
        else Console.WriteLine("Точки a и c находятся на одном расстоянии " +
        "от начала отсчета");

        Console.WriteLine();
        Console.WriteLine("Управление циклом с помощью объекта класса ThreeD.");
        do
        {
            b.Show();
            b--;
        } while (b);

        Console.WriteLine();
        if (!a) Console.WriteLine("Точка а ложна.");
        if (!b) Console.WriteLine("Точка b ложна.");
        if (!c) Console.WriteLine("Точка с ложна.");
        Console.WriteLine();
        if (a & b) Console.WriteLine("a & b истинно.");
        else Console.WriteLine("a & b ложно.");
        if (a & c) Console.WriteLine("a & с истинно.");
        else Console.WriteLine("a & с ложно.");
        if (a | b) Console.WriteLine("a | b истинно.");
        else Console.WriteLine("a | b ложно.");
        if (a | c) Console.WriteLine("a | с истинно.");
        else Console.WriteLine("a | с ложно.");

        Console.WriteLine();
        i = a; // преобразовать в тип int
        Console.WriteLine("Результат присваивания i = a: " + i);
        Console.WriteLine();
        c.Show();
        i = a * 2 - c; // преобразовать в тип int (помним, что операторы * и - перегужены)
        Console.WriteLine("Результат вычисления выражения a * 2 - c: " + i);

        Console.WriteLine();
        // Использование явного оператора преобразования
        j = (double) a;
        Console.WriteLine("Результат присваивания j = a: " + j);
    }
}