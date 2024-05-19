using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Recognizer;

public static class ThresholdFilterTask
{
    private static int _width;
    private static int _height;
    private static int _pixelCount;

    public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
	{
        _width = original.GetLength(0);
        _height = original.GetLength(1);
        _pixelCount = _width * _height;

        var threshold = GetThreshold(original, whitePixelsFraction);

        var result = new double[_width, _height];

        for (int i = 0; i < _width; i++)
            for (int j = 0; j < _height; j++)
                if (original[i, j] >= threshold)
                    result[i, j] = 1;

        return result;
    }

    private static double GetThreshold(double[,] original, double whitePixelsFraction)
    {
        if ((int)(whitePixelsFraction * _pixelCount) == 0)
            return int.MaxValue;
        
        var oneDimesionArray = new List<double>(_pixelCount + 1);

        for (int i = 0; i < _width; i++)
            for (int j  = 0; j < _height; j++)
                oneDimesionArray.Add(original[i, j]);

        oneDimesionArray.Sort();
        oneDimesionArray.Reverse();
        return oneDimesionArray[(int)(whitePixelsFraction * (_pixelCount)) - 1];
    }
}
