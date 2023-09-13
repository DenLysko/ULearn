using System;
using System.Diagnostics;
using System.Text;

namespace Lesson_6_7
{
    class Program
    {
        static void Main()
        {
            // Нужен, когда много работы со строками
            // На то он и билдер))
            var builder = new StringBuilder();
            builder.Append("Hello");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = "";
            for (int i = 0; i < 10000; i++)
            {
                result += i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            builder.Clear();
            for (int i = 0; i < 10000000; i++)
            {
                builder.Append(i);
            }
            stopwatch1.Stop();
            Console.WriteLine(stopwatch1.ElapsedMilliseconds);

            string str = "123";
            //var number = (int)str.Substring(1);
        
        }
    }
}