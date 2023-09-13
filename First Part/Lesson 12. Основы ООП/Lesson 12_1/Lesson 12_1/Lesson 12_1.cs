using System;

namespace Lesson_12_1
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public int Age;

    }
    public class Program
    {
        static Student[] Students;

        // Из старого
        //static string[] FirstNames;
        //static string[] LastNames;
        //static int[] Age;
        
        static void PrintStudent (Student student)
        {
            Console.WriteLine("{0,15}{1}({2})", 
                student.LastName, 
                student.FirstName,
                student.Age);
        }

        static void Main()
        {
            Students = new []
            {
                new Student { FirstName = "John", 
                              LastName = "Jones", 
                              Age = 18},
                new Student { FirstName = "William", 
                              LastName = "Williams", 
                              Age = 19},
            };

            // Другой способ задать 
            //Students[0] = new Student();
            //Studens[0].FirstName = "John";
            //Studens[0].LastName = "Jones";

            PrintStudent(Students[0]);
            PrintStudent(Students[1]);
        }
    }
}