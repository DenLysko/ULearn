namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			var numberOfIterations = (height - 1) / 4;
			DoTheIncompleteIteration(robot, width);
			DoTheRemainingIterations(robot, width, numberOfIterations - 1);
		}

		public static void DoTheIncompleteIteration(Robot robot, int width)
        {
			for (int i = 0; i < width - 3; i++)
				robot.MoveTo(Direction.Right);
			DoDoubleDownMove(robot);
			for(int i = 0; i < width - 3; i++)
				robot.MoveTo(Direction.Left);
		}

		public static void DoDoubleDownMove(Robot robot)
        {
			robot.MoveTo(Direction.Down);
			robot.MoveTo(Direction.Down);
        }

		public static void DoTheRemainingIterations(Robot robot, int width, int number)
		{
			for (int i = 0; i < number; i++)
				DoSingleIteration(robot, width);
        }

		public static void DoSingleIteration(Robot robot, int width)
        {
			DoDoubleDownMove(robot);
			DoTheIncompleteIteration(robot, width);
        }




	}
}