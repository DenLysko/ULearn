using System;

namespace Lesson_6_5
{
    class Program
    {
        static void Main()
        {
            var array = new int[10];
            Console.WriteLine(array[0]);
            var ch = '1';
            var t = Char.GetNumericValue(ch);
            Console.WriteLine(t.GetType());
        }
    }
}