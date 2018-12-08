using System;
using System.Collections.Generic;
using System.Text;
using static AdventOfCode.Helpers;
using System.Linq;

namespace AdventOfCode18
{
    /*
      
      
     * */
    static public class Day8
    {
        private static int Part1(List<string> input)
        {
            var sumRes = 0;
            var mainTree = new Node();
            var lst = new List<int>();
            input.First().Split(" ").ToList().ForEach(x => lst.Add(Convert.ToInt32(x)));


           

            return sumRes;
        }

        private static int Part2(List<string> input)
        {
            var sumRes = 0;

            return sumRes;
        }

        public static void Execute()
        {

            RunTests();
            Part1(GetInputList(8));
        }

        private static void RunTests()
        {
            Test_Part1();
            Test_Part2();
        }

        private static void Test_Part2()
        {

        }

        private static void Test_Part1()
        {
            var lst = new List<string>(){ "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2" };

            var tests = new List<Tuple<List<string>, int>>
            {
                new Tuple<List<string>, int>(lst, 138)
            };

            tests.ForEach(test => AssertEqual(Part1(test.Item1), test.Item2));
        }


}
