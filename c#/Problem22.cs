using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem22 : Problem
    {
        private Int32 position = 0;

        public override void process()
        {
            // Read names into a List, and sort alphabetically
            List<String> names = readCsvFile("Problem22.txt");
            names.Sort((one, two) => String.Compare(one, two));

            // Get the total of all the name scores
            Int64 total = names.Select(n => getNameValue(n)).Sum();

            Console.WriteLine("Total for {0} names: {1}", names.Count(), total);
        }

        private Int32 getNameValue(String name)
        {
            position++;
            return ASCIIEncoding.ASCII.GetBytes(name).Select(x => x - 64).Sum() * position;
        }

        private List<String> readCsvFile(string filename)
        {
            List<String> items = new List<String>();
            using (StreamReader reader = new StreamReader(@"..\..\..\resources\" + filename))
            {
                while (!reader.EndOfStream)
                {
                    string data = reader.ReadLine();
                    List<String> temp = data.Split(',').Select(n => n.Replace("\"", "")).ToList();
                    items = items.Union(temp).ToList();
                }
            }

            return items;
        }
    }
}
