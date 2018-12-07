using System;
using System.Collections.Generic;
using System.Text;
using static AdventOfCode.Helpers;
using System.Linq;

namespace AdventOfCode18
{
    static class Day4
    {
        public static void Execute()
        {

            var input = GetInputList("https://adventofcode.com/2018/day/4/input");
            RunTests();
            var p1= Part1(input);
            Console.WriteLine(string.Format("d4Part1 res {0}", p1));
            var p2 = Part2(input);
            Console.WriteLine(string.Format("d4Part1 res {0}", p2));

        }

        private static void RunTests()
        {
            Test_Part1();
            Test_Part2();
        }

        private static void Test_Part1()
        {
            var logs = new List<string>()
            {
                "[1518 - 11 - 01 00:00] Guard #10 begins shift",
                "[1518 - 11 - 01 00:05] falls asleep",
                "[1518 - 11 - 01 00:25] wakes up",
                "[1518 - 11 - 01 00:30] falls asleep",
                "[1518 - 11 - 01 00:55] wakes up",
                "[1518 - 11 - 01 23:58] Guard #99 begins shift",
                "[1518 - 11 - 02 00:40] falls asleep",
                "[1518 - 11 - 02 00:50] wakes up",
                "[1518 - 11 - 03 00:05] Guard #10 begins shift",
                "[1518 - 11 - 03 00:24] falls asleep",
                "[1518 - 11 - 03 00:29] wakes up",
                "[1518 - 11 - 04 00:02] Guard #99 begins shift",
                "[1518 - 11 - 04 00:36] falls asleep",
                "[1518 - 11 - 04 00:46] wakes up",
                "[1518 - 11 - 05 00:03] Guard #99 begins shift",
                "[1518 - 11 - 05 00:45] falls asleep",
                "[1518 - 11 - 05 00:55] wakes up"
            };


            var tests = new List<Tuple<List<string>, int>>
            {
                new Tuple<List<string>, int>(logs, 240)
            };

            tests.ForEach(test => AssertEqual(Part1(test.Item1), test.Item2));
        }

        private static void Test_Part2()
        {
            var logs = new List<string>()
            {
                "[1518 - 11 - 01 00:00] Guard #10 begins shift",
                "[1518 - 11 - 01 00:05] falls asleep",
                "[1518 - 11 - 01 00:25] wakes up",
                "[1518 - 11 - 01 00:30] falls asleep",
                "[1518 - 11 - 01 00:55] wakes up",
                "[1518 - 11 - 01 23:58] Guard #99 begins shift",
                "[1518 - 11 - 02 00:40] falls asleep",
                "[1518 - 11 - 02 00:50] wakes up",
                "[1518 - 11 - 03 00:05] Guard #10 begins shift",
                "[1518 - 11 - 03 00:24] falls asleep",
                "[1518 - 11 - 03 00:29] wakes up",
                "[1518 - 11 - 04 00:02] Guard #99 begins shift",
                "[1518 - 11 - 04 00:36] falls asleep",
                "[1518 - 11 - 04 00:46] wakes up",
                "[1518 - 11 - 05 00:03] Guard #99 begins shift",
                "[1518 - 11 - 05 00:45] falls asleep",
                "[1518 - 11 - 05 00:55] wakes up"
            };


            var tests = new List<Tuple<List<string>, int>>
            {
                new Tuple<List<string>, int>(logs, 4455)
            };

            tests.ForEach(test => AssertEqual(Part2(test.Item1), test.Item2));
        }

        private static int Part1(List<string> input)
        {
            var guardReport = BuildGuardReportFromLogs(input);
            
            var guard = guardReport.Where(x => x.TotalMinutesSlept == guardReport.Max(y => y.TotalMinutesSlept)).FirstOrDefault();
            int minute = Array.IndexOf(guard.MinuteSlept, guard.MinuteSlept.Max());
            return guard.GuardID * minute;

        }

        private static int Part2(List<string> input)
        {
            var max = 0;
            var currentBestGuard = 0;
            var currentBestMinute = 0;
            var guardReport = BuildGuardReportFromLogs(input);
            foreach (var guard in guardReport)
            {
                var val = guard.MinuteSlept.Max();
                if (val > max)
                {
                    max = val;
                    currentBestGuard = guard.GuardID;
                    currentBestMinute = Array.IndexOf(guard.MinuteSlept, val);
                }
            }
            return currentBestMinute * currentBestGuard;
        }

        private static List<GuardReport> BuildGuardReportFromLogs(List<string> logs)
        {

            var currentGuardId = 0;
            var fallsAsleepAt = 0;
            var wakesUpAt = 0;
            var minutesSleptCount = 0;
            var whichMinutes = new int[60];

            var orderedLog = logs.OrderBy(x => Convert.ToDateTime(x.Substring(1, (x.IndexOf("]") - 1)))).ToList();
            var guardReport = new List<GuardReport>();
            GuardReport guard = null;
            foreach (var log in orderedLog)
            {
                if (log.Contains("#"))
                {
                    currentGuardId = Convert.ToInt32(log.Substring(log.IndexOf("#") + 1, ((log.IndexOf("b") - 2) - (log.IndexOf("#")))));
                    fallsAsleepAt = 0;
                    wakesUpAt = 0;
                }

                if (log.Contains("falls"))
                {
                    fallsAsleepAt = Convert.ToDateTime(log.Substring(1, (log.IndexOf("]") - 1))).Minute;
                }
                if (log.Contains("wakes"))
                {
                    wakesUpAt = Convert.ToDateTime(log.Substring(1, (log.IndexOf("]") - 1))).Minute;
                    minutesSleptCount = wakesUpAt - fallsAsleepAt;

                    guard = guardReport.Find(x => x.GuardID == currentGuardId);
                    if (guard != null)
                    {
                        guard.TotalMinutesSlept += minutesSleptCount;

                        for (int i = fallsAsleepAt; i < wakesUpAt; i++)
                        {
                            guard.MinuteSlept[i] += 1;
                        }

                        guardReport.RemoveAll(x => x.GuardID == currentGuardId);
                        guardReport.Add(guard);
                    }
                    else
                    {
                        guard = new GuardReport();
                        guard.GuardID = currentGuardId;
                        guard.TotalMinutesSlept = minutesSleptCount;
                        for (int i = fallsAsleepAt; i < wakesUpAt; i++)
                        {
                            guard.MinuteSlept[i] += 1;
                        }
                        guardReport.Add(guard);
                    }

                }
            }
            return guardReport;
        }
        private class GuardReport
        {
            public GuardReport()
            {
                MinuteSlept = new int[60];
            }
            public int GuardID { get; set; }
            public int TotalMinutesSlept { get; set; }

            public int[] MinuteSlept
            {
                get; set;
            }
        }
    }
}

