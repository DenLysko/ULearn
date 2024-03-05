using System.Collections.Generic;

namespace Lesson_13_3;

internal class Program
{
    public static void Main()
    {
        Console.WriteLine(MiddleOfThree(2, 5, 4));
        Console.WriteLine(MiddleOfThree(3, 1, 2));
        Console.WriteLine(MiddleOfThree(3, 5, 9));
        Console.WriteLine(MiddleOfThree("B", "Z", "A"));
        Console.WriteLine(MiddleOfThree(3.45, 2.67, 3.12));
    }

    static IComparable MiddleOfThree(IComparable a, IComparable b, IComparable c)
    {
        if (a.CompareTo(b) == 0 || a.CompareTo(c) == 0)
            return a;
        if (b.CompareTo(c) == 0)
            return b;

        if (a.CompareTo(b) < 0 && b.CompareTo(c) < 0
            || a.CompareTo(b) > 0 && b.CompareTo(c) > 0)
            return b;

        if (b.CompareTo(a) < 0 && a.CompareTo(c) < 0
            || b.CompareTo(a) > 0 && a.CompareTo(c) > 0)
            return a;
        return c;
    }
}
