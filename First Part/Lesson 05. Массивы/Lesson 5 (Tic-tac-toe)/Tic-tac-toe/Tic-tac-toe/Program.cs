using System;

namespace Tic_tac_toe
{
    public class Result
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }

        public static void Main()
        {
            Run("XXX OO. ...");
            Run("OXO XO. .XO");
            Run("OXO XOX OX.");
            Run("XOX OXO OXO");
            Run("... ... ...");
            Run("XXX OOO ...");
            Run("XOO XOO XX.");
            Run(".O. XO. XOX");
        }

        private static void Run(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
                for (var y = 0; y < field.Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }

        public static GameResult GetGameResult(Mark[,] field)
        {
            if (CheckWinner(field, Mark.Circle) && CheckWinner(field, Mark.Cross))
                return GameResult.Draw;
            else if (CheckWinner(field, Mark.Circle))
                return GameResult.CircleWin;
            else if (CheckWinner(field, Mark.Cross))
                return GameResult.CrossWin;
            else
                return GameResult.Draw;
        }

        public static bool CheckWinner(Mark[,] field, Mark sign)
        {
                return field[0, 0] == sign && field[1, 1] == sign && field[2, 2] == sign ||
                    field[0, 2] == sign && field[1, 1] == sign && field[2, 0] == sign ||
                    field[0, 0] == sign && field[0, 1] == sign && field[0, 2] == sign ||
                    field[1, 0] == sign && field[1, 1] == sign && field[1, 2] == sign ||
                    field[2, 0] == sign && field[2, 1] == sign && field[2, 2] == sign ||
                    field[0, 0] == sign && field[1, 0] == sign && field[2, 0] == sign ||
                    field[0, 1] == sign && field[1, 1] == sign && field[2, 1] == sign ||
                    field[0, 2] == sign && field[1, 2] == sign && field[2, 2] == sign; 
        }
    }
}
