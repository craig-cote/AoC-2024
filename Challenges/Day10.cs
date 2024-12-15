
namespace Challenges
{
	//    Start: 7:24am
	// A Solved: 9:12am
	// B solved: 9:21am

	public class Day10 : Shared
	{
		private const string ExampleA1 = "...0...\r\n...1...\r\n...2...\r\n6543456\r\n7.....7\r\n8.....8\r\n9.....9";
		private const string ExampleA2 = "..90..9\r\n...1.98\r\n...2..7\r\n6543456\r\n765.987\r\n876....\r\n987....";
		private const string ExampleA3 = "10..9..\r\n2...8..\r\n3...7..\r\n4567654\r\n...8..3\r\n...9..2\r\n.....01";
		private const string ExampleA4 = "89010123\r\n78121874\r\n87430965\r\n96549874\r\n45678903\r\n32019012\r\n01329801\r\n10456732";
		private const string Data = "14567892107654348943218769016567650154541210421036\r\n03456783298993267654309458122168743243450344323145\r\n12567654456780154327812367433059804012769455410234\r\n03498012349876065016901056544965418765898766708943\r\n12345101212145076545411034545878329658981055899854\r\n09876876705034187632110123656789421047432765988765\r\n67878965896123298901001656743078431236598894012034\r\n50965014387654567650012349856127340012367653213125\r\n41234321298347656543243492347833458903458743404987\r\n30087430178298343650156781016942167812769252985676\r\n21196567069121243761056432679851043212890101679854\r\n33203498451080252852347841589765654301285234521763\r\n14512432347890161943210950432106567610106501430012\r\n01693501036543270856102167645656788943217432567897\r\n32789672321015389987343078938765497654998549879898\r\n45679987410234578101256560129812321067801456734787\r\n03478756500187665432107452121901054328982340125676\r\n12568767891098987013898943030810167017654321010210\r\n21079458910127698123965436945107878988901267124378\r\n30980349821034787654876327876716901210985458095469\r\n45671210136765693454761016329825432345671329186954\r\n12789800345876548763876125419434501654510413277843\r\n03543211238989439012985630308765898746701204567832\r\n14623400141232323101234521678906567239874343236901\r\n25710519850541014143219834567611452108965650145690\r\n76897678769650001054301712106320143210345789036781\r\n87678989678742112363212601235431234321276988325432\r\n90549876349233678478004592347842389123489676710876\r\n21632305256104569589123487656965476016512369856945\r\n52301014107012345670149874565456365017603450747832\r\n65490123458912396501234563432147454328214921632401\r\n86985432167905487654341012563038901039309834521321\r\n97876789001856778761232127678127612398712701100410\r\n89810678012760869890103238999210543125625632234509\r\n76701549013451987217876434785695610034534548765678\r\n05432432174012987301987325654780123435210159854789\r\n12980120985123673458986510783279234987346543123898\r\n43878921976034562567603412892168765679857012010187\r\n34565437852178901070412103601001410012768001921236\r\n45430566543065012181543014580432321003459122876545\r\n50121098767654327892678877698569457654219433468904\r\n23292145678954218983019988087658768894308596567812\r\n14587239010563007654128679112565489765107687656521\r\n05674678323472167659436543203474321087230156785430\r\n96983565401089898748540987654589321098543243896543\r\n87874328992396701037621296562105465407698012565432\r\n78765017687478632128760345673456978312789801478521\r\n29653078596569543019656921087567889213456700329650\r\n12532169430430156010567892193610367804765410418789\r\n03445678321321060123456543012323458912894321001678";
		private const string ExampleB1 = ".....0.\r\n..4321.\r\n..5..2.\r\n..6543.\r\n..7..4.\r\n..8765.\r\n..9....";
		private const string ExampleB2 = "..90..9\r\n...1.98\r\n...2..7\r\n6543456\r\n765.987\r\n876....\r\n987....";
		private const string ExampleB3 = "012345\r\n123456\r\n234567\r\n345678\r\n4.6789\r\n56789.";
		private const string ExampleB4 = "89010123\r\n78121874\r\n87430965\r\n96549874\r\n45678903\r\n32019012\r\n01329801\r\n10456732";

		[TestCase(ExampleA1, 2)]
		[TestCase(ExampleA2, 4)]
		[TestCase(ExampleA3, 3)]
		[TestCase(ExampleA4, 36)]
		[TestCase(Data, 638)]
		[Parallelizable]
		public void QuestionA(string data, int expected)
		{
			var grid = GenerateNewPopulatedGrid(data);
			WriteGrid(grid);

			List<int> scores = CalculateScoresForeachTrailheadFromPeaksReached(grid);
			int solution = scores.Sum();

			Console.WriteLine(solution);
			Assert.That(solution, Is.EqualTo(expected));
		}

		private static List<int> CalculateScoresForeachTrailheadFromPeaksReached(char[,] grid)
		{
			List<int> scores = [];

			List<Tuple<int, int>> zeros = FindAllTrailheads(grid);
			foreach (var zero in zeros)
			{
				List<Tuple<int, int>> newTrail = [zero];
				var allCompleteTrails = GenerateAllCompleteTrails(grid, newTrail, 0);
				scores.Add(CountUniquePeaksReached(allCompleteTrails));
			}

			return scores;
		}

		private static int CountUniquePeaksReached(List<List<Tuple<int, int>>> allCompleteTrails)
		{
			List<Tuple<int, int>> uniquePeaks = [];

			foreach (var trail in allCompleteTrails)
			{
				if (!uniquePeaks.Contains(trail[^1]))
				{
					uniquePeaks.Add(trail[^1]);
				}
			}

			return uniquePeaks.Count;
		}

		private static List<Tuple<int, int>> FindAllTrailheads(char[,] grid)
		{
			List<Tuple<int, int>> trailheads = [];

			for (int y = 0; y < grid.GetLength(0); ++y)
			{
				for (int x = 0; x < grid.GetLength(1); ++x)
				{
					if (grid[y,x] != EMPTY && (Convert.ToInt32(grid[y, x].ToString()) == 0))
					{
						trailheads.Add(new Tuple<int, int>(y, x));
					}
				}
			}

			return trailheads;
		}

		private static List<List<Tuple<int, int>>> GenerateAllCompleteTrails(char[,] grid, List<Tuple<int, int>> trail, int currentElevation)
		{
			List<List<Tuple<int, int>>> allBranches = [];

			if (currentElevation < 9)
			{
				var allNewBranches = IdentifyNewBranchesFromCurrentLocation(grid, trail[^1], currentElevation + 1);
				foreach (var branch in allNewBranches)
				{
					List<Tuple<int, int>> branchingTrail = new(trail)
					{
						branch
					};

					if (currentElevation + 1 == 9)
					{
						allBranches.Add(branchingTrail);
					}
					else
					{
						allBranches.AddRange(GenerateAllCompleteTrails(grid, branchingTrail, currentElevation + 1));
					}
				}
			}

			return allBranches;
		}

		private static List<Tuple<int, int>> IdentifyNewBranchesFromCurrentLocation(char[,] grid, Tuple<int, int> currentLocation, int nextElevation)
		{
			List<Tuple<int, int>> surroundingCoordinates = [];

			surroundingCoordinates.Add(new Tuple<int, int>(currentLocation.Item1 - 1, currentLocation.Item2));
			surroundingCoordinates.Add(new Tuple<int, int>(currentLocation.Item1 + 1, currentLocation.Item2));
			surroundingCoordinates.Add(new Tuple<int, int>(currentLocation.Item1, currentLocation.Item2 - 1));
			surroundingCoordinates.Add(new Tuple<int, int>(currentLocation.Item1, currentLocation.Item2 + 1));

			surroundingCoordinates.RemoveAll(t => t.Item1 < 0);
			surroundingCoordinates.RemoveAll(t => t.Item1 >= grid.GetLength(0));
			surroundingCoordinates.RemoveAll(t => t.Item2 < 0);
			surroundingCoordinates.RemoveAll(t => t.Item2 >= grid.GetLength(1));

			List<Tuple<int, int>> branches = [];

			foreach (var coords in surroundingCoordinates)
			{
				if (grid[coords.Item1, coords.Item2] != EMPTY && (Convert.ToInt32(grid[coords.Item1, coords.Item2].ToString()) == nextElevation))
				{
					branches.Add(new Tuple<int, int>(coords.Item1, coords.Item2));
				}
			}

			return branches;
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

		[TestCase(ExampleB1, 3)]
		[TestCase(ExampleB2, 13)]
		[TestCase(ExampleB3, 227)]
		[TestCase(ExampleB4, 81)]
		[TestCase(Data, 1289)]
		[Parallelizable]
		public void QuestionB(string data, int expected)
		{
			var grid = GenerateNewPopulatedGrid(data);
			WriteGrid(grid);

			List<int> scores = CalculateScoresForeachTrailheadFromRatings(grid);
			int solution = scores.Sum();

			Console.WriteLine(solution);
			Assert.That(solution, Is.EqualTo(expected));
		}

		private static List<int> CalculateScoresForeachTrailheadFromRatings(char[,] grid)
		{
			List<int> scores = [];

			List<Tuple<int, int>> zeros = FindAllTrailheads(grid);
			foreach (var zero in zeros)
			{
				List<Tuple<int, int>> newTrail = [zero];
				scores.Add(GenerateAllCompleteTrails(grid, newTrail, 0).Count);
			}

			return scores;
		}
	}
}