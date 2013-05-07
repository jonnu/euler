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

        private Dictionary<int, int> monthLength = new Dictionary<int, int>()
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

        private List<DateTime> validSundays = new List<DateTime>();

        public override void Process()
        {
            int day = 1, month = 1, year = 1900;
            
            // 01/01/1900 was a Monday
            int daycount = (int)Days.Monday;

            while (year < 2001)
            {
                // Is this day a Sunday in the twentieth century?
                if (year > 1900 && day == 1 && daycount % 7 == (int)Days.Sunday)
                {
                    validSundays.Add(new DateTime(year, month, day));
                }

                day++;
                daycount++;

                if (day > GetMonthLength(month, year))
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

            Console.WriteLine("Sundays that fell on the 1st day of the month in the twentieth century: {0}", validSundays.Count);
        }

        private int GetMonthLength(int month, int year)
        {
            if (month != (int)Months.February)
                return monthLength[month];

            return !IsLeapYear(year) ? monthLength[month] : monthLength[month] + 1;
        }

        private bool IsLeapYear(int year)
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

