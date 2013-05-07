using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    class Problem22 : Problem
    {
        private int position = 0;

        public override void Process()
        {
            // Read names into a List, and sort alphabetically
            List<String> names = ReadCsvFile("Problem22.txt");
            names.Sort((one, two) => String.Compare(one, two));

            // Get the total of all the name scores
            long total = names.Select(n => CalculateNameValue(n)).Sum();

            Console.WriteLine("Total for {0} names: {1}", names.Count(), total);
        }

        private int CalculateNameValue(String name)
        {
            position++;
            return ASCIIEncoding.ASCII.GetBytes(name).Select(x => x - 64).Sum() * position;
        }

        private List<string> ReadCsvFile(string filename)
        {
            List<string> items = new List<string>();
            using (StreamReader reader = new StreamReader(@"..\..\..\resources\" + filename))
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
