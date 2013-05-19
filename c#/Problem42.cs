using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem42 : Problem
    {
        private List<int> triangles = new List<int>();

        public override void Process()
        {
            // Create dictionary containing all words and their values
            Dictionary<string, int> words = ReadCsvFile("Problem42.txt")
                .ToDictionary(x => x, x => GetWordValue(x));

            // Generate all triangle numbers up to the maximum value in the dictionary
            for (int i = 1, step = 2; i <= words.Max(x => x.Value); i += step, step++)
            {
                triangles.Add(i);
            }

            // Find all KeyValuePairs that have a value which is triangular
            int count = words.Where(x => triangles.Contains(x.Value)).Count();
            Console.WriteLine("Words that have triangle value: {0}", count);
        }

        private int GetWordValue(string word)
        {
            return word.ToUpper().ToCharArray().Select(x => (int)x - 64).Sum();
        }

        private List<string> ReadCsvFile(string filename)
        {
            List<string> items = new List<string>();
            using (StreamReader reader = new StreamReader(@"..\..\..\..\resources\" + filename))
            {
                while (!reader.EndOfStream)
                {
                    string data = reader.ReadLine();
                    List<string> temp = data.Split(',').Select(n => n.Replace("\"", "")).ToList();
                    items = items.Union(temp).ToList();
                }
            }

            return items;
        }
    }
}
