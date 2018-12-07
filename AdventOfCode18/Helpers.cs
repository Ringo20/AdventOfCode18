using System;
using System.Collections.Generic;
using System.Net;

namespace AdventOfCode
{
    public static class Helpers
    {
        public static List<string> GetInputList(string url)
        {
            var res = new List<string>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Cookie", "session=53616c7465645f5ffd9d7bf36f8bcd3ab129f985625f5f49f9bc3f8bedbbc66425ba88e00268a62e1431c23b1c99b880");
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


        public static void AssertEqual<T>(T a, T b)
        {
            if (!a.Equals(b))
            {
                throw new Exception(String.Format("Test fallito. {0} diverso da {1}", a, b));
            }
            else
            {
                Console.WriteLine(String.Format("{0} uguale {1}. Test Ok", a, b));
            }
        }
    }
}
