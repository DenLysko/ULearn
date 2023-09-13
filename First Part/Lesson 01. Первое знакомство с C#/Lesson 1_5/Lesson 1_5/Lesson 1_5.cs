using System;

namespace Lesson_1_5
{
    class Program
    {
        // Лучше не заводить глобальных переменных
        //static int glovalVariable;
        static void Main()
        {
            // Неинициализированная глобальная переменная
            // равна нулю, а локальная неинициализированная
            // не имеет значения по умолчанию; и это 
            // относится не только к int

            // Неправильно
            //int localVariable;

            var localVariable = 0;
            Console.WriteLine(localVariable.ToString());
            localVariable = DoWork();
            Console.WriteLine(localVariable);

            // Применение TryParse
            bool b = double.TryParse("asd", out double d);
            Console.WriteLine(d.GetType());
            
        }

        static void M1()
        {
            int i = 0;
            
        }

        static string who = "class";
        static void Mixed()
        {   
            // Использовать локальную переменную перед 
            // её объявлением нельзя, даже если есть 
            // глобальная с таким же именем
            //Console.Write(who + " ");
            
            string who = "Mixed";
            Console.Write(who);
        }
        static int DoWork()
        {
            return 10;
        }
    }
}