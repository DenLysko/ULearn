using System;

namespace Lesson_13_5
{
    public class Program
    {
        static void Main()
        {

        }
    }

    class Book : IComparable
    {
        public string Title;
        public int Theme;

        public int CompareTo(object? obj)
        {
            var secondBook = (Book)obj;
            int firstResult = Theme.CompareTo(secondBook.Theme);
            if (firstResult == 0)
                return Title.CompareTo(secondBook.Title);
            return firstResult;
        }
    }
}