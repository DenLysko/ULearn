namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			int longerSideLength = width;
			int shorterSideLength = height;
			var shorterDirection = Direction.Down;
			var longerDirection = Direction.Right;
			if (width < height)
            {
				longerSideLength = height;
				shorterSideLength = width;
				shorterDirection = Direction.Right;
				longerDirection = Direction.Down;
			}
			var relationOfSteps = (longerSideLength - 2) / (shorterSideLength - 2);
			var numberOfIterations = shorterSideLength - 3;
			DoIterations(robot, relationOfSteps, longerDirection, shorterDirection, numberOfIterations);
		}

		public static void DoIterations(Robot robot, int relationOfSteps,
			Direction longerDirection, Direction shorterDirection, int numberOfIterations)
		{
			for (int i = 0; i < numberOfIterations; i++)
				DoOneIteration(robot, relationOfSteps, longerDirection, shorterDirection);
			DoIncompleteIteration(robot, relationOfSteps, longerDirection);
		}

		public static void DoOneIteration(Robot robot, int relationOfSteps,
			Direction longerDirection, Direction shorterDirection)
        {
			for (int i = 0; i < relationOfSteps; i++)
				robot.MoveTo(longerDirection);
			robot.MoveTo(shorterDirection);
		}

		public static void DoIncompleteIteration(Robot robot, int relationOfSteps,
			Direction longerDirection)
        {
			for (int i = 0; i < relationOfSteps; i++)
				robot.MoveTo(longerDirection);
        }
	}
}
