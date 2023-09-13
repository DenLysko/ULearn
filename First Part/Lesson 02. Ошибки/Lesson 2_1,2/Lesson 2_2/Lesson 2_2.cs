using System;

class Program
{
    static void Main()
    {
        try
        {
            FailProcess();
        }
        catch
        {
            Console.WriteLine("Failed to fail process!");
            Console.ReadKey();
        }

        static void FailProcess()
        {
            unchecked
            {
                Console.WriteLine();
            }
        }
    }
}