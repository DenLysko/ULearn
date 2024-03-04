using System;
using System.Drawing;
using Color = Avalonia.Media.Color;

namespace GeometryTasks;

public class Vector
{
    public double X;
    public double Y;

    public double GetLength() =>
        Geometry.GetLength(this);

    public Vector Add(Vector vector) =>
        Geometry.Add(this, vector);

    public bool Belongs(Segment segment) =>
        Geometry.IsVectorInSegment(this, segment);
}

public class Segment
{
    public Vector Begin;
    public Vector End;
    public Color Color;

    public double GetLength() => Geometry.GetLength(this);

    public bool Contains(Vector vector) => 
        Geometry.IsVectorInSegment(vector, this);


}

public class Geometry
{
    public static double GetLength(Vector vector) =>
        Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);

    public static double GetLength(Segment segment) =>
        Math.Sqrt(
            Math.Pow((segment.Begin.X -  segment.End.X), 2) 
            + Math.Pow((segment.Begin.Y - segment.End.Y), 2));

    public static Vector Add(Vector vector1, Vector vector2)
    {
        var resultVector = new Vector
        {
            X = vector1.X + vector2.X,
            Y = vector1.Y + vector2.Y
        };
        return resultVector;
    }

    public static Vector Subtract(Vector vector1, Vector vector2)
    {
        var resultVector = new Vector
        {
            X = vector1.X - vector2.X,
            Y = vector1.Y - vector2.Y
        };
        return resultVector;
    }

    public static bool IsVectorInSegment(Vector vector, Segment segment)
    {
        var segmentLength = GetLength(segment);

        var fromBeginToPoint = Subtract(vector, segment.Begin);
        var fromEndToPoint = Subtract(vector, segment.End);
        
        return Math.Abs(
            (GetLength(fromBeginToPoint) + GetLength(fromEndToPoint)) - segmentLength) < 1e-3;
    }
}