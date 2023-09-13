using System;
using System.Text;

namespace Lesson_6_8
{
    class Program
    {
        static void Main()
        {
			string str1 = "push asdgkj24ijtoidj";
			string str2 = "pop 8";
			string[] commands = new string[2];
			commands[0] = str1;
			commands[1] = str2;
			var result = ApplyCommands(commands);
			Console.WriteLine(result);
        }

		private static string ApplyCommands(string[] commands)
		{
			var builder = new StringBuilder();
			foreach (var command in commands)
			{
				if (command.Length > 4 && command[1] == 'u')
				{
					builder.Append(command.Substring(5));
				}
				else
				{
					var number = int.Parse(command.Substring(4));
					builder.Remove(builder.Length - number - 1, builder.Length - 1);
				}
			}
			var result = builder.ToString();
			return result;
		}
	}
}