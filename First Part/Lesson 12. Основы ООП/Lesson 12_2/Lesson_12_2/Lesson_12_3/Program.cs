using System;

namespace Lesson_12_3
{
	public class Program
	{
		static double MyNextDouble(Random rnd, double min, double max)
		{
			return rnd.NextDouble() * (max - min) + min;
		}

		static void Main()
		{
			var rnd = new Random();
			Console.WriteLine(MyNextDouble(rnd, 10, 20));
			Console.WriteLine(rnd.NextDouble(10, 20));
			var array = new int[] { 1, 2, 3, 4, 5 };
			array.Swap(0, 1);
			var file = new FileInfo("text.txt");
			var str = file.Directory;
			var list = new List<DirectoryInfo>();
			//list.ToArray<string>();
			var str11 = "123";
			var str22 = "123";
			if (str11 == str22)
            {
                Console.WriteLine("Good");
            }
			var directoryInfo = new DirectoryInfo(".");
			var directoryInfo1 = new DirectoryInfo(".");
			Console.WriteLine(directoryInfo.ToString());

			if (directoryInfo.ToString() == directoryInfo1.ToString())
			{
				Console.WriteLine("Very Good");
			}
            else
            {
                Console.WriteLine("Saaad(");
            }
		
			var secondList = list.Distinct().ToList();
			foreach(var element in secondList)
            {
                Console.WriteLine(element);
            }
			foreach (var element in list)
			{
				Console.WriteLine(element);
			}
		}
	}

	public static class RandomExtensions
	{
		public static double NextDouble(this Random rnd, double min, double max)
		{
			return rnd.NextDouble() * (max - min) + min;
		}
	}

	public static class ArrayExtensions
	{
		public static void Swap(this int[] array, int i, int j)
		{
			var t = array[i];
			array[i] = array[j];
			array[j] = t;
		}
	}
}