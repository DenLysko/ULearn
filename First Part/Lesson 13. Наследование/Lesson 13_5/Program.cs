namespace Lesson_13_5;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    class Book : IComparable
    {
        public string Title;
        public int Theme;

        public int CompareTo(object? obj)
        {
            var book = (Book)obj!;
            if (Theme.CompareTo(book.Theme) < 0)
                return -1;
            else if (Theme.CompareTo(book.Theme) > 0)
                return 1;
            else
                return Title.CompareTo(book.Title);
        }
    }
}
