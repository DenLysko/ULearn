namespace Lesson_13_2;

internal class Program
{
    public static void Main()
    {
        var ints = new[] { 1, 2 };
        var strings = new[] { "A", "B" };

        Print(Combine(ints, ints));
        Print(Combine(ints, ints, ints));
        Print(Combine(ints));
        Print(Combine());
        Print(Combine(strings, strings));
        Print(Combine(ints, strings));
    }

    static void Print(Array array)
    {
        if (array == null)
        {
            Console.WriteLine("null");
            return;
        }
        for (int i = 0; i < array.Length; i++)
            Console.Write("{0} ", array.GetValue(i));
        Console.WriteLine();
    }
    
    public static Array Combine(params Array[] arrays)
    {
        if (arrays == null
            || arrays.Length == 0)
            return null!;

        var firstType = arrays[0].GetType().GetElementType();
        var resultLength = 0;

        foreach (var array in arrays)
        {
            if (array.GetType().GetElementType() != firstType)
                return null!;
            
            resultLength += array.Length;
        }

        var result = Array.CreateInstance(arrays[0].GetType().GetElementType()!, resultLength);

        long commonCounter = 0;
        foreach(var array in arrays)
            for (int i = 0; i < array.Length; i++, commonCounter++)
                result.SetValue(array.GetValue(i), commonCounter);
        
        return result;
    }

}
