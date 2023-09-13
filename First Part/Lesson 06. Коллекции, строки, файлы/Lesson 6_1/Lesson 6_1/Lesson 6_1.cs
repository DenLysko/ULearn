using System;

namespace Lesson_6_1
{
    class Program
    {
        static void Main()
        {
            //Обратите внимание на пространство имен
            //System.Collections.Generic
            //Угловые скобки пока - волшебные слова. 
            List<int> list = new List<int>();
            list.Add(0);

            List<string> list1 = new List<string>();

            list.Insert(1, 1);
            foreach(var e in list)
            {
                Console.WriteLine(e);
            }
            list.Clear();
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
                Console.WriteLine(list[i] + "\t" + list.Capacity);


            }
        }
    }
}