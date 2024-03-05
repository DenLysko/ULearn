using System.Collections;

namespace Lesson_13_6;

internal class Program
{
    public static void Main()
    {
        var array = new[]
        {
            new Point { X = 1, Y = 0 },
            new Point { X = -1, Y = 0 },
            new Point { X = 0, Y = 1 },
            new Point { X = 0, Y = -1 },
            new Point { X = 0.01, Y = 1 }
        };
    
        Array.Sort(array, new ClockwiseComparer());
        foreach (Point e in array)
            Console.WriteLine("{0} {1}", e.X, e.Y);
    }

    public class Point
    {
        public double X;
        public double Y;
    }

    public class ClockwiseComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var point1 = (Point)x;
            var point2 = (Point)y;
            
            var quarter1 = GetQuarter(point1);
            var quarter2 = GetQuarter(point2);
            if (quarter1 != quarter2)
                return quarter1.CompareTo(quarter2);

            var ctg1 = GetCtg(point1);
            var ctg2 = GetCtg(point2);

            return -ctg1.CompareTo(ctg2);
        }

        private double GetCtg(Point point)
        {
            return point.X / point.Y;
        }

        private int GetQuarter(Point x)
        {
            if (x.X > 0 && x.Y >= 0)
                return 1;
            if (x.X <= 0 && x.Y > 0)
                return 2;
            if (x.X < 0 && x.Y <= 0)
                return 3;
            return 4;
        }
    }
}
