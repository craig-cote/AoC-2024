namespace Challenges
{
	//    Start: unrecorded and full of interuptions
	// A Solved: 7:46pm (also full of interuptions)
	// B solved: 00:00pm

	public class Day14 : Shared
	{
		private const string ExampleA1 = "p=0,4 v=3,-3\r\np=6,3 v=-1,-3\r\np=10,3 v=-1,2\r\np=2,0 v=2,-1\r\np=0,0 v=1,3\r\np=3,0 v=-2,-2\r\np=7,6 v=-1,-3\r\np=3,0 v=-1,-2\r\np=9,3 v=2,3\r\np=7,3 v=-1,2\r\np=2,4 v=2,-3\r\np=9,5 v=-3,-3";
		private const string Data = "p=69,95 v=70,-27\r\np=95,51 v=-76,-2\r\np=54,32 v=-80,-4\r\np=41,28 v=27,6\r\np=63,6 v=-33,55\r\np=80,2 v=77,-78\r\np=69,53 v=54,-1\r\np=78,40 v=-11,99\r\np=36,55 v=-18,9\r\np=71,24 v=83,67\r\np=3,77 v=-38,71\r\np=13,54 v=5,-73\r\np=89,20 v=-9,25\r\np=39,70 v=-40,-61\r\np=38,55 v=-27,30\r\np=40,4 v=-87,19\r\np=62,23 v=35,-48\r\np=65,46 v=-61,13\r\np=43,58 v=-93,2\r\np=1,19 v=-61,17\r\np=81,23 v=-51,53\r\np=11,53 v=78,20\r\np=70,67 v=-70,-67\r\np=20,45 v=-88,40\r\np=90,37 v=-37,-8\r\np=90,0 v=-11,51\r\np=50,89 v=-20,80\r\np=84,58 v=29,48\r\np=1,24 v=-76,-50\r\np=39,70 v=-16,-67\r\np=4,58 v=91,-97\r\np=35,3 v=54,-86\r\np=55,38 v=56,-14\r\np=81,6 v=-4,-84\r\np=90,42 v=17,-30\r\np=54,0 v=8,13\r\np=30,30 v=88,-42\r\np=3,84 v=-29,-17\r\np=75,6 v=-28,-88\r\np=63,6 v=-94,-98\r\np=58,19 v=-93,75\r\np=97,63 v=-3,51\r\np=6,99 v=-30,50\r\np=48,83 v=-32,88\r\np=59,40 v=-59,-73\r\np=54,102 v=-86,13\r\np=93,48 v=-91,-18\r\np=80,4 v=72,-32\r\np=89,11 v=98,-56\r\np=64,93 v=-72,-5\r\np=0,36 v=31,6\r\np=46,56 v=-88,-91\r\np=58,94 v=-67,1\r\np=80,73 v=-18,96\r\np=3,101 v=-2,-21\r\np=67,30 v=-45,87\r\np=97,77 v=-3,74\r\np=24,54 v=66,-89\r\np=96,17 v=99,-71\r\np=84,7 v=50,-20\r\np=89,62 v=65,-67\r\np=13,12 v=-48,-90\r\np=73,2 v=-45,39\r\np=47,100 v=-59,90\r\np=36,9 v=46,-76\r\np=78,52 v=12,-70\r\np=1,42 v=-91,18\r\np=20,23 v=-89,61\r\np=96,47 v=24,-79\r\np=98,100 v=31,27\r\np=35,73 v=-80,-29\r\np=40,39 v=81,10\r\np=8,7 v=25,21\r\np=23,10 v=-1,19\r\np=95,77 v=-27,49\r\np=43,88 v=20,-80\r\np=58,83 v=21,-35\r\np=0,26 v=38,-20\r\np=47,92 v=61,94\r\np=23,74 v=72,-22\r\np=52,54 v=1,-93\r\np=8,61 v=65,-59\r\np=8,52 v=72,-93\r\np=63,14 v=17,60\r\np=16,51 v=82,-9\r\np=77,34 v=56,-20\r\np=74,5 v=-58,-72\r\np=35,77 v=6,58\r\np=37,79 v=-81,-9\r\np=25,78 v=26,94\r\np=40,48 v=40,17\r\np=62,73 v=-45,23\r\np=47,72 v=42,84\r\np=83,12 v=37,-90\r\np=65,2 v=-65,65\r\np=29,52 v=67,-77\r\np=98,39 v=24,4\r\np=76,66 v=83,40\r\np=6,26 v=18,-16\r\np=68,89 v=-52,-3\r\np=64,19 v=30,-63\r\np=36,39 v=-68,-10\r\np=46,30 v=-53,-22\r\np=77,44 v=-45,-4\r\np=82,60 v=78,8\r\np=87,77 v=-37,84\r\np=93,58 v=-57,-89\r\np=55,44 v=55,8\r\np=1,60 v=-16,-81\r\np=98,62 v=-30,-93\r\np=64,74 v=-25,56\r\np=64,22 v=3,29\r\np=94,32 v=-57,-34\r\np=35,88 v=-94,-19\r\np=53,87 v=89,-78\r\np=18,33 v=-33,-96\r\np=62,30 v=-39,1\r\np=3,79 v=-47,-24\r\np=32,102 v=41,98\r\np=63,85 v=-76,86\r\np=55,28 v=-64,-26\r\np=29,93 v=72,-87\r\np=96,41 v=-50,-20\r\np=38,21 v=-7,95\r\np=67,20 v=-97,-54\r\np=12,26 v=-26,32\r\np=21,35 v=-68,77\r\np=38,49 v=80,64\r\np=94,55 v=57,-72\r\np=60,65 v=90,60\r\np=73,85 v=-75,-73\r\np=83,42 v=83,42\r\np=6,19 v=-89,-25\r\np=72,68 v=63,-17\r\np=15,31 v=86,83\r\np=39,31 v=74,81\r\np=42,12 v=-98,-25\r\np=64,28 v=81,-31\r\np=38,98 v=-35,-99\r\np=1,67 v=85,-59\r\np=44,7 v=-65,-58\r\np=75,41 v=-64,70\r\np=67,90 v=-37,-15\r\np=56,20 v=-93,-44\r\np=70,101 v=-58,-15\r\np=69,8 v=90,-34\r\np=56,86 v=42,74\r\np=74,1 v=-85,-66\r\np=55,16 v=48,53\r\np=98,85 v=10,-86\r\np=83,15 v=-84,-64\r\np=34,33 v=98,-37\r\np=30,59 v=88,52\r\np=55,49 v=55,34\r\np=97,39 v=-30,-36\r\np=31,102 v=13,-80\r\np=42,98 v=-33,-3\r\np=27,71 v=-70,-10\r\np=30,79 v=-82,44\r\np=34,88 v=-8,-29\r\np=0,55 v=51,-79\r\np=26,12 v=19,-72\r\np=3,71 v=-36,80\r\np=50,59 v=22,-93\r\np=74,44 v=-79,95\r\np=16,5 v=-8,29\r\np=99,11 v=30,47\r\np=73,43 v=89,-28\r\np=26,4 v=53,27\r\np=11,21 v=-22,-28\r\np=14,3 v=60,15\r\np=26,1 v=-37,48\r\np=6,62 v=-86,75\r\np=24,87 v=90,17\r\np=47,90 v=81,-11\r\np=90,65 v=98,-71\r\np=91,59 v=-4,-35\r\np=9,29 v=97,82\r\np=89,15 v=30,51\r\np=50,100 v=20,-78\r\np=62,36 v=-96,78\r\np=9,102 v=99,29\r\np=80,97 v=27,55\r\np=36,13 v=74,-64\r\np=88,20 v=36,35\r\np=25,3 v=87,-90\r\np=11,31 v=-83,-36\r\np=67,51 v=-34,32\r\np=38,66 v=-34,-67\r\np=30,11 v=-39,50\r\np=3,86 v=95,-29\r\np=76,4 v=63,-64\r\np=28,99 v=-89,56\r\np=30,97 v=-48,3\r\np=98,33 v=84,-48\r\np=82,26 v=-64,69\r\np=98,73 v=-3,-33\r\np=16,81 v=-67,2\r\np=21,96 v=92,-37\r\np=44,36 v=-41,-87\r\np=48,44 v=-32,77\r\np=79,61 v=-90,19\r\np=26,46 v=66,81\r\np=11,69 v=25,-59\r\np=13,75 v=12,-47\r\np=79,83 v=63,-31\r\np=40,82 v=-1,-3\r\np=89,85 v=91,78\r\np=27,28 v=-83,-17\r\np=35,10 v=-82,73\r\np=23,84 v=33,-11\r\np=9,2 v=99,21\r\np=39,86 v=5,-67\r\np=45,39 v=87,-28\r\np=80,44 v=-70,32\r\np=14,59 v=-73,71\r\np=51,99 v=-10,61\r\np=99,51 v=-16,22\r\np=2,17 v=-63,77\r\np=45,31 v=-73,69\r\np=77,7 v=63,-72\r\np=31,74 v=-29,43\r\np=100,77 v=-2,93\r\np=23,38 v=53,65\r\np=92,89 v=-94,-23\r\np=71,12 v=-20,55\r\np=92,1 v=-44,-48\r\np=61,62 v=17,74\r\np=44,2 v=-1,-51\r\np=27,82 v=6,78\r\np=89,19 v=-44,-42\r\np=96,14 v=31,45\r\np=32,31 v=53,67\r\np=26,89 v=79,-21\r\np=96,24 v=-51,59\r\np=2,30 v=-66,72\r\np=70,91 v=55,15\r\np=87,1 v=37,29\r\np=76,80 v=-11,46\r\np=73,1 v=-72,-72\r\np=100,43 v=65,10\r\np=62,32 v=-12,79\r\np=33,29 v=74,-22\r\np=76,24 v=-6,-31\r\np=3,71 v=-96,-50\r\np=18,100 v=46,86\r\np=36,101 v=73,-15\r\np=81,76 v=-50,68\r\np=35,25 v=81,-44\r\np=74,79 v=16,74\r\np=7,53 v=65,-81\r\np=89,96 v=30,-9\r\np=20,2 v=-82,-7\r\np=47,97 v=-13,5\r\np=50,16 v=96,-94\r\np=19,45 v=-89,-4\r\np=45,2 v=89,-64\r\np=60,35 v=90,73\r\np=47,45 v=42,95\r\np=55,24 v=-32,31\r\np=15,74 v=-96,34\r\np=69,86 v=36,83\r\np=69,94 v=76,98\r\np=33,92 v=-4,-63\r\np=52,5 v=28,-56\r\np=14,58 v=91,-30\r\np=9,30 v=26,-20\r\np=9,14 v=19,-8\r\np=17,69 v=12,46\r\np=89,33 v=-68,-34\r\np=7,88 v=59,-66\r\np=79,93 v=-5,72\r\np=43,95 v=27,-9\r\np=43,62 v=41,10\r\np=60,0 v=-52,-84\r\np=7,25 v=71,-38\r\np=76,13 v=-51,-24\r\np=11,5 v=-89,-76\r\np=69,58 v=-92,-55\r\np=36,87 v=34,80\r\np=57,76 v=-32,-29\r\np=78,25 v=-34,27\r\np=58,60 v=-39,-65\r\np=13,9 v=33,-36\r\np=38,5 v=-23,45\r\np=99,49 v=93,-57\r\np=18,11 v=-89,57\r\np=74,36 v=-37,-73\r\np=70,1 v=57,-60\r\np=80,65 v=-11,46\r\np=41,16 v=28,-18\r\np=35,23 v=-80,-18\r\np=82,11 v=76,67\r\np=74,47 v=25,-81\r\np=12,98 v=66,5\r\np=69,23 v=-92,-52\r\np=2,85 v=58,92\r\np=17,68 v=-48,-63\r\np=22,60 v=-12,89\r\np=75,34 v=-11,73\r\np=16,27 v=87,-99\r\np=95,34 v=-3,-20\r\np=16,20 v=38,-10\r\np=10,22 v=-22,-58\r\np=53,7 v=75,43\r\np=74,27 v=63,63\r\np=2,84 v=-27,-71\r\np=99,33 v=61,90\r\np=89,7 v=17,53\r\np=65,2 v=49,41\r\np=83,48 v=-78,-99\r\np=34,27 v=52,-72\r\np=46,24 v=-33,63\r\np=48,64 v=-60,28\r\np=46,16 v=21,-60\r\np=88,23 v=38,-40\r\np=77,72 v=63,46\r\np=33,57 v=-21,28\r\np=36,82 v=11,64\r\np=83,38 v=17,91\r\np=49,67 v=94,52\r\np=95,38 v=23,-36\r\np=87,29 v=50,75\r\np=88,70 v=-64,50\r\np=56,18 v=22,-14\r\np=85,7 v=24,3\r\np=69,39 v=56,6\r\np=82,97 v=77,41\r\np=28,3 v=-88,29\r\np=59,15 v=-86,-48\r\np=43,78 v=64,84\r\np=78,86 v=-55,-3\r\np=62,38 v=-79,-2\r\np=81,68 v=94,46\r\np=48,80 v=-85,-67\r\np=13,77 v=-90,32\r\np=51,43 v=49,30\r\np=94,55 v=-57,30\r\np=41,15 v=-13,-38\r\np=40,97 v=-53,80\r\np=39,6 v=34,-38\r\np=97,96 v=77,27\r\np=73,87 v=76,-21\r\np=27,22 v=76,-17\r\np=80,94 v=94,-7\r\np=78,18 v=-31,-64\r\np=34,47 v=81,-95\r\np=87,96 v=51,94\r\np=35,21 v=-14,-48\r\np=95,16 v=-85,-53\r\np=77,14 v=-90,59\r\np=49,48 v=41,14\r\np=75,52 v=-92,32\r\np=16,91 v=96,-11\r\np=50,24 v=-46,92\r\np=88,38 v=37,-93\r\np=97,13 v=85,43\r\np=81,44 v=50,99\r\np=97,45 v=-97,-75\r\np=35,91 v=94,15\r\np=3,74 v=18,-47\r\np=64,32 v=62,91\r\np=74,16 v=31,-64\r\np=65,37 v=44,89\r\np=90,25 v=-98,-64\r\np=13,98 v=-36,-5\r\np=83,102 v=84,-90\r\np=42,15 v=-67,45\r\np=8,10 v=86,73\r\np=72,84 v=-11,-9\r\np=58,99 v=36,-84\r\np=59,19 v=-5,51\r\np=22,38 v=-76,-78\r\np=24,8 v=-68,45\r\np=60,70 v=-32,44\r\np=41,5 v=-19,-40\r\np=28,4 v=-48,35\r\np=53,47 v=-38,72\r\np=82,80 v=23,84\r\np=21,95 v=19,-17\r\np=85,5 v=-71,-86\r\np=90,2 v=-44,-46\r\np=92,63 v=-84,-53\r\np=82,67 v=83,-83\r\np=9,76 v=-29,-65\r\np=87,55 v=-90,-75\r\np=2,59 v=-19,33\r\np=17,78 v=38,-17\r\np=99,8 v=51,37\r\np=58,35 v=42,79\r\np=9,97 v=-77,37\r\np=63,19 v=-32,-36\r\np=76,31 v=50,81\r\np=14,68 v=-89,42\r\np=49,45 v=97,7\r\np=81,52 v=-38,-93\r\np=75,97 v=3,80\r\np=48,101 v=67,-78\r\np=89,95 v=91,-7\r\np=6,96 v=52,-1\r\np=67,37 v=75,79\r\np=73,47 v=37,2\r\np=7,98 v=32,3\r\np=7,87 v=-43,-23\r\np=27,61 v=62,-79\r\np=30,85 v=6,1\r\np=42,29 v=34,-46\r\np=47,30 v=95,73\r\np=25,88 v=6,78\r\np=72,92 v=36,84\r\np=90,92 v=64,31\r\np=79,70 v=-72,90\r\np=39,77 v=81,-38\r\np=50,2 v=-88,-35\r\np=90,91 v=38,-35\r\np=75,17 v=89,61\r\np=98,60 v=-16,-49\r\np=56,1 v=56,84\r\np=1,82 v=55,-45\r\np=22,59 v=86,-81\r\np=100,84 v=-23,-88\r\np=90,51 v=-17,-91\r\np=82,53 v=3,-77\r\np=77,96 v=36,-9\r\np=76,52 v=-38,-69\r\np=8,18 v=-72,-72\r\np=48,74 v=-20,8\r\np=22,81 v=90,-2\r\np=55,102 v=-73,52\r\np=83,79 v=-48,14\r\np=83,13 v=97,-60\r\np=35,96 v=-94,-9\r\np=49,56 v=-45,89\r\np=55,16 v=-10,71\r\np=58,51 v=89,16\r\np=1,15 v=-37,83\r\np=27,66 v=-41,-67\r\np=68,92 v=56,7\r\np=48,41 v=35,47\r\np=69,38 v=56,53\r\np=57,87 v=-58,-42\r\np=69,50 v=69,50\r\np=11,101 v=72,7\r\np=61,5 v=-20,-8\r\np=41,22 v=-53,-54\r\np=2,40 v=45,-8\r\np=15,44 v=-21,67\r\np=25,44 v=80,-79\r\np=23,91 v=-25,-79\r\np=82,55 v=-90,-85\r\np=37,13 v=-26,-26\r\np=10,2 v=-90,96\r\np=10,45 v=-95,90\r\np=61,12 v=55,-60\r\np=97,37 v=98,89\r\np=7,95 v=-2,-90\r\np=23,93 v=39,5\r\np=70,74 v=12,44\r\np=28,54 v=-41,-98\r\np=34,91 v=25,-84\r\np=16,48 v=-21,-57\r\np=87,83 v=17,-21\r\np=82,64 v=23,36\r\np=60,75 v=42,-29\r\np=30,16 v=23,64\r\np=4,80 v=92,92\r\np=74,26 v=62,65\r\np=24,11 v=25,-58\r\np=26,97 v=57,20\r\np=2,99 v=-62,21\r\np=44,62 v=61,48\r\np=8,43 v=79,-89\r\np=32,93 v=-54,37\r\np=31,33 v=6,-12\r\np=80,35 v=-51,-16\r\np=72,14 v=-18,22\r\np=3,68 v=-15,86\r\np=87,15 v=11,37\r\np=4,57 v=-9,-61\r\np=23,37 v=-82,-22\r\np=9,77 v=-76,-37\r\np=32,7 v=-21,60\r\np=43,69 v=-50,95\r\np=90,55 v=4,-43\r\np=58,34 v=59,-27\r\np=44,2 v=45,-24\r\np=32,91 v=67,29\r\np=52,35 v=-26,-60\r\np=80,102 v=90,-20\r\np=5,59 v=-43,-75\r\np=51,57 v=45,70\r\np=90,65 v=51,16\r\np=54,40 v=-74,79\r\np=47,12 v=-33,-54\r\np=71,80 v=-85,-37\r\np=24,12 v=-28,-50\r\np=50,8 v=-79,61\r\np=27,86 v=65,-30\r\np=25,46 v=16,48\r\np=5,3 v=-76,-90";

		public class RobotDetails
		{
			public required Tuple<int, int> InitialPosition { get; set; }
			public required Tuple<int, int> Veclocity { get; set; }
			public int ElapsedSeconds { get; set; }
			public required Tuple<int, int> CurrentPosition { get; set; }
		}

		public class RobotMovementPredictor
		{
			public int Width { get; set; }
			public int Height { get; set; }

			public void PredictRobotMovement(RobotDetails robot, int numberOfSeconds, bool fromInitialPosition = true)
			{
				var startingPosition = robot.InitialPosition;
				if (!fromInitialPosition)
				{
					startingPosition = robot.CurrentPosition;
				}
				robot.CurrentPosition = startingPosition;

				for (int i = 0; i < numberOfSeconds; ++i)
				{
					var newY = robot.CurrentPosition.Item2 + robot.Veclocity.Item2;
					var newX = robot.CurrentPosition.Item1 + robot.Veclocity.Item1;

					if (newY > Height + ZERO_INDEX_OFFSET)
					{
						newY = newY - Height;
					}

					if (newY < 0)
					{
						newY = newY + Height;
					}

					if (newX > Width + ZERO_INDEX_OFFSET)
					{
						newX = newX - Width;
					}

					if (newX < 0)
					{
						newX = newX + Width;
					}

					robot.CurrentPosition = new Tuple<int, int>(newX, newY);
					robot.ElapsedSeconds = i + (ZERO_INDEX_OFFSET * 1);
				}
			}
		}

		[TestCase(ExampleA1, 11, 7, 12)]
		[TestCase(Data, 101, 103, 218619120)]
		[Parallelizable]
		public void QuestionA(string data, int width, int height, int expected)
		{
			RobotMovementPredictor predictor = new() { Width = width, Height = height };

			List<RobotDetails> definitions = ParseDefinitions(data);

			Parallel.For(0, definitions.Count, i =>
			{
				predictor.PredictRobotMovement(definitions[i], 100);
			});

			var locations = new int[height, width];
			MapRobotsToLocations(locations, definitions);

			WriteGrid(locations);

			var positionsWithRobots = CountOfRobotsInQuadrants(locations);

			var product = 1;
			foreach (var position in positionsWithRobots)
			{
				product *= position;
			}

			Console.WriteLine(product);
			Assert.That(product, Is.EqualTo(expected));
		}

		private static List<RobotDetails> ParseDefinitions(string data)
		{
			List<RobotDetails> robots = [];

			string[] rows = data.Split("\r\n");
			foreach (var row in rows)
			{
				string[] details = row.Split(" ");
				string[] position = details[0].Replace("p=", string.Empty).Split(",");
				string[] velocity = details[1].Replace("v=", string.Empty).Split(",");
				robots.Add(new RobotDetails()
				{
					InitialPosition = new Tuple<int, int>(Convert.ToInt32(position[0]), Convert.ToInt32(position[1])),
					CurrentPosition = new Tuple<int, int>(Convert.ToInt32(position[0]), Convert.ToInt32(position[1])),
					Veclocity = new Tuple<int, int>(Convert.ToInt32(velocity[0]), Convert.ToInt32(velocity[1])),
				});
			}

			return robots;
		}

		private static void MapRobotsToLocations(int[,] grid, List<RobotDetails> robots)
		{
			foreach (var robot in robots)
			{
				++grid[robot.CurrentPosition.Item2, robot.CurrentPosition.Item1];
			}
		}

		private static int[] CountOfRobotsInQuadrants(int[,] robotsPerLocation)
		{
			List<int[,]> quadrants = ParseQuadrants(robotsPerLocation);

			int[] counts = new int[quadrants.Count];
			for (int i = 0; i < quadrants.Count; ++i)
			{
				counts[i] = SumOfRobotsInQuadrant(quadrants[i]);
			}

			return counts;
		}

		private static List<int[,]> ParseQuadrants(int[,] locations)
		{
			List<int[,]> quadrants = [];

			Tuple<int, int, int, int> topLeftQuadrantCoords = new(0, locations.GetLength(1) / 2, 0, locations.GetLength(0) / 2);
			Tuple<int, int, int, int> topRighttQuadrantCoords = new(topLeftQuadrantCoords.Item2 + 1, locations.GetLength(1), 0, topLeftQuadrantCoords.Item4);
			Tuple<int, int, int, int> bottomLeftQuadrantCoords = new(0, topLeftQuadrantCoords.Item2, topLeftQuadrantCoords.Item4 + 1, locations.GetLength(0));
			Tuple<int, int, int, int> bottomRightQuadrantCoords = new(topRighttQuadrantCoords.Item1, topRighttQuadrantCoords.Item2, bottomLeftQuadrantCoords.Item3, bottomLeftQuadrantCoords.Item4);

			quadrants.Add(CopyQuadrant(locations, topLeftQuadrantCoords));
			quadrants.Add(CopyQuadrant(locations, topRighttQuadrantCoords));
			quadrants.Add(CopyQuadrant(locations, bottomLeftQuadrantCoords));
			quadrants.Add(CopyQuadrant(locations, bottomRightQuadrantCoords));

			return quadrants;
		}

		private static int[,] CopyQuadrant(int[,] locations, Tuple<int, int, int, int> quadrantCoords)
		{
			int[,] quadrant = new int[quadrantCoords.Item4 - quadrantCoords.Item3, quadrantCoords.Item2 - quadrantCoords.Item1];

			for (int y = quadrantCoords.Item3; y < quadrantCoords.Item4; ++y)
			{
				for (int x = quadrantCoords.Item1; x < quadrantCoords.Item2; ++x)
				{
					quadrant[y - quadrantCoords.Item3, x - quadrantCoords.Item1] = locations[y, x];
				}
			}

			return quadrant;
		}

		private static int SumOfRobotsInQuadrant(int[,] robotsPerLocation)
		{
			int countOfRobotsInQuadrant = 0;

			foreach (var countOfRobots in robotsPerLocation)
			{
				countOfRobotsInQuadrant += countOfRobots;
			}

			return countOfRobotsInQuadrant;
		}

		[TestCase(Data, 101, 103, 218619120)]
		public void QuestionB(string data, int width, int height, int expected)
		{
			RobotMovementPredictor predictor = new() { Width = width, Height = height };

			List<RobotDetails> definitions = ParseDefinitions(data);

			var locations = new int[height, width];
			MapRobotsToLocations(locations, definitions);

			//while top border does not exist, execut PredictRobotMovement.
			int seconds = 0;
			while (!GridHasTopBorder(locations))
			{
				AdvanceRobotsOneSecond(predictor, definitions);
				++seconds;

				MapRobotsToLocations(locations, definitions);
			}

			WriteGridWithRobots(locations);

			Assert.That(seconds, Is.EqualTo(expected));
		}

		private static bool GridHasTopBorder(int[,] locations)
		{
			for (int i = 0; i < locations.GetLength(1); ++i)
			{
				if (locations[0, i] == 0)
				{
					return false;
				}
			}

			return true;
		}

		private static void AdvanceRobotsOneSecond(RobotMovementPredictor predictor, List<RobotDetails> definitions)
		{
			Parallel.For(0, definitions.Count, i =>
			{
				predictor.PredictRobotMovement(definitions[i], 1);
			});
		}
	}
}