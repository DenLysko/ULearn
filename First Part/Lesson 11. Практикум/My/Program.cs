using System;
using Calculator;

namespace My
{
    public class Program
    {
        public static void Main()
        {
            var shoulder = double.Parse(Console.ReadLine());
            var elbow = double.Parse(Console.ReadLine());
            var wrist = double.Parse(Console.ReadLine());

            var result = CalculateCoordinates(shoulder, elbow, wrist);

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}