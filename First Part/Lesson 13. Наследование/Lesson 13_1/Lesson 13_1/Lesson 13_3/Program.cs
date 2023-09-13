using System;

namespace Lesson_13_3
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(MiddleOfThree(2, 5, 4));
            Console.WriteLine(MiddleOfThree(3, 1, 2));
            Console.WriteLine(MiddleOfThree(3, 5, 9));
            Console.WriteLine(MiddleOfThree("B", "Z", "A"));
            Console.WriteLine(MiddleOfThree(3.45, 2.67, 3.12));
        }

        public static object MiddleOfThree(IComparable firstObject,
           IComparable secondObject, IComparable thirdObject)
        {
            
            if ((firstObject).CompareTo(secondObject) < 0)
            {
                if ((thirdObject).CompareTo(firstObject) < 0)
                    return firstObject;
                else if ((thirdObject).CompareTo(secondObject) < 0)
                    return thirdObject;
                else
                    return secondObject;

            }
            else
            {
                if ((thirdObject).CompareTo(secondObject) < 0)
                    return secondObject;
                else if ((thirdObject).CompareTo(firstObject) < 0)
                    return thirdObject;
                else
                    return firstObject;
            }
        }
    }
}