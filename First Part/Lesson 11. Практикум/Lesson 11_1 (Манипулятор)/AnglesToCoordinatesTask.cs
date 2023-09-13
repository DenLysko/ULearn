using System;
using System.Drawing;
using NUnit.Framework;

namespace Manipulation
{
    public static class AnglesToCoordinatesTask
    {
        /// <summary>
        /// По значению углов суставов возвращает массив координат суставов
        /// в порядке new []{elbow, wrist, palmEnd}
        /// </summary>
        public static PointF[] GetJointPositions(double shoulder, double elbow, double wrist)
        {
            var elbowPos = new PointF((float)Math.Cos(shoulder) * Manipulator.UpperArm,
                                      (float)Math.Sin(shoulder) * Manipulator.UpperArm);

            var wristPos = new PointF(elbowPos.X - (float)Math.Cos(elbow + shoulder) * Manipulator.Forearm,
                                      elbowPos.Y - (float)Math.Sin(elbow + shoulder) * Manipulator.Forearm);

            var palmEndPos = new PointF(wristPos.X + (float)Math.Cos(wrist + elbow + shoulder) * Manipulator.Palm,
                                        wristPos.Y - (float)Math.Sin(wrist + elbow + shoulder) * Manipulator.Palm);
            return new PointF[]
            {
                elbowPos,
                wristPos,
                palmEndPos
            };
        }
    }

    [TestFixture]
    public class AnglesToCoordinatesTask_Tests
    {
        // Доработайте эти тесты!
        // С помощью строчки TestCase можно добавлять новые тестовые данные.
        // Аргументы TestCase превратятся в аргументы метода.
        [TestCase(Math.PI / 2, Math.PI / 2, Math.PI, Manipulator.Forearm + Manipulator.Palm, Manipulator.UpperArm)]
        [TestCase(0, 0, 0, - Manipulator.Forearm + Manipulator.Palm + Manipulator.UpperArm, 0)]
        [TestCase(Math.PI / 2, 3 * Math.PI / 2, Math.PI / 2, - Manipulator.Forearm, Manipulator.UpperArm + Manipulator.Palm)]
        [TestCase(Math.PI, Math.PI, Math.PI / 2, - Manipulator.Forearm - Manipulator.UpperArm, Manipulator.Palm)]
        public void TestGetJointPositions(double shoulder, double elbow, double wrist, double palmEndX, double palmEndY)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(shoulder, elbow, wrist);
            Assert.AreEqual(palmEndX, joints[2].X, 1e-5, "palm endX");
            Assert.AreEqual(palmEndY, joints[2].Y, 1e-5, "palm endY");
            Assert.AreEqual(Math.Sqrt(joints[0].X * joints[0].X + joints[0].Y * joints[0].Y), 
                            Manipulator.UpperArm, 1e-5);
            Assert.AreEqual(Math.Sqrt( (joints[1].X - joints[0].X) * (joints[1].X - joints[0].X) + 
                                        ((joints[1].Y - joints[0].Y) * (joints[1].Y - joints[0].Y))), 
                            Manipulator.Forearm, 1e-5);
        }
    }
}