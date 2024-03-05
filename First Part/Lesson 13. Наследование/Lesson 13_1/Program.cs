namespace Lesson_13_1;

internal class Program
{
    public static void Main()
    {
        Print(1, 2);
        Print("a", 'b');
        Print(1, "a");
        Print(true, "a", 1);
    }

    public static void Print(params object[] arr) =>
        Console.WriteLine(string.Join(", ", arr));
}
