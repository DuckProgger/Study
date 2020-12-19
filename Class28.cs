// Продемонстрировать применение оператора is.
using System;

namespace c29_1
{
    class A { }
    class В : A { }
    class UseIs
    {
        static void test()
        {
            A a = new A();
            В b = new В();
            if (a is A)
                Console.WriteLine("а имеет тип A");
            if (b is A)
                Console.WriteLine("b совместим с А, поскольку он производный от А");
            if (a is В)
                Console.WriteLine("Не выводится, поскольку а не производный от В");
            if (b is В)
                Console.WriteLine("В имеет тип В");
            if (a is object)
                Console.WriteLine("а имеет тип object");
        }
    }
}

// Использовать оператор is для предотвращения неправильного приведения типов.
namespace c29_2
{
    class A { }
    class B : A { }
    class CheckCast
    {
        static void test()
        {
            A a = new A();
            B b = new B();
            // Проверить, можно ли привести а к типу В.
            if (a is B) // если да, то выполнить приведение типов
                b = (B)a;
            else // если нет, то пропустить приведение типов
                b = null;
            if (b == null)
                Console.WriteLine("Приведение типов b = (В) HE допустимо.");
            else
                Console.WriteLine("Приведение типов b = (В) допустимо.");
        }
    }
}

// Продемонстрировать применение оператора as.
namespace c29_3
{
    class A { }
    class В : A { }
    class CheckCast
    {
        static void test()
        {
            A a = new A();
            В b = new В();
            b = a as В; // выполнить приведение типов, если это возможно
            if (b == null)
                Console.WriteLine("Приведение типов b = (В) НЕ допустимо.");
            else
                Console.WriteLine("Приведение типов b = (В) допустимо.");
        }
    }
}

// Продемонстрировать применение оператора typeof.
namespace c29_4
{
    using System;
    using System.IO;
    class UseTypeof
    {
        static void test()
        {
            Type t = typeof(Type);
            Console.WriteLine(t.FullName);
            if (t.IsClass) Console.WriteLine("Относится к классу.");
            if (t.IsAbstract) Console.WriteLine("Является абстрактным классом.");
            else Console.WriteLine("Является конкретным классом.");
        }
    }
}

// Анализ методов с помощью рефлексии.
namespace c29_5
{
    using System;
    using System.Reflection;
    class MyClass
    {
        int x;
        int y;
        public MyClass(int i, int j)
        {
            x = i;
            y = j;
        }
        public int Sum()
        {
            return x + y;
        }
        public bool IsBetween(int i)
        {
            if (x < i && i < y) return true;
            else return false;
        }
        public void Set(int a, int b)
        {
            x = a;
            y = b;
        }
        public void Set(double a, double b)
        {
            x = (int)a;
            y = (int)b;
        }
        public void Show()
        {
            Console.WriteLine(" x: {0}, у: {1}", x, y);
        }
    }
    class ReflectDemo
    {
        static void test()
        {
            Type t = typeof(MyClass); // получить объект класса Type,
                                      // представляющий класс MyClass
            Console.WriteLine("Анализ методов, определенных в классе " + t.Name);
            Console.WriteLine();
            Console.WriteLine("Поддерживаемые методы: ");
            MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public); // извлекаем только методы, определённые в классе
            // Вывести методы, поддерживаемые в классе MyClass.
            foreach (MethodInfo m in mi)
            {
                // Вывести возвращаемый тип и имя каждого метода.
                Console.Write(" " + m.ReturnType.Name + " " + m.Name + "(");
                // Вывести параметры.
                ParameterInfo[] pi = m.GetParameters();
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name);
                    if (i + 1 < pi.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
                Console.WriteLine();
            }
        }
    }
}

// Вызвать методы с помощью рефлексии.
namespace c29_6
{
    using System;
    using System.Reflection;
    class MyClass
    {
        int x;
        int y;
        public MyClass(int i, int j)
        {
            x = i;
            y = j;
        }
        public int Sum()
        {
            return x + y;
        }
        public bool IsBetween(int i)
        {
            if ((x < i) && (i < y)) return true;
            else return false;
        }
    public void Set(int a, int b)
        {
            Console.Write("В методе Set(int, int). ");
            x = a;
            y = b;
            Show();
        }
        // Перегрузить метод Set.
        public void Set(double a, double b)
        {
            Console.Write("В методе Set(double, double). ");
            x = (int)a;
            y = (int)b;
            Show();
        }
        public void Show()
        {
            Console.WriteLine("Значение x: {0}, значение у: {1}", x, y);
        }
    }
    class InvokeMethDemo
    {
        static void test()
        {
            Type t = typeof(MyClass);
            MyClass reflectOb = new MyClass(10, 20);
            int val;
            Console.WriteLine("Вызов методов, определенных в классе " + t.Name);
            Console.WriteLine();
            MethodInfo[] mi = t.GetMethods();
            // Вызвать каждый метод.
            foreach (MethodInfo m in mi)
            {
                // Получить параметры.
                ParameterInfo[] pi = m.GetParameters();
                if (m.Name.CompareTo("Set") == 0 && pi[0].ParameterType == typeof(int))
                {
                    object[] args = new object[2];
                    args[0] = 9;
                    args[1] = 18;
                    m.Invoke(reflectOb, args);
                }
                else if (m.Name.CompareTo("Set") == 0 && pi[0].ParameterType == typeof(double))
                {
                    object[] args = new object[2];
                    args[0] = 1.12;
                    args[1] = 23.4;
                    m.Invoke(reflectOb, args);
                }
                else if (m.Name.CompareTo("Sum") == 0)
                {
                    val = (int)m.Invoke(reflectOb, null);
                    Console.WriteLine("Сумма равна " + val);
                }
                else if (m.Name.CompareTo("IsBetween") == 0)
                {
                    object[] args = new object[1];
                    args[0] = 14;
                    if ((bool)m.Invoke(reflectOb, args))
                        Console.WriteLine("Значение 14 находится между x и у");
                }
                else if (m.Name.CompareTo("Show") == 0)
                {
                    m.Invoke(reflectOb, null);
                }
            }
        }
    }
}

// Создать объект с помощью рефлексии.
namespace c29_7
{
    using System;
    using System.Reflection;
    class MyClass
    {
        int x;
        int y;
        public MyClass(int i)
        {
            Console.WriteLine("Конструирование класса MyClass(int, int). ");
            x = y = i;
        }
        public MyClass(int i, int j)
        {
            Console.WriteLine("Конструирование класса MyClass(int, int). ");
            x = i;
            y = j;
            Show();
        }
        public int Sum()
        {
            return x + y;
        }
        public bool IsBetween(int i)
        {
            if ((x < i) && (i < y)) return true;
            else return false;
        }
        public void Set(int a, int b)
        {
            Console.Write("В методе Set(int, int). ");
            x = a;
            y = b;
            Show();
        }
        // Перегрузить метод Set.
        public void Set(double a, double b)
        {
            Console.Write("В методе(double, double). ");
            x = (int)a;
            y = (int)b;
            Show();
        }
        public void Show()
        {
            Console.WriteLine("Значение x: {0}, значение у: {1}", x, y);
        }
    }
    class InvokeConsDemo
    {
        static void test()
        {
            Type t = typeof(MyClass);
            int val;
            // Получить сведения о конструкторе.
            ConstructorInfo[] ci = t.GetConstructors();
            Console.WriteLine("Доступные конструкторы: ");
            foreach (ConstructorInfo с in ci)
            {
                // Вывести возвращаемый тип и имя.
                Console.Write(" " + t.Name + "(");
                // Вывести параметры.
                ParameterInfo[] pi = с.GetParameters();
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name);
                    if (i + 1 < pi.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
            Console.WriteLine();
        // Найти подходящий конструктор.
            int x;
            for (x = 0; x < ci.Length; x++)
            {
                ParameterInfo[] pi = ci[x].GetParameters();
                if (pi.Length == 2) break;
            }
            if (x == ci.Length)
            {
                Console.WriteLine("Подходящий конструктор не найден.");
                return;
            }
            else
                Console.WriteLine("Найден конструктор с двумя параметрами.\n");
            // Сконструировать объект.
            object[] consargs = new object[2];
            consargs[0] = 10;
            consargs[1] = 20;
            object reflectOb = ci[x].Invoke(consargs);
            Console.WriteLine("\nВызов методов для объекта reflectOb.");
            Console.WriteLine();
            MethodInfo[] mi = t.GetMethods();
            // Вызвать каждый метод.
            foreach (MethodInfo m in mi)
            {
                // Получить параметры.
                ParameterInfo[] pi = m.GetParameters();
                if (m.Name.CompareTo("Set") == 0 &&
                pi[0].ParameterType == typeof(int))
                {
                    // Это метод Set(int, int).
                    object[] args = new object[2];
                    args[0] = 9;
                    args[1] = 18;
                    m.Invoke(reflectOb, args);
                }
                else if (m.Name.CompareTo("Set") == 0 &&
                pi[0].ParameterType == typeof(double))
                {
                    // Это метод Set(double, double).
                    object[] args = new object[2];
                    args[0] = 1.12;
                    args[1] = 23.4;
                    m.Invoke(reflectOb, args);
                }
                else if (m.Name.CompareTo("Sum") == 0)
                {
                    val = (int)m.Invoke(reflectOb, null);
                    Console.WriteLine("Сумма равна " + val);
                }
                else if (m.Name.CompareTo("IsBetween") == 0)
                {
                    object[] args = new object[1];
                    args[0] = 14;
                    if ((bool)m.Invoke(reflectOb, args))
                        Console.WriteLine("Значение 14 находится между x и у");
                }
                else if (m.Name.CompareTo("Show") == 0)
                {
                    m.Invoke(reflectOb, null);
                }
            }
        }
    }
}

// Обнаружить сборку, определить типы и создать объект с помощью рефлексии. 
namespace c29_8
{
    
    using System;
    using System.Reflection;
    class ReflectAssemblyDemo
    {
        static void test()
        {
            int val;
            // Загрузить сборку MyClasses.exe.
            Assembly asm = Assembly.LoadFrom("Study.dll");
            // Обнаружить типы, содержащиеся в сборке MyClasses.exe.
            Type[] alltypes = asm.GetTypes();
            Type t = null;
            foreach (Type type in alltypes)
            {
                Console.WriteLine("Найдено: " + type.Name);
                // найти класс MyClass из пространства имён c29_7
                if (type.Namespace == "c29_7" && type.Name == "MyClass")
                {
                    t = type; 
                    Console.WriteLine(type.Namespace);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Использовано: " + t.Name);
            // Получить сведения о конструкторе.
            ConstructorInfo[] ci = t.GetConstructors();
            Console.WriteLine("Доступные конструкторы: ");
            foreach (ConstructorInfo с in ci)
            {
                // Вывести возвращаемый тип и имя.
                Console.Write(" " + t.Name + "(");
                // Вывести параметры.
                ParameterInfo[] pi = с.GetParameters();
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name);
                    if (i + 1 < pi.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
            Console.WriteLine();
            // Найти подходящий конструктор.
            int x;
            for (x = 0; x < ci.Length; x++)
            {
                ParameterInfo[] pi = ci[x].GetParameters();
                if (pi.Length == 2) break;
            }
            if (x == ci.Length)
            {
                Console.WriteLine("Подходящий конструктор не найден.");
                return;
            }
            else
                Console.WriteLine("Найден конструктор с двумя параметрами.\n");
            // Сконструировать объект.
            object[] consargs = new object[2];
            consargs[0] = 10;
            consargs[1] = 20;
            object reflectOb = ci[x].Invoke(consargs);
            Console.WriteLine("/nВызов методов для объекта reflectOb.");
            Console.WriteLine();
            MethodInfo[] mi = t.GetMethods();
            // Вызвать каждый метод.
            foreach (MethodInfo m in mi)
            {
                // Получить параметры.
                ParameterInfo[] pi = m.GetParameters();
                if (m.Name.CompareTo("Set") == 0 &&
                pi[0].ParameterType == typeof(int))
                {
                    // Это метод Set(int, int).
                    object[] args = new object[2];
                    args[0] = 9;
                    args[1] = 18;
                    m.Invoke(reflectOb, args);
                }
                else if (m.Name.CompareTo("Set") == 0 &&
                pi[0].ParameterType == typeof(double))
                {
                    // Это метод Set(double, double).
                    object[] args = new object[2];
                    args[0] = 1.12;
                    args[1] = 23.4;
                    m.Invoke(reflectOb, args);
                }
                else if (m.Name.CompareTo("Sum") == 0)
                {
                    val = (int)m.Invoke(reflectOb, null);
                    Console.WriteLine("Сумма равна " + val);
                }
                else if (m.Name.CompareTo("IsBetween") == 0)
                {
                    object[] args = new object[1];
                    args[0] = 14;
                    if ((bool)m.Invoke(reflectOb, args))
                        Console.WriteLine("Значение 14 находится между x и у");
                }
                else if (m.Name.CompareTo("Show") == 0)
                {
                    m.Invoke(reflectOb, null);
                }
            }
        }
    }
}

namespace c29_9
{
    // Использовать класс MyClass, ничего не зная о нем заранее.
    using System;
    using System.Reflection;
    class ReflectAssemblyDemo
    {
        static void test()
        {
            int val;
            Assembly asm = Assembly.LoadFrom("Study.dll");
            Type[] alltypes = asm.GetTypes();
            Type t = null;
            foreach (Type type in alltypes)
            {
                // найти класс MyClass из пространства имён c29_7
                if (type.Namespace == "c29_7" && type.Name == "MyClass")
                {
                    t = type;
                    break;
                }
            }
            if (t == null) // если класс не найден
            {
                Console.WriteLine("Класс не найден");
                return;
            }
            Console.WriteLine("Использовано: " + t.Name + " из пространства имён " + t.Namespace);
            ConstructorInfo[] ci = t.GetConstructors();
            // Использовать первый обнаруженный конструктор.
            ParameterInfo[] cpi = ci[0].GetParameters();
            object reflectOb;
            if (cpi.Length > 0)
            {
                object[] consargs = new object[cpi.Length];
                // Инициализировать аргументы.
                for(int n = 0; n < cpi.Length; n++)
                   consargs[n] = 10 + n * 20;
                // Сконструировать объект.
                reflectOb = ci[0].Invoke(consargs);
            }
            else
                reflectOb = ci[0].Invoke(null);
            Console.WriteLine("\nВызов методов для объекта reflectOb.");
            Console.WriteLine();
            // Игнорировать наследуемые методы.
            MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly |
            BindingFlags.Instance |
            BindingFlags.Public);
            // Вызвать каждый метод.
            foreach (MethodInfo m in mi)
            {
                Console.WriteLine("Вызов метода {0} ", m.Name);
                // Получить параметры.
                ParameterInfo[] pi = m.GetParameters();
                // Выполнить методы.
                switch (pi.Length)
                {
                    case 0: // аргументы отсутствуют
                        if (m.ReturnType == typeof(int))
                        {
                            val = (int)m.Invoke(reflectOb, null);
                            Console.WriteLine("Результат: " + val);
                        }
                        else if (m.ReturnType == typeof(void))
                        {
                            m.Invoke(reflectOb, null);
                        }
                        break;
                    case 1: // один аргумент
                        if (pi[0].ParameterType == typeof(int))
                        {
                            object[] args = new object[1];
                            args[0] = 14;
                            if ((bool)m.Invoke(reflectOb, args))
                                Console.WriteLine("Значение 14 находится между x и у");
                            else
                                Console.WriteLine("Значение 14 не находится между х и у");
                        }
                        break;
                    case 2: // два аргумента
                        if ((pi[0].ParameterType == typeof(int)) &&
                        (pi[1].ParameterType == typeof(int)))
                        {
                            object[] args = new object[2];
                            args[0] = 9;
                            args[1] = 18;
                            m.Invoke(reflectOb, args);
                        }
                        else if ((pi[0].ParameterType == typeof(double)) &&
                        (pi[1].ParameterType == typeof(double)))
                        {
                            object[] args = new object[2];
                            args[0] = 1.12;
                            args[1] = 23.4;
                            m.Invoke(reflectOb, args);
                        }
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}