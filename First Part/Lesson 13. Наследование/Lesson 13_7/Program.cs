namespace Lesson_13_7;

public class Program
{
    public static void Main()
    {
        var triangle = new Triangle
        {
            A = new Point { X = 0, Y = 0 },
            B = new Point { X = 1, Y = 2 },
            C = new Point { X = 3, Y = 2 }
        };
        Console.WriteLine(triangle.ToString());
    }

    public class Point
    {
        public double X;
        public double Y;

        public override string ToString()
        {
            return $"{X} {Y}";
        }
    }

    public class Triangle
    {
        public Point A;
        public Point B;
        public Point C;

        public override string ToString()
        {
            string result = string.Empty;
            var points = new List<Point>{ A, B, C };
            
            foreach (var point in points)
                result += "(" + point.ToString() + ") ";
            
            return result.TrimEnd();
        }
    }
}
