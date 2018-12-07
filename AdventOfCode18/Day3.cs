using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AdventOfCode.Helpers;

namespace AdventOfCode18
{
    public static class Day3
    {
        public static void Execute()
        {
            var input = GetInputList("https://adventofcode.com/2018/day/3/input");
            RunTests();
            var res_part1 = Part1(input);
            Console.WriteLine("d3p1 res: " + res_part1);

            var res_part2 = Part2(input);
            Console.WriteLine("d3p2 res: " + res_part2);

        }

        private static void RunTests()
        {
            Test_Part1();
            Test_Part2();
        }

        private static void Test_Part1()
        {

            var tests = new List<Tuple<List<string>, int>>
            {
                new Tuple<List<string>, int>(new List<string>() { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" }, 4)
            };

            tests.ForEach(test => AssertEqual(Part1(test.Item1), test.Item2));
        }

        private static void Test_Part2()
        {

            var tests = new List<Tuple<List<string>, int>>
            {
                new Tuple<List<string>, int>(new List<string>() { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" }, 3)
            };

            tests.ForEach(test => AssertEqual(Part2(test.Item1), test.Item2));
        }

        private static int Part1(List<string> input)
        {
            var cnt = 0;
            var ind = 0;
            var matrixW = 1000;
            var matrixH = 1000;
            var top = 0;
            var left = 0;
            var width = 0;
            var height = 0;
            var matrix = new int[matrixW, matrixH];
            
            foreach (var s in input)
            {
                top = 0;
                left = 0;
                width = 0;
                height = 0;
                ind = Convert.ToInt32(s.Substring(s.IndexOf("#") + 1, s.IndexOf(" ")));
                left = Convert.ToInt32(s.Substring(s.IndexOf("@") + 2, (s.IndexOf(",") - (s.IndexOf("@") + 2))));
                top = Convert.ToInt32(s.Substring(s.IndexOf(",")+1, (s.IndexOf(":")- (s.IndexOf(",") + 1))));
                width = Convert.ToInt32(s.Substring(s.IndexOf(":")+2, s.IndexOf("x")- (s.IndexOf(":") + 2)));
                height = Convert.ToInt32(s.Substring(s.IndexOf("x") + 1));
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (matrix[left + i, top + j] == 0)
                        {
                            matrix[left + i, top + j] = ind;

                        }
                        else if(matrix[left + i, top + j] != -1)
                        {
                            matrix[left + i, top + j] = -1;
                            cnt++;
                        }
                    }
                }
            }

            return cnt;
        }

        private static int Part2(List<string> input)
        {
            var cnt = 0;
            var ind = 0;
            var matrixW = 1000;
            var matrixH = 1000;
            var top = 0;
            var left = 0;
            var width = 0;
            var height = 0;
            var matrix = new int[matrixW, matrixH];
            var excluded = new List<int>();
            var indexList = new List<int>();
            foreach (var s in input)
            {

                top = 0;
                left = 0;
                width = 0;
                height = 0;
                ind = Convert.ToInt32(s.Substring(s.IndexOf("#") + 1, s.IndexOf(" ")));
                left = Convert.ToInt32(s.Substring(s.IndexOf("@") + 2, (s.IndexOf(",") - (s.IndexOf("@") + 2))));
                top = Convert.ToInt32(s.Substring(s.IndexOf(",") + 1, (s.IndexOf(":") - (s.IndexOf(",") + 1))));
                width = Convert.ToInt32(s.Substring(s.IndexOf(":") + 2, s.IndexOf("x") - (s.IndexOf(":") + 2)));
                height = Convert.ToInt32(s.Substring(s.IndexOf("x") + 1));
                indexList.Add(ind);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (matrix[left + i, top + j] == 0)
                        {
                            matrix[left + i, top + j] = ind;

                        }
                        else 
                        {
                            if (matrix[left + i, top + j] != -1)
                            {
                                excluded.Add(matrix[left + i, top + j]);
                            }
                            excluded.Add(ind);
                        }
                    }
                }
            }

            
            cnt = indexList.Find(x => !excluded.Contains(x));
            return cnt;
        }
    }
}
