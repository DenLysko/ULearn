namespace Recognizer;

public static class GrayscaleTask
{
	public static double[,] ToGrayscale(Pixel[,] original)
	{
		var width = original.GetLength(0);
		var height = original.GetLength(1);
		var grayscale = new double[width,height];

		for (int i = 0; i < width; i++)
			for (int j = 0; j < height; j++)
			{
				var currentPixel = original[i,j];
				grayscale[i,j] = (0.299 * currentPixel.R + 0.587*currentPixel.G + 0.114 * currentPixel.B) / 255;
			}

		return grayscale;
	}
}
