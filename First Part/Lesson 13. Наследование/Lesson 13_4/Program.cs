namespace Lesson_13_4;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(Min(new[] { 3, 6, 2, 4 }));
        Console.WriteLine(Min(new[] { "B", "A", "C", "D" }));
        Console.WriteLine(Min(new[] { '4', '2', '7' }));
    }

    public static IComparable Min(Array array)
    {
        IComparable min = (IComparable)array.GetValue(0)!;
        for (int i = 1; i < array.Length; i++)
        {
            var anotherValue = array.GetValue(i);
            if (min!.CompareTo(anotherValue) > 0)
                min = (IComparable)anotherValue!;
        }
        return min;
    }
}
