using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    public class DateModifier
    {
        string firstDate;
        string secondDate;
        long difference;

        public static long DifferenceBetweenDates(string firstDate,string secondDate)
        {
            DateTime date1 = DateTime.Parse(firstDate);
            DateTime date2 = DateTime.Parse(secondDate);


            return DateAndTime.DateDiff(DateInterval.Day, date1, date2);
        }
    }
}
