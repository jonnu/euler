using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    class Problem19 : Problem
    {
        enum Days
        {
            Sunday = 0,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        };

        enum Months
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        };

        Dictionary<int, int> monthLength = new Dictionary<int, int>()
        {
            { 1, 31 },
            { 2, 28 },
            { 3, 31 },
            { 4, 30 },
            { 5, 31 },
            { 6, 30 },
            { 7, 31 },
            { 8, 31 },
            { 9, 30 },
            { 10, 31 },
            { 11, 30 },
            { 12, 31 }
        };

        public override void process()
        {
            int day = 1, month = 1, year = 1900, daycount = (int)Days.Monday, sundaysOnFirst = 0;

            while (year < 2001)
            {
                //Console.WriteLine("{0} {1} {2} {3}", Enum.GetName(typeof(Days), daycount % 7), day, Enum.GetName(typeof(Months), month), year);

                if (year > 1900 && day == 1)
                {
                    bool isSunday = (daycount % 7 == 0);
                    if (isSunday)
                    {
                        sundaysOnFirst++;
                        Console.WriteLine("{0} {1} {2} {3}", Enum.GetName(typeof(Days), daycount % 7), day, Enum.GetName(typeof(Months), month), year);
                    }
                }

                day++;
                daycount++;

                if (day > getMonthLength(month, year))
                {
                    day = 1;
                    month++;
                }

                if (month > 12)
                {
                    month = 1;
                    year++;
                }
            }

            Console.WriteLine("sundaysOnFirst: {0}", sundaysOnFirst);
            
        }

        private int getMonthLength(int month, int year)
        {
            if (month != (int)Months.February)
                return monthLength[month];

            return !isLeapYear(year) ? monthLength[month] : monthLength[month] + 1;
        }

        private bool isLeapYear(int year)
        {
            // Years divisible by 4.
            if (year % 4 != 0)
                return false;

            // Centuries only if divisible by 400.
            if (year % 100 == 0 && year % 400 != 0)
                return false;

            return true;
        }
    }
}
