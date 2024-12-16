
using System.Collections.Concurrent;

namespace Challenges
{
	//    Start: 10:50pm
	// A Solved: 00:00pm
	// B solved: 00:00pm

	public class Day15 : Shared
	{
		private const string ExampleA1_Map = "########\r\n#..O.O.#\r\n##@.O..#\r\n#...O..#\r\n#.#.O..#\r\n#...O..#\r\n#......#\r\n########";
		private const string ExampleA1_Moves = "<^^>>>vv<v>>v<<";
		private const string ExampleA2_Map = "##########\r\n#..O..O.O#\r\n#......O.#\r\n#.OO..O.O#\r\n#..O@..O.#\r\n#O#..O...#\r\n#O..O..O.#\r\n#.OO.O.OO#\r\n#....O...#\r\n##########";
		private const string ExampleA2_Moves = "<vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^\r\nvvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v\r\n><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<\r\n<<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^\r\n^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><\r\n^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^\r\n>^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^\r\n<><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>\r\n^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>\r\nv^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^";
		private const string Data_Map = "";
		private const string Data_Moves = "";

		private const char OPEN = ' ';
		private const char WALL = '#';
		private const char BOX = 'O';
		private const char ROBOT = '@';
		private const char NORTH = '^';
		private const char EAST = '>';
		private const char SOUTH = 'v';
		private const char WEST = '<';

		[TestCase(ExampleA1_Map, ExampleA1_Moves, 2028)]
		[TestCase(ExampleA2_Map, ExampleA2_Moves, 10092)]
		[TestCase(Data_Map, Data_Moves, 0)]
		[Parallelizable]
		public void QuestionA(string data,string movesString, int expected)
		{
			var grid = GenerateNewPopulatedGrid(data);
			WriteGrid(grid);

			CardinalDirection[] moves = GenerateMoves(movesString);
			ExecuteMoves(grid, moves);

			ConcurrentBag<int> gpses = CalculateGpsForeachBox(grid);
			int gps = gpses.Sum(x => x);

			Console.WriteLine(gps);
			Assert.That(gps, Is.EqualTo(expected));
		}

		private static CardinalDirection[] GenerateMoves(string movesString)
		{
			List<CardinalDirection> moves = [];

			foreach (var move in movesString)
			{
				switch (move)
				{
					case NORTH:
						moves.Add(CardinalDirection.N);
						break;
					case EAST:
						moves.Add(CardinalDirection.E);
						break;
					case SOUTH:
						moves.Add(CardinalDirection.S);
						break;
					case WEST:
						moves.Add(CardinalDirection.W);
						break;
				}
			}

			return moves.ToArray();
		}

		private static void ExecuteMoves(char[,] grid, CardinalDirection[] moves)
		{
			Tuple<int, int> robotCoordinates = DetermineRobotCoordinates(grid);

			foreach (var move in moves)
			{
				switch (move)
				{
					case CardinalDirection.N:
						break;
					case CardinalDirection.E:
						break;
					case CardinalDirection.S:
						break;
					case CardinalDirection.W:
						break;
				}
			}
		}

		private static Tuple<int, int> DetermineRobotCoordinates(char[,] grid)
		{
			for (int y = 0; y < grid.GetLength(0); ++y)
			{
				for (int x = 0; x < grid.GetLength(1); ++x)
				{
					if (grid[y, x] == ROBOT)
					{
						return new Tuple<int, int>(x, y);
					}
				}
			}

			throw new InvalidDataException("Unable to determine the robot's starting location.");
		}

		private static ConcurrentBag<int> CalculateGpsForeachBox(char[,] grid)
		{
			ConcurrentBag<int> gpses = [];

			Parallel.For(0, grid.GetLength(0), y =>
			{
				Parallel.For(0, grid.GetLength(1), x =>
				{
					if (grid[y, x] == BOX)
					{
						gpses.Add(100 * y + x);
					}
				});
			});

			return gpses;
		}

		[TestCase(ExampleA1_Map, 0)]
		//[TestCase(Data_Map, Data_Moves, 0)]
		[Parallelizable]
		public void QuestionB(string data, int expected)
		{
			int solution = 0;

			var grid = GenerateNewPopulatedGrid(data);
			WriteGrid(grid);

			Console.WriteLine(solution);
			Assert.That(solution, Is.EqualTo(expected));
		}
	}
}