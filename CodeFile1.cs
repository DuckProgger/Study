using System;
class Ladder
{
    static void xcv()
    {
        for (int num = 2; num < 500; num++)
            for (int i = 2; i <= 9; i++)
                if ((num % i) == 0)
                    break;
                else if (i == 9)
                    Console.WriteLine(num + " не делится на 2, 3, 5, 7 или 9");
    }
}