using SkiaSharp;
using System;

namespace Recognizer;
internal static class SobelFilterTask
{
    public static double[,] SobelFilter(double[,] g, double[,] sx)
    {
        var width = g.GetLength(0);
        var height = g.GetLength(1);
        var result = new double[width, height];

        var sy = MatrixTranspose(sx);
        var vicinitySize = sx.GetLength(0);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Вместо этого кода должно быть поэлементное умножение матриц sx
                // и полученной транспонированием из неё sy на окрестность точки (x, y)
                // Такая операция ещё называется свёрткой (Сonvolution)
                var vicinity = GetVicinityOfPoint(x, y, g, vicinitySize);
                result[x,y] = SobelFilterForPointVicinity(vicinity, g[x, y], sx, sy);
            }
        }

        return result;
    }


    // Несколько костыльно получилось, из-за того, что изначально неправильно понял задание
    private static double[,] GetVicinityOfPoint(int x, int y, double[,] g, int vicinitySize)
    {
        int deviationFromCenter = (vicinitySize - 1) / 2;

        if (IsExtremePoint(x, y, g, deviationFromCenter))
            return new double[1, 1] { { g[x, y] } };

        var vicinity = new double[vicinitySize, vicinitySize];

        for (int i = -deviationFromCenter; i <= deviationFromCenter; i++)
            for (int j = -deviationFromCenter; j <= deviationFromCenter; j++)
                vicinity[i + deviationFromCenter, j + deviationFromCenter] = g[x + i, y + j];

        return vicinity;
    }

    private static bool IsExtremePoint(int x, int y, double[,] g, int deviationFromCenter)
    {
        return
            x < deviationFromCenter
            || y < deviationFromCenter
            || x >= (g.GetLength(0) - deviationFromCenter)
            || y >= (g.GetLength(1) - deviationFromCenter);
    }

    private static double SobelFilterForPointVicinity(double[,] vicinity, double pointValue, double[,] sx, double[,] sy)
    {
        if (vicinity.GetLength(0) == 0 || vicinity.GetLength(1) == 0)
            throw new ArgumentException("Область точки задана неверно");

        if (vicinity.GetLength(0) < sx.GetLength(0) || vicinity.GetLength(1) < sx.GetLength(0))
            return 0;

        var gradX = Convolve(vicinity, sx);
        var gradY = Convolve(vicinity, sy);

        return Math.Sqrt(gradX * gradX + gradY * gradY);
    }

    private static double Convolve(double[,] vicinity, double[,] convolveMatrix)
    {
        if (vicinity.GetLength(0) != vicinity.GetLength(1))
            throw new Exception("Свертка не может происходить на не квадратных матрицах");

        int matrixSize = vicinity.GetLength(0);
        double result = 0;
        
        //var centerMinor = GetCenterMinor(convolveMatrix, matrixSize);
        for (int i = 0; i < matrixSize; i++)
            for (int j = 0; j < matrixSize; j++)
                result += (vicinity[i, j] * convolveMatrix[i, j]);

        return result;
    }

    private static double[,] MatrixTranspose(double[,] matrix)
    {
        var width = matrix.GetLength(0);
        var height = matrix.GetLength(1);
        var transposedMatrix = new double[width, height];

        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                transposedMatrix[i, j] = matrix[j, i];

        return transposedMatrix;
    }
}