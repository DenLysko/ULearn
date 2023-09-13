using System;

namespace Lesson_13_4
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(Min(new[] { 3, 6, 2, 4 }));
            Console.WriteLine(Min(new[] { "B", "A", "C", "D" }));
            Console.WriteLine(Min(new[] { '4', '2', '7' }));
        }

        static object Min(Array arr)
        {
            if (arr.Length == 0) 
                return null;
            
            IComparable min = (IComparable)arr.GetValue(0);
            foreach (IComparable item in arr)
            {
                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }
            }
            return min;
        }
    }
}