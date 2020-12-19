// Индексатор для создания отказоустойчивого массива с перегрузкой
using System;

class FailSoftArray
{
    int[] a; // ссылка на базовый массив
    // Построить массив заданного размера.
    public FailSoftArray(int size)
    {
        a = new int[size];
        Length = size;
    }
    // Это индексатор типа int для массива FailSoftArray.
    public int this[int index]
    {
        // Это аксессор get.
        get
        {
            if (ok(index))
            {
                Error = false;
                return a[index];
            }
            else
            {
                Error = true;
                return 0;
            }
        }
        // Это аксессор set.
        set
        {
            if (ok(index))
            {
                a[index] = value;
                Error = false;
            }
            else Error = true;
        }
    }
    /* Это еще один индексатор для массива FailSoftArray.
    Он округляет свой аргумент до ближайшего целого индекса. */
    public int this[double idx]
    {
        // Это аксессор get.
        get
        {
            int index;
            // Округлить до ближайшего целого.
            if ((idx - (int)idx) < 0.5) index = (int)idx;
            else index = (int)idx + 1;
            if (ok(index))
            {
                Error = false;
                return a[index];
            }
            else
            {
                Error = true;
                return 0;
            }
        }
        // Это аксессор set.
        set
        {
            int index;
        // Округлить до ближайшего целого.
        if ((idx - (int)idx) < 0.5) index = (int)idx;
            else index = (int)idx + 1;
            if (ok(index))
            {
                a[index] = value;
                Error = false;
            }
            else Error = true;
        }
    }
    // Возвратить логическое значение true, если
    // индекс находится в установленных границах.

    // Автоматически реализуемое свойство с длиной массива (только чтение)
    public int Length { get; private set; }

    // Автоматически реализуемое свойство с возратом ошибки (только чтение)
    public bool Error { get; private set; }

    private bool ok(int index)
    {
        if (index >= 0 & index < Length) return true;
        return false;
    }
}
// Продемонстрировать применение отказоустойчивого массива.
class PwrOfTwo
{
    /* Доступ к логическому массиву, содержащему степени
    числа 2 от 0 до 15. */
    public int this[int index]
    {
        // Вычислить и возвратить степень числа 2.
        get
        {
            if ((index >= 0) && (index < 16)) return pwr(index);
            else return -1;
        }
        // Аксессор set отсутствует.
    }
    int pwr(int p)
    {
        int result = 1;
        for (int i = 0; i < p; i++)
            result *= 2;
        return result;
    }

    public int sqrt(int op)
    {
        int result = 1;
        if (op >= 0 && op < 16)
        {
            for (int i = 0; i < op; i++)
                result *= 2;
            return result;
        }
        else return -1;
    }
}

// Двумерный отказоустойчивый массив
class FailSoftArray2D
{
    int[,] a; // ссылка на базовый двумерный массив
    int rows, cols; // размеры массива
    int len; // открытая переменная длины массива
    bool ErrFlag; // обозначает результат последней операции
                         // Построить массив заданных размеров.
    public FailSoftArray2D(int r, int с)
    {
        rows = r;
        cols = с;
        a = new int[rows, cols];
        len = rows * cols;
    }
    // Это индексатор для класса FailSoftArray2D.
    public int this[int index1, int index2]
    {
        // Это аксессор get.
        get
        {
            if (ok(index1, index2))
            {
                ErrFlag = false;
                return a[index1, index2];
            }
            else
            {
                ErrFlag = true;
                return 0;
            }
        }
        // Это аксессор set.
        set
        {
            if (ok(index1, index2))
            {
                a[index1, index2] = value;
                ErrFlag = false;
            }
            else ErrFlag = true;
        }
    }
    // Возвратить логическое значение true, если
    // индексы находятся в установленных пределах.

    // Свойство с длиной массива (только чтение)
    public int Length
    {
        get
        {
            return len;
        }
    }

    // Свойство с возратом ошибки (только чтение)
    public bool Error
    {
        get
        {
            return ErrFlag;
        }
    }
    private bool ok(int index1, int index2)
    {
        if (index1 >= 0 & index1 < rows &
        index2 >= 0 & index2 < cols)
            return true;
        return false;
    }
}


class FSDemo
{
    static void test()
    {
        FailSoftArray fs = new FailSoftArray(5);
        int x;
        // Выявить скрытые сбои.
        Console.WriteLine("Скрытый сбой.");
        for (int i = 0; i < (fs.Length * 2); i++)
            fs[i] = i * 10;
        for (int i = 0; i < (fs.Length * 2); i++)
        {
            x = fs[i];
            if (x != -1) Console.Write(x + " ");
        }
        Console.WriteLine();
        // А теперь показать сбои.
        Console.WriteLine("\nСбой с уведомлением об ошибках.");
        for (int i = 0; i < (fs.Length * 2); i++)
        {
            fs[i] = i * 10;
            if (fs.Error)
                Console.WriteLine("fs[" + i + "] вне границ");
        }
        for (int i = 0; i < (fs.Length * 2); i++)
        {
            x = fs[i];
            if (!fs.Error) Console.Write(x + " ");

            else
                Console.WriteLine("fs[" + i + "] вне границ");
        }


        Console.WriteLine();
        // Поместить ряд значений в массив fs.
        for (int i = 0; i < fs.Length; i++)
            fs[i] = i;
        // А теперь воспользоваться индексами
        // типа int и double для обращения к массиву.
        Console.WriteLine("fs[1] : " + fs[1]);
        Console.WriteLine("fs[2] : " + fs[2]);
        Console.WriteLine("fs[1.1]: " + fs[1.1]);
        Console.WriteLine("fs[1.6]: " + fs[1.6]);

        Console.WriteLine();
        PwrOfTwo pwr = new PwrOfTwo();
        Console.Write("Первые 8 степеней числа 2: ");
        for (int i = 0; i < 8; i++)
            Console.Write(pwr[i] + " ");
        Console.WriteLine();
        Console.Write("А это некоторые ошибки: ");
        Console.Write(pwr[-1] + " " + pwr[17]); // Реализация через индексатор
        Console.WriteLine();
        for (int i = 0; i < 8; i++)
            Console.Write(pwr.sqrt(i) + " "); // Реализация через метод
        Console.Write(pwr.sqrt(-1) + " " + pwr.sqrt(17)); 
        Console.WriteLine();


        // Двумерный массив
        FailSoftArray2D fs2 = new FailSoftArray2D(3, 5);
        // Выявить скрытые сбои.
        Console.WriteLine("Скрытый сбой.");
        for (int i = 0; i < 6; i++)
            fs2[i, i] = i * 10;
        for (int i = 0; i < 6; i++)
        {
            x = fs2[i, i];
            if (x != -1) Console.Write(x + " ");
        }
        Console.WriteLine();
        // А теперь показать сбои.
        Console.WriteLine("\nСбой с уведомлением об ошибках.");
        for (int i = 0; i < 6; i++)
        {
            fs2[i, i] = i * 10;
            if (fs2.Error)
                Console.WriteLine("fs[" + i + ", " + i + "] вне границ");
        }
        for (int i = 0; i < 6; i++)
        {
            x = fs2[i, i];
            if (!fs2.Error) Console.Write(x + " ");
            else
                Console.WriteLine("fs[" + i + ", " + i + "] вне границ");
        }

    }
}

class RangeArray
{
    int[] a; // ссылка на базовый массив
    int LowRange, HighRange;

    public RangeArray(int down, int up)
    {
        up ++;

        length = up - down;
        a = new int[length];
        LowRange = down;
        HighRange = --up;
    }


    public int this[int index]
    {
        get
        {
            if (Ok(index))
                return a[index - LowRange];
            else
                return 0;
        }
        set
        {
            if (Ok(index))
            {
                a[index - LowRange] = value;
            }
        }
    }
    bool Ok(int index)
    {
        if (index >= LowRange && index <= HighRange)
            return true;
        else return false;
    }

    public int length { get; private set; }
}

class RangeArrayDemo
{
    static void test()
    {
        RangeArray arr = new RangeArray(-5, 10);
        for (int i = -5; i < 10; i++)
        {
            arr[i] = i;
            Console.WriteLine(arr[i]);
        }

    }
}


