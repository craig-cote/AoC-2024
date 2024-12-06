
using System.Numerics;

namespace Challenges
{
	//    Start:  9:00pm
	//    Break:  9:14pm
	//     Back:  9:30pm
	// A Solved: 11:20pm  Damn multidimensional arrays! :D
	// B solved: 00:00pm

	public class Day6
	{
		private const string Example = "....#.....\r\n.........#\r\n..........\r\n..#.......\r\n.......#..\r\n..........\r\n.#..^.....\r\n........#.\r\n#.........\r\n......#...";
		private const string Data = ".........#...................................................................................................#.................#..\r\n...........................#.......................................#..............................................................\r\n.............#.................................................................................#............................#.....\r\n...#.....................#.......#....................................#..............#.............................#...........#.#\r\n..........#.....#..#.....#.............#..................#............#.....#........#.#.......#............................#....\r\n...#...................#..........#...................#.........#..#..............##.......................................#......\r\n..................................................................................................#...............................\r\n...............#.........#....#.#..#.........#...........#...#....................#.........#.......#....#........................\r\n..........................................#......#.#...................................................#.............#............\r\n....................#............................#..........................................#.....................#.........#.....\r\n..............#..................................#................#..#...........................................#................\r\n.........#....###.......#........................................................................................#.#.....#...#..#.\r\n.#....................................#.....................................#.................................#..................#\r\n........................#...................................#.#....................#......##.#.........#..........................\r\n............#.......#..................#..........................................................................................\r\n....#.............#.#.....#...#.....#......................#...............#............##...#....................................\r\n...#....#.....................................##........#........#....##.....................................#....................\r\n...........................................................................#........#..........##................................#\r\n..............................#.#......................#..........................#..#........#...............................#...\r\n..............#.........###.......................................#...........#...............#......#.........#........#.....#...\r\n............#............................#....................#........................#............#.............................\r\n.........................................#.....................................................#.....#...............#............\r\n.#...##.......................#.......#..........................................................................#...#...........#\r\n....#..............#............#......#........................#.......................#...#.......................#.............\r\n.......#...............#......#......#..........................................#..................#....................#...#.....\r\n.......................................................................#.........#................................................\r\n.#.......#........................................................##..............................................................\r\n.........................#...................#..#......##..................................#......#......#........................\r\n......................................#..............................................#......#..........#.#.........#..............\r\n.....#..............#..#........#..............................#...##.............................................................\r\n..##............................#.......................................................#..........#..............................\r\n...........................................................##................................................#....................\r\n#...............#.........#.....................................................#......................###........................\r\n#.#.......................#........................#..#.....................#....#........#........................#...#.........#\r\n............#.............#.#............#........................#..........#....................................................\r\n............#...................#.....................................................................................#.......#...\r\n.............................#...#..#...........................#...#.........................................................#...\r\n........#.......................##..........................................................#.........#.....................#.....\r\n............##............#..........................................................#.#.....#......#.#.......#...................\r\n...........#.....#......#.................#.............#......................................#.....#...#........................\r\n#............#.........#.......##.....#......#...........#...........#.......#................#...................................\r\n......#..#...#.....#................................................#............#...#..........^.................................\r\n............................................................................................................#....#................\r\n......................................#.............................#........................#...............#.....#...#..........\r\n...#.........................................................................#....................................................\r\n.....................................#.........................................................#.............#.........#..........\r\n#..............................#...#.................................#............................................................\r\n..........#..................#............#.......#...........................#...................#.....#.........................\r\n............................#...##.............................................................#............#.....................\r\n.................#..................................................................#..#..............#...........................\r\n..................#...............................#................#............#...........#......#............#.................\r\n.....#......................#..............#.......................#......................#.......................................\r\n...............................#.....#.......................#.......#......................#......#............#...........#.....\r\n......#.............##....#.....#...............#.....#............................#....................................#.........\r\n...#.#.......#..#...##.............................................................#.#.#...........#.....#................#.......\r\n...........................................#...#......#...........................................................................\r\n.........#.................................#........................................................................#........#.#..\r\n........................#..........................................#.......#..............#.......................................\r\n....................................................#...............#..........................#..................................\r\n............................#................#......#...............#.....................#.......................................\r\n#.#............#......................................................................................#.....#.....................\r\n................................................................#....#..........................................#........#......#.\r\n.......#........#......................................................................#.................#..................#.#...\r\n...............................#...#......................................................................#.........#.........#...\r\n...........#..#..................##..#.........................................#..............##............................#.....\r\n#........#...............#.....#.....#.................#............#....#.............................#.......#.................#\r\n...............#...................................................#.......#.......................#......#.............#.........\r\n...#............................................................................................................................#.\r\n#.....................#......................................................#...........................................#........\r\n...........#..........................................#.......................................#.....................#.............\r\n....#.##.......#..............#.....#..............................#....................................#.....................#...\r\n...............................................................................................................#...............#..\r\n.#...........................#...#.....#...#...................#....#........#.........#................................#.........\r\n.................#............................................................................#........................#..#.......\r\n.............#....#.....................................................#............#.........................#.......#..........\r\n#....#........................#....................................................................##.............................\r\n...#.#.....................................#...............................................#.....................#....#.........#.\r\n.........#..............................#....................................#.................#............#.....................\r\n................................................................#.................................................................\r\n#.......#..............................................#.............................#...........#................................\r\n.#......#.........#.............................#...............................................................#.................\r\n.........#.....#......#.......................................................................................................#...\r\n#..............................#........#............................#.................................#.....#.....#..............\r\n......#.....................................#.......#........#....................................................................\r\n#.......#.....................................#......................................................................#............\r\n.....................................#......................................#......#.##..................#.....#.#................\r\n.......................#.........#......#...........................................................................##............\r\n.....#......#.#.................................................#.............................#............#.#.......#............\r\n..................#.......................................#.#.............................#..................................#....\r\n......................#.......#.....................#...................#......#.........................................#........\r\n.........#...................................................................................................#....#...............\r\n.........................#...........#..........#...............#.....#...................................................##......\r\n#...#......#.#.....................#..................#.................#..................#......................................\r\n..............................#.....#................#.....................#............#...#....#............#...#...............\r\n.........................#..................#.............................................................................#.......\r\n.......#....................#.......................#.....................#..........#...........#..........#...................#.\r\n....#..........#..#................#.....#..........#........#..................#.....................##...............#.........#\r\n.....................................................................................#......................................#.....\r\n.......................................#...................................#.......................#..........................#...\r\n.......#...............................#............#.....#..............................................#.................#......\r\n.#..........................#..................................................................#...#.#.......#.#..........#.......\r\n#...............................................................#.#............................#...............#......#...........\r\n...#..........................#.#..#.#.............................................................#......#.......................\r\n..................#........#.....................................................#...............................................#\r\n....................#.............#.........#........##................#.............#............#..#............................\r\n.........................#.................................#...........................................#.....#....................\r\n..........................................##..........#................................#........................................#.\r\n.................................................................................#..........#....................##........##.....\r\n.....###......#.....#...................................................................................#..#...................#..\r\n........#.....#.....#.....#..........#.................................................#.#......................#.................\r\n...........................................#....#..............#..#..............#................................................\r\n....#.............#...................................#.....#........................................................#............\r\n.........#........#.............#..................#..........#..........................###.......#....#.#.#.....................\r\n..................#....................#...................#...#..................................................................\r\n.......#...............#................................................................................#................#........\r\n....#..........................#......#....................................#.............#...#......................#...#.........\r\n.#..#....................#.....................#.............#...............................#....................#....##.........\r\n..#..#........#......#.................##..#.......#....................#.............................................#...........\r\n..................#......#.............#.##.................................##.....................................#...#..........\r\n.#...##........#........................................................................................#.....#...#....#..........\r\n............#........................#............................................#.........#.............#.......................\r\n................#......#........#...........................................................#............#........................\r\n..............................#.#......#................................#...........#......................................#......\r\n...................#...................#.............#............#.............#.................................................\r\n.........#.......#....#........#.........#.....................#..#.......#..#...#.............................#..................\r\n.........#...#.........................................................................#.....#.......#............................\r\n.........................#..........#...............................................#.....................................#....#..\r\n....#..................##..##...........#.........#..................................................#...#...........#...........#\r\n.......#.......#.....#...............#.#.....#.............#........................#..............................#..#.........#.\r\n........................#........................................#.............................##.................................";

		private const char OBSTACLE = '#';
		private const char ENROUTE = 'X';
		private const int ZERO_OFFSET = -1;

		private enum Direction
		{
			N,
			E,
			S,
			W
		}

		[TestCase(Example, 5, 7, 41)]
		[TestCase(Data, 97, 42, 5067)]
		public void QuestionA(string data, int startX, int startY, int expected)
		{
			// parse the lab into a (shudder) multi-dimensional array (shudder)
			// walk the guard through the lab one step at a time, following the rules:
			// - If there is something directly in front of you, turn right 90 degrees.
			// - Otherwise, take a step forward.
			// for each step, mark that element of the array with an X
			// until the path leaves the bounds of the array
			// then count the total number of elements having an X

			int solution = 0;

			string[] rows = data.Split("\r\n");
			char[,] grid = InitializeGrid(rows);
			PopulateGrid(grid, rows);

			Direction startingDirection = Direction.N;
			List<Tuple<int, int, Direction>> happyPath = [];
			PredictPathHavingNoInfiniteLoop(grid, startX, startY, startingDirection, happyPath);
			foreach (var element in grid)
			{
				if (element == ENROUTE)
				{
					++solution;
				}
			}

			Console.WriteLine(solution);
			Assert.That(solution, Is.EqualTo(expected));
		}

		private static char[,] InitializeGrid(string[] data)
		{
			int rows = data.Length;
			int columns = data[0].Length;

			return new char[columns, rows];
		}

		private static void PopulateGrid(char[,] grid, string[] data)
		{
			for (int y = 0; y < data.Length; ++y)
			{
				for (int x = 0; x < data[0].Length; ++x)
				{
					grid[y, x] = data[y][x];
				}
			}
		}

		[TestCase(Example, 5, 7, 6)]
		[TestCase(Data, 97, 42, 0)] // 921 is too low, 2002 is too high!
		public void QuestionB(string data, int startX, int startY, int expected)
		{
			int solution = 0;

			string[] rows = data.Split("\r\n");
			char[,] grid = InitializeGrid(rows);
			PopulateGrid(grid, rows);

			Direction startingDirection = Direction.N;
			List<Tuple<int, int, Direction>> happyPath = [];


			PredictPathHavingNoInfiniteLoop(grid, startX, startY, startingDirection, happyPath);
			happyPath.RemoveAt(happyPath.Count - 1); // if we hit the final point, it's too late -- and the "next" point will exceed the dimensions of the array

			// now that we know the path, we need to see if putting an obstacle on any of these positions results in an infinite loop
			// where an infinite loop can be defined as when the guard returns to a position he's already been and ends up heading
			// in the same direction
			for (int i = 0; i < happyPath.Count; ++i)
			{
				PopulateGrid(grid, rows);
				if (DetermineIfNewObstacleAtNextElementOnPathCausesAnInfiniteLoop(grid, happyPath[i], startX, startY))
				{
					++solution;
				}
			}

			Console.WriteLine(solution);
			Assert.That(solution, Is.EqualTo(expected));
		}

		private static bool PredictPathHavingNoInfiniteLoop(char[,] grid, int x, int y, Direction direction, List<Tuple<int, int, Direction>> happyPath)
		{
			int newX = x;
			int newY = y;
			Direction newDirection = direction;

			grid[newY + ZERO_OFFSET, newX + ZERO_OFFSET] = ENROUTE;
			happyPath.Add(new Tuple<int, int, Direction>(x, y, direction));
			//Console.WriteLine("{0},{1}", newX, newY);

			switch (direction)
			{
				case Direction.N:
					--newY;
					if (newY == 0) // I'm keep X and Y indexed to 1 to make it easy on my brain :D
					{
						return true;
					}

					if (grid[newY + ZERO_OFFSET, newX + ZERO_OFFSET] == OBSTACLE)
					{
						++newY;
						newDirection = Direction.E;
						//Console.WriteLine("Turn E at {0},{1}", newX, newY);
					}
					break;
				case Direction.E:
					++newX;
					if (newX > grid.GetLength(0)) // I'm keep X and Y indexed to 1 to make it easy on my brain :D
					{
						return true;
					}

					if (grid[newY + ZERO_OFFSET, newX + ZERO_OFFSET] == OBSTACLE)
					{
						--newX;
						newDirection = Direction.S;
						//Console.WriteLine("Turn S at {0},{1}", newX, newY);
					}
					break;
				case Direction.S:
					++newY;
					if (newY > grid.GetLength(1)) // I'm keep X and Y indexed to 1 to make it easy on my brain :D
					{
						return true;
					}

					if (grid[newY + ZERO_OFFSET, newX + ZERO_OFFSET] == OBSTACLE)
					{
						--newY;
						newDirection = Direction.W;
						//Console.WriteLine("Turn W at {0},{1}", newX, newY);
					}
					break;
				case Direction.W:
					--newX;
					if (newX == 0) // I'm keep X and Y indexed to 1 to make it easy on my brain :D
					{
						return true;
					}

					if (grid[newY + ZERO_OFFSET, newX + ZERO_OFFSET] == OBSTACLE)
					{
						++newX;
						newDirection = Direction.N;
						//Console.WriteLine("Turn N at {0},{1}", newX, newY);
					}
					break;
			}

			var newVector = new Tuple<int, int, Direction>(newX, newY, newDirection);
			if (happyPath.Contains(newVector))
			{
				return false; // The next location+direction has already been encountered, meaning that this is going to be an infinite loop
			}

			return PredictPathHavingNoInfiniteLoop(grid, newX, newY, newDirection, happyPath);
		}

		private static bool DetermineIfNewObstacleAtNextElementOnPathCausesAnInfiniteLoop(char[,] grid, Tuple<int, int, Direction> vector, int originalX, int originalY)
		{
			List<Tuple<int, int, Direction>> path = [];

			// does putting an obstacle immediately ahead of the current vector result in an infinite loop?
			int newObstacleX = vector.Item1;
			int newObstacleY = vector.Item2;

			switch(vector.Item3)
			{
				case Direction.N:
					--newObstacleY;
					break;
				case Direction.E:
					++newObstacleX;
					break;
				case Direction.S:
					++newObstacleY;
					break;
				case Direction.W:
					--newObstacleX;
					break;
			}


			if ((newObstacleY == originalY) && (newObstacleX  == originalX)) // this is the original location, and you *can't* put an obstacle here ever
			{
				return false;
			}

			if (grid[newObstacleY + ZERO_OFFSET, newObstacleX + ZERO_OFFSET] == OBSTACLE)
			{
				return false;
			}

			grid[newObstacleY + ZERO_OFFSET, newObstacleX + ZERO_OFFSET] = OBSTACLE; // Add the new obstacle

			// Determine if the grid is now an infinite loop
			var infinite = !PredictPathHavingNoInfiniteLoop(grid, vector.Item1, vector.Item2, vector.Item3, path); // returns false if it is an infinite loop, but we think of that is true!
			if (infinite)
			{
				Console.WriteLine("Obstacle placed at: x={0} y={1}", newObstacleX, newObstacleY);
			}

			return infinite;
		}
	}
}