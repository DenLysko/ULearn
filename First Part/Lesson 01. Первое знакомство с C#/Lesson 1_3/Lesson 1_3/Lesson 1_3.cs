using System;
using System.Globalization;

namespace Lesson_1_3
{
    class Program
    {
        static void Main()
        {
            string str = "Hello, World!";
            Console.WriteLine(str);
            Console.WriteLine(str.Length);
            Console.WriteLine(str.Substring(0,5));
            // static - значит нужно вызывать через точку
           
            char a = str[0];
            Console.WriteLine(a);
            
            // Символы могут быть из разных языков, но 
            // консоль далеко не все их может вывести
            string str2 = null;
            
            // Ввод строки с консоли
            string str3 = Console.ReadLine();
            
            // Каст в строку
            int number = int.Parse(str3);
            Console.WriteLine(number + 1);
            str3 = number.ToString();
            
            // Необходимо вводить через запятую
            double number2 = double.Parse(Console.ReadLine());
            Console.WriteLine(number2 + 1);
            
            // Универсальный способ, но консоль выведет 
            // через запятую
            double number3 = double.Parse(Console.ReadLine(), 
                CultureInfo.InvariantCulture);
            Console.WriteLine(number3 + 10);

            // Вот так работает var
            var s = Console.ReadLine();
            int number4 = s.Length;
            Console.WriteLine(number4);

            


        }
    }
}