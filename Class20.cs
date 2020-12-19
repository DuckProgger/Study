// Перечисления

using System;
class EnumDemo
{
    enum Apple
    {
        Jonathan, GoldenDel, RedDel, Winesap,
        Cortland, McIntosh
    };
    static void test()
    {
        string[] color = 
        {
            "красный",
            "желтый",
            "красный",
            "красный",
            "красный",
            "красновато-зеленый"
        };
        Apple i; // объявить переменную перечислимого типа
                 // Использовать переменную i для циклического
                 // обращения к членам перечисления.
        for (i = Apple.Jonathan; i <= Apple.McIntosh; i++)
            Console.WriteLine(i + " имеет значение " + (int)i);
        Console.WriteLine();
        // Использовать перечисление для индексирования массива.
        for (i = Apple.Jonathan; i <= Apple.McIntosh; i++)
            Console.WriteLine("Цвет сорта " + i + " — " +
            color[(int)i]);
    }
}

// Сымитировать управление лентой конвейера.
class ConveyorControl
{
    // Перечислить команды конвейера.
    public enum Action { Start, Stop, Forward, Reverse };
    public void Conveyor(Action com)
    {
        switch (com)
        {
            case Action.Start:
                Console.WriteLine("Запустить конвейер.");
                break;
            case Action.Stop:
                Console.WriteLine("Остановить конвейер.");
                break;
            case Action.Forward:
                Console.WriteLine("Переместить конвейер вперед.");
                break;
            case Action.Reverse:
                Console.WriteLine("Переместить конвейер назад.");
                break;
        }
    }
}
class ConveyorDemo
{
    static void test()
    {
        ConveyorControl с = new ConveyorControl();
        с.Conveyor(ConveyorControl.Action.Start);
        с.Conveyor(ConveyorControl.Action.Forward);
        с.Conveyor(ConveyorControl.Action.Reverse);
        с.Conveyor(ConveyorControl.Action.Stop);
    }
}