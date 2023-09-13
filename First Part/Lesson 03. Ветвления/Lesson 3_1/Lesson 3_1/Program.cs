using System;

namespace Lesson_4_1
{
    class Program
    {
        enum Suits
        {
            Wands,
            Coins,
            Cups,
            Swords
        }

        public static void Main()
        {
            Console.WriteLine(GetSuit(Suits.Wands));
            Console.WriteLine(GetSuit(Suits.Coins));
            Console.WriteLine(GetSuit(Suits.Cups));
            Console.WriteLine(GetSuit(Suits.Swords));

            var arrayToPower = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var array = GetPoweredArray(arrayToPower, 3);
            foreach (var element in array)
            {
                Console.Write(element);
                Console.Write(" ");
            }
            var arrr = new int[4];
            foreach (var element in arrr)
            {
                element = 0;
            }

        }
        public static int[] GetPoweredArray(int[] arr, int power)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (int)Math.Pow(arr[i], power);
            }
            return arr;

        }
        private static string GetSuit(Suits suit)
        {
            
            return new string[] { "жезлов", "монет", "кубков", "мечей" }[(int)suit] ;

            //   return var strs[(int)suit] = new[] { "жезлов", "монет", "кубков", "мечей" };
        }
    }
}