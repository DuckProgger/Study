// Перегрузка оператора преобразования
using System;
// тип4-разрядных данных.
class Nybble
{
    int val; // базовый тип для хранения данных
    public Nybble() { val = 0; }
    public Nybble(int i)
    {
        val = i;
        val = val & 0xF; // сохранить 4 младших разряда
    }
    // Перегрузить бинарный оператор + для сложения двух объектов типа Nybble.
    public static Nybble operator +(Nybble op1, Nybble op2)
    {
        Nybble result = new Nybble();
        result.val = op1.val + op2.val;
        result.val = result.val & 0xF; // сохранить 4 младших разряда
        return result;
    }
    // Перегрузить бинарный оператор + для сложения
    // объекта типа Nybble и значения типа int.
    public static Nybble operator +(Nybble op1, int op2)
    {
        Nybble result = new Nybble();
        result.val = op1.val + op2;
        result.val = result.val & 0xF; // сохранить 4 младших разряда
        return result;
    }
    // Перегрузить бинарный оператор + для сложения
    // значения типа int и объекта типа Nybble.
    public static Nybble operator +(int op1, Nybble op2)
    {
        Nybble result = new Nybble();
        result.val = op1 + op2.val;
        result.val = result.val & 0xF; // сохранить 4 младших разряда
        return result;
    }
    // Перегрузить оператор ++.
    public static Nybble operator ++(Nybble op)
    {
        Nybble result = new Nybble();
        result.val = op.val + 1;
        result.val = result.val & 0xF; // сохранить 4 младших разряда
        return result;
    }
    // Перегрузить оператор >.
    public static bool operator >(Nybble op1, Nybble op2)
    {
        if (op1.val > op2.val) return true;
        else return false;
    }
    // Перегрузить оператор <.
    public static bool operator <(Nybble op1, Nybble op2)
    {
        if (op1.val < op2.val) return true;
        else return false;
    }
    // Преобразовать тип Nybble в тип int.
    public static implicit operator int(Nybble op)
    {
        return op.val;
    }
    // Преобразовать тип int в тип Nybble.
    public static implicit operator Nybble(int op)
    {
        if (op < 0xF)
            return new Nybble(op);
        else
            return new Nybble(0xF);
    }
}
class NybbleDemo
{
    static void test()
    {
        Nybble a = new Nybble(1);
        Nybble b = new Nybble(10);
        Nybble с = new Nybble();
        int t;
        Console.WriteLine("a: " + (int)a);
        Console.WriteLine("b: " + (int)b);
        // Использовать тип Nybble в условном операторе if.
        if (a < b) Console.WriteLine("а меньше b\n");
        // Сложить два объекта типа Nybble.
        с = a + b;
        Console.WriteLine("с после операции с = а + b: " + (int)с);
        // Сложить значение типа int с объектом типа Nybble.
        a += 5;
        Console.WriteLine("а после операции а += 5: " + (int)a);
        Console.WriteLine();
        // Использовать тип Nybble в выражении типа int.
        t = a * 2 + 3;
        Console.WriteLine("Результат вычисления выражения а * 2 + 3: " + t);
        Console.WriteLine();
        // Продемонстрировать присваивание значения типа int и переполнение.
        a = 19;
        Console.WriteLine("Результат присваивания а = 19: " + (int)a);
        Console.WriteLine();
        // Использовать тип Nybble для управления циклом.
        Console.WriteLine("Управление циклом for " +
        "с помощью объекта типа Nybble.");
        for (a = 0; a < 10; a++)
            Console.Write((int)a + " ");
        Console.WriteLine();
    }
}