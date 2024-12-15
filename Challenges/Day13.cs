namespace Challenges
{
	//    Start:  0:00pm
	// A Solved: 00:00pm
	// B solved: 00:00pm

	public class Day13 : Shared
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