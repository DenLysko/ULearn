using System;
using static System.Console;
using Solver;

namespace Lesson_7;

public class Program
{
    public static void Main()
    {
        var a = double.Parse(ReadLine());
        var b = double.Parse(ReadLine());
        var c = double.Parse(ReadLine());

        var result = QuadraticEquationsSolver.Solve(a, b, c);

        WriteLine(result[0]);
        WriteLine(result[1]);
    }


}