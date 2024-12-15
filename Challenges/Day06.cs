
using System.IO;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Xml.Linq;

namespace Challenges
{
	//    Start:  9:00pm
	//    Break:  9:14pm
	//     Back:  9:30pm
	// A Solved: 11:20pm  Damn multidimensional arrays! :D
	// B solved: 00:00pm

	public class Day06 : Shared
	{
		private const string Example = "....#.....\r\n.........#\r\n..........\r\n..#.......\r\n.......#..\r\n..........\r\n.#..^.....\r\n........#.\r\n#.........\r\n......#...";
		private const string Data = ".........#...................................................................................................#.................#..\r\n...........................#.......................................#..............................................................\r\n.............#.................................................................................#............................#.....\r\n...#.....................#.......#....................................#..............#.............................#...........#.#\r\n..........#.....#..#.....#.............#..................#............#.....#........#.#.......#............................#....\r\n...#...................#..........#...................#.........#..#..............##.......................................#......\r\n..................................................................................................#...............................\r\n...............#.........#....#.#..#.........#...........#...#....................#.........#.......#....#........................\r\n..........................................#......#.#...................................................#.............#............\r\n....................#............................#..........................................#.....................#.........#.....\r\n..............#..................................#................#..#...........................................#................\r\n.........#....###.......#........................................................................................#.#.....#...#..#.\r\n.#....................................#.....................................#.................................#..................#\r\n........................#...................................#.#....................#......##.#.........#..........................\r\n............#.......#..................#..........................................................................................\r\n....#.............#.#.....#...#.....#......................#...............#............##...#....................................\r\n...#....#.....................................##........#........#....##.....................................#....................\r\n...........................................................................#........#..........##................................#\r\n..............................#.#......................#..........................#..#........#...............................#...\r\n..............#.........###.......................................#...........#...............#......#.........#........#.....#...\r\n............#............................#....................#........................#............#.............................\r\n.........................................#.....................................................#.....#...............#............\r\n.#...##.......................#.......#..........................................................................#...#...........#\r\n....#..............#............#......#........................#.......................#...#.......................#.............\r\n.......#...............#......#......#..........................................#..................#....................#...#.....\r\n.......................................................................#.........#................................................\r\n.#.......#........................................................##..............................................................\r\n.........................#...................#..#......##..................................#......#......#........................\r\n......................................#..............................................#......#..........#.#.........#..............\r\n.....#..............#..#........#..............................#...##.............................................................\r\n..##............................#.......................................................#..........#..............................\r\n...........................................................##................................................#....................\r\n#...............#.........#.....................................................#......................###........................\r\n#.#.......................#........................#..#.....................#....#........#........................#...#.........#\r\n............#.............#.#............#........................#..........#....................................................\r\n............#...................#.....................................................................................#.......#...\r\n.............................#...#..#...........................#...#.........................................................#...\r\n........#.......................##..........................................................#.........#.....................#.....\r\n............##............#..........................................................#.#.....#......#.#.......#...................\r\n...........#.....#......#.................#.............#......................................#.....#...#........................\r\n#............#.........#.......##.....#......#...........#...........#.......#................#...................................\r\n......#..#...#.....#................................................#............#...#..........^.................................\r\n............................................................................................................#....#................\r\n......................................#.............................#........................#...............#.....#...#..........\r\n...#.........................................................................#....................................................\r\n.....................................#.........................................................#.............#.........#..........\r\n#..............................#...#.................................#............................................................\r\n..........#..................#............#.......#...........................#...................#.....#.........................\r\n............................#...##.............................................................#............#.....................\r\n.................#..................................................................#..#..............#...........................\r\n..................#...............................#................#............#...........#......#............#.................\r\n.....#......................#..............#.......................#......................#.......................................\r\n...............................#.....#.......................#.......#......................#......#............#...........#.....\r\n......#.............##....#.....#...............#.....#............................#....................................#.........\r\n...#.#.......#..#...##.............................................................#.#.#...........#.....#................#.......\r\n...........................................#...#......#...........................................................................\r\n.........#.................................#........................................................................#........#.#..\r\n........................#..........................................#.......#..............#.......................................\r\n....................................................#...............#..........................#..................................\r\n............................#................#......#...............#.....................#.......................................\r\n#.#............#......................................................................................#.....#.....................\r\n................................................................#....#..........................................#........#......#.\r\n.......#........#......................................................................#.................#..................#.#...\r\n...............................#...#......................................................................#.........#.........#...\r\n...........#..#..................##..#.........................................#..............##............................#.....\r\n#........#...............#.....#.....#.................#............#....#.............................#.......#.................#\r\n...............#...................................................#.......#.......................#......#.............#.........\r\n...#............................................................................................................................#.\r\n#.....................#......................................................#...........................................#........\r\n...........#..........................................#.......................................#.....................#.............\r\n....#.##.......#..............#.....#..............................#....................................#.....................#...\r\n...............................................................................................................#...............#..\r\n.#...........................#...#.....#...#...................#....#........#.........#................................#.........\r\n.................#............................................................................#........................#..#.......\r\n.............#....#.....................................................#............#.........................#.......#..........\r\n#....#........................#....................................................................##.............................\r\n...#.#.....................................#...............................................#.....................#....#.........#.\r\n.........#..............................#....................................#.................#............#.....................\r\n................................................................#.................................................................\r\n#.......#..............................................#.............................#...........#................................\r\n.#......#.........#.............................#...............................................................#.................\r\n.........#.....#......#.......................................................................................................#...\r\n#..............................#........#............................#.................................#.....#.....#..............\r\n......#.....................................#.......#........#....................................................................\r\n#.......#.....................................#......................................................................#............\r\n.....................................#......................................#......#.##..................#.....#.#................\r\n.......................#.........#......#...........................................................................##............\r\n.....#......#.#.................................................#.............................#............#.#.......#............\r\n..................#.......................................#.#.............................#..................................#....\r\n......................#.......#.....................#...................#......#.........................................#........\r\n.........#...................................................................................................#....#...............\r\n.........................#...........#..........#...............#.....#...................................................##......\r\n#...#......#.#.....................#..................#.................#..................#......................................\r\n..............................#.....#................#.....................#............#...#....#............#...#...............\r\n.........................#..................#.............................................................................#.......\r\n.......#....................#.......................#.....................#..........#...........#..........#...................#.\r\n....#..........#..#................#.....#..........#........#..................#.....................##...............#.........#\r\n.....................................................................................#......................................#.....\r\n.......................................#...................................#.......................#..........................#...\r\n.......#...............................#............#.....#..............................................#.................#......\r\n.#..........................#..................................................................#...#.#.......#.#..........#.......\r\n#...............................................................#.#............................#...............#......#...........\r\n...#..........................#.#..#.#.............................................................#......#.......................\r\n..................#........#.....................................................#...............................................#\r\n....................#.............#.........#........##................#.............#............#..#............................\r\n.........................#.................................#...........................................#.....#....................\r\n..........................................##..........#................................#........................................#.\r\n.................................................................................#..........#....................##........##.....\r\n.....###......#.....#...................................................................................#..#...................#..\r\n........#.....#.....#.....#..........#.................................................#.#......................#.................\r\n...........................................#....#..............#..#..............#................................................\r\n....#.............#...................................#.....#........................................................#............\r\n.........#........#.............#..................#..........#..........................###.......#....#.#.#.....................\r\n..................#....................#...................#...#..................................................................\r\n.......#...............#................................................................................#................#........\r\n....#..........................#......#....................................#.............#...#......................#...#.........\r\n.#..#....................#.....................#.............#...............................#....................#....##.........\r\n..#..#........#......#.................##..#.......#....................#.............................................#...........\r\n..................#......#.............#.##.................................##.....................................#...#..........\r\n.#...##........#........................................................................................#.....#...#....#..........\r\n............#........................#............................................#.........#.............#.......................\r\n................#......#........#...........................................................#............#........................\r\n..............................#.#......#................................#...........#......................................#......\r\n...................#...................#.............#............#.............#.................................................\r\n.........#.......#....#........#.........#.....................#..#.......#..#...#.............................#..................\r\n.........#...#.........................................................................#.....#.......#............................\r\n.........................#..........#...............................................#.....................................#....#..\r\n....#..................##..##...........#.........#..................................................#...#...........#...........#\r\n.......#.......#.....#...............#.#.....#.............#........................#..............................#..#.........#.\r\n........................#........................................#.............................##.................................";

		private const char START = '^';
		private const char OBSTACLE = '#';
		private const char ENROUTE = 'X';

		[TestCase(Example, 5, 7, 41)]
		[TestCase(Data, 97, 42, 5067)]
		[Parallelizable]
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

			var grid = GenerateNewPopulatedGrid(data);

			CardinalDirection startingDirection = CardinalDirection.N;
			MarkPath(grid, startX, startY, startingDirection);
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

		private static char[,] GenerateNewPopulatedGrid(string data)
		{
			string[] rows = data.Split("\r\n");
			char[,] grid = InitializeGrid(rows);
			PopulateGrid(grid, rows);

			return grid;
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

		private static void MarkPath(char[,] grid, int x, int y, CardinalDirection direction)
		{
			int newX = x;
			int newY = y;
			CardinalDirection newDirection = direction;

			grid[newY + ZERO_INDEX_OFFSET, newX + ZERO_INDEX_OFFSET] = ENROUTE;
			//Console.WriteLine("{0},{1}", newX, newY);

			switch (direction)
			{
				case CardinalDirection.N:
					--newY;
					if (newY == 0) // I'm keep X and Y indexed to 1 to make it easy on my brain :D
					{
						return;
					}

					if (grid[newY + ZERO_INDEX_OFFSET, newX + ZERO_INDEX_OFFSET] == OBSTACLE)
					{
						++newY;
						newDirection = CardinalDirection.E;
						//Console.WriteLine("Turn E at {0},{1}", newX, newY);
					}
					break;
				case CardinalDirection.E:
					++newX;
					if (newX > grid.GetLength(0)) // I'm keep X and Y indexed to 1 to make it easy on my brain :D
					{
						return;
					}

					if (grid[newY + ZERO_INDEX_OFFSET, newX + ZERO_INDEX_OFFSET] == OBSTACLE)
					{
						--newX;
						newDirection = CardinalDirection.S;
						//Console.WriteLine("Turn S at {0},{1}", newX, newY);
					}
					break;
				case CardinalDirection.S:
					++newY;
					if (newY > grid.GetLength(1)) // I'm keep X and Y indexed to 1 to make it easy on my brain :D
					{
						return;
					}

					if (grid[newY + ZERO_INDEX_OFFSET, newX + ZERO_INDEX_OFFSET] == OBSTACLE)
					{
						--newY;
						newDirection = CardinalDirection.W;
						//Console.WriteLine("Turn W at {0},{1}", newX, newY);
					}
					break;
				case CardinalDirection.W:
					--newX;
					if (newX == 0) // I'm keep X and Y indexed to 1 to make it easy on my brain :D
					{
						return;
					}

					if (grid[newY + ZERO_INDEX_OFFSET, newX + ZERO_INDEX_OFFSET] == OBSTACLE)
					{
						++newX;
						newDirection = CardinalDirection.N;
						//Console.WriteLine("Turn N at {0},{1}", newX, newY);
					}
					break;
			}

			MarkPath(grid, newX, newY, newDirection);
		}

		[TestCase(Example, 5, 7, 6)]
		[TestCase(Data, 97, 42, 0)] // 921 is too low, 2002 is too high!
		public void QuestionB(string data, int startX, int startY, int expected)
		{
			// Note: full brute-force method took forever to run on this laptop!
			int solution = 0;

			CardinalDirection startingDirection = CardinalDirection.N;

			var grid = GenerateNewPopulatedGrid(data);
			MarkPath(grid, startX, startY, startingDirection);
			grid[startY, startX] = START;

			// Partial brute-force method
			// For each infinite loop created, the obstacle that is added has to be adjacent to the path
			// So... figure out a list of just those coordinates, add them to the path coordinates,
			// and then take the superset or coordinates and count how many result in an infiinite loop.

			// now that we know the path, we need to see if putting an obstacle on any of these positions results in an infinite loop
			// where an infinite loop can be defined as when the guard returns to a position he's already been and ends up heading
			// in the same direction

			HashSet<Tuple<int, int>> testedObstacleCoordinates = [];

			for (int y = 0; y < grid.GetLength(0); y++)
			{
				for (int x = 0; x < grid.GetLength(1); x++)
				{
					//Console.Write(grid[y, x] + " ");
					if (grid[y, x] == ENROUTE)
					{
						var referenceGrid = GenerateNewPopulatedGrid(data);
						Array.Copy(grid, referenceGrid, grid.Length);

						var obstaclesToTest = GenerateListOfPotentialObstacles(referenceGrid, x, y, startX, startY);
						foreach (var obstacle in obstaclesToTest)
						{
							Console.Write(obstacle.Item1 + "," + obstacle.Item2 + "  ");
						}
					}
					//	var referenceGrid = GenerateNewPopulatedGrid(data);
					//	Array.Copy(grid, referenceGrid, grid.Length);

					//	var obstaclesToTest = GenerateListOfPotentialObstacles(referenceGrid, x, y, startX, startY);
					//	foreach (var obstacle in obstaclesToTest)
					//	{
					//		if (testedObstacleCoordinates.Contains(obstacle))
					//		{
					//			continue;
					//		}


					//		referenceGrid[obstacle.Item1, obstacle.Item2] = OBSTACLE;
					//		List<Tuple<int, int, Direction>> happyPath = [];
					//		if (!PredictPathHavingNoInfiniteLoop(referenceGrid, startX, startY, startingDirection, happyPath))
					//		{
					//			Console.WriteLine(obstacle.Item1 + " " + obstacle.Item2);
					//			++solution;
					//		}

					//		testedObstacleCoordinates.Add(obstacle);
					//	}
					//}

					//switch (referenceGrid[y, x])
					//{
					//	case START:
					//	case ENROUTE:
					//		// generate a list of all non-obstacle, non-start coordinates that are adjacent to this position
					//		List<Tuple<int, int>> potentialObstacles = GenerateListOfPotentialObstacles(referenceGrid, x, y, startX, startY);
					//		foreach (var potentialObstacle in potentialObstacles)
					//		{
					//			if (!testedObstacleCoordinates.Contains(potentialObstacle))
					//			{
					//				testedObstacleCoordinates.Add(potentialObstacle);
					//				var testGrid = GenerateNewPopulatedGrid(data);
					//				testGrid[y + ZERO_INDEX_OFFSET, x + ZERO_INDEX_OFFSET] = OBSTACLE;

					//				List<Tuple<int, int, Direction>> happyPath = [];
					//				if (!PredictPathHavingNoInfiniteLoop(testGrid, startX, startY, startingDirection, happyPath))
					//				{
					//					++solution;
					//				}
					//			}
					//		}
					//		break;
					//	case OBSTACLE:
					//	default:
					//		// ignore these coordinates
					//		break;
				}

				Console.WriteLine();
			}

			//for (int i = 0; i < happyPath.Count; ++i)
			//{
			//PopulateGrid(grid, rows);
			//if (DetermineIfNewObstacleAtNextElementOnPathCausesAnInfiniteLoop(grid, happyPath[i], startX, startY))
			//{
			//	++solution;
			//}
			//}

			Console.WriteLine(solution);
			Assert.That(solution, Is.EqualTo(expected));
		}

		private static List<Tuple<int, int>> GenerateListOfPotentialObstacles(char[,] testGrid, int x, int y, int startX, int startY)
		{
			List<Tuple<int, int>> potentialObstacles = [];

			if ((y > 0) && (y < testGrid.GetLength(0) + ZERO_INDEX_OFFSET))
			{
				AddCoordinatesIfValidSpotForAnObstacle(potentialObstacles, testGrid, x, y - 1);
				AddCoordinatesIfValidSpotForAnObstacle(potentialObstacles, testGrid, x, y + 1);
			}
			else if (y > 0)
			{
				AddCoordinatesIfValidSpotForAnObstacle(potentialObstacles, testGrid, x, y - 1);
			}
			else if (y < testGrid.GetLength(0) + ZERO_INDEX_OFFSET)
			{
				AddCoordinatesIfValidSpotForAnObstacle(potentialObstacles, testGrid, x, y + 1);
			}

			if ((x > 0) && (x < testGrid.GetLength(1) + ZERO_INDEX_OFFSET))
			{
				AddCoordinatesIfValidSpotForAnObstacle(potentialObstacles, testGrid, x - 1, y);
				AddCoordinatesIfValidSpotForAnObstacle(potentialObstacles, testGrid, x + 1, y);
			}
			else if (y > 0)
			{
				AddCoordinatesIfValidSpotForAnObstacle(potentialObstacles, testGrid, x - 1, y);
			}
			else if (y < testGrid.GetLength(1) + ZERO_INDEX_OFFSET)
			{
				AddCoordinatesIfValidSpotForAnObstacle(potentialObstacles, testGrid, x + 1, y);
			}

			if (testGrid[y, x] != START)
			{
				potentialObstacles.Add(new Tuple<int, int>(y, x));
			}

			return potentialObstacles;
		}

		private static void AddCoordinatesIfValidSpotForAnObstacle(List<Tuple<int, int>> newObstacles, char[,] testGrid, int x, int y)
		{
			if ((testGrid[y, x] != OBSTACLE) && (testGrid[y, x] != ENROUTE) && (testGrid[y, x] != START))
			{
				newObstacles.Add(new Tuple<int, int>(y, x + 1));
			}
		}

		private static bool PredictPathHavingNoInfiniteLoop(char[,] grid, int x, int y, CardinalDirection direction, List<Tuple<int, int, CardinalDirection>> happyPath)
		{
			int newX = x;
			int newY = y;
			CardinalDirection newDirection = direction;

			grid[newY + ZERO_INDEX_OFFSET, newX + ZERO_INDEX_OFFSET] = ENROUTE;
			happyPath.Add(new Tuple<int, int, CardinalDirection>(x, y, direction));
			//Console.WriteLine("{0},{1}", newX, newY);

			switch (direction)
			{
				case CardinalDirection.N:
					--newY;
					if (newY == 0) // I'm keep X and Y indexed to 1 to make it easy on my brain :D
					{
						return true;
					}

					if (grid[newY + ZERO_INDEX_OFFSET, newX + ZERO_INDEX_OFFSET] == OBSTACLE)
					{
						++newY;
						newDirection = CardinalDirection.E;
						//Console.WriteLine("Turn E at {0},{1}", newX, newY);
					}
					break;
				case CardinalDirection.E:
					++newX;
					if (newX > grid.GetLength(0)) // I'm keep X and Y indexed to 1 to make it easy on my brain :D
					{
						return true;
					}

					if (grid[newY + ZERO_INDEX_OFFSET, newX + ZERO_INDEX_OFFSET] == OBSTACLE)
					{
						--newX;
						newDirection = CardinalDirection.S;
						//Console.WriteLine("Turn S at {0},{1}", newX, newY);
					}
					break;
				case CardinalDirection.S:
					++newY;
					if (newY > grid.GetLength(1)) // I'm keep X and Y indexed to 1 to make it easy on my brain :D
					{
						return true;
					}

					if (grid[newY + ZERO_INDEX_OFFSET, newX + ZERO_INDEX_OFFSET] == OBSTACLE)
					{
						--newY;
						newDirection = CardinalDirection.W;
						//Console.WriteLine("Turn W at {0},{1}", newX, newY);
					}
					break;
				case CardinalDirection.W:
					--newX;
					if (newX == 0) // I'm keep X and Y indexed to 1 to make it easy on my brain :D
					{
						return true;
					}

					if (grid[newY + ZERO_INDEX_OFFSET, newX + ZERO_INDEX_OFFSET] == OBSTACLE)
					{
						++newX;
						newDirection = CardinalDirection.N;
						//Console.WriteLine("Turn N at {0},{1}", newX, newY);
					}
					break;
			}

			var newVector = new Tuple<int, int, CardinalDirection>(newX, newY, newDirection);
			if (happyPath.Contains(newVector))
			{
				return false; // The next location+direction has already been encountered, meaning that this is going to be an infinite loop
			}

			return PredictPathHavingNoInfiniteLoop(grid, newX, newY, newDirection, happyPath);
		}
	}
}