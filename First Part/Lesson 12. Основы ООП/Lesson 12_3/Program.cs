using System.Runtime.CompilerServices;

namespace Lesson_12_3;

public static class StringExtension
{
    public static int ToInt(this string s)
        => int.TryParse(s, out int result)
        ? result
        : 0;
}
internal class Program
{

    public static void Main()
    {
        var arg1 = "100500";
        Console.Write(arg1.ToInt() + "42".ToInt()); // 100542
    }
}
