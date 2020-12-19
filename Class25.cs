using System;

// Очень простой пример, демонстрирующий событие.
namespace c25_1
{

    // Объявить тип делегата для события.
    delegate void MyEventHandler();

    // Объявить класс, содержащий событие.
    class MyEvent
    {
        public event MyEventHandler SomeEvent;

        // Этот метод вызывается для запуска события.
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent();
        }
    }
    class EventDemo
    {
        // Обработчик события.
        static void Handler()
        {
            Console.WriteLine("Произошло событие");
        }
        static void test()
        {
            MyEvent evt = new MyEvent();
            // Добавить метод Handler() в список событий.
            evt.SomeEvent += Handler;
            // Запустить событие.
            evt.OnSomeEvent();
        }
    }
}

// Групповая адресация события.
namespace c25_2
{

    // Объявить тип делегата для события.
    delegate void MyEventHandler();
    class MyEvent
    {
        public event MyEventHandler SomeEvent;

        // Этот метод вызывается для запуска события.
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent();
        }
    }

    class H
    {
        public void Xhandler()
        {
            Console.WriteLine("Событие получено объектом класса X");
        }
    }
    class M
    {
        public void Yhandler()
        {
            Console.WriteLine("Событие получено объектом класса Y");
        }
    }
    class EventDemo2
    {
        static void Handler()
        {
            Console.WriteLine("Событие получено объектом класса EventDemo");
        }
        static void test()
        {
            MyEvent evt = new MyEvent();
            H xOb = new H();
            M yOb = new M();
            // Добавить обработчики в список событий.
            evt.SomeEvent += Handler;
            evt.SomeEvent += xOb.Xhandler;
            evt.SomeEvent += yOb.Yhandler;
            // Запустить событие.
            evt.OnSomeEvent();
            Console.WriteLine();
            // Удалить обработчик.
            evt.SomeEvent -= xOb.Xhandler;
            evt.OnSomeEvent();
        }
    }
}

// Применение аксессоров событий
namespace c25_3
{
    delegate void MyEventHandler();

    // Объявить класс для хранения максимум трех событий.
    class MyEvent2
    {
        MyEventHandler[] evnt = new MyEventHandler[3];

        public event MyEventHandler SomeEvent
        {
            // Добавить событие в список.
            add
            {
                int i;
                for (i = 0; i < 3; i++)
                    if (evnt[i] == null)
                    {
                        evnt[i] = value;
                        break;
                    }
                if (i == 3) Console.WriteLine("Список событий заполнен.");
            }
            // Удалить событие из списка.
            remove
            {
                int i;
                for (i = 0; i < 3; i++)
                    if (evnt[i] == value)
                    {
                        evnt[i] = null;
                        break;
                    }
                if (i == 3) Console.WriteLine("Обработчик событий не найден.");
            }
        }
        // Этот метод вызывается для запуска событий.
        public void OnSomeEvent()
        {
            for (int i = 0; i < 3; i++)
                if (evnt[i] != null) evnt[i]();
        }
    }

}



// Создать ряд классов, использующих делегат MyEventHandler.
namespace c25_4
{
    delegate void MyEventHandler();

    // Объявить класс для хранения максимум трех событий.
    class MyEvent2
    {
        MyEventHandler[] evnt = new MyEventHandler[3];

        public event MyEventHandler SomeEvent
        {
            // Добавить событие в список.
            add
            {
                int i;
                for (i = 0; i < 3; i++)
                    if (evnt[i] == null)
                    {
                        evnt[i] = value;
                        break;
                    }
                if (i == 3) Console.WriteLine("Список событий заполнен.");
            }
            // Удалить событие из списка.
            remove
            {
                int i;
                for (i = 0; i < 3; i++)
                    if (evnt[i] == value)
                    {
                        evnt[i] = null;
                        break;
                    }
                if (i == 3) Console.WriteLine("Обработчик событий не найден.");
            }
        }
        // Этот метод вызывается для запуска событий.
        public void OnSomeEvent()
        {
            for (int i = 0; i < 3; i++)
                if (evnt[i] != null) evnt[i]();
        }
    }
    class W
    {
        public void Whandler()
        {
            Console.WriteLine("Событие получено объектом W");
        }
    }
    class J
    {
        public void Xhandler()
        {
            Console.WriteLine("Событие получено объектом X");
        }
    }
    class K
    {
        public void Yhandler()
        {
            Console.WriteLine("Событие получено объектом Y");
        }
    }
    class Z
    {
        public void Zhandler()
        {
            Console.WriteLine("Событие получено объектом Z");
        }
    }
    class EventDemo5
    {
        static void test()
        {
            MyEvent2 evt = new MyEvent2();
            W wOb = new W();
            J xOb = new J();
            K yOb = new K();
            Z zOb = new Z();
            // Добавить обработчики в цепочку событий.
            Console.WriteLine("Добавление событий. ");
            evt.SomeEvent += wOb.Whandler;
            evt.SomeEvent += xOb.Xhandler;
            evt.SomeEvent += yOb.Yhandler;

            // Сохранить нельзя - список заполнен.
            evt.SomeEvent += zOb.Zhandler;
            Console.WriteLine();
            // Запустить события.
            evt.OnSomeEvent();
            Console.WriteLine();
            // Удалить обработчик.
            Console.WriteLine("Удаление обработчика xOb.Xhandler.");
            evt.SomeEvent -= xOb.Xhandler;
            evt.OnSomeEvent();
            Console.WriteLine();
            // Попробовать удалить обработчик еще раз.
            Console.WriteLine("Попытка удалить обработчик " +
            "xOb.Xhandler еще раз.");
            evt.SomeEvent -= xOb.Xhandler;
            evt.OnSomeEvent();
            Console.WriteLine();
            // А теперь добавить обработчик Zhandler.
            Console.WriteLine("Добавление обработчика zOb.Zhandler.");
            evt.SomeEvent += zOb.Zhandler;
            evt.OnSomeEvent();
        }
    }
}

// Использовать лямбда-выражение в качестве обработчика событий.
namespace c25_5
{
    // Объявить тип делегата для события.
    delegate void MyEventHandler2(int n);

    // Объявить класс, содержащий событие.
    class MyEvent3
    {
        public event MyEventHandler2 SomeEvent;
        // Этот метод вызывается для запуска события.
        public void OnSomeEvent(int n)
        {
            if (SomeEvent != null)
                SomeEvent(n);
        }
    }
    class LambdaEventDemo
    {
        static void test()
        {
            MyEvent3 evt = new MyEvent3();
            // Использовать лямбда-выражение в качестве обработчика событий.
            evt.SomeEvent += n => Console.WriteLine("Событие получено. Значение равно " + n);
            // Запустить событие.
            evt.OnSomeEvent(1);
            evt.OnSomeEvent(2);
        }
    }
}

// Пример формирования .NET-совместимого события.
namespace c25_6
{
    using System;
    // Объявить класс, производный от класса EventArgs.
    class MyEventArgs : EventArgs
    {
        public int EventNum;
    }
    // Объявить тип делегата для события.
    delegate void MyEventHandler(object source, MyEventArgs arg);
    // Объявить класс, содержащий событие.
    class MyEvent
    {
        static int count = 0;
        public event MyEventHandler SomeEvent;
        // Этот метод запускает событие SomeEvent.
        public void OnSomeEvent()
        {
            MyEventArgs arg = new MyEventArgs();
            if (SomeEvent != null)
            {
                arg.EventNum = count++;
                SomeEvent(this, arg);
            }
        }
    }
    class X
    {
        public void Handler(object source, MyEventArgs arg)
        {
            Console.WriteLine("Событие " + arg.EventNum +
            " получено объектом класса X.");
            Console.WriteLine("Источник: " + source);
            Console.WriteLine();
        }
    }
    class Y
    {
        public void Handler(object source, MyEventArgs arg)
        {
            Console.WriteLine("Событие " + arg.EventNum +
            " получено объектом класса Y.");
            Console.WriteLine("Источник: " + source);
            Console.WriteLine();
        }
    }
    class EventDemo6
    {
        static void test()
        {
            X ob1 = new X();
            Y ob2 = new Y();
            MyEvent evt = new MyEvent();
            // Добавить обработчик Handler() в цепочку событий.
            evt.SomeEvent += ob1.Handler;
            evt.SomeEvent += ob2.Handler;
            // Запустить событие.
            evt.OnSomeEvent();
            evt.OnSomeEvent();
        }
    }
}

// Использовать встроенный делегат EventHandler.
namespace c25_7
{
    // Объявить класс, содержащий событие,
    class MyEvent5
    {
        public event EventHandler SomeEvent; // использовать делегат EventHandler
                                             // Этот метод вызывается для запуска события.
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent(this, EventArgs.Empty);
        }
    }
    class EventDemo7
    {
        static void Handler(object source, EventArgs arg)
        {
            Console.WriteLine("Произошло событие");
            Console.WriteLine("Источник: " + source);
        }
        static void test()
        {
            MyEvent5 evt = new MyEvent5();
            // Добавить обработчик Handler() в цепочку событий.
            evt.SomeEvent += Handler;
            // Запустить событие.
            evt.OnSomeEvent();
        }
    }
}

// Пример обработки событий, связанных с нажатием клавиш на клавиатуре.
namespace c25_8
{
    // Создать класс, производный от класса EventArgs и
    // хранящий символ нажатой клавиши.
    class KeyEventArgs : EventArgs
    {
        public char ch;
    }
    // Объявить класс события, связанного с нажатием клавиш на клавиатуре.
    class KeyEvent
    {
        public event EventHandler<KeyEventArgs> KeyPress;
        // Этот метод вызывается при нажатии клавиши.
        public void OnKeyPress(char key)
        {
            KeyEventArgs k = new KeyEventArgs();
            if (KeyPress != null)
            {
                k.ch = key;
                KeyPress(this, k);
            }
        }
    }
    // Продемонстрировать обработку события типа KeyEvent.
    class KeyEventDemo
    {
        static void test()
        {
            KeyEvent kevt = new KeyEvent();
            ConsoleKeyInfo key;
            int count = 0;
            // Использовать лямбда-выражение для отображения факта нажатия клавиши.
            kevt.KeyPress += (sender, e) =>
            Console.WriteLine(" Получено сообщение о нажатии клавиши: " + e.ch);
            // Использовать лямбда-выражение для подсчета нажатых клавиш.
            kevt.KeyPress += (sender, e) =>
            count++; // count — это внешняя переменная
            Console.WriteLine("Введите несколько символов. " +
            "По завершении введите точку.");
            do
            {
                key = Console.ReadKey();
                kevt.OnKeyPress(key.KeyChar);
            } while (key.KeyChar != '.');
            Console.WriteLine("Было нажато " + count + " клавиш.");
        }
    }
}

// Использовать события таймера
namespace c25_test
{
    using System.Timers;
    class Demo
    {
        static int i = 0;

        public static void test()
        {
            Timer timer = new Timer(1000); 
            timer.AutoReset = true;

            A ob1 = new A();
            B ob2 = new B();

            timer.Elapsed += ob1.Inc; // подписать на событие объект А
            timer.Elapsed += ob2.Inc; // подписать на событие объект В
            timer.Elapsed += (x, y) => // добавить лямбда-выражение в событие
            {
                i += 3;
                Console.WriteLine("{0}\n{1}\n", i, DateTime.Now);
            };
            timer.Start();

            char ch = (char)Console.ReadKey().KeyChar;

        }

    }

    class A
    {
        public int val { get; private set; } 

        public void Inc(object sender, ElapsedEventArgs e)
        {
            val++;
            Console.WriteLine(val);
        }
    }

    class B
    {
        public int val { get; private set; }

        public void Inc(object sender, ElapsedEventArgs e)
        {
            val += 2;
            Console.WriteLine(val);
        }

    }


} 

// Отработка групповой адресации событий
namespace c25_test2
{
    class Demo
    {
        
        static void test()
        {
            E evt = new E();
            A ob1 = new A();
            B ob2 = new B();

            evt.Evt += ob1.Inc;
            evt.Evt += ob2.Inc;
            evt.Evt += (x, y) => Console.WriteLine("{0} {1} {2}", ob1.val, ob2.val, x);

            for (int i = 0; i < 10; i++)
            {
                evt.Elapse();
            }
        }


    }

    class E
    {
         public event EventHandler Evt;

         public void Elapse()
         {
            if (Evt != null)
            {
                Evt(this, EventArgs.Empty);
            }
         }
        
    }

    class A
    {
        public int val { get; private set; }

        public void Inc(object sender, EventArgs e)
        {
            val++;
        }
    }

    class B
    {
        public int val { get; private set; }

        public void Inc(object sender, EventArgs e)
        {
            val += 2;
        }

    }
}
