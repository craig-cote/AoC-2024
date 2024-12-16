
using System.Collections.Concurrent;

namespace Challenges
{
	//    Start: 10:50pm
	// A Solved: 11:53pm
	// B solved: 00:00pm

	public class Day15 : Shared
	{
		private const string ExampleA1_Map = "########\r\n#..O.O.#\r\n##@.O..#\r\n#...O..#\r\n#.#.O..#\r\n#...O..#\r\n#......#\r\n########";
		private const string ExampleA1_Moves = "<^^>>>vv<v>>v<<";
		private const string ExampleA2_Map = "##########\r\n#..O..O.O#\r\n#......O.#\r\n#.OO..O.O#\r\n#..O@..O.#\r\n#O#..O...#\r\n#O..O..O.#\r\n#.OO.O.OO#\r\n#....O...#\r\n##########";
		private const string ExampleA2_Moves = "<vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^\r\nvvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v\r\n><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<\r\n<<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^\r\n^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><\r\n^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^\r\n>^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^\r\n<><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>\r\n^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>\r\nv^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^";
		private const string Data_Map = "##################################################\r\n#...O.#..O....##O..OO.#O..#.#.......OO...#O.#OO..#\r\n#O#..OO...O..O.O.....O.O.O....OO#.....O#.O.OO..O.#\r\n#........O....#...O......O.OO...#..O.O.#O#....O..#\r\n#..O.OO..O..O.#..O.O.OO.O...O...O......#O.....O..#\r\n#..OO.....O.OO.O#.......O.........O.....O.O.O....#\r\n#.O.#.O.O#......OO........O.O.....OO..O.O.O.#.#O.#\r\n#........#.....#.##O....O.O..OOO.......OOO.#O....#\r\n#.O#.#...OO.....#.......O...O...#O.O.......OO..OO#\r\n#.O...O..#O...#O..O.........O.O..OO..O.......O.OO#\r\n#O.O......O.OO..O.O.......O.OO#O.##...#....#O.O.O#\r\n#.O...O.OO.O....O..O.O...O...#.O....OO..O.O#O#OO.#\r\n#.....O.O..#O.....O.O..##O.O#OO...O...O.O.O......#\r\n##..O...O..OO.O.O.O..OO........#.##.........O.O..#\r\n#..O...O.OO..OOO.O...#..#.........#.O....OO......#\r\n#O....OOO.OO...O##.O.OO..O.O.....O.O.OOO....O.O.O#\r\n#O.O..OO.O..OO............O....O....O..OO...OO..##\r\n#.O...O.O.O.....O..O.O...O.#.......OOO...........#\r\n#O.O...O.....#..O..#O...O.O.O....O#...#.###.....O#\r\n#.O...O.O..#O.#.OO.......O.OO.O...O...........O..#\r\n##O.#O....O.#............O..O..O.....O..O..OO....#\r\n##..#.OO.O.OO.#.O....O...#........#........O.O...#\r\n#..O.OO...O....#..OO.O...........OOOO#..OO#O.....#\r\n#OO.O#...#..#...O#........O.OOO...OO....#O.OO#OOO#\r\n#...OOO............#O.#.@...O.....O#.#.O...O..O..#\r\n#...O...OO.#..O......O..............#OOO......OOO#\r\n#..#OO...O.#O......O..OO.O#...O....OO..O...O.O#O.#\r\n#.#.##...#O........#.O.....#O#.O.OO..OOO..#..O...#\r\n#.#....#...O..O#O..OOO.....#....#......O...O...#.#\r\n#....O....O......O.O.O..........O.O..O.O......O..#\r\n#.#OO#O.OO............O##.##O.O#.O...O#.........O#\r\n##.O.#..........#......#OOOO.OO.#.O.O.O.....O..#.#\r\n#O.....#OO.....O..............#...O.O..O.....OO#.#\r\n#O.O.O..O#OO.O.O....O..O......O..O........OO.....#\r\n##O....O...............................#.O.....O##\r\n##..O...#...O.........O#...#O...O.OO......OO.O..O#\r\n#O..OO.....OOOO.#......O.#OO..O.O...O.O...O.O.O#.#\r\n#..O.....O.O........O.....O.....O#....OO##OOO..#O#\r\n#O..##....OOO..O#.O....O.#...O.....O.O.O......O.O#\r\n#..OO.#O.......O.OO.O#O.O.....O.....OO..OO.OOOO..#\r\n#.#.#OO.O..O.O........O#.#...#..O.O.O.#.O..OO.O.O#\r\n#..O#.OO.O.#.....O...O..OO#..O...O.O#...O.....#.O#\r\n#.OO.OO....O.O..O..#OO.....#......#.#OO..#.#O.O#.#\r\n#...O....#..#......O....O..O#O...O....OO.......O.#\r\n#.#.....O#.......O..O..#O.OOOO..........O.O......#\r\n#.O.O.....OO.O.O.O..#O.O.O..O.OO....O....##.....##\r\n#O..#.OOO##....O.O..OOOO.O...O..O#..........O....#\r\n##.O##...O.O.....O.O#...O.........#...........OOO#\r\n#O#O.....#..O.OOO...O..OO.....OOO............#O..#\r\n##################################################";
		private const string Data_Moves = "^^<^>^^<<^v>^><^^^<v<v^>^^<><^v>v<^vv>^v<^>>v>^vv<<vv>>>>>>v^>v>^>^v<^v^<v^<^v>>^^>v<<>>^v^<v<v>v<v<v^<>>^>v^>^^^<^<v<v<<<v<^vv>^v>>v<v^>><vvv>^>v<^^vvv<>vvv<^v<>v><><^^<>v^^<^><v^><>>^^>v^<v>>^<><<^><<>v>>vvv<^^v^v^><vv>>v^^><v^<<^v>^vv<^<^<^<><>>>^><vv>>^<v^<><><^v<^<^v<^^>^<><<^<<^vv^^v<vv^^>^<^<v^v^^<v^>^v<vvv^vv<^^<^^>v>>^v>^v><v^^^v>^<^<v<^>>^><>^v<>v>^^^<^vv^^<^v<vv>><^^^v<<>>>^<^^>^<v>v>><v^v<<<v>^<vv<^<v^>^<^<v^<>^><v<>^>><<^><vv>>vv<>v^<vvv^<v><v^vv>^<<><vvv>^<><>^^v<^v<<>vv><^>><^<<v<^>^>>^^>v<^>v^>^<vv><v><<^^^^v^<>^>^v^^v<v^<v>v<><<<v>vv^v><vv^>>>v>>>>><v<vvvv<<^v>^v>^<><<<><>v<vv<v><>^vv>v<>^v^<>>v<v>>>v^>^<vv^^<v<^<^>vv^vvv^^<<>vv>^>^v>>v^^vv<^v>^^vv<>^v>^>v^^<>^^><vvvvvv<^^>^^v<>^^^<^^<>^>^v><v><<>>^<>>v>>^><^>v<v><>v^v<v><>^<<>>v>^v<vv><>^v<^>^^v>v>>^<^^^<<vvv><<v><<>vvv^v><<v^vv><^^^v^^^>v><<^^v>vv^v><v>^>^v<>>vv<<^v<v><>v><^><>>^vv><>><<vv^v<^^>><<>>v>><><vv>v^^<^<v<<^vv^<^^<v^<vv<<v<>v<>^<^<^>v^^^>>v<^^<^^^>^^>^>^>^^<><vvv>v>v<vv<^v<^>vv^<vv>v^>^<^<>v>^^>v<^>v>v>><>\r\n^vv>>>^vv><^v^<>v>^><<v>^^<v^v<v^>^>^v>><>>^>^<<^^v^^vv>^v^<<v>^v^>v<v>v<<>^>vvv>v>^vvv>>vv^>v^^v^^v<v^v>v^^<><<<^^><<^<vv<>>>>^<>v><v>>^v<v<<vv>>v>><>v><<^v^><>v><v^^<>v>^>>^^><>v<v<^vv<^v>>^><v>^v>^>><<<^vv<>^<<^><^<<><>vv^^v<<>v>v^vvv<v^>>^>^>^<>v<>vv>^><vv>>v<v<>^^v<>><>>v<>>^^<>v^<v^v^v>vvv<><^^v^>vv<<v>^^>>>v>^>^^><<^v><v^>^^>>^^>v<<<v^><><<><>vv^>v>v^>vv><^<v^><>><<>^>vv<<<v>>v><^^<v^><v>^>v^^<^v>v^<<v^>><v^>^<<>^^vvv>vvv><<><^><>>><<>>^><v<<v><^<v<>>^><><^^vv<^>^vvv<^>>><<^>><^v<v^<vv<v><<v^^v^<><^>v>^v>v<v<<>>><v>^vv^>>><v^><^>v^<>>v>v^v^><^<vv>v^v^<^v<>^><^>>v^^>v<^^^<v^^v>v>v>^^^<^^><v<vv<^vv^<vv<<<><><^>>v<>v<^v>^^<>v^>^v<v^<vv^v>v<<<v>^<^v^^^>v^vv<>vv>^^<<><^><vv>><<^v<^>v>>^>><<^<>vv^>v><>^vv^^v>v<<>^<><^^>^^><^>>^v>vvvv>^>v><<^<v^v<^<<^^<>^><^v^<<v<>^v><^>vvv><^v<>><<^^>^<^<<v^^^<^v><<<v<<>v>^v^>^>vv^<><v^^<><><>^^<^v^^>^^^^^vv<<<v^<vv<<<v^^<v<^<<v><vv^<<<<<<^^^vv><^vv<<<>><>v>vv>^^^<^><><<><<v<><>><^vv^^<<v^<^^^>v<>^^^^<><^^^<vv><>^^<><<>><vv>>^<>v<v^v<<vv^>^^>^^>>^v>v^\r\n^>>v<><<<vvv^^^<vv><<<vvv>v<<<<^v<>v<<^vv<^vv<^^>>v^>^v^>^<>>>v<^<<^^>>vv^^<^^^>^><vv<v<v^^v<vv^<<^v<<^v<v<v><>>>vv<>vv<>^^>vv^vvvv<v>vv<vv^^>^<v<vvvv^>v>^^<<^<<<>v>^<^<v>v>vv<<v<^vv>>^^<v<v<v<>>^>><^<v<<>^^v<>^<^v>^><><<vv<^><<^><>^>^^vv^>^<<<^>^v>^v<<<>^^<^^<<^<v><^^<>^<<<^v^<>^>vv<vvv>v><<<^vv^<^><>><><>v^^>v<^<^vv<>><^>v>^v<><>>^v^^^^v^<<><^^v>><>^v^<v^><>>^<vv>v>v^^v<^v><>>v<v^v<v<v>><^^<<^v<>v<<^<v>^>><<<^>>v<v<<^^v<v>v>^<^>^<^v^<^v>>>>>><^vv<v<v^<^v^<<><^>v>>v<vv>^<vv<<v^v>>>vvv<v<vv<<<^v<v<>^vvvvvvv>^^>>>^v<>><>^<<<>^><^^v^v<>><^>^>v><<v>>>v^>^<^<^<v^vv>><<^<>vv^^v^<>v<<<^>>v<v>vv^>><<^<^^><^^>>>v>^^^>^v<v>v<v^<v^>^<<>^^^<^v>><>>>>v^<>>^^^<>v^^v^>><<>v>>^>^vvv<v>><>^v>vv^v>><vvvvv^>^><>^>v<<^>><^^v><^<v^^>>^^>^>vv><<<^vvvvv<^<^<<vv>^<^^<>v^^>^v<^^v<>v>^>^>vv^>v>^<vvv<<^<>^<^<^^v><^<^^v^<vv>v<>>^>v^v<^v>>><^v<^<<^v<^vv^^><>^v<><^><v^v>v<>vvv^^^>^^^^^v<^^^<v^<^>^v<<v<^^v<^v^<<^>><<>>>v^v<>v^^^>^vv>v>v>>><><v^<v><vv<>v>vvvv>v>>vvv><v<v^<^<v<^vvv>^<v<>v<>^^v^<^vv^^>^^>>vv<><^vv><v<\r\n<^^>^<^>><<>>v>vv^vv<^<<<<>^v<<>>^v<>>>^v><<<><^<^><>>><vv<v<v^<>>v^>v<><v^><^v>v^>^^v^^>v<<v<<v^^^<>v<^v^^<<<^v^^vv^v<v>v>vv^>^^v<vv^<<^>v^<^^<vvv><^>>>>^><<>^><vvv>^v^<^v>v^v><<>v^<>>v^^^<v>><<^>^>^<^vvv>><v<<>^<^><<v>^v>^^<><^^^>^><vvvv><^^><v>>v^vvv><vvv<^^v^v<v<><^<<v^>v>>^<<<<>^v<v>v^>^<^<<>><^>vvv>v>>v^><><>vv>>^vv>>vv<^<>^^^>^>v>^v><^v^>v^<v^v^^^>^v^>^>vv<vvv^<<^<>vvv<vv^<vv<<<v^^>v<<^^<^<>^^^v<v<^>><>><<<^^<>v<>vv<^<^v^v>v>v^vv^v<<v<^>^v<v^^v>^<<<<^^<<>v<<<<<>v<^<v>vv<>^<><v^^v^^<v^^<<vv<v^vv^>><><^<^^<^<>v<>^<<<<v^<<^<<vv<v<>>vv<<vv>^vv<>^^<>v><<v>><vv^^^^><<<^<^>v^vv>vvvv^>v<<v<>^^^v<<<><v<v^^><v^v>>^>>^>><v<<>vv>>>v>v^<<<v<^<<>>^^<v^vv<^^<v<v^^<>v>v^<vv<v<<>>^<^^<^^>><^^>v>v>^^>v>>>^<>^^v^v>^^<^v>^v><<<vv>v^>v^<v^><v^<^>vvv><<^>>v^^>>>^<v^v^>vvv<v<>v^>^^v^^>vvv>^v^^<v^<<v^<<<>^v^<^<vvv<<<<<v<<vv^<v>>v>>><v>^^<><>v<vv^>v>^vvv<<>>v<v<>^<>^<^<<v<<vv^<v^^<<^<^v<^<^>vv^<<vv^<^vv>v>v><^^>^><vv>vv<^<v<>^<^^v<><vvv<<>^vvv^^v<v<v<^<>^vv>>^>v>v<^^<>vv>^<<>^^^>^<^<^>v>vv^^><>^>^v>>^<>\r\n^<^^<^>v<^<^>^^>><<<>v<^^><>>^^<^^>^v^^><^v^^<^vv><>>v<^v^>>>^<>>^>^>^<<v>>^^^<^v<>vv^v^^<^>v>^>><<>>v<><^<<v<v><<>v>>^<><v<v<>>>>v>^v^<<<>^vv<<v><^>vv>vv>><v^v^^v<<<^<<<^vv><^><><<>v><vv<><^<<v<<vv^vv<^>>v>>>><><>^<v^^>vv<^v^vv><<^>v>v<<><>^>^v<^>v>v<>v<<>^vv<vv>>v><>><<<>>^^^<^^^^<<v^<<v><v<v<v>>^>>vv>^v<^>>vv>^^v>^vv^<v<^^v>^<v<v>^v><v>v>>><<<>>>v>vv<^>^v>v<vv^^v<^<v^^v<^v><v^>v^^^<><>v<^>><^vv>^<<^<>><<<<^<vv^<v<<v^>^>^^<v^<^vvvv<<v^><><>v><<^v<<<<<^v<v><v<<^<<v<>>v<^^v<<^<>^><<v^v^><<>>v<<^v>v>>>v<>>v><><^vv<vv><^^<<v^vv<^>v>v<v^<<<<v>v^<>^^>>>><<<>^^^^v>v>>>>^v><<^^<vv>>v^<<v^^<^v^v>v<>>^^v>^><^v>^>^^vvvvv<v>>^>v<v<^<>>v><vvv>v>v^^<v>^>^<><<^^^^<<v^<v>>^<^<vv<<^^^v>v>^>><v>>><v<>vv>>>v^>^><^^v>>^>>vv<^^<>><v>vv^^v<v<>^<>>>vvv<>^>vv^<<^<^<>vv>^>v>v<^<<><<vv^<<>^v^<^^^<^^^^vv^>^^>^^>><>^<^>v>v<^>>^^^^>^^><<v><v>>vv><^<vv^<v^v^vv>^>v>^^^^v><v>^v>^v<^v^>v>^<v<^v<v><v<<v^>>^^^>v>v^^v^<v>v>^v<^<v^^^v^>^^>^>vv^^vv>vv>v^v<^<^vv^><v^vv<<^>^^<v>v>^vvvv<>^^v<><vv>><<<vv>v<^>><><^><>>^<v^<><\r\n^><^v>v^><v^<>vvv^^v^v<v^>v<>>>v>>vv^^>v^><^^<>v^><<v<<v^<<v>>^v^<v^v^^^^^<^v<v^<^^<^>><v^^^>v>^^>><<<v>^><>v><^v><vv^>>>><<<><v>v^><<<>><<>^v^^^^<^^><><>^^vv^<^v<v>^>>^>^><>vv^>>>>v^<>vv^>>v^<>vv<v^^>>>><v><^><^>^vvvv><<^vvv^<>>v^v>><^^^><>>v^<v<v<v><v^^vv<v>>^<^^><<<>vvv^^^v>^v<>v^>v<<v^v>>v>v<>^v>vvvv<^>^^^v^^<v><>^<vv<><^^<vv<^<v<>v>>^^^><>v^>><^>vv>><^^^v>><^<<^><<>^>^<>v<v<^<<>v>vv^^^^<^>^v<>>^v>>>^v<>v<^v<<^v^v<<<v^vv^><^>><v^>v^v^v<<^^v>vv<v^^v<v^^<<<^v<^>^>v><>v>^vv>^v>><v^^>^<<^><>v>^>v>^<v><<^<>>^<v^^<<>^v<>^>v^<>^v><v<><v<vv>vvv<><<>>^<^^>^<<>^<>vv^^v^^<<>v<<><^<<v<><v<<>^^<>>><<^<v<v<>v<<^>v<v^^v<><<v>><v<^v>vv>^>>>>>vv<<><^^vv^>v^<>v<<vvvv><<>^>^<v^<>v>vv^^<^v>v<^<<v^>>>^vv>v^<>^v^<>^>><><>v>>v>^><^><^>v><<>>^^^<vv<<<v^v^<<><<^v>v>^vv^>><v>>^^<vv^v<^^vv><>v<^<^>>^v^>v<><^>>>vvv^^^^>vv>^>>>><^<>^>v^v<v<^v>>v<^<v^v<>>>>><^^vv><<>vv<>v<>>^>^^<>>vv>>><<>vvv<<>>vv>^<^^v>>v>^<<<><^v^v^>^v^><<>^v><>>^^>v>>>^<v<>^>>v<>>>^v>^v^<<<vv^>^<<<><>vv^>vvv>^^v>v<^v^v^><^v<>^v>^<>><<^v>vv^\r\n^>v<>>^vvv>>v<v<^>^vvv>>v^><>><^v<><vv>vv^<v<^>>^^><<>><^<^>^v<>v>>v^<>>^<<^vv<^^<>^v><<>>^^<<<v>^vv^v>^>^<>v>>>^<^<^<>v<^><<^><<>>vv><<><v<><>^<v^^<^>>>v^<v>^<v>>>>^v<^^<<vv^v<v<^^<<>v><>><^<<<vv^>^v>>^vv^v<><v<vv<>^>><<v<<>>>>^<v<v^v<^v><>>v><>>^^v>>^><^^^>^^>^>^>^<vv>vvvvv<^^>>>>v>vv>v>^vv^v<^v>^>^>vv>v<>v<><<>v^v<>><<<<v<<^vv>v<<>^v^><<v^^v>>v<><<v<v>^v>^>^><^^^>v<<v<^<v<^<>>vvv<<^^<vv^v<^^v>v>^vv^<^>v>>>v>^^><^>^v>^v^^>^^<v^^><v<vv^^>v><>><v<>^<^><^^v^^vv<^>^^>^>>vv<^<vv>><v>vv<<<v<^vvv<<<><>><><<^^v><vv^v><^<^<>v^v>^v^<<<v^>v^<<<<<vv>v^<>v<^^<<^>^v<<><>><v><><<<^^>v>^^<^^<v^v<vv>><v<<>v>v<^v>^>>v>>v>v<vv<>><^v^v<^v>^vv^><^v>><v<><<^<^^^^^^>>v>v^<>v>>v<vvv><>v^>v><<<^v^<^<^<>^>>v>>>v><v>^vv>^^<>v^<v>v>v><^v<v>^>v>>^<vvv><^v>>>v>v>vv>^^^>vvv<v^<v>v^><^>^^^v<^><>^^<<^<<^^<^^>^<>^<^<^<v<v^>^v<^^<<><v>>>^v>^^^^^^^^<>v><v><^<^v><v^v^vv><^>^v^^v>v^^<>vv^<^^v<><v^>v^><v>^v>v<<<<v^<^v><>><><v<>^<v<><^<^<<><>>^<><<<v>^^<>v^>>^vvv<v^<<v>^<^^v^^v<<><^>vv>>^v<^^<v^^<>>^<v>^>^<v<<<^<^v^^vv<>>>\r\n^>vv>^^>v^>>^<vv^>><>>^<>v><<>v>v^^^>>v>>vv^^<<<>v^^<vvvv<>v<v><<>v<vv^^>>>^<>^v<<v>^<v^vv<^vvv>^^<><^<<>^<>>v^vv<v>v^<v<^^v<<><vv<^^<^<<v<^>v<v>^<v<^^v><^<v<<v<^^<v^<^>>v^<^^<<^^<<^v<><^v^^v^v^v^^>v^><^>vv>>^><^<<v<>v>v>><>^<vv<<^^>v>^<v><vv^v>^<^>>v^<v<><<>v<<v^v>v^>v<v^^<^^>v>vv^><vv>v^vvv^<>^v<v<<^<>><<vv<><<>v^vv>vv<><v^v>^><^<><^v>>v<<^^^><^>^<>v^^v^^><^^>>v^^<>v>><<vv^^v^>>v<<v<v<<^><<vv>^^^^^<<><>^vv^<><<>v>>>^><<<v>^<><>^^v^vv>>v^vvv<>><><><v<<v>^vv^v>^<^<^v>>>><^>>v>^v><<>^^<>^v^<>vv^<^<vv^vv><>^<<>v><^<^^<v<^<v^^v<>^^>^<>^^^^<^^>v<<<<v^>v>v>>^vv>vv<v^vv>v^>v^vv>v^>vv<v^>^v<>>>vv>^>>^^^>><^^v^^<^^>vv<^v>v^vv<<vv^<<vv^^<><^<v^>^<>^vv<<v^^v>^vv>vv<v><><v<>>^<<><v<v>^<<v><>v<v<^<^vv^^<^<><<>v<>v^^<>vv>^^>^vv^v<v^v^^>>^<>v^v^>vv^^^>^>><>v><>>>v>>>v>v^v^v>v<^>^<^^>v<>>^><<v^>^^<^^<^v^v>vv<v>v<^vv<v^<<v><^<<v^v^^^vv>><>^<<v^<>v^>vv^^<vv^^^^>^>^>^>><<^>>^<v>v^>v^^^v<^^^<^>>v^v<>^<><<v<v<vvv^^<^<>v><^^v^<^>>^^v^>>^<<v<<^<<v><<>v<^^^^<<^<v<>^v^^^^^>vv^>>v<^><<<v<<^<v><><v^v<vv>v^<>v>^\r\n^<v>^<<>^<^<<<>v^^v>v>>^^^^^^<><^^<<^^v<>^^<v^v><^>^v><v<^^^>>>><><<<^^v^<><<<><<v><^v<<^v>vvv>><^>^>^><^>^>>>v^<v><<<<<vvvv^v>^>>v^><^<vv<^>^vv>vv<^>><^^v^^vv<>^^v<>^<v>>>^^vv^^>>v^>>><<vv>v<^v^vvv>vvv>^v>^^^<><>v>v<v<>><<><^v>>>^<<^vv^^>>^<^^v^>v^<><<^>v>^v^<<><><>v^>>>v>><<^^v^vv^v<><<v^vv^>^vvvv^>^><><v^<^^^v^vv<<v>>>>v^>>^vvv^<><^v>vv<>^><><^>v>vvvv>^^><v>vvv<v>><^>^v>>^>v>^v<>>>>^^>^>v>^<vvv^^<vv<>^>^^>>><^<^^v<v<^v<^^v^>^^^^>^v>v<<v>v^vvv>><v>v^<^v^v<^v^v<^<<>^v^<>>v>v>^^<v<>vv>^v<v>><v><>^^<v><<<>v<>v>v><<<<^vv>^>>v><<v<vv<<>v<^v>v<<>><<>^><<^>>vvvv^<^v^^>>vv>><^vv<^^^>>>v^>^v>vvvv^>>v^><<^<^>^>^<v<>>v><v<><><<<^<^vv^<<<>^<<^^<<>v<>><<<>>>>^>v><vv<^>^^><><v>^><<v>v>^><vv^v<>^v<^v^v>^<^v^^><<<>v>>v^vv>^^^^v><^>><><<<v^^^<<<^<v^>^^<>vv^v^<><v>^>^<>v<^^<vv<^>>>>^>^><v<vv^^>><v><<<><^>>^v<v<^v^^vv<<v^<^<>><<>vv>><<>v^^>v>vv<^<v<^<<vv>v<^>v^v<v^<<v<v<v<^>>>^v<><<<>^v<v>^<><^v<<<v<v<<^<^^<^^>vv>>^>^>^>>v>^<^v<<<>^v^v>^<vv^v<^^^v>v<>v>v>><^<<<v>><>v^^^v^<<vv<<><^v>>><^^^v>vv>v<>v<>^^>\r\n>^^<^v>v<<^<v><>^^>^<>v<v^v>v>v^>^<^v^<v^<v>^>^>vv^<>><<>^v>^><vv^<<^>v^v<^^^>v<>v>><v><vv>><vv>vvv<>^^^vv<^v<^v^<^<>>v<>^<vv<>><vv<^<><<<vvvv>^<^><^<<v<v^vv>vv^>><vv^<><<<vv^<>>>^vv>v<v^v<v^<<>v^^>v^^vv<>><>^vv^<vv>>v>>^^<^^v<v<<>^>^^v<>^<vv^vvv^<<^^v^><<<<^v^^v><v<>>v^^v>^^<^<^>>v^v>^<<v<<>^v<>>^vvv<<v^^^v^v>^vv>^<<<>^^^<^^<v<<<>^vv^^^<>^^v>>><v>><<v^v>^>v<v<<^v<v^v>vv<^><>^<><>^^<v>>>^<<^>^^<>vv^vv<>v<<v>^>vvv><^<^v><v^>vv<^^^>v>>vv<>><^^<v>v^^vv>^<<^<<^>v^>v^<>^<>v^v<v^vv<><>v><^><v^<<>>^<v>^<><>>v^vv^<v<>^<^>v<>>>^>>><<><>>^<vvv^>v>^^>>v><<^^v<v><>^<<><>>>><vv^^^<<v^<<v>^>><><^>>>v^vvv^^^<><>^<^v<>>v^>>vvv>^<><v<v<^>^vv<>^v>><>><>v^v>^^>vv<^<<<v<^<^>^^^v<><^<^v>vv>^<>v<<^vv^^vvv>><>>v<<v^v<>>v^^vv^>^<<<vv>^^v<<v<<^>^>v<^^<<^vv><>>^v>^^vvvv>^<^<v^<^>v^<vv<^v<<<v>^v<v^<^>v><^^^v<>>v^v^^>v^^^^^<v<^v<>^^>^v<<><<<^vv<<^v<v<<v^v>v^<vv^><<^<<>>><<><v><<><><vv<<vvv^>vv>>^^>>>>^<v>^v^^v<vv<><<>>^<<vvv>>>>^^<>>>vv><<>>><v<v>^<^<>vv>>v^>v>^>>>^>^>>>>>>^>>><^^v><<><^vvv^>^v^>^>>^v>v^v<>^><^>v\r\n^^^<^vv>^<<^<<><^<<>v^<^^vv><^<vv<^^<^v^^><>^v>v<>^v^^vvv<v><^<>vvv<v^<>^>><^vvv<v<^><>^>><>>^>v<>>>>>v^^<^<>^>^<^<<^^<>^>^>^v^v<v<^v<<^<vv><<>v>^v>>>><v<>^>v>>^v<>><>^>^>v<^<^<^<^<<<v^<<^<^vvv<^^<v<v><>^^>><v<>^<>vvv<<><vv<^<v>><>^>vv^>^^v^^><vv>v<^^>>>v^v<><^^<v^<vv>vv<v<^v>v>v<<^<^>^^<v><<^v>>><^^<^^v<>v^><<vv^>>^v^<<>v>>v>^^>><<v>^<<<^><^^vvv^>^>v<^v<v<>^>^><<^v<>>^><>^<v<><>>vv<><>v^<>v^<^>>vv><^v^v<<<>v><v^vvv<>^<vv^v<><^v^v<<<^<>>vv^<^^>>^v^<<v>v<^vvv<>v^v>><^v>>^v^^^><<^<<v><v<v^>^<^>^vvvv<^v>^>>><vv<^vv^v>^v<<><v<^v><<^>><^^<v^>v^^^v^>vv<vv^>v^^>^v<<v>^>vv^^^v>><<>vv>>^<v^<>^<>^v>v^v<v^v><<^^^>>^vv<>>v>vvv<v<^vv^<^v^^<v^v<v^^v<^><^v<<>^^v<^>v>^>v>^<>v^<v>v<><vvv<<v^v^v>>>^vvv^v^<>>>>^v^<<>>>>v<>>^^^^><<^^^^<>^<v<v<^<v>>^<>><<^<<>>^>>vvvvvv^><^^>^^^>^>v<^^<vvv^v<<vv>^^>>v>v<><^<^^>>^>>^v><v<v^^^v<v<vvv<vv>vv^vv<v<>^v<vv^vv<^<vvv<<><>>v<<<><<v<v^>vv^<^<v^<vv^^^<v<>v>v><>^v>v<^<>>^>>v<<<>^<v^v^^v>vvv<v<^>>v^<<^^>^<>vv><>^^<vv>^v>v^>vv<^^<>^<>v<v^<vvv^<>>vvv<^><<<>^>>^^>v^v<<>^v>>\r\nv^^v<<v>v>><v>><<>^>^>^v><^^v<^^^^^v^^<>><>>>^<<><^<<^<v<>>^<^^^<>>>>v<<>>>vvv<vvv>v^<v<>v^<><v<>v^^>>^>>^<^^v^>v<>^>vv<>>>>vv<v>v>v^v^vv>v<vv><>>vv^<>v^<>><v<<<<v<<<<^<<>v<<>vv<<>^>vv<><vv^<>v>^<vvvv<^^><><^v^>>^<^<<>v^<<^<v<^vv>><><>^^><v><><<>>v<<v^v^^^<v>^vv<>^>>v<><^>^<<>^>v^><><>^<v>v>^<v><>v<<v^^v^vv>^>^v>^>>^>^<<><<^>^><><^v^><^vvv<v<>v><>^v>^>vv<^v<v<>><^<vvvv>^^^>><<v<>^v<<><>v^^^^^^<v<v<<v^^vv<>^vvv>^<<<<>v^<<^><<^>vv<^><^v<v<^<<>v<v<v<^vv^^<v^^v<v>^>^v<vv^<v>vv^<v^>>>>><<<^^vv><^<v<<<>><^>>v^^>^^><^vvv<<^vv^^<^>^>v^vv<v<<vv><><v<v<><^>v>v><>>^>>^^^^^v<>^^>v^>^>^^<^<^<v>^vv^^vv^>v<v<<>v>vvvv<>v^>^<^^v>^>^v<v^v<<>v>v^v<v><<><^v>>>vvv^^<<>><^<vv>^>^<v^v^v><v^vvv>vvv^>v<^><vv^>v>>^<>^<vv^^<^v<><>v><^<>><<<>><<<^<vv<>>>>v>vvv^>><<v^^vv>><v>>>>^>v>>v>^>^>>><><v<<<^>^><<^<^>v^^v^>^^>^>^<>^v^>^v<v^^><>v^<<>v^v>v><vv<><^>>v>><v><<>v<v>><<>vvv>><^^v<>>v>v^>>vv>^<^>^<><v<v<><v<vv>v<v^v^<><<v<<^vv<v^><^<v>vv<^>v^v<^<<^<^v<^v><^vv<v^>v><v<<<v<>^<>^vv^>>><^^<^v<^^<^<v>v^vv<<<>^v>v<<>v>><\r\n<>>vv^v>v<^<^^v^v^<^>>><^^<<<^<<^<^<<>v^^^^^<^>v^>vvv^>><^<<>>v^<><<v^v>><<^^<^^><<><vv>>v^v^v><v<^<^v<<>><^^><v>>v>v<^<><^^><<>^<<vv<v>^v^^v>^^<^<v>v^^v^<^v>^<><<v^^^^<><vvvv<v<<<^^v^<><v<<><v<^>>^<v<v>>^^^<v<<>^<><^^<<>v>^<v^^^><><^<><^v<v<>^^<v><^^<^><vv><^<<^^^>v<<>^><vv^>>>>>>v>^>^>><<vv^<<<>^^>>^v>^v>><^vv^v<<^^^<^v^v^>v^v<v>>^<<^vvvv>v>^^>><<<<<vv>>^v^v^><vvvvv^<^vvv<><><><<<>><^<^^^^vv<>><v>>>><vv>^v>>>>>v^<^<>vv^<^^v^^>>^<v^^<>^<^<^<><>>^><^>^<<v^v>^^>v<^^>><^<^vv^v^<<^>>>v<<vvvvv><^>><<^v<^<^<>v<^vv^^^v<^v<^^vv<v^^v>>^vv<vvvv>>>>v^^^>><>v^>><<>v>^^<v<<>^<^^<<>><>v>>v^v<^>vvvv^^^^vv><>v>^v>v^v><<>^vv^v>>^<>^^^^^v^v>^^vv>v>>>v>^<v>^^vvvv^^>^^><^vv><><>^v^>>v>v^><><^^^^<^vv>^^v>^^>^vv<v>v^^>^>^^v^<^>v^vv<>vv^<<><>^>vv^^v>vv^^<<>>^v^^<<^>^><>v>>^<<<v>v>^<v<vv<>v<<<vvv<<v^v><<vv^vv<^^><>^v>^^^>>v<^^v>>v^>v>>>^vv^>><<><<vvvv<<>><v^vv><^^^v<^>>vv>>>^^<v^<v<^^<^<>^vv>>v<v>><^^>v><><v>>^>v>v^<>vv<<^vv>>^>^vv><v^^>vvv<v>^>>vv^^<>><>v^>^v>v^v>^>>v<^v^<><v<><>^v<>>><<>^v><>v^vvv>vvvv>^<<\r\n^^><<<^^v>^v<<^<^v<^v^v><^v<vv^><^>^v<<vv<>><^^<<^>><>vv^vvv^v<vv<<^v^^v<>>v<>v<<>vv><>vvv<><^vv^^<<^<^v<>^<^<><<v<v<><><vv>^>>^v>>^v^>><^><vv>^><^vv>>><v<>>^>vv^v^<<v><>^^<^v^<<v<<>v>>^<<v>v^v>v><v^>v><^<v^>>^<vv^>vv>v<^v^vv<>>^>>^>v^^^^^><<>vv^vv<^^>^>^<<^^^>v<>vv<^^<<v^<<v<>^<v<^v<<^^^>v>^>>><^<<>^<>^v<<>^>v^>vv^^^<>^^<><v>^><v^^>>^^v^<v^v><v>v>vv<<<^>>><v<^vv>v>>^^^>^^v^<^^>^>^>>>><^^>^<^^><v>v<<^v><v<>^^^v>^^^>^<^^>v<<^v>v<v>v>v^^>^>v>^vv>>v^<v<^^>v<<<><vvv<^>^<^^v><^^<^<v<<^>^v<<^vv>>v>vvv>^v>vvv<vv^^^vvv^^>>^<><><v<<vvv>^><<<^v^^^^v^^>v>^>v<^v<<^>^vv^<v^^>^<>>^<^<<vvv>v>^<^^<>>><>><<v^<>v<>><^vvv>v>><v>>^>v<^^>v^^vv>v^^<><^v<v^^>v^^v><^^<>^>v>>vv<v<><>>^<<^^vv>v<v<^v^<<^^^>v<^^v<v^v^>v<v^^>^<<^v<>>v<>>>>^^v>v>>^<^v>vv<^>^<<><<^<><v^>>^<<v^^v^^^<<<>^><>^<vv><v^>>v^<>^^<^<>v<v>^v<>v><<>^<^^^v><vvv>^<^<^><v^^>>>><>^><<v<>v>^^<^>^<><v><vv>v<vv<v^>>^^<<^v^<><^v<>^v<<v^v^v<><<<<<^^<^>v<v<><<>^v^>^v^v>^<^>^<v><^>v<<vv<<<<v^<^vv<>v^v>^v>>^v<>v<^vv<>>^^^<>v><><>><>v>^<vv^^^<^>>v^<v<vv<>v\r\nvv<<>>vv<^>^^<<^>v>^v<<^^<v<><v^><<^^><vv>^>>vv<<>^v><>>>^^<<<v<<>^vv>vvv<<><<><v^^>v^<v^^>v>v>vv^>v>^v<v<<<vv>^<v><v<^>>^>>^v>><>^<^><<><>>>vv<<vv>>>v>><>vv<<>>v<vv^>v>^<vvv^^v>^vv<><vv^>^^<<<^^v<>v^^<<<><>v<^^>v<>^vv>^v>>^^^<><<^^^<<<v>>>^v^>vvv^v>v<^v<<>>^<v<<^>v^^v^<v<<><^<>^<vv^^v<>^<<v>>v><>><><<^v<<vv<<>v<^<<>>><>>vv^>^<<>^^v>^><v>^<<^v>^>v^>^vv<^v><^^v^<>v^<^>>^v<<v>^^^^^v^^>^<<v<<>v<v^^<<<><><^><^v<^<>v<^v^v>^<v^vvv>>v><^><><v<^^><^v^<<><v>^>^>^^v^<v<^<><<v<>^<>^>vvvv^v^v^v^v><><><>v^<v^v<<>^v^<v^^^v^<v^v<<v^<><<v<>>>vvv^<>^<^^vv^^<<<^v^>>>>>^^>>^>>^^>^v>vvv<<v<v^^<<<v<v^^^<>^^v>^<v^v<v^>^v<vv>^v^^<<^><vv>>v>v>^^>^<<^><>>^v^><>^^>v>^<<>^^><<v^<vvv>^v>^>>^^^<>>><<^^^<>>v^<><><>v^v>><v<^vvv><^<^<^v^>v^vvvv^v>>vv^>v<<^^^<<>>^<>vv><^><v^v<v^vvv^v^v>^v>v^<^^^v^>v^>^<>^v^v^v<<<^>^<>^>v<^>>>vv<<>>^vv<>^><v>^vvvv>v<<v>v^v<^vv<^^^v<^<>^><>>v>^><<^<>><^^<v^v>>^<v>v^^<^^vv^<<>><v<vv^^^>v<^v>>><<^^v><vv<v>^<^v^^^v<vv>>^^^^<^^^<^>v<^<>>^<^>vvv<^<v>><>v<^^>><^><^v<vvv^v^^><><<<^^v^^><^v<<>v\r\n^vv<>v>^v>^<><vv^<>^v><vv^vv^^v^<<<v><>><><^>^^^^<<vv>v^<>^><>^v<<<v^^><v^<v^v^v^>vv<v<^>>>v^<<v>>v<v^>><>v>v^^<<<>>^v>^vvv<v^><vv^><^^^><^v>>v^vv<<>><>v<>>v<<<^<<<^<><<<<v><<v<v<><>>^v^vvvvvv^v^<<v^<^<>>v<<v^>v<>vv<><<<v>^v><><v^>>><^v^v>v<v<<<><vv>>v>>v><^v><<v>>^vv>v^v<v>^^>>>v>v^v>vvv<<<>>>v^v><<<>v>>^><<^vv<>><vvv><^>^vvv>v<<<<>^>v<^^<><v><^<^>>^vv<^v>^<v^<<>v^>^^>^^><^vv<<^<><<<v><^<<^v<vvv^>^v^>^><v^>>>^v^><<>>^^v^<<^<>>v^>vv><>^^<^>^^v^v<<>^^<v^<v^<<^<v>^v<>>><v<<^vv<><<^^^<>^^>^>v^^>^v^^<^>^^>vv>vvvv<^v>v<v^<^^v<v^^>^v<>^v<<^>>v>>^^v>^^v><vvv<>v><^^v<<<<v>vv^<><v>><<>vv^<<><^<<^^^<v<^>v>^<<<<^>v>^v^^><>^<^vv><vv>v>>^^>>^><^>^<^v^>^<v<^<^<^>>>^>v<<>><^^<<>vv><^<<<>v>^^v>v<v^^>vvv>v<>>><^^>^>^vvvv^vvvv<>v<^v^^^^v<>^^>v^^<^^<<^<>^v<^v>>v^<<^<>v^^v^^<vv><v<v^<^v<<^^v^<<<v<><^><vv^^^v>>v<>^<v^vv><>>^<><<v<<^v>^^^>><>v^<v<^^^v<v><^><^v^^>>v<<vv<<vv^<>^<>v^<>^vv>v<^^<^vv<>vv>>^vv>^v<<^>>^^>vv^><^><v^<^<^^>><v><vv^<<^<vv<v<v><^>^>v^v^vv>v<^>><^>v>v>v><>>^<<><^v<^^>v><v>>>^v><<>^v>>v>^\r\n<v^>>^^>^><<<>v>>^><<><v<<^><>^<><>>^>>>v^vv<v<^v>^<<>^>^<vv^<^vv^>v<>>><v<v>>v<<vv^vv^>v<>v^>>v<<<<<v>>v<vv^v>v^v^<<v^^>v^>^>>vvv<>>^vv>^v^><<v<<>^^^<v<v>v<>>v^vv<v>^v^<^^v>>>v<>^v^<^vvv<><>>vv^>v<<<<>>vv<<vvv^^vvv^v^>>^v<v>>><^><^^^<vv^>>v<vv^<><<>>>v>^v^<^<vv>>v^^<v^v<<<><<vv^vvv^>v>v>>>v>^>^<vv>v<^<^^<^vv<v<>>^<>^v>vv>^<v^vv^>^>><^v^v>v<<v><<v<<>>v^^^>^^>^<>^>v>>v>><v<^<>>><v>vv><vv><>>^v^>>v^^v^><>^><>^^>>>v^<>>>v<v^>^>v^^>>>>v>v<^v>><v<>^v^><>^^<>^<<<>^<>>><v>>>v><>^v^v^<<<<v^^^^>^<<<<>v<^^^v><><>^^v^v<^^^<v<vvv<<^>^>^<^^<v<>^<<v^><v>>vvv<^v^>^v><>v^v^^<>>^v><<v<<<^v><v><<<v<v>vv^^>v<^^<><<<>>>>><<v><<^<>>^v<vvv>>vvv<<v^<^v^<>>v<<^><v^^<>>v>v<>><vv<<^v>^>^^v>><^<^<^^^v<v^vv>v^<><v<^vv><^^v<^<^<>^>^<v<^^>v>vv^v>^v<>v^^<<<^^<>^v<>^<^v^><>v<>^v>^v<v^>v^v^>><v^^v>v>^v<<^>v<<^^v<v>^v>^v<^^>>>>v><>^>vv>^v<v^v^<<>v<^v>^><vv<>v>v<^^<>v<v^^^<^<^^<v>^><v>^v^>>v^^>^v<v<>^>v<^vv^^^v<><v^vvv><>^^^>v^^>^<^^><^v^>><^^v>^^^v^>>><><v><<<>><<<<>v>^>>>^^^v<^^^><<>>>^v<><>v<^vvvv>^<><>^<<<>v^^v^^>vv\r\n<><^>^v^>v^^^<>^^^<><>>>>vv<<v>^v><v^v^^^>v>^^><<>v>^<^v^vv^<vvvv<><>>^<v<<>^^^<v<^vv^v<^v>^v^>vv^><^><v<^^^>>^v^v^^vvvv>><<<v<<vvvv<>vvv><><^^>v^>><>^<>^^v^^v>^<v^<>>^^v<vv>^^>v^><^^v<^><>vv^<^^^>>vv^^<<<>>^^v^>v<^<^v>>>v>>><<vvvv<v<^^><>><><v^vvv>v^^v<>v>^v<<^^<v<<v<v<>vv^<<v<<^>>v^v>^<<<>>v^<>v^>vv>v^^>v<>v>v<v^^>>><>^<<^v^<v^v<^v^^v<><^<^<^vv>>^>vv^^>>^<><>^<v>>>vvv^>v^^>vv^vv<<>v><v<<^vvv><<v<v>vv><<>>>^<^v<<<>v^<<>^<>>>v<>>^<^<^v^<^v>><v>v<<v<^<>v^<<<^<>^v<^^>v>^v<^^>v^v^>>v>v<<^>v^>v^>^^<<^<vvv^v>^v<v><<<v<v<^<>^v<<^v<v<v^^<<vv^^v<>vv^>^^<v>>>><>^>^^<v^v>>><<vv<<^>v>>>^v>^>>v<^^v<>^vv<v^>v>^^>>>v^>v<<v<^^^^><^<^v><^v>^^>^v>^<>v^<vv^><v<>^<>vv>v><><v><v^<vv><^v^>^^<<<<>><<><vvv<vvv>^^<<>v^><v^<^>^^>^^vv<^^v^^>^>vv>>^<>v><<v>v>v^^<v>^vv^vv>vvv^>vv>vv^<v>>>>v<^^><^>>vv>^><<><^><<v>v>><<v>>vv^<><<^<^<>^><v<<<>v>v^v<<v<^><>v^><<v^<>^^v<>^>vv^v<v<^<<v<vv<>>>>^^^v>>>^><<<^<^<^^v<<<v^<<^<><>><>^^vvv>^vv>>^v<v^^><><^v<><vv>v>^v^><>^v<<v>v^^^><^>v^vv<<<v<>vv>v<v^<<vv>><^v<^<v<vv>^^><^^<v>\r\n<v^v><^<^v>vvv^v<^v^^>vv^><><>vvv<v<><v>><>v<v<<>v^^^<v>>^<^^<<^v^v>^v^<<^<v^v<v^^<v^^<<^v^>>>v<^^<><^v<v>^<<v>>>>>^<<>^v^<<>><<v^^>^<^><<>v^>^>v>vv<v^^<^v<<v>^<<v^>vv^^^^vv>^>vv<v^<>>^^v<^<>>><>vv>>vvv><^v>^v^v^<^>^vv><^<^>^<v<^>><^<><<^^vv<vv^<v><v^<>>>^>v^^^v<<v<v^<<^^^>><v^^^<^^><<vv^^<>^v^<><v^><^>>v^<v<v^^>^v<^>v>^<v<>^<>v<<^vv^v><^v^v<^vv^><><^^<<v^<^v^v>>v^<<^^vv^<<>^v^^^<<<><<>>^>^>v><<>v^<<>v<^v^<v^><><<v^^><^^<>vv>^vv^^v^v>^><^vvvv^v^<v<<vv<<^<v^>>^<^^vvvv^<^<v<<v>v<^<<<v><>v>><>>^<vv>v^^><>^v>^v><<<^^^^^<<^><<v^v<v>v^>v<v^<>>v>v^^^^v><^><vvv>>^>^><>v>vv<<<v^v<^<vv^<>>>^><>v<><^<><v^<>>^^<^>^^^v^^<<>>vv>><^<<v><<<>^v<<^v^v<<>^>^vv>><>v<<vv^>^^<>v^>v>>vv<^vv<v>>>>>v<<vvv<v><>v><><^<<^<^><<<<>v<v<<vv^v>>>v><>v<>v<^vv><<>v>><v^>v>vv><^>><>>>^^^>v>^<>v<v^v<><>v^<^v<>v^^^vvv^^v^vvv>vvv^v>>^<^>^v<^>>>^<>>^v<<>v<^<<^><<v^^>>>>^<><^v^^><>><^>vv>^>vv<^v^>v^^v^>^<^<v^>>^vvv>>vv^^vv^><<v>^^<<><^>^v^v>>^<v<><^<^^^<<^>v>>^vvv>v>><^>^<^v><v<<v><^v>^<v<vvvv>v<vv<v^^><v<^>^^<<^>^^<<>>vv^^<^\r\n<<<^<^v<^v>>v<v<<>^^>><><^>v<vvvvv>v>^^^vvv<<<v^<^^<^^v<>>^>v>^><<<<v^v><^v<v<^>v<v<^>^v>^>><<^vv>^^<>v>>><v^>>><><^vv<>v<^><^>>>v<^>>v^<^>>>^>^>v^>vv>^>^<v<vv<<<<^^><v<>vv<v^<><<v^v>^^<^vv^<^><^<^<vv>^v^<<v^<v^<v^<^v<>><<^><^>>^<v^>^<^>^>^^<^v^>><^>>><><^^>v^v>vv^^v>^><<^<<<><<<^v>><vv^>>><<<>v<>^>^v^<>^><>^>><<<>>^v^vv^v^<^<<>^^<<^^>^^v<>^vv>v>v^^v^<vv^>><v<^>^v<^^v><v<^>^<^v><<>^<^^v<^^v^<><<>^<vv<^vv^^^>^<<v<>v>vv>><^>v>v<vv<vv^^><>^v>v<<<><vv<<^<v>v^<>vv<>^<^>vv^^<^<^>>><<vv<>v^^vv><<^<>^<<<>v><v>vv^><^>><>><^^><^v>v>><>><v^<v^v>v>>v^<vv>^<<>>v>vv^>^v>v<^>><>>vvv<<vv>^>^>^<vvv^v><vvv>^^>^>^>^><>v><^<v^^^<<<<<v^^<<^<<^^>>>vv><v<><^v>>^>>v^<^<<>>v<>v>v^^v^<>><>><>^>v><^<>^><>v><<<^v<<>>^^<^^>v^>^>^><v>>v^v^>^^v>vv^v<<v^^^v<>vvv><>^^>vvv^>vvvv>^^^>^<^^>v<^<vv>vvv<<>^<<<>^<vv^v>>^v>v>v^><><^>><v<^vvv>>>^>^<^^^<vvv>><>vvvvv<v^>^v<v<>v>^>^>>v^v^vv^>^>>v>>^^v>>^^><>v<^<<>>^>><vvvv>^^><^<vv>>>v><^>v^^><<v^v<<^<>^>v^<<>^><vvv^<><^^>>^><<vvv<v<>vv>>^^<<><vv<<>>>^><<v^^^><<v>^v>v<<v>v^>v<<>v";

		private const char WALL = '#';
		private const char BOX = 'O';
		private const char ROBOT = '@';
		private const char NORTH = '^';
		private const char EAST = '>';
		private const char SOUTH = 'v';
		private const char WEST = '<';
		private const char WIDE_BOX_LEFT = '[';
		private const char WIDE_BOX_RIGHT = ']';

		[TestCase(ExampleA1_Map, ExampleA1_Moves, 2028)]
		[TestCase(ExampleA2_Map, ExampleA2_Moves, 10092)]
		[TestCase(Data_Map, Data_Moves, 1438161)]
		[Parallelizable]
		public void QuestionA(string data, string movesString, int expected)
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
						robotCoordinates = ProcessMoveNorth(grid, robotCoordinates);
						break;
					case CardinalDirection.E:
						robotCoordinates = ProcessMoveEast(grid, robotCoordinates);
						break;
					case CardinalDirection.S:
						robotCoordinates = ProcessMoveSouth(grid, robotCoordinates);
						break;
					case CardinalDirection.W:
						robotCoordinates = ProcessMoveWest(grid, robotCoordinates);
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

		private static Tuple<int, int> ProcessMoveNorth(char[,] grid, Tuple<int, int> robotCoordinates)
		{
			var newCoordinates = new Tuple<int, int>(robotCoordinates.Item1 - 1, robotCoordinates.Item2);
			switch (grid[newCoordinates.Item1, newCoordinates.Item2])
			{
				case WALL:
					return robotCoordinates;
				case BOX:
					bool boxMoved = ProcessBoxMovement(grid, newCoordinates, CardinalDirection.N);
					if (boxMoved)
					{
						grid[robotCoordinates.Item1, robotCoordinates.Item2] = EMPTY;
						grid[newCoordinates.Item1, newCoordinates.Item2] = ROBOT;
						return newCoordinates;
					}
					else
					{
						return robotCoordinates;
					}
				case EMPTY:
					grid[robotCoordinates.Item1, robotCoordinates.Item2] = EMPTY;
					grid[newCoordinates.Item1, newCoordinates.Item2] = ROBOT;
					return newCoordinates;
			}

			throw new InvalidDataException("The robot crashed into an unknown object!");
		}

		private static Tuple<int, int> ProcessMoveEast(char[,] grid, Tuple<int, int> robotCoordinates)
		{
			var newCoordinates = new Tuple<int, int>(robotCoordinates.Item1, robotCoordinates.Item2 + 1);
			switch (grid[newCoordinates.Item1, newCoordinates.Item2])
			{
				case WALL:
					return robotCoordinates;
				case BOX:
					bool boxMoved = ProcessBoxMovement(grid, newCoordinates, CardinalDirection.E);
					if (boxMoved)
					{
						grid[robotCoordinates.Item1, robotCoordinates.Item2] = EMPTY;
						grid[newCoordinates.Item1, newCoordinates.Item2] = ROBOT;
						return newCoordinates;
					}
					else
					{
						return robotCoordinates;
					}
				case EMPTY:
					grid[robotCoordinates.Item1, robotCoordinates.Item2] = EMPTY;
					grid[newCoordinates.Item1, newCoordinates.Item2] = ROBOT;
					return newCoordinates;
			}

			throw new InvalidDataException("The robot crashed into an unknown object!");
		}

		private static Tuple<int, int> ProcessMoveSouth(char[,] grid, Tuple<int, int> robotCoordinates)
		{
			var newCoordinates = new Tuple<int, int>(robotCoordinates.Item1 + 1, robotCoordinates.Item2);
			switch (grid[newCoordinates.Item1, newCoordinates.Item2])
			{
				case WALL:
					return robotCoordinates;
				case BOX:
					bool boxMoved = ProcessBoxMovement(grid, newCoordinates, CardinalDirection.S);
					if (boxMoved)
					{
						grid[robotCoordinates.Item1, robotCoordinates.Item2] = EMPTY;
						grid[newCoordinates.Item1, newCoordinates.Item2] = ROBOT;
						return newCoordinates;
					}
					else
					{
						return robotCoordinates;
					}
				case EMPTY:
					grid[robotCoordinates.Item1, robotCoordinates.Item2] = EMPTY;
					grid[newCoordinates.Item1, newCoordinates.Item2] = ROBOT;
					return newCoordinates;
			}

			throw new InvalidDataException("The robot crashed into an unknown object!");
		}

		private static Tuple<int, int> ProcessMoveWest(char[,] grid, Tuple<int, int> robotCoordinates)
		{
			var newCoordinates = new Tuple<int, int>(robotCoordinates.Item1, robotCoordinates.Item2 - 1);
			switch (grid[newCoordinates.Item1, newCoordinates.Item2])
			{
				case WALL:
					return robotCoordinates;
				case BOX:
					bool boxMoved = ProcessBoxMovement(grid, newCoordinates, CardinalDirection.W);
					if (boxMoved)
					{
						grid[robotCoordinates.Item1, robotCoordinates.Item2] = EMPTY;
						grid[newCoordinates.Item1, newCoordinates.Item2] = ROBOT;
						return newCoordinates;
					}
					else
					{
						return robotCoordinates;
					}
				case EMPTY:
					grid[robotCoordinates.Item1, robotCoordinates.Item2] = EMPTY;
					grid[newCoordinates.Item1, newCoordinates.Item2] = ROBOT;
					return newCoordinates;
			}

			throw new InvalidDataException("The robot crashed into an unknown object!");
		}

		private static bool ProcessBoxMovement(char[,] grid, Tuple<int, int> boxCoordinates, CardinalDirection direction)
		{
			int y = boxCoordinates.Item1;
			int x = boxCoordinates.Item2;

			switch (direction)
			{
				case CardinalDirection.N:
					y -= 1;
					break;
				case CardinalDirection.E:
					x += 1;
					break;
				case CardinalDirection.S:
					y += 1;
					break;
				case CardinalDirection.W:
					x -= 1;
					break;
			}

			switch (grid[y, x])
			{
				case EMPTY:
					grid[boxCoordinates.Item1, boxCoordinates.Item2] = EMPTY;
					grid[y, x] = BOX;
					return true;
				case WALL:
					return false;
				case BOX:
					var boxCanMove = ProcessBoxMovement(grid, new Tuple<int, int>(y, x), direction);
					if (boxCanMove)
					{
						grid[boxCoordinates.Item1, boxCoordinates.Item2] = EMPTY;
						grid[y, x] = BOX;
					}
					return boxCanMove;
			}

			throw new InvalidDataException("What sort of obstacle has the box run into?");
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

		[TestCase(ExampleA2_Map, ExampleA2_Moves, 9021)]
		[TestCase(Data_Map, Data_Moves, 0)]
		[Parallelizable]
		public void QuestionB(string data, string movesString, int expected)
		{
			var grid = GenerateNewPopulatedGrid(data);
			WriteGrid(grid);

			grid = GenerateNewPopulatedWideGrid(data);
			WriteGrid(grid);

			CardinalDirection[] moves = GenerateMoves(movesString);
			ExecuteMovesForWideGrid(grid, moves);

			ConcurrentBag<int> gpses = CalculateGpsForeachWideBox(grid);

			int gps = gpses.Sum(x => x);

			Console.WriteLine(gps);
			Assert.That(gps, Is.EqualTo(expected));
		}

		private static char[,] GenerateNewPopulatedWideGrid(string data)
		{
			string[] rows = data.Split("\r\n");
			char[,] grid = InitializeWideGrid(rows);
			PopulateWideGrid(grid, rows);

			return grid;
		}

		private static char[,] InitializeWideGrid(string[] data)
		{
			int rows = data.Length;
			int columns = data[0].Length * 2;

			return new char[rows, columns];
		}

		private static void PopulateWideGrid(char[,] grid, string[] data)
		{
			for (int y = 0; y < data.Length; ++y)
			{
				for (int x = 0; x < data[0].Length; ++x)
				{
					switch (data[y][x])
					{
						case EMPTY:
							grid[y, x * 2] = EMPTY;
							grid[y, x * 2 + 1] = EMPTY;
							break;
						case WALL:
							grid[y, x * 2] = WALL;
							grid[y, x * 2 + 1] = WALL;
							break;
						case BOX:
							grid[y, x * 2] = WIDE_BOX_LEFT;
							grid[y, x * 2 + 1] = WIDE_BOX_RIGHT;
							break;
						case ROBOT:
							grid[y, x * 2] = ROBOT;
							grid[y, x * 2 + 1] = EMPTY;
							break;
					}
				}
			}
		}

		private static void ExecuteMovesForWideGrid(object grid, CardinalDirection[] moves)
		{
			// TODO
			throw new NotImplementedException();
		}

		private static ConcurrentBag<int> CalculateGpsForeachWideBox(char[,] grid)
		{
			ConcurrentBag<int> gpses = [];

			Parallel.For(0, grid.GetLength(0), y =>
			{
				Parallel.For(0, grid.GetLength(1), x =>
				{
					if (grid[y, x] == WIDE_BOX_RIGHT)
					{
						// TODO
//						gpses.Add(100 * y + x);
					}
				});
			});

			return gpses;
		}
	}
}