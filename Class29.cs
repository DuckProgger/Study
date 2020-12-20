#define TRIAL
using System;
using System.Reflection;
// Простой пример применения атрибута.
namespace с30_1
{
    using System;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.All)]
    public class RemarkAttribute : Attribute
    {
        string pri_remark; // базовое поле свойства Remark
        public RemarkAttribute(string comment)
        {
            pri_remark = comment;
        }
        public string Remark
        {
            get
            {
                return pri_remark;
            }
        }
    }
    [RemarkAttribute("В этом классе используется атрибут.")]
    class UseAttrib
    {
        // ...
    }
    class AttribDemo
    {
        static void test()
        {
            Type t = typeof(UseAttrib);
            Console.Write("Атрибуты в классе " + t.Name + ": ");
            object[] attribs = t.GetCustomAttributes(false);
            foreach (object o in attribs)
            {
                Console.WriteLine(o);
            }
            Console.Write("Примечание: ");
            // Извлечь атрибут RemarkAttribute.
            Type tRemAtt = typeof(RemarkAttribute);
            RemarkAttribute ra = (RemarkAttribute)Attribute.GetCustomAttribute(t, tRemAtt);

            Console.WriteLine(ra.Remark);
            // RemarkAttribute ra = (RemarkAttribute)Attribute.GetCustomAttribute(typeof(UseAttrib), typeof(RemarkAttribute));
            // Console.WriteLine(ra.Remark);
        }
    }

}

// Использовать именованный параметр атрибута.
namespace c30_2
{
    using System;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.All)]
    public class RemarkAttribute : Attribute
    {
        string pri_remark; // базовое поле свойства Remark
        public string Supplement; // это именованный параметр
        public RemarkAttribute(string comment)
        {
            pri_remark = comment;
            Supplement = "Отсутствует";
        }
        public string Remark
        {
            get
            {
                return pri_remark;
            }
        }
    }
    [RemarkAttribute("В этом классе используется атрибут.",
    Supplement = "Это дополнительная информация.")]
    class UseAttrib
    {
        // ...
    }
    class NamedParamDemo
    {
        static void test()
        {
            Type t = typeof(UseAttrib);
            Console.Write("Атрибуты в классе " + t.Name + ": ");
            object[] attribs = t.GetCustomAttributes(false);
            foreach (object o in attribs)
            {
                Console.WriteLine(o);
            }
            // Извлечь атрибут RemarkAttribute.
            Type tRemAtt = typeof(RemarkAttribute);
            RemarkAttribute ra = (RemarkAttribute)Attribute.GetCustomAttribute(t, tRemAtt);
            Console.Write("Примечание: ");
            Console.WriteLine(ra.Remark);
            Console.Write("Дополнение: ");
            Console.WriteLine(ra.Supplement);
        }
    }
}

// Использовать свойство в качестве именованного параметра атрибута.
namespace c30_3
{
    using System;
    using System.Reflection;
    [AttributeUsage(AttributeTargets.All)]
    public class RemarkAttribute : Attribute
    {
        string pri_remark; // базовое поле свойства Remark
        public string Supplement; // это именованный параметр
        public RemarkAttribute(string comment)
        {
            pri_remark = comment;
            Supplement = "Отсутствует";
            Priority = 1;
        }
        public string Remark
        {
            get
            {
                return pri_remark;
            }
        }
        // Использовать свойство в качестве именованного параметра.
        public int Priority { get; set; }
    }
    [RemarkAttribute("В этом классе используется атрибут.",
        Supplement = " Это дополнительная информация.",
        Priority = 10)]
    class UseAttrib
    {
        // ...
    }
    class NamedParamDemo
    {
        static void test()
        {
            Type t = typeof(UseAttrib);
            Console.Write("Атрибуты в классе " + t.Name + ": ");
            object[] attribs = t.GetCustomAttributes(false);
            foreach (object o in attribs)
            {
                Console.WriteLine(o);
            }
            // Извлечь атрибут RemarkAttribute.
            Type tRemAtt = typeof(RemarkAttribute);
            RemarkAttribute ra = (RemarkAttribute)Attribute.GetCustomAttribute(t, tRemAtt);
            Console.WriteLine("Примечание: " + ra.Remark);
            Console.WriteLine("Дополнение: " + ra.Supplement);
            Console.WriteLine("Приоритет: " + ra.Priority);
        }
    }
}

// Продемонстрировать применение встроенного атрибута Conditional.
namespace c30_4
{

    using System;
    using System.Diagnostics;
    class Test
    {
        [Conditional("TRIAL")]
        void Trial()
        {
            Console.WriteLine("Пробная версия, не " +
            "предназначенная для распространения.");
        }
        [Conditional("RELEASE")]
        void Release()
        {
            Console.WriteLine("Окончательная рабочая версия.");
        }
        static void test()
        {
            Test t = new Test();
            t.Trial(); //вызывается только в том случае, если
                       // определен идентификатор TRIAL
            t.Release(); // вызывается только в том случае, если
                         // определен идентификатор RELEASE
        }
    }
}

// Продемонстрировать применение атрибута Obsolete.
namespace c30_5
{

    using System;
    class Test
    {
        [Obsolete("Лучше использовать метод MyMeth2.")]
        public static int MyMeth(int a, int b)
        {
            return a / b;
        }
        // Усовершенствованный вариант метода MyMeth.
        public static int MyMeth2(int a, int b)
        {
            return b == 0 ? 0 : a / b;
        }
        static void test()
        {
            // Для этого кода выводится предупреждение.
            Console.WriteLine("4 / 3 равно " + Test.MyMeth(4, 3));
            // А для этого кода предупреждение не выводится.
            Console.WriteLine("4 / 3 равно " + Test.MyMeth2(4, 3));
        }
    }
}

namespace c30_test
{
    [AttributeUsage(AttributeTargets.Property)]
    class NameAttribute : Attribute
    {
        public string Name { get; private set; }

        public NameAttribute(string name)
        {
            Name = name;
        }
    }

    class Fields
    {
        [Name("Володька")]
        int Field { get; set; }
    }


    class AttributeTest
    {
        [Name("Володька")]
        static int Field { get; set; }

        static void test()
        {
            // извлечение атрибута из свойства того же класса, в котором определён извлекающий метод
            var t = typeof(AttributeTest).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            NameAttribute attr = (NameAttribute)t[0].GetCustomAttribute(typeof(NameAttribute));
            Console.WriteLine(attr.Name);
            
            // извлечение атрибута из свойства экзепляра
            Fields f = new Fields();
            Type t2 = f.GetType();
            PropertyInfo[] pi = t2.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
            NameAttribute attr2 = (NameAttribute)pi[0].GetCustomAttribute(typeof(NameAttribute));
            Console.WriteLine(attr2.Name);

        }
    }
}

