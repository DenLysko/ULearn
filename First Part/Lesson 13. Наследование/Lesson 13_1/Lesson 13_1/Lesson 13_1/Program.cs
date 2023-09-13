using System;

namespace Lesson_13_1
{
    public class Program
    {
		public static void Main()
		{
			Print(1, 2);
			Print("a", 'b');
			Print(1, "a");
			Print(true, "a", 1);
		}

		public static void Print(params object[] things)
        {
			int count = 0;
			foreach (object thing in things)
            {
				if (count < things.Length - 1)
					Console.Write(thing + ", ");
				else 
					Console.Write(thing);
				count++;
            }
			Console.WriteLine();
        }
	}
}