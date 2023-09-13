using System;

namespace Lesson_1_2
{
    class Program
    {
        static void Main()
        {
            int a = 45;
            float b = 12.23f;
            double c = 12.52;
            long d = 3000000000000;
            b = a; // Неявный каст
            b = 12.23f;
            a = (int)b; // Явный каст
            b = (float)c; // Явный каст
            a = (int)d; // Плохой каст
            Console.WriteLine(a);
            a = (int)b;
            Console.WriteLine(a);
            a = (int)Math.Round(b);
            Console.WriteLine(a);
            checked // Чтобы дало ошибку
            {
                a = (int)d;
            }

        }
    }
}