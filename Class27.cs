// Препроцессор
//#define EXP

using System;
using System.Collections.Generic;
using System.Text;


namespace Study
{
    class Class27
    {
        static void test()
        {
            // можно свернуть то, что внутри региона
            #region test 
#if EXP
                Console.WriteLine("пк");
#error trhrt
#warning yyiuy
#else
            Console.WriteLine("пк");
#endif

#line 1 // теперь здесь начинется отсчёт линий
#line default // теперь отсчёт линий вернулся к исходной нумерации
#line hidden
            Console.WriteLine("пк"); // эти строки при пошаговой отладке пропускаются
            ;
            ;
#line default
            #endregion test
        }
    }

}
