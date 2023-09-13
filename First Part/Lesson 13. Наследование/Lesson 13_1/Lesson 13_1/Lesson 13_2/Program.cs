using System;

namespace Lesson_13_2
{
    public class Program
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

		public static Array Combine(params object[] arrays)
        {
			if (arrays.Length == 0)
				return null;

			var firstArrayType = arrays[0].GetType().GetElementType();
			string str = "123";
            string[] strings = new string[] { str };
			int int1 = 5;
			var arr3 = Array.CreateInstance(firstArrayType, 0);

			// Пришлось закинуть arr3 через ref, потому что он оказывается ValueType
            if(!CreateFinalArray(firstArrayType, ref arr3, ref str, int1, strings, arrays))
				return null;

			int i = 0;
			foreach (Array array in arrays)
            {
				foreach (var item in array)
                {
					if (item.GetType() != firstArrayType)
						return null;
					arr3.SetValue(item, i);
					i++;
                }
            }

			return arr3;
        }

		public static bool CreateFinalArray(Type type, ref Array arr3, ref string str, int int1, string[] strings, params object[] arrays)
        {
			int length = 0;
			foreach (var array in arrays)
			{
				length += ((Array)array).Length;
				if (array.GetType().GetElementType() != type)
					return false;
			}
			strings[0] = "456";
			str = "456";
			int1 = 4;
			arr3 = Array.CreateInstance(type, length);
			return true;
		}
	}
}