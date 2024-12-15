namespace Challenges
{
	public class Shared
	{
		public const int ZERO_INDEX_OFFSET = -1;
		public const char EMPTY = '.';

		public enum TimeComparison
		{
			Before,
			After
		}

		public enum CardinalDirection
		{
			N,
			E,
			S,
			W
		}

		public static void WriteGrid(char[,] grid)
		{
			for (int y = 0; y < grid.GetLength(0); y++)
			{
				for (int x = 0; x < grid.GetLength(0); x++)
				{
					Console.Write(grid[y, x] + " ");
				}

				Console.WriteLine();
			}

			Console.WriteLine();
		}

		public static char[,] GenerateNewPopulatedGrid(string data)
		{
			string[] rows = data.Split("\r\n");
			char[,] grid = InitializeGrid(rows);
			PopulateGrid(grid, rows);

			return grid;
		}

		public static char[,] InitializeGrid(string[] data)
		{
			int rows = data.Length;
			int columns = data[0].Length;

			return new char[columns, rows];
		}

		public static void PopulateGrid(char[,] grid, string[] data)
		{
			for (int y = 0; y < data.Length; ++y)
			{
				for (int x = 0; x < data[0].Length; ++x)
				{
					grid[y, x] = data[y][x];
				}
			}
		}
	}
}
