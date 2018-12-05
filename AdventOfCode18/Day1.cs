using System;
using System.Collections.Generic;
using System.Text;
using static AdventOfCode.Helpers;

namespace AdventOfCode
{
    static class Day1
    {
        static public void Execute()
        {

            var input = GetInputList("https://adventofcode.com/2018/day/1/input");
            RunTestsDay1();
            var d1p1 = Day1_Part1(input);
            var d1p2 = Day1_Part2(input);
            Console.WriteLine(String.Format("Risultato parte 1: {0}", d1p1));
            Console.WriteLine(String.Format("Risultato Parte 2: {0}", d1p2));
            Console.Read();
        }


        static private int Day1_Part1(List<string> Input)
        {
            var cnt = 0;

            Input.ForEach(x => cnt += (Convert.ToInt32(x)));

            return cnt;
        }

        static private int Day1_Part2(List<string> Input)
        {
            var nums = new List<int>();
            var cnt = 0;
            var resp = new List<int>();

            Input.ForEach(x => resp.Add(Convert.ToInt32(x)));

            while (true)
            {
                foreach (var n in resp)
                {
                    cnt += n;
                    if (!nums.Exists(x => x == cnt))
                    {
                        nums.Add(cnt);
                    }
                    else
                    {
                        return cnt;
                    }
                }
            }

        }

        static void RunTestsDay1()
        {
            Day1_Part1_Test();
            Day1_Part2_Test();
        }
        static void Day1_Part1_Test()
        {

            var tests = new List<Tuple<List<string>, int>>
            {
                new Tuple<List<string>, int>(new List<string>() { "+1", "-1" }, 0),
                new Tuple<List<string>, int>(new List<string>() { "+3", "+3", "+4", "-2", "-4" }, 4),
                new Tuple<List<string>, int>(new List<string>() { "+7", "+7", "-2", "-7", "-4" }, 1)
            };

            tests.ForEach(test => AssertEqual(Day1_Part1(test.Item1), test.Item2));
        }

        static void Day1_Part2_Test()
        {
            var tests = new List<Tuple<List<string>, int>>
            {
                new Tuple<List<string>, int>(new List<string>() { "+1", "-1" }, 1),
                new Tuple<List<string>, int>(new List<string>() { "+3", "+3", "+4", "-2", "-4" }, 10),
                new Tuple<List<string>, int>(new List<string>() { "+7", "+7", "-2", "-7", "-4" }, 14)
            };

            tests.ForEach(test => AssertEqual(Day1_Part2(test.Item1), test.Item2));

        }
    }
}
