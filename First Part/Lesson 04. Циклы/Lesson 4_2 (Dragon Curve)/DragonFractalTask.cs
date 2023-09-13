// В этом пространстве имен содержатся средства для работы с изображениями. 
// Чтобы оно стало доступно, в проект был подключен Reference на сборку System.Drawing.dll
using System;
using System.Drawing;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
			double x = 1.0;
			double y = 0.0;
			double x1, y1;
			int nextNumber;
			var random = new Random(seed);
			for (int i = 0; i < iterationsCount; i++)
			{
				nextNumber = random.Next(2);
				if (nextNumber % 2 == 0)
				{
					x1 = (x * Math.Cos(Math.PI / 4) - y * Math.Sin(Math.PI / 4)) / Math.Sqrt(2);
					y1 = (x * Math.Sin(Math.PI / 4) + y * Math.Cos(Math.PI / 4)) / Math.Sqrt(2);
				}
				else
				{
					x1 = (x * Math.Cos(3 * Math.PI / 4) - y * Math.Sin(3 * Math.PI / 4)) / Math.Sqrt(2) + 1;
					y1 = (x * Math.Sin(3 * Math.PI / 4) + y * Math.Cos(3 * Math.PI / 4)) / Math.Sqrt(2);
				}
				pixels.SetPixel(x1, y1);
				x = x1;
				y = y1;
			}
		}
	}
}