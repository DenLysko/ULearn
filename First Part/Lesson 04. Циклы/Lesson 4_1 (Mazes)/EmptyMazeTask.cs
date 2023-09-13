namespace Mazes
{
	public static class EmptyMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			MoveToRightWall(robot, width);
			MoveToDownWall(robot, height);
		}

		public static void MoveToRightWall(Robot robot, int width)
        {
			for (int i = 0; i < width - 3; i++)
				robot.MoveTo(Direction.Right);
		}

		public static void MoveToDownWall(Robot robot, int height)
		{
			for (int i = 0; i < height - 3; i++)
				robot.MoveTo(Direction.Down);
		}
	}
}