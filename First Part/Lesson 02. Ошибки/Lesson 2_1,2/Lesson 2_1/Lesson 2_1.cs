using System;

namespace Lesson_2_1
{
    class Program
    {
        // Вот так объявляются enum'ы
        enum Lights
        {
            Red,
            Yellow,
            Green
        }
        static void Main()
        {
            var a = (int)Lights.Red;
            var b = (int)Lights.Yellow;
            var c = (int)Lights.Green;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
    }
}