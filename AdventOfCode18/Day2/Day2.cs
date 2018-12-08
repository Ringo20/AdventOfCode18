using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AdventOfCode.Helpers;

namespace AdventOfCode
{
    public static class Day2
    {
        

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

        static private string Day2_Part2(List<string> Input)
        {
            var distance = 0;
            var commons = "";
            foreach (var str in Input)
            {
                foreach (var str_lev2 in Input)
                {
                    if(str != str_lev2)
                    {
                        commons = "";
                        distance = 0;
                        for (int i = 0; i < str.Length; i++)
                        {
                            if (str[i] != str_lev2[i])
                            {
                                distance += 1;
                            }
                            else
                            {
                                commons += str[i];
                            }

                            if (distance > 1) break;
                        }
                        if (distance == 1)
                            return commons;
                    }
                }
            }
            return commons;
        }

        static public void Execute()
        {
            var input = GetInputList(2);
            RunTestsDay2();
            var d2p1 = Day2_Part1(input);
            Console.WriteLine(String.Format("Risultato day2 parte 1: {0}", d2p1));
            var d2p2 = Day2_Part2(input);
            Console.WriteLine(String.Format("Risultato day2 parte 2: {0}", d2p2));

        }

        static void RunTestsDay2()
        {
            Day2_Part1_Test();
            Day2_Part2_Test();
        }



        static void Day2_Part1_Test()
        {

            var tests = new List<Tuple<List<string>, int>>
            {
                new Tuple<List<string>, int>(new List<string>() { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" }, 12)
            };

            tests.ForEach(test => AssertEqual(Day2_Part1(test.Item1), test.Item2));

        }

        static void Day2_Part2_Test()
        {
            var tests = new List<Tuple<List<string>, string>>()
            {
                new Tuple<List<string>, string>(new List<string>() { "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz" }, "fgij")
            };
            tests.ForEach(test => AssertEqual(Day2_Part2(test.Item1), test.Item2));

        }
    }
}
