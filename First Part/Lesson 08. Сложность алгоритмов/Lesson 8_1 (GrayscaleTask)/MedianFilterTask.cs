using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace Recognizer;

internal static class MedianFilterTask
{
	private static int _width;
	private static int _height;
	/* 
	 * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
	 * обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
	 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
	 * https://en.wikipedia.org/wiki/Median_filter
	 * 
	 * Используйте окно размером 3х3 для не граничных пикселей,
	 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
	 */
	public static double[,] MedianFilter(double[,] original)
	{
        _width = original.GetLength(0);
        _height = original.GetLength(1);

		var result = new double[_width, _height];

		for (var i = 0; i < _width; i++)
			for (var j = 0; j < _height; j++)
				result[i, j] = CalculateMedianValue(i, j, original);
		return original;
	}

	private static double CalculateMedianValue(int i, int j, double[,] original) 
	{
		if (_width == 0 || _height == 0)
			throw new Exception();

		if (_width == 1 && _height == 1)
			return original[0, 0];

		// Придётся рассмотреть картинки размером 1x2 и 2x1)))
        if (IsCorner(i, j))
        {
			if (i == 0 && j == 0)
				return GetMedianValue(original[i, j], original[i, j + 1], original[i + 1, j], original[i + 1, j + 1]);
			else if (i == 0 && j == _height - 1)
				return GetMedianValue(original[i, j], original[i + 1, j], original[i + 1, j - 1], original[i, j - 1]);
			else if (i == _width - 1 && j == 0)
                return GetMedianValue(original[i, j], original[i - 1, j], original[i - 1, j + 1], original[i, j + 1]);
			else
                return GetMedianValue(original[i, j], original[i - 1, j], original[i - 1, j - 1], original[i, j - 1]);
        }
        else if (IsBoundary(i, j))
        {
			if (i == 0)
				return GetMedianValue(
					original[i, j - 1], original[i + 1, j - 1], 
					original[i, j], original[i, j + 1], 
					original[i + 1, j], original[i + 1, j + 1]);
			else if (j == 0)
			{
                return GetMedianValue(
					original[i - 1, j], original[i - 1, j + 1],
					original[i, j], original[i, j + 1],
					original[i + 1, j], original[i + 1, j + 1]);
            }
			else if (i == _width - 1)
			{
                return GetMedianValue(
					original[i - 1, j - 1], original[i, j - 1],
					original[i - 1, j], original[i, j],
					original[i - 1, j + 1], original[i, j + 1]);
            }
			else if (j == _height - 1)
            {
                return GetMedianValue(
                    original[i - 1, j - 1], original[i - 1, j],
                    original[i, j - 1], original[i, j],
                    original[i + 1, j - 1], original[i + 1, j]);
            }
        }
		return GetMedianValue(
				original[i - 1, j - 1], original[i, j - 1], original[i + 1, j - 1],
				original[i - 1, j], original[i, j], original[i + 1, j],
				original[i - 1, j + 1], original[i, j + 1], original[i + 1, j + 1]);
    }

	private static double GetMedianValue(params double[] values)
	{
		if (values == null)
			throw new Exception();

        var length = values.Length;
		if (length == 0)
			throw new Exception();

		if (length % 2 == 0)
		{
	        Array.Sort(values);
			return (values[length / 2 - 1] + values[length / 2]) / 2;
		}
		return values.Sum() / length;
	}

	private static bool IsCorner(int i, int j) 
	{
		return
			(i == 0 && j == 0)
			|| (i == _width - 1 && j == 0)
			|| (i == 0 && j == _height - 1)
			|| (i == _width - 1 && j == _height - 1);
	}

    private static bool IsBoundary(int i, int j)
    {
		return
			i == 0
			|| j == 0
			|| i == _width - 1
			|| j == _height - 1;
    }
}
