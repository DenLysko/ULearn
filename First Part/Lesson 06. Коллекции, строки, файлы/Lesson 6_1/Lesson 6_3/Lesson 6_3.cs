using System;

namespace Lesson_6_3
{
    class Program
    {
        static void Main()
        {
            var array = new[] { "A", "B", "D", "A", "B" };
            var dictionary = new Dictionary<string, int>();
            //dictionary["A"] = 10;
            //Console.WriteLine(dictionary["A"]);
            
            foreach (var str in array)
            {
                if (!dictionary.ContainsKey(str))
                    dictionary[str] = 1;
                else
                    dictionary[str]++;
            }

            foreach (var pair in dictionary)
                Console.WriteLine(pair.Key + "\t" + pair.Value);
            // Словари немного медленнее массивов
            string str1 = "asdf";
            string str2 = str1.Substring(0, 2);
            Console.WriteLine(str2);
        }
    }
}