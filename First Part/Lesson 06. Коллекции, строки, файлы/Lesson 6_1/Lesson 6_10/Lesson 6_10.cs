using System;
using System.Reflection;

namespace Lesson_6_10
{
    class Program
    {
        static void Main()
        {
            File.WriteAllText("test.txt", "Hello, World!");
            // В какой папке находимся
            Console.WriteLine(Assembly.GetExecutingAssembly().Location);
            // Адрес сборки
            Console.WriteLine(Environment.CurrentDirectory);
            // Чтобы нормально записать путь до файла
            Console.WriteLine(Path.Combine(Environment.CurrentDirectory,"test.txt"));
            File.WriteAllLines("test1.txt", new string[]
            {
                "Line 1",
                "Line 2"
            });
            Console.WriteLine(File.ReadAllText("test1.txt"));
            foreach (var filename in Directory.GetFiles("."))
            {
                Console.WriteLine(filename);
            }
            File.WriteAllText("C:\test\new.txt", "123456");
        }
    }
}