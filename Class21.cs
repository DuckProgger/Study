// Обработка исключений

using System;
class ExcDemo3
{
    static void test()
    {
        int[] numer = { 4, 8, 16, 32, 64, 128 };
        int[] denom = { 2, 0, 4, 4, 0, 8 };
        for (int i = 0; i < numer.Length; i++)
        {
            try
            {
                Console.WriteLine(numer[i] + " / " +
                denom[i] + " равно " +
                numer[i] / denom[i]);
            }
            catch (DivideByZeroException) 
            {
                // Перехватить исключение.
                Console.WriteLine("Делить на нуль нельзя!");
            }
        }
    }
}

class NestTrys
{
    static void test()
    {
        // Здесь массив numer длиннее массива denom.
        int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
        int[] denom = { 2, 0, 4, 4, 0, 8 };
        try
        { // внешний блок try
            for (int i = 0; i < numer.Length; i++)
            {
                try
                { // вложенный блок try
                    Console.WriteLine(numer[i] + " / " +
                    denom[i] + " равно " +
                    numer[i] / denom[i]);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Делить на нуль нельзя!");
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Подходящий элемент не найден.");
            Console.WriteLine("Неисправимая ошибка - программа прервана.");
        }

        // таким образом во внутреннем блоке try перехватываются незначительные ошибки, исправив которые можно продолжать выполнение программы,
        // а во внешнем блоке находится обработчик ошибок, не подлежащих исправлению
    }
}

// Сгенерировать исключение вручную.
class ThrowDemo
{
    static void test()
    {
        try
        {
        Console.WriteLine("До генерирования исключения.");
            throw new DivideByZeroException();
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Исключение перехвачено.");
        }
        Console.WriteLine("После пары операторов try/catch.");
    }
}

// Сгенерировать исключение повторно.
class Rethrow
{
    public static void GenException()
    {
        // Здесь массив numer длиннее массива denom.
        int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
        int[] denom = { 2, 0, 4, 4, 0, 8 };
        for (int i = 0; i < numer.Length; i++)
        {
            try
            {
                Console.WriteLine(numer[i] + " / " +
                denom[i] + " равно " +
                numer[i] / denom[i]);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Делить на нуль нельзя!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Подходящий элемент не найден.");
                throw; // сгенерировать исключение повторно
            }
        }
    }
}
class RethrowDemo
{
    static void test()
    {
        try
        {
            Rethrow.GenException();
        }
        catch (IndexOutOfRangeException)
        {
            // перехватить исключение повторно
            Console.WriteLine("Неисправимая ошибка - программа прервана.");
        }
    }
}

// Использовать члены класса Exception.
class ExcTest
{
    public static void GenException()
    {
        int[] nums = new int[4];
        Console.WriteLine("До генерирования исключения.");
        // Сгенерировать исключение в связи с выходом за границы массива.
        for (int i = 0; i < 10; i++)
        {
            nums[i] = i;
            Console.WriteLine("nums[{0}]: (1)", i, nums[i]);
        }
        Console.WriteLine("He подлежит выводу");
    }
}
class UseExcept
{
    static void test()
    {
        try
        {
            ExcTest.GenException();
        }
        catch (IndexOutOfRangeException exc)
        {
            Console.WriteLine("Стандартное сообщение таково: ");
            Console.WriteLine(exc); // вызвать метод ToString()
            Console.WriteLine("Свойство StackTrace: " + exc.StackTrace);
            Console.WriteLine("Свойство Message: " + exc.Message);
            Console.WriteLine("Свойство TargetSite: " + exc.TargetSite);
        }
        Console.WriteLine("После блока перехвата исключения.");
    }
}

// Продемонстрировать обработку исключения NullReferenceException.
class X
{
    int x;
    public X(int a)
    {
        x = a;
    }
    public int Add(X o)
    {
        return x + o.x;
    }
}
// Продемонстрировать генерирование и обработку
// исключения NullReferenceException.
class NREDemo
{
    static void test()
    {
        X p = new X(10);
        X q = null; // присвоить явным образом пустое значение переменной q
        int val;
        try
        {
            val = p.Add(q); // эта операция приведет к исключительной ситуации
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Исключение NullReferenceException!");
            Console.WriteLine("Исправление ошибки...\n");
            // А теперь исправить ошибку.
            q = new X(9);
            val = p.Add(q);
        }
        Console.WriteLine("Значение val равно {0}", val);
    }
}

// Использовать специальное исключение для обработки
// ошибок при обращении к массиву класса RangeArray.
// Создать исключение для класса RangeArray.
class RangeArrayException : Exception
{
    /* Реализовать все конструкторы класса Exception. Такие конструкторы просто
    реализуют конструктор базового класса. А поскольку класс исключения
    RangeArrayException ничего не добавляет к классу Exception, то никаких
    дополнительных действий не требуется. */
    //public RangeArrayException() : base() { }
    public RangeArrayException(string str) : base(str) { }
    //public RangeArrayException(string str, Exception inner) : base(str, inner) { }
    /*protected RangeArrayException(System.Runtime.Serialization.SerializationInfo si,
    System.Runtime.Serialization.StreamingContext sc) : base(si, sc) { }*/
    // Переопределить метод ToString() для класса исключения RangeArrayException.
    public override string ToString()
    {
        return Message;
    }
}
// Улучшенный вариант класса RangeArray.
class RangeArrayNew
{
    // Закрытые данные.
    int[] a; // ссылка на базовый массив
    int lowerBound; // наименьший индекс
    int upperBound; // наибольший индекс
                    // Автоматически реализуемое и доступное только для чтения свойство Length.
    public int Length { get; private set; }
    // Построить массив по заданному размеру
    public RangeArrayNew(int low, int high)
    {
        high++;
        if (high <= low)
            throw new RangeArrayException("Нижний индекс не меньше верхнего.");
        a = new int[high - low];
        Length = high - low;
        lowerBound = low;
        upperBound = --high;
    }
    // Это индексатор для класса RangeArray.
    public int this[int index]
    {
        // Это аксессор get.
        get
        {
            if (ok(index))
                return a[index - lowerBound];
            else
                throw new RangeArrayException("Ошибка нарушения границ.");
        }
        // Это аксессор set.
        set
        {
            if (ok(index))
                a[index - lowerBound] = value;
            else 
                throw new RangeArrayException("Ошибка нарушения границ.");
        }
    }
    // Возвратить логическое значение true, если
    // индекс находится в установленных границах.
    private bool ok(int index)
    {
        if (index >= lowerBound & index <= upperBound) return true;
        return false;
    }
}
// Продемонстрировать применение массива с произвольно
// задаваемыми пределами индексирования.
class RangeArrayNewDemo
{
    static void test()
    {
        try
        {
            RangeArrayNew ra = new RangeArrayNew(-5, 5);
            RangeArrayNew ra2 = new RangeArrayNew(1, 10);
            // Использовать объект ra в качестве массива.
            Console.WriteLine("Длина массива ra: " + ra.Length);
            for (int i = -5; i <= 5; i++)
                ra[i] = i;
            Console.Write("Содержимое массива ra: ");
            for (int i = -5; i <= 5; i++)
                Console.Write(ra[i] + " ");
            Console.WriteLine("\n");
            // Использовать объект ra2 в качестве массива.
            Console.WriteLine("Длина массива ra2: " + ra2.Length);
            for (int i = 1; i <= 10; i++)
                ra2[i] = i;
            Console.Write("Длина массива ra2: ");
            for (int i = 1; i <= 10; i++)
                Console.Write(ra2[i] + " ");
        Console.WriteLine("\n");
        }
        catch (RangeArrayException exc)
        {
            Console.WriteLine(exc);
        }
        // А теперь продемонстрировать обработку некоторых ошибок.
        Console.WriteLine("Сгенерировать ошибки нарушения границ.");
        // Использовать неверно заданный конструктор.
        try
        {
            RangeArrayNew ra3 = new RangeArrayNew(100, -10); // Ошибка!
        }
        catch (RangeArrayException exc)
        {
            Console.WriteLine(exc);
        }
        // Использовать неверно заданный индекс.
        try
        {
            RangeArrayNew ra3 = new RangeArrayNew(-2, 2);
            for (int i = -2; i <= 2; i++)
                ra3[i] = i;
            Console.Write("Содержимое массива ra3: ");
            for (int i = -2; i <= 10; i++) // сгенерировать ошибку нарушения границ
                Console.Write(ra3[i] + " ");
        }
        catch (RangeArrayException exc)
        {
            Console.WriteLine(exc);
        }
    }
}

// Исключения производных классов должны появляться до
// исключений базового класса.

// Создать класс исключения.
class ExceptA : Exception
{
    public ExceptA(string str) : base(str) { }
    public override string ToString()
        {
            return Message;
        }
}
// Создать класс исключения, производный от класса ExceptA.
class ExceptB : ExceptA
{
    public ExceptB(string str) : base(str) { }
    public override string ToString()
    {
        return Message;
    }
}
class OrderMatters
{
    static void test()
    {
        for (int x = 0; x < 3; x++)
        {
            try
            {
                if (x == 0) throw new ExceptA("Перехват исключения типа ExceptA");
                else if (x == 1) throw new ExceptB("Перехват исключения типа ExceptB");
                else throw new Exception();
            }
            catch (ExceptB exc) 
            {
                Console.WriteLine(exc);
            }
            catch (ExceptA exc)
            {
                Console.WriteLine(exc);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }
    }
}


// Ключевые слова checked и unchecked.
class CheckedDemo
{
    static void test()
    {
        byte a, b;
        byte result;
        a = 127;
        b = 127;
        try
        {
            result = unchecked((byte)(a * b));
            Console.WriteLine("Непроверенный на переполнение результат: " + result);
            result = checked((byte)(a * b)); // эта операция приводит к исключительной ситуации
            Console.WriteLine("Проверенный на переполнение результат: " + result); //не подлежит выполнению
        }
        catch (OverflowException exc)
        {
            Console.WriteLine(exc);
        }
    }
}

// Продемонстрировать применение ключевых слов checked
// и unchecked в блоке операторов.
class CheckedBlocks
{
    static void test()
    {
        byte a, b;
        byte result;
        try
        {
            unchecked
            {
                a = 127;
                b = 127;
                result = ((byte)(a * b));
                Console.WriteLine("Непроверенный на переполнение результат: " + result);
                a = 125;
                b = 5;
                result = ((byte)(a * b));
                Console.WriteLine("Непроверенный на переполнение результат: " + result);
            }
            checked
            {
                a = 2;
                b = 7;
                result = ((byte)(a * b)); // верно
                Console.WriteLine("Проверенный на переполнение результат: " + result);
                a = 127;
                b = 127;
                result = ((byte)(a * b)); // эта операция приводит к исключительной ситуации
                Console.WriteLine("Проверенный на переполнение результат: " + result); // не подлежит выполнению
            }
        }
        catch (OverflowException exc)
        {
            Console.WriteLine(exc);
        }
    }
}