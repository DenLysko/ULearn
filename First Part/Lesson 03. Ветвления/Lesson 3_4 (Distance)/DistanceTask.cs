using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
            if (GetLengthOfSection(ax, ay, bx, by) == 0)
				return GetLengthOfSection(ax, ay, x, y);

			if (CheckPointOnTheSegment(ax, ay, bx, by, x, y))
				return 0;
			
            var area = GetHeronArea(GetLengthOfSection(ax, ay, bx, by), 
                GetLengthOfSection (ax, ay, x, y), GetLengthOfSection (bx, by, x, y));
            
            if (area < 1e-04)
				return Math.Min(GetLengthOfSection(ax, ay, x, y), GetLengthOfSection(bx, by, x, y));
            
            if (CheckObtuseAngle(ax, ay , bx, by, x, y))
               return Math.Min(GetLengthOfSection(ax, ay, x, y), GetLengthOfSection(bx, by, x, y));
			
            return 2 * area / GetLengthOfSection(ax, ay, bx, by);
		}

		public static double GetLengthOfSection (double x1, double y1, double x2, double y2)
        {
			return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

		public static double GetHeronArea(double ab, double ac, double bc)
        {
			var halfThePerimeter = (ab + ac + bc) / 2;
            if (halfThePerimeter * (halfThePerimeter - ab) * (halfThePerimeter - ac) * (halfThePerimeter - bc) < 1e-05)
            {
                return 0;
            }
            else
			    return Math.Sqrt(halfThePerimeter * (halfThePerimeter - ab) * (halfThePerimeter - ac) * (halfThePerimeter - bc));
        }

		public static bool CheckPointOnTheSegment (double ax, double ay, double bx, double by, double x, double y)
        {
            if (GetLengthOfSection(ax, ay, x, y) < 1e-05 || GetLengthOfSection(bx, by, x, y) < 1e-05)
                return true;
            if (Math.Abs(ay - by) < 1e-05)
                return Math.Abs(y - ay) < 1e-05 &&
                    (x - ax < 1e-05 && x - bx > -1e-05 ||
                    x - bx < 1e-05 && x - ax > -1e-05);
            if (Math.Abs(y - by) < 1e-05)
                return Math.Abs(x - bx) < 1e-05;
            return (Math.Abs(Math.Abs((ax - bx) / (ay - by)) - Math.Abs((x - bx) / (y - by))) < 1e-05) &&
                ((x - bx > -1e-05 && x - ax < 1e-05) || (x - bx < 1e-05 && x - ax > 1e-05)) &&
                ((y - by > -1e-05 && y - ay < 1e-05) || (y - by < 1e-05 && y - ay > 1e-05));
        }

        public static bool CheckObtuseAngle(double ax, double ay, double bx, double by, double x, double y)
        {
            var ab = GetLengthOfSection(ax, ay, bx, by);
            var ac = GetLengthOfSection(ax, ay, x, y);
            var bc = GetLengthOfSection(bx, by, x, y);
            var firstAngle = Math.Acos((ab * ab + ac * ac - bc * bc) / (2 * ab * ac));
            var secondAngle = Math.Acos((ab * ab + bc * bc - ac * ac) / (2 * ab * bc));
            return firstAngle - Math.PI / 2 > -1e-05 || secondAngle - Math.PI / 2 > -1e-05;
        }
    }
}