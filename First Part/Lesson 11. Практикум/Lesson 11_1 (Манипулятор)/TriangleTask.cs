using System;
using NUnit.Framework;

namespace Manipulation
{
    public class TriangleTask
    {
        /// <summary>
        /// Возвращает угол (в радианах) между сторонами a и b в треугольнике со сторонами a, b, c 
        /// </summary>
        public static double GetABAngle(double a, double b, double c)
        {
            if ( a <= 0 || b <= 0 || c < 0 || c == 0 && a != b)
                return double.NaN;
            if ( a - b - c > 1e-5 || b - a - c > 1e-5 || c - a - b > 1e-5)
                return double.NaN;
            return Math.Acos((a * a + b * b - c * c) / (2 * a * b));
        }
    }

    [TestFixture]
    public class TriangleTask_Tests
    {
        [TestCase(3, 4, 5, Math.PI / 2)]
        [TestCase(1, 1, 1, Math.PI / 3)]
        [TestCase(2, 2, 2, Math.PI / 3)]
        [TestCase(3, 3, 3, Math.PI / 3)]
        // добавьте ещё тестовых случаев!
        public void TestGetABAngle(double a, double b, double c, double expectedAngle)
        {
            var result = TriangleTask.GetABAngle(a, b, c);
            Assert.AreEqual(result, expectedAngle, 1e-5);
        }
    }
}