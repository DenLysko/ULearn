using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			if (IntersectionOfTheFirstType(r1, r2))
				return true;

			if (IntersectionOfTheSecondType(r1, r2))
				return true;

			if (IndexOfInnerRectangle(r1, r2) != -1)
				return true;

			return false;
		}

		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			if (!AreIntersected(r1, r2))
				return 0;
			
			if (r1.Width == 0 || r1.Height == 0 || r2.Width == 0 || r2.Height == 0)
				return 0;
			
			if (IndexOfInnerRectangle(r1, r2) == 0)
				return r1.Height * r1.Width;
			if (IndexOfInnerRectangle(r1, r2) == 1)
				return r2.Height * r2.Width;

			if (IntersectionOfTheFirstType(r1, r2))
            {
				if (FirstFirstType(r1, r2))
					return (Math.Min(r1.Right, r2.Right) - r2.Left) * (Math.Min(r1.Bottom, r2.Bottom) - r2.Top);
				if (FirstSecondType(r1, r2))
					return (r2.Bottom - r1.Top) * (Math.Min(r1.Right, r2.Right) - r2.Left);
				if (FirstThirdType(r1, r2))
					return (r2.Right - Math.Max(r1.Left, r2.Left)) * (Math.Min(r1.Bottom, r2.Bottom) - r2.Top);
				if (FirstFourthType(r1, r2))
					return (r2.Bottom - r1.Top) * (r2.Right - r1.Left);
            }

            if (IntersectionOfTheSecondType(r1, r2))
			{
				if (SecondFirstType(r1, r2))
				{
					if (r2.Top < r1.Top)
						return (r1.Width) * (r2.Bottom - r1.Top);
					else
						return (r1.Width) * (Math.Min(r2.Bottom, r1.Bottom) - r2.Top);
				}
				if (SecondSecondType(r1, r2))
				{
					if (r2.Left < r1.Left)
						return (r1.Height) * (r2.Right - r1.Left);
					else
						return (r1.Height) * (Math.Min(r2.Right, r1.Right) - r2.Left);
				}
			}
			return -1;
		}

		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			if (r1.Top >= r2.Top && r1.Left >= r2.Left &&
				r1.Bottom <= r2.Bottom && r1.Right <= r2.Right)
				return 0;
			if (r2.Top >= r1.Top && r2.Left >= r1.Left &&
				r2.Bottom <= r1.Bottom && r2.Right <= r1.Right)
				return 1;
			return -1;
		}

		public static bool IntersectionOfTheFirstType(Rectangle r1, Rectangle r2)
        {
            return FirstFirstType(r1, r2) || FirstSecondType(r1, r2) ||
				FirstThirdType(r1, r2) || FirstFourthType(r1, r2);
		}

		public static bool IntersectionOfTheSecondType(Rectangle r1, Rectangle r2)
        {
			return SecondFirstType(r1, r2) || SecondSecondType(r1, r2);
		}

		public static bool FirstFirstType(Rectangle r1, Rectangle r2)
        {
			return r1.Bottom >= r2.Top && r1.Top < r2.Top &&
				r1.Right >= r2.Left && r1.Left < r2.Left;
		}

		public static bool FirstSecondType(Rectangle r1, Rectangle r2)
        {
			return r1.Top <= r2.Bottom && r1.Bottom > r2.Bottom &&
				r1.Right >= r2.Left && r1.Left < r2.Left;
		}

		public static bool FirstThirdType(Rectangle r1, Rectangle r2)
        {
			return r1.Left <= r2.Right && r1.Right > r2.Right &&
				r1.Bottom >= r2.Top && r1.Top < r2.Top;
		}

		public static bool FirstFourthType(Rectangle r1, Rectangle r2)
        {
			return r1.Top <= r2.Bottom && r1.Bottom > r2.Bottom &&
				r1.Left <= r2.Right && r1.Right > r2.Right;
		}
		
		public static bool SecondFirstType(Rectangle r1, Rectangle r2)
        {
			if (r1.Left >= r2.Left && r1.Right <= r2.Right)
			{
				if ((r1.Top < r2.Top && r1.Bottom >= r2.Top) || (r1.Bottom > r2.Bottom) && (r1.Top <= r2.Bottom))
					return true;
			}
			return false;
		}
		
		public static bool SecondSecondType(Rectangle r1, Rectangle r2)
        {
			if (r1.Top >= r2.Top && r1.Bottom <= r2.Bottom)
			{
				if ((r1.Left < r2.Left && r1.Right >= r2.Left) || (r1.Left <= r2.Right && r1.Right > r2.Right))
					return true;
			}
			return false;
		}
	}
}