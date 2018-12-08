using System;
using System.Collections.Generic;
using System.Net;

namespace AdventOfCode
{
    public static class Helpers
    {
        public static List<string> GetInputList(int dayID)
        {
            var res = new List<string>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetUrlByDayId(dayID));
            request.Headers.Add("Cookie", "session=53616c7465645f5f8418a80d010824dbe4714002eee405ff0aee2bf7e85c43a69ffafa3ae28ae7ab7a6926d971403b42");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                var line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    res.Add(line);
                }

            }
            return res;
        }


        private static string GetUrlByDayId (int dayID)
        {
            var res = string.Format("https://adventofcode.com/2018/day/{0}/input", dayID); ;
            return res;
        }


        public static void AssertEqual<T>(T a, T b, bool print = false)
        {
            if (!a.Equals(b) && print)
            {
                throw new Exception(String.Format("Test fallito. {0} diverso da {1}", a, b));
            }
            else 
            {
                if (print)
                {
                    Console.WriteLine(String.Format("{0} uguale {1}. Test Ok", a, b));
                }
            }
        }
    }
}
