namespace Challenges
{
	//    Start:  0:00pm
	// A Solved: 00:00pm
	// B solved: 00:00pm

	public class Day13
	{
		private const string Example = "";
		private const string Data = "";

		[TestCase(Example, 0)]
		[TestCase(Data, 0), Ignore("Waiting for Example to pass before testing with puzzle input.")]
		[Parallelizable]
		public void QuestionA(string data, int expected)
		{
			int solution = 0;

			var grid = GenerateNewPopulatedGrid(data);
			WriteGrid(grid);

			Console.WriteLine(solution);
			Assert.That(solution, Is.EqualTo(expected));
		}

		private static void WriteGrid(char[,] grid)
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

		[TestCase(Example, 0)]
		[TestCase(Data, 0), Ignore("Waiting for Example to pass before testing with puzzle input.")]
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