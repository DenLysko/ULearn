using System;



namespace GeometryTasks
{
    public class Vector
    {
        public double X;
        public double Y;   
    }

    public static class Geometry
    {
        public static double GetLength(Vector v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }

        public static Vector Add(Vector v1, Vector v2)
        {
            var sum =  new Vector();
            sum.X = v1.X + v2.X;
            sum.Y = v1.Y + v2.Y;
            return sum;
        }

        public static Vector Difference(Vector v1, Vector v2)
        {
            var sum = new Vector();
            sum.X = v1.X - v2.X;
            sum.Y = v1.Y - v2.Y;
            return sum;
        }

        public static double GetLength(Segment segm)
        {
            var difference = new Vector();
            difference = Difference(segm.End, segm.Begin);
            //difference.X = segm.End.X - segm.Begin.X;
            //difference.Y = segm.End.Y - segm.Begin.Y;
            return GetLength(difference);
        }

        public static bool IsVectorInSegment(Vector v, Segment segm)
        {
            var firstDifference = new Vector();
            firstDifference = Difference(v, segm.Begin);
            var secondDifference = new Vector();
            secondDifference = Difference(segm.End, v);

            var firstLength = GetLength(firstDifference);
            var secondLength = GetLength(secondDifference);
            var thirdLength = GetLength(segm);

            return firstLength + secondLength - thirdLength < 1e-05;
        }
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;  
    }
}