using System;

namespace Lesson_6_2
{
    class Program
    {
		// Шифр незнакомки
        static void Main()
        {
			var lines = new string[] { "Hello, my name is Denis", "I'm codding", "Please, don't distract me." };
			var message = DecodeMessage(lines);
			Console.WriteLine(message);
        }
		private static string DecodeMessage(string[] lines)
		{
			var result = new List<string>();
			foreach (var line in lines)
			{
				string[] words = line.Split(' ');
				foreach (var word in words)
					if (word.Length > 0 && char.IsUpper(word[0]))
						result.Add(word);
			}
			result.Reverse();
			return String.Join(" ", result.ToArray());
		}
	}
}