using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AdventOfCode.Helpers;

namespace AdventOfCode
{
    public static class Day2
    {
        static public void Execute()
        {
            var input = GetInputList("https://adventofcode.com/2018/day/2/input");
            RunTestsDay2();
            var d2p1 = Day2_Part1(input);
            Console.WriteLine(String.Format("Parte 1: {0}", d2p1));
            Console.Read();
        }

        static private int Day2_Part1(List<string> Input)
        {
            var res = 0;
            var twos = 0;
            var threes = 0;
            foreach (var s in Input)
            {
                var t = s.GroupBy(c => c).Select(ch => ch.Count());
                if (t.Any(x => x == 2)) twos += 1;
                if (t.Any(x => x == 3)) threes += 1;

                res = twos * threes;

            }
            return res;
        }


        static void RunTestsDay2()
        {
            Day2_Part1_Test();
        }



        static void Day2_Part1_Test()
        {

            var tests = new List<Tuple<List<string>, int>>
            {
                new Tuple<List<string>, int>(new List<string>() { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" }, 12)
            };

            tests.ForEach(test => AssertEqual(Day2_Part1(test.Item1), test.Item2));

        }
    }
}
