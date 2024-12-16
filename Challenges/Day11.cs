using static Challenges.Day14;

namespace Challenges
{
	//    Start:  8:20pm
	// A Solved:  9:21pm
	// B solved: 00:00pm

	public class Day11 : Shared
	{
		private const string Example = "125 17";
		private const string Data = "6571 0 5851763 526746 23 69822 9 989";

		[TestCase(Example, 55312)]
		[TestCase(Data, 203953)]
		[Parallelizable]
		public void QuestionA(string data, int expected)
		{
			List<long> stones = ParseStones(data);
			for (int i = 0; i < 25; ++i)
			{
				stones = Blink(stones);
			}

			Console.WriteLine(stones.Count);
			Assert.That(stones, Has.Count.EqualTo(expected));
		}

		private static List<long> ParseStones(string data)
		{
			List<long> stones = [];

			string[] stoneStrings = data.Split(" ");
			foreach (var stoneString in stoneStrings)
			{
				stones.Add(Convert.ToInt64(stoneString));
			}

			return stones;
		}

		private static List<long> Blink(List<long> stones)
		{
			List<long>[] transformationResults = new List<long>[stones.Count];

			Parallel.For(0, stones.Count, i =>
			{
				transformationResults[i] = Transform(stones[i]);
			});

			var newStones = ApplyTransformations(transformationResults);

			return newStones;
		}

		private static List<long> Transform(long stone)
		{
			List<long> transformedStones = [];

			if (stone == 0)
			{
				transformedStones.Add(1);
			}
			else
			{
				var stoneAsString = stone.ToString();
				if (stoneAsString.Length % 2 == 0)
				{
					var firstStone = stoneAsString[..(stoneAsString.Length / 2)];
					transformedStones.Add(Convert.ToInt64(firstStone));

					var secondStone = stoneAsString[(stoneAsString.Length / 2)..];
					transformedStones.Add(Convert.ToInt64(secondStone));
				}
				else
				{
					transformedStones.Add(stone * 2024);
				}
			}

			return transformedStones;
		}

		private static List<long> ApplyTransformations(List<long>[] transformations)
		{
			List<long> newStones = [];

			foreach (var transformation in transformations)
			{
				newStones.AddRange(transformation);
			}

			return newStones;
		}

		[TestCase(Data, 0)]
		[Parallelizable]
		public void QuestionB(string data, int expected)
		{
			List<long> stones = ParseStones(data);
			for (int i = 0; i < 75; ++i)
			{
				stones = Blink(stones);
			}

			Console.WriteLine(stones.Count);
			Assert.That(stones, Has.Count.EqualTo(expected));
		}
	}
}