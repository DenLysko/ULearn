using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class Coordinates
    {
        public static int[][] GetJointPositions(double shoulder, double elbow, double wrist)
        {


            double upperArm = 150;
            double foreArm = 120;
            double palmArm = 60;
            var elbowPosX = Math.Cos(shoulder) * upperArm;
            var elbowPosY = Math.Sin(shoulder) * upperArm;
            //var elbowPos = new PointF((float)Math.Cos(shoulder) * Manipulator.UpperArm,
            //    (float)Math.Sin(shoulder) * Manipulator.UpperArm);

            var wristPosX = elbowPosX - Math.Cos(elbow + shoulder) * foreArm;
            var wristPosY = elbowPosY - Math.Sin(elbow + shoulder) * foreArm;

            //var wristPos = new PointF(elbowPos.X - (float)Math.Cos(elbow + shoulder) * Manipulator.Forearm,
            //    elbowPos.Y - (float)Math.Sin(elbow + shoulder) * Manipulator.Forearm);

            var palmPosX = elbowPosX + wristPosX + Math.Cos(elbow + shoulder + wrist) * palmArm;
            var palmPosY = elbowPosY + wristPosY + Math.Cos(elbow + shoulder + wrist) * palmArm;

            //var palmEndPos = new PointF(elbowPos.X + wristPos.X + (float)Math.Cos(wrist + elbow + shoulder) * Manipulator.Palm,
            //    elbowPos.Y + wristPos.Y - (float)Math.Sin(wrist + elbow + shoulder) * Manipulator.Palm);
            return new double int[3][2]
            {
                new double[] {}
                wristPos,
                palmEndPos
            };
        }
    }
}