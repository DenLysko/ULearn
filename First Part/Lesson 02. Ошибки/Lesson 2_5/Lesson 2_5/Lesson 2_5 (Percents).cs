using System;

namespace Lesson_2_5
{
    class Program
    {
        static void Main()
        {
            string data = Console.ReadLine();
            double total = Calculate(data);

            Console.WriteLine(total);
        }

        static double Calculate(string data)
        {
            string[] dataInStrings = data.Split(' ');
            double originalAmount = double.Parse(dataInStrings[0]);
            double percentagesInYear = double.Parse(dataInStrings[1]);
            double percentagesInMonth = percentagesInYear / 12;
            double numberOfMonths = double.Parse(dataInStrings[2]);

            return originalAmount * Math.Pow((1 + percentagesInMonth/100), numberOfMonths);

        }
    }
}