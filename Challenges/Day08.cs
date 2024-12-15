
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Challenges
{
	//    Start:  9:15pm
	// A Solved: 11:05pm
	// B solved: 11:30pm

	public class Day08 : Shared
	{
		private const string Problem1Example1 = "..........\r\n..........\r\n..........\r\n....a.....\r\n..........\r\n.....a....\r\n..........\r\n..........\r\n..........\r\n..........";
		private const string Problem1Example2 = "..........\r\n..........\r\n..........\r\n....a.....\r\n........a.\r\n.....a....\r\n..........\r\n..........\r\n..........\r\n..........";
		private const string Problem1Example3 = "..........\r\n..........\r\n..........\r\n....a.....\r\n........a.\r\n.....a....\r\n..........\r\n......A...\r\n..........\r\n..........";
		private const string Problem1Example5 = "..........\r\n....a.....\r\n..........\r\n....a.....\r\n..........\r\n..........\r\n..........\r\n....a.....\r\n..........\r\n....a.....";
		private const string Problem1Example6 = "a.........\r\n..........\r\n..a.......\r\n..........\r\n..........\r\n..........\r\n..........\r\n.......a..\r\n..........\r\n.........a";
		private const string Problem1Example7 = "..........\r\n....a.....\r\n..........\r\n....a.....\r\n..........\r\n..........\r\n..........\r\n....A.....\r\n..........\r\n....A.....";

		private const string Problem2Example1 = "T.........\r\n...T......\r\n.T........\r\n..........\r\n..........\r\n..........\r\n..........\r\n..........\r\n..........\r\n..........";

		private const string CommonExample = "............\r\n........0...\r\n.....0......\r\n.......0....\r\n....0.......\r\n......A.....\r\n............\r\n............\r\n........A...\r\n.........A..\r\n............\r\n............";
		private const string CommonData = ".............C.7..................G..0...y........\r\n..................7................C..............\r\n....................................0......W....y.\r\n.......................................D..W.......\r\n..........u.......................................\r\n..................................4.......D0...j..\r\n.....................................D............\r\n................O.....C................G..........\r\n............F.....................C...............\r\n......u..........F.................4.......y......\r\n..........X..........5....4...........1...........\r\n..........F...........5X...................3......\r\n.............F.............................j.3....\r\n.................u..............X.................\r\n............................7.....................\r\n..................................................\r\n..........................5.....j2.........4......\r\n....d.....................y...................j1..\r\n..................................................\r\n............................Y.e...................\r\n.................d...X...............J...........e\r\n.............d....................................\r\n..............................Y..............1....\r\n.........................................Y........\r\n......................W......8..f...J.........3...\r\n.......w.............J............................\r\n...................................U.....f......e.\r\n.................................Of....e....t...1.\r\n.......g..........d......s........................\r\n................G................f................\r\n.....................................O............\r\n...g........................T.....U...............\r\n......................s..........T.............G..\r\n................................s.......8.........\r\n.....9........g...........o...U............E......\r\n............g............................t....o...\r\n...........................................6....E.\r\n.....................s......x........6....E.......\r\n..........w.9................x............t.......\r\n...........9........w...........J.....6o..........\r\n.............................................o....\r\n..........S................U......................\r\n.......S..2..........c........T.O....t............\r\n.....2...S.....c...................T..............\r\n..................x.......................8.......\r\n....9.............................................\r\n...wS.....................................6.......\r\n................2........................8........\r\n..................................................\r\n.................x....c........................E..";

		private const char ANTINODE = '#';


		[TestCase(Problem1Example1, 2)]
		[TestCase(Problem1Example2, 4)]
		[TestCase(Problem1Example3, 4)]
		[TestCase(CommonExample, 14)]
		[TestCase(Problem1Example5, 1)]
		[TestCase(Problem1Example6, 2)]
		[TestCase(Problem1Example7, 1)]
		[TestCase(CommonData, 222)]
		[Parallelizable]
		public void QuestionA(string data, int expected)
		{
			HashSet<Tuple<int, int>> uniqueAntinodes = [];

			var grid = GenerateNewPopulatedGrid(data);
			//WriteGrid(grid);

			var uniqueFrequences = ParseUniqueFrequencies(grid);

			foreach (var frequency in uniqueFrequences)
			{
				var antennasForSpecificFrequency = ParseAntennas(grid, frequency);
				var antinodes = DetermineAntinodes(grid, antennasForSpecificFrequency);
				foreach (var antinode in antinodes)
				{
					uniqueAntinodes.Add(antinode);
				}
			}

			var antinodeGrid = GenerateAntinodeGrid(grid, 'a', new List<Tuple<int, int>>(), uniqueAntinodes);
			//WriteGrid(antinodeGrid);

			Console.WriteLine(uniqueAntinodes.Count);
			Assert.That(uniqueAntinodes.Count, Is.EqualTo(expected));
		}

		private static char[,] GenerateAntinodeGrid(char[,] grid, char frequency, List<Tuple<int, int>> antennas, HashSet<Tuple<int, int>> antinodes)
		{
			var combinedGrid = new char[grid.GetLength(0), grid.GetLength(1)];

			for (int y = 0; y < grid.GetLength(0); y++)
			{
				for (int x = 0; x < grid.GetLength(1); x++)
				{
					combinedGrid[y, x] = EMPTY;
				}
			}

			foreach (var antenna in antennas)
			{
				combinedGrid[antenna.Item1, antenna.Item2] = frequency;
			}

			foreach (var antinode in antinodes)
			{
				combinedGrid[antinode.Item1, antinode.Item2] = ANTINODE;
			}

			return combinedGrid;
		}

		private static List<char> ParseUniqueFrequencies(char[,] grid)
		{
			List<char> frequencies = [];

			for (int y = 0; y < grid.GetLength(0); y++)
			{
				for (int x = 0; x < grid.GetLength(1); x++)
				{
					if ((grid[y, x] != EMPTY) && !frequencies.Contains(grid[y, x]))
					{
						frequencies.Add(grid[y, x]);
					}
				}
			}

			return frequencies;
		}

		private static List<Tuple<int, int>> ParseAntennas(char[,] grid, char frequency)
		{
			List<Tuple<int, int>> antennas = [];

			for (int y = 0; y < grid.GetLength(0); y++)
			{
				for (int x = 0; x < grid.GetLength(1); x++)
				{
					if (grid[y, x] == frequency)
					{
						antennas.Add(new Tuple<int, int>(y, x));
					}
				}
			}

			return antennas;
		}

		private static HashSet<Tuple<int, int>> DetermineAntinodes(char[,] grid, List<Tuple<int, int>> antennas)
		{
			const int OFFSET_FOR_SECOND_ANTENNA = -1;

			HashSet<Tuple<int, int>> antinodes = [];

			for (int indexOfAntenna1 = 0; indexOfAntenna1 < antennas.Count + OFFSET_FOR_SECOND_ANTENNA; indexOfAntenna1++)
			{
				for (int indexOfAntenna2 = indexOfAntenna1 + 1; indexOfAntenna2 <= antennas.Count + OFFSET_FOR_SECOND_ANTENNA; indexOfAntenna2++)
				{
					var validAntinodes = GetValidAntinodesForPairOfAntennas(antennas[indexOfAntenna1], antennas[indexOfAntenna2], grid.GetLength(0), grid.GetLength(1));
					foreach (var antinode in validAntinodes)
					{
						antinodes.Add(antinode);
					}
				}
			}

			return antinodes;
		}

		private static List<Tuple<int, int>> GetValidAntinodesForPairOfAntennas(Tuple<int, int> antenna1, Tuple<int, int> antenna2, int maxY, int maxX)
		{
			List<Tuple<int, int>> antinodes = [];

			int yDifference = Math.Abs(antenna1.Item1 - antenna2.Item1);
			int xDifference = Math.Abs(antenna1.Item2 - antenna2.Item2);

			int antinode1Y = antenna1.Item1;
			int antinode1X = antenna1.Item2;
			int antinode2Y = antenna2.Item1;
			int antinode2X = antenna2.Item2;

			if (antinode1Y < antinode2Y)
			{
				antinode1Y -= yDifference;
				antinode2Y += yDifference;
			}
			else
			{
				antinode1Y += yDifference;
				antinode2Y -= yDifference;
			}


			if (antinode1X < antinode2X)
			{
				antinode1X -= xDifference;
				antinode2X += xDifference;
			}
			else
			{
				antinode1X += xDifference;
				antinode2X -= xDifference;
			}

			if ((antinode1Y >= 0) && (antinode1Y < maxY) && (antinode1X >= 0) && (antinode1X < maxX))
			{
				antinodes.Add(new Tuple<int, int>(antinode1Y, antinode1X));
			}

			if ((antinode2Y >= 0) && (antinode2Y < maxY) && (antinode2X >= 0) && (antinode2X < maxX))
			{
				antinodes.Add(new Tuple<int, int>(antinode2Y, antinode2X));
			}

			return antinodes;
		}

		[TestCase(Problem2Example1, 9)]
		[TestCase(CommonExample, 34)]
		[TestCase(CommonData, 884)]
		[Parallelizable]
		public void QuestionB(string data, int expected)
		{
			HashSet<Tuple<int, int>> uniqueAntinodes = [];

			var grid = GenerateNewPopulatedGrid(data);
			//WriteGrid(grid);

			var uniqueFrequences = ParseUniqueFrequencies(grid);

			foreach (var frequency in uniqueFrequences)
			{
				var antennasForSpecificFrequency = ParseAntennas(grid, frequency);
				var antinodes = DetermineAntinodesWithHarmonics(grid, antennasForSpecificFrequency);
				foreach (var antinode in antinodes)
				{
					uniqueAntinodes.Add(antinode);
				}
			}

			var antinodeGrid = GenerateAntinodeGrid(grid, 'a', new List<Tuple<int, int>>(), uniqueAntinodes);
			//WriteGrid(antinodeGrid);

			Console.WriteLine(uniqueAntinodes.Count);
			Assert.That(uniqueAntinodes.Count, Is.EqualTo(expected));
		}

		private static HashSet<Tuple<int, int>> DetermineAntinodesWithHarmonics(char[,] grid, List<Tuple<int, int>> antennas)
		{
			const int OFFSET_FOR_SECOND_ANTENNA = -1;

			HashSet<Tuple<int, int>> antinodes = [];

			for (int indexOfAntenna1 = 0; indexOfAntenna1 < antennas.Count + OFFSET_FOR_SECOND_ANTENNA; indexOfAntenna1++)
			{
				for (int indexOfAntenna2 = indexOfAntenna1 + 1; indexOfAntenna2 <= antennas.Count + OFFSET_FOR_SECOND_ANTENNA; indexOfAntenna2++)
				{
					var validAntinodes = GetValidAntinodesForPairOfAntennasWithHarmonics(antennas[indexOfAntenna1], antennas[indexOfAntenna2], grid.GetLength(0), grid.GetLength(1));
					foreach (var antinode in validAntinodes)
					{
						antinodes.Add(antinode);
					}
				}
			}

			return antinodes;
		}

		private static List<Tuple<int, int>> GetValidAntinodesForPairOfAntennasWithHarmonics(Tuple<int, int> antenna1, Tuple<int, int> antenna2, int maxY, int maxX)
		{
			const int REVERSE_DIRECITON = -1;

			List<Tuple<int, int>> antinodes = [];
			antinodes.Add(antenna1);
			antinodes.Add(antenna2);

			int yDifference = antenna1.Item1 - antenna2.Item1;
			int xDifference = antenna1.Item2 - antenna2.Item2;

			var antinodesSet = GenerateAntinodesForAntennna(antenna1, yDifference, xDifference, maxY, maxX);
			foreach (var antinode in antinodesSet)
			{
				if ((antinode.Item1 >= 0) && (antinode.Item1 < maxY) && (antinode.Item2 >= 0) && (antinode.Item2 < maxX))
				{
					antinodes.Add(antinode);
				}
			}

			antinodesSet = GenerateAntinodesForAntennna(antenna2, yDifference * REVERSE_DIRECITON, xDifference * REVERSE_DIRECITON, maxY, maxX);
			foreach (var antinode in antinodesSet)
			{
				if ((antinode.Item1 >= 0) && (antinode.Item1 < maxY) && (antinode.Item2 >= 0) && (antinode.Item2 < maxX))
				{
					antinodes.Add(antinode);
				}
			}

			return antinodes;
		}

		private static List<Tuple<int, int>> GenerateAntinodesForAntennna(Tuple<int, int> antenna1, int yDifference, int xDifference, int maxY, int maxX)
		{
			List<Tuple<int, int>> antinodesWithHarmonics = [];

			var y = antenna1.Item1;
			var x = antenna1.Item2;

			while ((y > 0) && (y <  maxY) && (x > 0) && (x < maxX))
			{
				y += yDifference;
				x += xDifference;

				antinodesWithHarmonics.Add(new Tuple<int, int>(y, x));
			}

			return antinodesWithHarmonics;
		}
	}
}