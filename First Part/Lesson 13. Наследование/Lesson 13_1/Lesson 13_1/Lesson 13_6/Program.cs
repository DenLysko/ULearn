using System;
using System.Collections;

namespace Lesson_13_6
{
    public class Program
    {
		private static void Main()
		{
			var array = new[]
			{
				//new Point { X = 1, Y = 0 },
				//new Point { X = -1, Y = 0 },
				//new Point { X = 0, Y = 1 },
				//new Point { X = 0, Y = -1 },
				//new Point { X = 0.01, Y = 1 }

				//new Point { X = 1, Y = 0 },
				//new Point { X = 1, Y = 1 },
				//new Point { X = 0, Y = 1 },
				//new Point { X = -1, Y = 1 },
				//new Point { X = -1, Y = 0 },
				//new Point { X = -1, Y = -1 },
				//new Point { X = 0, Y = -1 },
				//new Point { X = 1, Y = -1 },

				new Point { X = 1, Y = 1 },
				new Point { X = -1, Y = 1 },
				new Point { X = 0, Y = 1 },
				new Point { X = 1, Y = 0 },
				new Point { X = -1, Y = -1 },
				new Point { X = 1, Y = -1 },
				new Point { X = -1, Y = 0 },
				new Point { X = 0, Y = -1 },
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
			public int Compare(object? x, object? y)
			{				
				double firstAngle = CalculateAngle((Point)x);
				double secondAngle = CalculateAngle((Point)y);
				return firstAngle.CompareTo(secondAngle);
			}

			public double CalculateAngle(Point point)
			{
				if (point.X == 0)
				{
					if (point.Y > 0)
						return Math.PI / 2;
					// Случай, когда X = 0, Y = 0 не рассмотрен
					else
						return 3 * Math.PI / 2;
				}
				else if (point.X > 0 && point.Y >= 0)
					return Math.Abs(Math.Atan(point.Y / point.X));
				else if (point.X <= 0 && point.Y > 0)
					return Math.Abs(Math.Atan(point.Y / (point.X))) + Math.PI / 2;
				else if (point.X < 0 && point.Y <= 0)
					return Math.Abs(Math.Atan((point.Y) / (point.X))) + Math.PI;
				else
					return Math.Abs(Math.Atan((point.Y) / (point.X))) + 3 * Math.PI / 2;
			}
		}
    }
}